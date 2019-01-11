using BombGameSolver.Source.ViewModel.Help;

namespace BombGameSolver.Source.Modules.Help {
    public partial class BigButtonModuleHelp {
        public BigButtonModuleHelp() {
            InitializeComponent();
            DataContext = new BigButtonModuleHelpVM();
        }
    }
}