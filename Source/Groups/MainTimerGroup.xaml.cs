using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Groups; 

public partial class MainTimerGroup {
    public MainTimerGroup() {
        InitializeComponent();

        DataContext = new MainTimerGroupVM();
    }
}