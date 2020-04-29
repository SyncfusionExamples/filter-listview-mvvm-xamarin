using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ListViewXamarin
{
    [Preserve(AllMembers = true)]
    public class TaskInfo : INotifyPropertyChanged
    {
        #region Fields

        private string title;
        private string description;
        private string tag;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value that indicates Task's header. 
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                this.RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates Task's description. 
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                this.RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates Task's tag collection. 
        /// </summary>
        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
                this.RaisePropertyChanged("Tag");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
