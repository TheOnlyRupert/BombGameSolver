using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules; 

public partial class MorseCodeModule {
    public MorseCodeModule() {
        InitializeComponent();

        DataContext = new MorseCodeVM();
    }
}