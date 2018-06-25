using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using PrismApp1.Services;

namespace PrismApp1.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        //private readonly ITextToSpeech _textToSpeech;
        public DelegateCommand NavigateToSpeakPageCommand { get; private set; }
        public DelegateCommand NavigateToDialogsCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
            
            _navigationService = navigationService;
           
            NavigateToSpeakPageCommand = new DelegateCommand(NavigateToSpeakPage);
            NavigateToDialogsCommand = new DelegateCommand(Dialogs);
        }

        private async void Dialogs()
        {
            await _navigationService.NavigateAsync("DialogsPage");
        }

        private async void NavigateToSpeakPage()
        {
            await _navigationService.NavigateAsync("SpeakPage");
        }
    }
}
