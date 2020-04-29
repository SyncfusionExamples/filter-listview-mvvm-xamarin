using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using Xamarin.Forms.Internals;

namespace ListViewXamarin
{
    [Preserve(AllMembers = true)]
    public class SortingFilteringViewModel
    {
        #region Properties
        public ObservableCollection<TaskInfo> Items { get; set; }

        #endregion

        #region Constructor
        public SortingFilteringViewModel()
        {
            AddItemDetails();
        }
        #endregion

        #region Methods
        private void AddItemDetails()
        {
            Items = new ObservableCollection<TaskInfo>();
            var random = new Random();

            for (int i = 0; i < Features.Count(); i++)
            {
                var details = new TaskInfo()
                {
                    Title = Features[i],
                    Description = Description[i],
                    Tag = Tags[random.Next(0, 4)],
                };
                Items.Add(details);
            }
            
        }
        #endregion

        #region Field

        string[] Tags = new string[]
        {
            "Feature Implementation",
            "Bug Fixing",
            "Testing",
            "Design",
            "Post Processing"
        };

        string[] Features = new string[]
        {
            "Drag and drop",
            "Swiping",
            "Pull To Refresh",
            "Selection in row header",
            "Multiple selection color",
            "Animating the selected row",
            "Long press event",
            "Double click event",
            "Header Template",
            "Orientation for ListView",
            "Multi-line text",
            "Item Border",
            "Item Style",
            "Scroll to a row/column index",
            "Group expand",
            "Enabling / disabling the bouncing behavior",
            "Group collapse",
            "Auto row height",
        };

        string[] Description = new string[] {
            "Rearrange the columns by dragging and dropping them",
            "Enables the users to swipe",
            "Pull To Refresh action refreshes the grid",
            "Apply selection using row header",
            "Apply different selection colors for different rows",
            "Add an animation upon selecting a row",
            "Users can listen to LongPresses in the listview",
            "Users can listen to double taps in the listview",
            "Load custom views as templates in header cells",
            "Orientation are vertical, horizontal",
            "Displays multi-line text for the record",
            "Enable item border",
            "Set the items style",
            "Scroll to a particular row and/or column index",
            "Expand groups in runtime",
            "Enable/disable the bouncing of the grid when over-scrolled",
            "Collapse groups in runtime",
            "Automatically adjusts the height of item to fit the content",
        };
        #endregion
    }
}
