using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MazeModuleVM : BaseViewModel {
        private string _inputNodeText, _mazeImage;

        public MazeModuleVM() {
            MazeImage = "../../Resources/maze/maze11.png";

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
            simpleMessenger.PushMessage("KeyBindings_MazeModule", null);
        }

        public string MazeImage {
            get => _mazeImage;
            set {
                _mazeImage = value;
                RaisePropertyChangedEvent("MazeImage");
            }
        }

        public string InputNodeText {
            get => _inputNodeText;
            set {
                _inputNodeText = VerifyNodeText(value);
                RaisePropertyChangedEvent("InputNodeText");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (ReferenceValues.CurrentModule == "../Modules/MazeModule.xaml") {
                if (e.PropertyName == "KEY_F12") {
                    //Reset;
                }
            }
        }

        private string VerifyNodeText(string value) {
            if (value.Length == 1) {
                if (value[0] == '1' || value[0] == '2' || value[0] == '3' || value[0] == '4' || value[0] == '5') {
                    return value;
                }

                return "";
            }

            switch (value) {
            case "11":
                MazeImage = "../../Resources/maze/maze11.png";
                break;
            case "12":
                MazeImage = "../../Resources/maze/maze12.png";
                break;
            case "21":
                MazeImage = "../../Resources/maze/maze21.png";
                break;
            case "24":
                MazeImage = "../../Resources/maze/maze24.png";
                break;
            case "32":
                MazeImage = "../../Resources/maze/maze32.png";
                break;
            case "41":
                MazeImage = "../../Resources/maze/maze41.png";
                break;
            case "44":
                MazeImage = "../../Resources/maze/maze44.png";
                break;
            case "51":
                MazeImage = "../../Resources/maze/maze51.png";
                break;
            case "53":
                MazeImage = "../../Resources/maze/maze53.png";
                break;
            default:
                return value[0] + "";
            }

            return value;
        }
    }
}