using GuildsApp.Models;
using GuildsApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GuildsApp.ViewModels
{
    public class CreateGuildViewModel : INotifyPropertyChanged
    {
        private readonly GuildServices _guildServices;

        public Guild CurrentGuild { get; set; } = new Guild();

        public ObservableCollection<string> Equipments1 { get; set; } = new ObservableCollection<string>
        {
            "Dumbbells",
            "Machines",
            "Callisthenics"
        };

        public ObservableCollection<string> Equipments2 { get; set; } = new ObservableCollection<string>
        {
            "Treadmill",
            "Yoga Mats"
        };

        private string _selectedEquipment;
        public string SelectedEquipment
        {
            get => _selectedEquipment;
            set
            {
                _selectedEquipment = value;
                OnPropertyChanged();
            }
        }

        private bool _isCheckBoxChecked;
        public bool IsCheckBoxChecked
        {
            get => _isCheckBoxChecked;
            set
            {
                _isCheckBoxChecked = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateGuildCommand { get; }
        public ICommand SelectEquipmentCommand { get; }

        public CreateGuildViewModel(GuildServices guildServices)
        {
            _guildServices = guildServices;
            CreateGuildCommand = new Command(async () => await CreateGuildAsync());
            SelectEquipmentCommand = new Command<string>((equipment) => SelectEquipment(equipment));
        }

        private void SelectEquipment(string equipment)
        {
            SelectedEquipment = equipment;
        }

        private async Task CreateGuildAsync()
        {
            var guildData = new
            {
                name = CurrentGuild.Name,
                members = 12, 
                rank = 1, 
                location = CurrentGuild.Location,
                equipment = SelectedEquipment, 
                description = CurrentGuild.Description,
                isPrivate = IsCheckBoxChecked,
                password = IsCheckBoxChecked ? Password : null
            };

            bool isSuccess = await _guildServices.CreateGuildAsync("https://ezl-test.vercel.app/addGuild", guildData);
            if (isSuccess)
            {
                CurrentGuild = new Guild();
                SelectedEquipment = string.Empty;
                IsCheckBoxChecked = false;
                Password = string.Empty;
                OnPropertyChanged(nameof(CurrentGuild));
            }
            else
            {
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}