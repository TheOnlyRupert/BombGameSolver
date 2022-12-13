using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Groups; 

public partial class MainSettingsGroup {
    public MainSettingsGroup() {
        InitializeComponent();

        DataContext = new MainSettingsGroupVM();
    }
}