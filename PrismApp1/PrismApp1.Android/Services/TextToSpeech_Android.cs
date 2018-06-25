using Android.Runtime;
using Android.Speech.Tts;
using PrismApp1.Services;
using PrismApp1.Droid;
using Xamarin.Forms;
using Debug = System.Diagnostics.Debug;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech_Android))]
namespace PrismApp1.Droid
{
    public class TextToSpeech_Android : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;
        private string toSpeak;

        public void Speak(string text)
        {
            var c = Forms.Context;
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(c, this);
            }
            else
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                System.Diagnostics.Debug.WriteLine("spoke " + toSpeak);
            }
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("speaker init");
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
            else
            {
                Debug.WriteLine("Was Quiet");
            }
        }

        
    }
}