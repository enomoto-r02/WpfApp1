using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public class GridData : INotifyPropertyChanged
    {
        public GridData(bool enable, string name, bool select)
        {
            this.enable = enable;
            this.name = name;
            this.select = select;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _enable;
        public bool enable
        {
            get
            {
                return _enable;
            }
            set
            {
                this._enable = value;
                OnPropertyChanged("enable");
            }
        }
        public string name { get; set; }
        private bool _select;
        public bool select 
        {
            get
            {
                return _select;
            }
            set
            {
                this._select = value;
                OnPropertyChanged("select");
            }
        }
    }
}
