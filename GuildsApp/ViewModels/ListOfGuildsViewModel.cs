using CommunityToolkit.Mvvm.Input;
using GuildsApp.Models;
using GuildsApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GuildsApp.ViewModels
{
    public class ListOfGuildsViewModel : INotifyPropertyChanged
    {
        private readonly GuildServices _guildServices;

        public ListOfGuildsViewModel()
        {
            
        }

        public ListOfGuildsViewModel(GuildServices guildServices)
        {
            _guildServices = guildServices;
            LoadDataCommand = new RelayCommand(async () => await LoadData());

            Task.Run(async () => await LoadData());

        }

        private ObservableCollection<Guild> _userGuilds = new ObservableCollection<Guild>();
        public ObservableCollection<Guild> UserGuilds
        {
            get => _userGuilds;
            set
            {
                _userGuilds = value;
                OnPropertyChanged();
            }
        }




        public ICommand LoadDataCommand { get; }

        public async Task LoadData()
        {
            var apiUrl = "https://ezl-test.vercel.app/allGuilds";
            var userGuilds = await _guildServices.GetAllGuildsAsync(apiUrl);

            UserGuilds = new ObservableCollection<Guild>(userGuilds);

            Debug.WriteLine($"User Guilds Count: {UserGuilds.Count}");
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
