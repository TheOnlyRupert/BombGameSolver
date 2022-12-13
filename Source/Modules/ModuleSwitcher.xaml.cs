using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules; 

public partial class ModuleSwitcher {
    public ModuleSwitcher() {
        InitializeComponent();

        DataContext = new ModuleSwitcherVM();
    }
}