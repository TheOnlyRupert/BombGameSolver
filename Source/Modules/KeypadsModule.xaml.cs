using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules {
    public partial class KeypadsModule {
        public KeypadsModule() {
            InitializeComponent();

            DataContext = new KeypadsViewModel();
        }
    }
}