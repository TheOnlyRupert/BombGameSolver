using System.Windows;
using System.Windows.Input;
using BombGameSolver.Source.ViewModel;

namespace BombGameSolver.Source.Modules; 

public partial class PasswordsModule {
    public PasswordsModule() {
        InitializeComponent();
        DataContext = new PasswordsModuleVM();
    }

    private void DisablePasteCommand(object sender, ExecutedRoutedEventArgs e) {
        if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut ||
            e.Command == ApplicationCommands.Paste) {
            e.Handled = true;
        }
    }

    private void MoveCursorToEndChar(object sender, RoutedEventArgs e) {
        if (Column0.CaretIndex != Column0.Text.Length) {
            Column0.CaretIndex = Column0.Text.Length;
        }

        if (Column1.CaretIndex != Column1.Text.Length) {
            Column1.CaretIndex = Column1.Text.Length;
        }

        if (Column2.CaretIndex != Column2.Text.Length) {
            Column2.CaretIndex = Column2.Text.Length;
        }
    }
}