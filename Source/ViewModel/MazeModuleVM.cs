using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MazeModuleVM : BaseViewModel {
        private readonly int[,] _mazeCoords;
        private string _inputNodeText, _inputYouText, _inputTargetText, _mazeImage, _currentMazeText;

        public MazeModuleVM() {
            MazeImage = "../../Resources/maze/maze11.png";
            CurrentMazeText = "Current Maze:  1,1";
            _mazeCoords = new int[3, 2];

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
                _inputNodeText = VerifyNodeText(value, 0);
                RaisePropertyChangedEvent("InputNodeText");
            }
        }

        public string InputYouText {
            get => _inputYouText;
            set {
                _inputYouText = VerifyNodeText(value, 1);
                RaisePropertyChangedEvent("InputYouText");
            }
        }

        public string InputTargetText {
            get => _inputTargetText;
            set {
                _inputTargetText = VerifyNodeText(value, 2);
                RaisePropertyChangedEvent("InputTargetText");
            }
        }

        public string CurrentMazeText {
            get => _currentMazeText;
            set {
                _currentMazeText = value;
                RaisePropertyChangedEvent("CurrentMazeText");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (ReferenceValues.CurrentModule == "../Modules/MazeModule.xaml") {
                if (e.PropertyName == "KEY_F12") {
                    //Reset;
                }
            }
        }

        private string VerifyNodeText(string value, int type) {
            switch (type) {
            /* Node Location */
            case 0:
                /* Reset if child is changed */
                //InputYouText = InputTargetText = "";
                _mazeCoords[1, 0] = _mazeCoords[1, 1] = _mazeCoords[2, 0] = _mazeCoords[2, 1] = 0;

                if (value.Length == 1) {
                    if (value[0] == '1' || value[0] == '2' || value[0] == '3' || value[0] == '4' || value[0] == '5') {
                        return value;
                    }

                    return "";
                }

                switch (value) {
                case "11":
                    MazeImage = "../../Resources/maze/maze11.png";
                    CurrentMazeText = "Current Maze:  1,1";
                    break;
                case "12":
                    MazeImage = "../../Resources/maze/maze12.png";
                    CurrentMazeText = "Current Maze:  1,2";
                    break;
                case "21":
                    MazeImage = "../../Resources/maze/maze21.png";
                    CurrentMazeText = "Current Maze:  2,1";
                    break;
                case "24":
                    MazeImage = "../../Resources/maze/maze24.png";
                    CurrentMazeText = "Current Maze:  2,4";
                    break;
                case "32":
                    MazeImage = "../../Resources/maze/maze32.png";
                    CurrentMazeText = "Current Maze:  3,2";
                    break;
                case "41":
                    MazeImage = "../../Resources/maze/maze41.png";
                    CurrentMazeText = "Current Maze:  4,1";
                    break;
                case "44":
                    MazeImage = "../../Resources/maze/maze44.png";
                    CurrentMazeText = "Current Maze:  4,4";
                    break;
                case "51":
                    MazeImage = "../../Resources/maze/maze51.png";
                    CurrentMazeText = "Current Maze:  5,1";
                    break;
                case "53":
                    MazeImage = "../../Resources/maze/maze53.png";
                    CurrentMazeText = "Current Maze:  5,3";
                    break;
                default:
                    return value[0] + "";
                }

                return value;

            /* Player Location */
            case 1:
                /* Reset if child is changed */
                //InputTargetText = "";
                _mazeCoords[2, 0] = _mazeCoords[2, 1] = 0;

                if (value.Length == 1) {
                    if (value[0] == '1' || value[0] == '2' || value[0] == '3' || value[0] == '4' || value[0] == '5' ||
                        value[0] == '6') {
                        return value;
                    }

                    return "";
                } else {
                    if (value[1] == '1' || value[1] == '2' || value[1] == '3' || value[1] == '4' || value[1] == '5' ||
                        value[1] == '6') {
                        /* Set player location into coords */
                        _mazeCoords[1, 0] = int.Parse(value[0].ToString());
                        _mazeCoords[1, 1] = int.Parse(value[1].ToString());

                        return value;
                    }

                    return value[0] + "";
                }

            /* Target Location */
            case 2:
                if (value.Length == 1) {
                    if (value[0] == '1' || value[0] == '2' || value[0] == '3' || value[0] == '4' || value[0] == '5' ||
                        value[0] == '6') {
                        return value;
                    }

                    return "";
                } else {
                    if (value[1] == '1' || value[1] == '2' || value[1] == '3' || value[1] == '4' || value[1] == '5' ||
                        value[1] == '6') {
                        /* Set target location into coords */
                        _mazeCoords[2, 0] = int.Parse(value[0].ToString());
                        _mazeCoords[2, 1] = int.Parse(value[1].ToString());

                        /* Call logic */
                        MazeLogic();

                        return value;
                    }

                    return value[0] + "";
                }
            }

            return value;
        }

        private void MazeLogic() {
            new Maze.Maze();
        }
    }
}