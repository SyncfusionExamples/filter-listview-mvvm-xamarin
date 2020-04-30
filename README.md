# How to filter Xamarin.Forms ListView (SfListView) using MVVM

You can filter [ListViewItems](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ListViewItem.html?) in MVVM using [behavior](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/event-to-command-behavior) in Xamarin.Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview?).

You can also refer the following article.

https://www.syncfusion.com/kb/11478/how-to-filter-xamarin-forms-listview-sflistview-using-mvvm

**XAML**

Define the [ContentPage](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.contentpage) behavior.
``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:sync="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage">
    <ContentPage.Behaviors>
        <local:Behavior/>
    </ContentPage.Behaviors>
    
    <ContentPage.BindingContext>
        <local:SortingFilteringViewModel/>
    </ContentPage.BindingContext>
 
    <ContentPage.Content>
        <Grid x:Name="MainGrid" Margin="{OnPlatform iOS='0,40,0,0'}">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
 
            <SearchBar x:Name="filterText" Placeholder="Search here to filter" />
            <sync:SfListView x:Name="listView" ItemsSource="{Binding Items}" Grid.Row="1" ItemSpacing="0,5,0,5" BackgroundColor="#F0F0F0" ItemSize="100">
                <sync:SfListView.ItemTemplate>
                    <DataTemplate x:Name="ItemTemplate" >
                        <Frame OutlineColor="#b3b3b3" Padding="2" Margin="10,0,10,0">
                            <Grid BackgroundColor="White" Padding="10">
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto"/>
                                    <RowDefinition Height="*"/>
                                    <RowDefinition Height="Auto"/>
                                </Grid.RowDefinitions>
                                <Label x:Name="TitleLabel" LineBreakMode="NoWrap" Text="{Binding Title}" FontAttributes="Bold" TextColor="Black"/>
                                <Label Grid.Row="1" x:Name="DescriptionLabel" Text="{Binding Description}" TextColor="Teal"/>
                                <Frame Grid.Row="2" Padding="4,2,4,2" BackgroundColor="#FFE7E8E9" HorizontalOptions="Start" VerticalOptions="End">
                                    <Label x:Name="TagLabel" LineBreakMode="NoWrap" Text="{Binding Tag}" FontSize="10" TextColor="Black"/>
                                </Frame>
                            </Grid>
                        </Frame>
                    </DataTemplate>
                </sync:SfListView.ItemTemplate>
            </sync:SfListView>
        </Grid>
    </ContentPage.Content>
</ContentPage>
```
**C#**

Trigger the [TextChanged](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.inputview.textchanged) event of the [SearchBar](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/searchbar) control to filter the ListView based on the [SearchText](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.inputview.text#Xamarin_Forms_InputView_Text). Set the [Filter](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.DataSource.Portable~Syncfusion.DataSource.DataSource~Filter.html) predicate for ListView to filter the items and call the [RefreshView](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~RefreshView().html?) method.
``` c#
namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        SfListView ListView;
        SearchBar SearchBar;
 
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            SearchBar = bindable.FindByName<SearchBar>("filterText");
            SearchBar.TextChanged += SearchBar_TextChanged;
            base.OnAttachedTo(bindable);
        }
 
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ListView.DataSource != null)
            {
                ListView.DataSource.Filter = FilterContacts;
                ListView.DataSource.RefreshFilter();
            }
            ListView.RefreshView();
        }
 
        private bool FilterContacts(object obj)
        {
            if (SearchBar == null || SearchBar.Text == null)
                return true;
 
            var taskInfo = obj as TaskInfo;
            return (taskInfo.Title.ToLower().Contains(SearchBar.Text.ToLower())
                || taskInfo.Description.ToLower().Contains(SearchBar.Text.ToLower()));
        }
    }
}
```
**Output**

![FilterListView](https://github.com/SyncfusionExamples/filter-listview-mvvm-xamarin/blob/master/ScreenShots/FilterListView.gif)
