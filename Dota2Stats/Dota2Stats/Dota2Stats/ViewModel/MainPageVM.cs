﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dota2Stats
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public MainPageVM()
        {
            // Only execute when SteamPersona is not empty
            SearchSteamPersonaCmd = new Command(SearchSteamPersona, () => true );
        }

        public INavigation Navigation
        {
            get;
            set;
        }

        string steamPersona;
        public string SteamPersona
        {
            get
            {
                return steamPersona;
            }
            set
            {
                if (value != steamPersona)
                {
                    steamPersona = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command SearchSteamPersonaCmd
        {
            get;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void SearchSteamPersona()
        {
            //await Navigation.PushAsync(new SearchSteamPersonaResultView(null));       //FOR DEBUG
            List<SteamUser> result = await OpenDotaApi.SearchSteamUserByPersona(steamPersona);
            await Navigation.PushAsync(new SearchSteamPersonaResultView(result));
        }
    }
}