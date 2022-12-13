using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Groups; 

public partial class MainButtonsGroup {
    public MainButtonsGroup() {
        InitializeComponent();

        DataContext = new MainButtonsGroupVM();
    }
}