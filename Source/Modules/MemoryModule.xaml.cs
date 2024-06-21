using System.Windows;
using System.Windows.Input;
using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules;

public partial class MemoryModule {
    public MemoryModule() {
        InitializeComponent();
        DataContext = new MemoryModuleVM();
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