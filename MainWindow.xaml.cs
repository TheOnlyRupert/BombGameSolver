using System;
using System.Windows.Media.Imaging;

namespace BombGameSolver {
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();

            Uri iconUri = new Uri("pack://application:,,,/Resources/folder.png", UriKind.RelativeOrAbsolute);
            Icon = BitmapFrame.Create(iconUri);
        }
    }
}