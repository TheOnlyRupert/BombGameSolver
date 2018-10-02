using System.Windows.Media;
using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules {
    public partial class MazeModule {
        public MazeModule() {
            InitializeComponent();
            DataContext = new MazeModuleVM();

            RenderOptions.SetBitmapScalingMode(Image, BitmapScalingMode.NearestNeighbor);
        }
    }
}