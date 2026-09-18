using AppMobileChuckNorris.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppMobileChuckNorris.ViewModels
{
    public partial class PotterViewModel : ObservableObject
    {
        private readonly IHarryPoterService _potterService;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotLoading))]
        private bool _isLoading;

        [ObservableProperty]
        private string _characterName = "Clique abaixo para carregar um personagem";

        [ObservableProperty]
        private string _house = string.Empty;

        [ObservableProperty]
        private string _actor = string.Empty;

        [ObservableProperty]
        private string _imageUrl = string.Empty;

        public bool IsNotLoading => !IsLoading;

        public PotterViewModel(IHarryPoterService potterService)
        {
            _potterService = potterService;
        }

        [RelayCommand(CanExecute = nameof(IsNotLoading))]
        private async Task FetchCharacterAsync()
        {
            IsLoading = true;

            var character = await _potterService.GetRandomCharacterAsync();

            if (character != null)
            {
                CharacterName = character.FullName;
                House = string.IsNullOrEmpty(character.HogwartsHouse) ? "Desconhecida" : character.HogwartsHouse;
                Actor = character.InterpretedBy;
                ImageUrl = character.Image;
            }
            else
            {
                CharacterName = "Erro ao carregar o personagem.";
                House = string.Empty;
                Actor = string.Empty;
                ImageUrl = string.Empty;
            }

            IsLoading = false;
        }
    }
}