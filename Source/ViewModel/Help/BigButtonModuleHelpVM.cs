using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel.Help {
    public class BigButtonModuleHelpVM : BaseViewModel {
        private string _mainText, _buttonImage, _buttonText;

        public BigButtonModuleHelpVM() {
            ButtonText = "Hold";
            ButtonImage = "../../Resources/button/button_Red.png";
            MainText =
                "Instructions:\n1) Defuser quickly press and release the button - or -\n2) Defuser press and holds the button, relays the new glowing color to the manual and release the button when a number that  corresponds  to that color is displayed anywhere in the countdown timer.\n\nExternal Forces:\n1) Battery amount";
        }

        public string MainText {
            get => _mainText;
            set {
                _mainText = value;
                RaisePropertyChangedEvent("MainText");
            }
        }

        public string ButtonText {
            get => _buttonText;
            set {
                _buttonText = value;
                RaisePropertyChangedEvent("ButtonText");
            }
        }

        public string ButtonImage {
            get => _buttonImage;
            set {
                _buttonImage = value;
                RaisePropertyChangedEvent("ButtonImage");
            }
        }
    }
}