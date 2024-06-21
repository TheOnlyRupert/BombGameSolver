using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules;

public partial class SimonSaysModule {
    public SimonSaysModule() {
        InitializeComponent();

        DataContext = new SimonSaysModuleVM();
    }
}