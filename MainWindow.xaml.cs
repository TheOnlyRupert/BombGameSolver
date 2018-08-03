using BombGameSolver.Source.ViewModel;

namespace BombGameSolver {
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();

            DataContext = new MainWindowVM();
        }
    }
}