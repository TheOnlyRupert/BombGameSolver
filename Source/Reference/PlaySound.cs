using System;
using System.Media;

namespace BombGameSolver.Source.Reference {
    public class PlaySound {
        private readonly SoundPlayer _audio;
        private readonly bool _canPlay;

        public PlaySound(string name) {
            _audio = new SoundPlayer("../../Resources/global/" + name + ".wav");

            try {
                _audio.Load();
                _canPlay = true;
            } catch (Exception) {
                Console.WriteLine("broke af");
                _canPlay = false;
            }
        }

        public void Play() {
            if (_canPlay) {
                _audio.Play();
            }
        }
    }
}