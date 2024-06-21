using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules;

public partial class NormWiresModule {
    public NormWiresModule() {
        InitializeComponent();

        DataContext = new NormWiresViewModel();
    }
}