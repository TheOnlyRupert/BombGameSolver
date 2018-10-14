using System.Media;

namespace BombGameSolver.Source.Reference {
    public class PlaySound {
        private readonly SoundPlayer _audio;

        public PlaySound(string name) {
            _audio = new SoundPlayer("../../Resources/global/" + name + ".wav");
            _audio.Load();
        }

        public void Play() {
            _audio.Play();
        }
    }
}