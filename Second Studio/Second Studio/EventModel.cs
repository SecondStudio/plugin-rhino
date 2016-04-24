using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Second_Studio
{
    public class EventModel : INotifyPropertyChanged
    {
        private string _origin;

        /// <summary>
        /// Gets / sets the origin string
        /// </summary>
        public string Origin
        {
            get { return _origin; }
            set
            {
                if (value == _origin)
                    return;

                _origin = value;
                OnPropertyChanged("Origin");
            }
        }

        private string _spawn;

        /// <summary>
        /// Gets / sets the spawn string
        /// </summary>
        public string Spawn        {
            get { return _spawn; }
            set
            {
                if (value == _spawn)
                    return;

                _spawn = value;
                OnPropertyChanged("Spawn");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
