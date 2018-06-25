using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using PrismApp1.Services;
using PrismApp1.UWP.Services;
using Unity.Attributes;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech_UWP))]
namespace PrismApp1.UWP.Services
{
    public class TextToSpeech_UWP : ITextToSpeech
    {
        public async void Speak(string text)
        {
            var player = new MediaElement();
            var synth = new SpeechSynthesizer();
            SpeechSynthesisStream audioStream = await synth.SynthesizeTextToStreamAsync(text);
            player.SetSource(audioStream, audioStream.ContentType);
            player.Play();
        }
    }
}
