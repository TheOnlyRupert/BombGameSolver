using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules; 

public partial class WhoFirstModule {
    public WhoFirstModule() {
        InitializeComponent();

        DataContext = new WhoFirstModuleVM();
    }
}