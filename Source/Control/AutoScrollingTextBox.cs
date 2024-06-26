using System;
using System.Windows.Controls;

namespace BombGameSolver.Source.Control;

public class AutoScrollingTextBox : TextBox {
    protected override void OnInitialized(EventArgs e) {
        base.OnInitialized(e);
        VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
    }

    protected override void OnTextChanged(TextChangedEventArgs e) {
        base.OnTextChanged(e);
        CaretIndex = Text.Length;
        ScrollToEnd();
    }
}