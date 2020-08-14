using System;
using System.Speech.Synthesis;

namespace TimeClock.ViewModels
{
	static class AudioTime
	{
		// Initialize a new instance of the SpeechSynthesizer.
		private static SpeechSynthesizer synth = new SpeechSynthesizer() { Rate = -2 };

		static AudioTime()
		{
			// Configure the audio output. 
			synth.SetOutputToDefaultAudioDevice();
		}

		public static void Say(DateTime time)
		{
			string text = "It is ";

			if (time.Minute == 0)
			{
				text += $"{time.Hour} o'clock.";
			}
			else if (time.Minute == 15)
			{
				text += $"Quarter past {time.Hour}.";
			}
			else if (time.Minute == 30)
			{
				text += $"Half past {time.Hour}.";
			}
			else if (time.Minute == 45)
			{
				int hour = time.Hour + 1;
				if (hour >= 24)
				{
					hour -= 24;
				}
				text += $"Quarter to {hour}.";
			}
			else
			{
				text += $"{time.Hour}, {time.Minute}.";
			}

			// Speak a string asynchronously.
			synth.SpeakAsync(text);
		}
	}
}
