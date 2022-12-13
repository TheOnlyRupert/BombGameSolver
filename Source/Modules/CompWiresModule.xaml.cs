using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules; 

public partial class CompWiresModule {
    public CompWiresModule() {
        InitializeComponent();
        DataContext = new CompWiresModuleVM();
    }
}