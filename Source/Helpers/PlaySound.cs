using System;
using System.Media;
using System.Windows;
using System.Windows.Resources;

namespace BombGameSolver.Source.Helpers;

public class PlaySound {
    private readonly SoundPlayer _audio;
    private readonly bool _canPlay;

    public PlaySound(string name) {
        StreamResourceInfo sri = Application.GetResourceStream(new Uri("pack://application:,,,/BombGameSolver;component/Resources/global/" + name + ".wav"));

        if (sri != null) {
            _audio = new SoundPlayer(sri.Stream);
            _audio.Load();
            _canPlay = true;
        } else {
            _canPlay = false;
        }
    }

    public void Play() {
        if (_canPlay) {
            _audio.Play();
        }
    }
}