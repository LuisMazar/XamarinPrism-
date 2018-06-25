using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using Prism.Navigation;
using static System.Int32;

namespace PrismApp1.ViewModels
{
	public class DialogsPageViewModel : BindableBase
	{
	    private readonly INavigationService _navigationService;
	    private string _millis;
	    IUserDialogs dialogs = UserDialogs.Instance;

        public string Millis
	    {
	        get => _millis;
	        set => SetProperty(ref _millis, value); 
	    }

	    public DelegateCommand ShowTraditional { get; set; }
	    public DelegateCommand ShowAlert { get; set; }
	    public DelegateCommand ShowSuccess { get; set; }
	    public DelegateCommand ShowToast { get; set; }
	    public DelegateCommand ShowError { get; set; }
	    public DelegateCommand ShowProgress { get; set; }

        public DialogsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowTraditional = new DelegateCommand(ShowTraditionalAlert);
            ShowAlert = new DelegateCommand(ShowAlertDisplay);
            ShowError = new DelegateCommand(ShowErrorAlert);
            ShowProgress = new DelegateCommand(ShowProgressAlert);
            ShowToast = new DelegateCommand(ShowToastAlert);
            ShowSuccess = new DelegateCommand(ShowSuccessAlert);
        }

        private void ShowSuccessAlert()
        {
            
            if (!TryParse(Millis, out var millis))
            {
                millis = 1000;
            }
            
            dialogs.ShowSuccess("Exito",millis);
        }

        private void ShowToastAlert()
        {
            if (!TryParse(Millis,out var millis))
            {
                millis = 1000;
            }

            dialogs.Toast("Toast message: <3", TimeSpan.FromMilliseconds(millis));
        }

        private void ShowProgressAlert()
        {
            var progressDialog = dialogs.Progress("Exito!", () => { dialogs.ShowError(":("); });
            progressDialog.Show();
        }

        private void ShowErrorAlert()
        {
            if (!TryParse(Millis, out var millis))
            {
                millis = 1000;
            }

            dialogs.ShowError("Error", millis);
        }

        private async void ShowAlertDisplay()
        {
            await dialogs.AlertAsync(
                "This is the body of an alert message",
                "Alert title",
                "It's cool");
        }

	    private void ShowTraditionalAlert()
        {
            //await DisplayAlert("Traditional alert", "Traditional message", "It's not so cool");
        }
    }
}
