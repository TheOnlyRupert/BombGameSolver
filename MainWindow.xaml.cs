using System;
using System.Windows.Media.Imaging;

namespace BombGameSolver {
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();

            /* Load window's icon */
            Icon = BitmapFrame.Create(new Uri("pack://application:,,,/Resources/all_icon/icon.png",
                                              UriKind.RelativeOrAbsolute));
        }
    }
}