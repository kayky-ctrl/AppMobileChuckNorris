using AppMobileChuckNorris.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMobileChuckNorris.ViewModels
{
    public partial class ChuckNorrisViewModel : ObservableObject
    {
        private readonly IChuckService _chuckService;

        [ObservableProperty]
        private string _jokeText = "Clique no botão para carregar uma piada";

        [ObservableProperty]
        private string _iconUrl = string.Empty;

        [ObservableProperty]
        private bool _isLoading = false;

        public ChuckNorrisViewModel(IChuckService chuckService)
        {
            _chuckService = chuckService;
        }

        [RelayCommand]
        private async Task FetchJokeAsync()
        {
            IsLoading = true;
            var joke = await _chuckService.GetRandomJokeAsync();
            if (joke != null)
            {
                JokeText = joke.Value;
                IconUrl = joke.IconUrl.ToString();
            }
            else
            {
                JokeText = "Erro ao carregar a piada. Tente novamente.";
                IconUrl = string.Empty;
            }
            IsLoading = false;
        }

    }
}
