using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules; 

public partial class MazeModule {
    public MazeModule() {
        InitializeComponent();
        DataContext = new MazeModuleVM();

        RenderOptions.SetBitmapScalingMode(Image, BitmapScalingMode.NearestNeighbor);
    }

    private void DisablePasteCommand(object sender, ExecutedRoutedEventArgs e) {
        if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut ||
            e.Command == ApplicationCommands.Paste) {
            e.Handled = true;
        }
    }

    private void MoveCursorToEndChar(object sender, RoutedEventArgs e) {
        if (MainFocusItem.CaretIndex != MainFocusItem.Text.Length) {
            MainFocusItem.CaretIndex = MainFocusItem.Text.Length;
        }
    }
}