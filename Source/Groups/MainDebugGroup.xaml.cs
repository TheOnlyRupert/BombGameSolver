using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Groups; 

public partial class MainDebugGroup {
    public MainDebugGroup() {
        InitializeComponent();

        DataContext = new MainDebugGroupVM();
    }
}