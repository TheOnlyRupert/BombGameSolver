using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Groups {
    public partial class MainDisplayGroup {
        public MainDisplayGroup() {
            InitializeComponent();

            DataContext = new MainDisplayGroupVM();
        }
    }
}