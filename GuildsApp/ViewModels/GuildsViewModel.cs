using CommunityToolkit.Mvvm.ComponentModel;
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
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GuildsApp.ViewModels
{
    public class GuildsViewModel : INotifyPropertyChanged
    {
        private readonly GuildServices _guildServices;



        public GuildsViewModel(GuildServices guildServices)
        {
            _guildServices = guildServices;
            LoadDataCommand = new RelayCommand(async () => await LoadData());

            Task.Run(async () => await LoadData()); // تحميل البيانات تلقائيًا

        }
        public GuildsViewModel()
        {
        }
        public event PropertyChangedEventHandler? PropertyChanged;

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

        private ObservableCollection<Guild> _recommendedGuilds = new ObservableCollection<Guild>();
        public ObservableCollection<Guild> RecommendedGuilds
        {
            get => _recommendedGuilds;
            set
            {
                _recommendedGuilds = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataCommand { get; }

        public async Task LoadData()
        {
            var apiUrl = "https://ezl-test.vercel.app/userGuilds";
            var userGuilds = await _guildServices.GetUserGuild(apiUrl);
            var recommendedGuilds = await _guildServices.GetRecommendedGuild(apiUrl);

            UserGuilds = new ObservableCollection<Guild>(userGuilds);
            RecommendedGuilds = new ObservableCollection<Guild>(recommendedGuilds);

            // تحقق من البيانات
            Debug.WriteLine($"User Guilds Count: {UserGuilds.Count}");
            Debug.WriteLine($"Recommended Guilds Count: {RecommendedGuilds.Count}");
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
