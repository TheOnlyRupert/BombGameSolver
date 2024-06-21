using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules;

public partial class BigButtonModule {
    public BigButtonModule() {
        InitializeComponent();
        DataContext = new BigButtonModuleVM();
    }
}