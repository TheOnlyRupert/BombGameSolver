using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules;

public partial class SequWiresModule {
    public SequWiresModule() {
        InitializeComponent();

        DataContext = new SequWiresModuleVM();
    }
}