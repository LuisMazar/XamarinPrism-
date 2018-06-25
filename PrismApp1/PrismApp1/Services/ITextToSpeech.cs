using System;
using System.Collections.Generic;
using System.Text;

namespace PrismApp1.Services
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
