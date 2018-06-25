using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Services;
using PrismApp1.Services;

namespace PrismApp1.ViewModels
{
	public class SpeakPageViewModel : BindableBase
	{
	    //private string _textToSay = "Hello Prism";
	    private readonly IDependencyService _textToSpeech;

        /*public string TextToSay
	    {
	        get => _textToSay;
	        set => SetProperty(ref _textToSay, value);
	    }*/

        public DelegateCommand SpeakCommand { get; set; }

        public SpeakPageViewModel(IDependencyService textToSpeech)
        {
            _textToSpeech = textToSpeech;
            SpeakCommand = new DelegateCommand(Speak);
        }

        private void Speak()
        {
            //TODO: Call Service
            _textToSpeech.Get<ITextToSpeech>().Speak("Hi I'm Luis and i'm awesome");
        }
    }
}
