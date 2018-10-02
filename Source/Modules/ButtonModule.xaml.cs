using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules {
    public partial class ButtonModule {
        public ButtonModule() {
            InitializeComponent();
            DataContext = new ButtonModuleVM();
        }
    }
}