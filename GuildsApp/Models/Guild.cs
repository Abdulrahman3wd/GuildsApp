using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuildsApp.Models
{
    public class Guild : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Members { get; set; }
        public string Rank { get; set; }
        public string Location { get; set; }
        public string Equipment { get; set; }
        public string Description { get; set; }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ArrowIcon)); 
            }
        }

        public string ArrowIcon => IsExpanded ? "arrowup.png" : "arrowdown.png";

        public Command ToggleVisibilityCommand { get; }

        public Guild()
        {
            ToggleVisibilityCommand = new Command(() => IsExpanded = !IsExpanded);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}

