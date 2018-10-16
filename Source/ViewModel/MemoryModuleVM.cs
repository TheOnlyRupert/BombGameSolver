using System;
using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MemoryModuleVM : BaseViewModel {
        private readonly int[] _roundLab = new int[5];
        private readonly int[,] _roundLogic = new int[5, 5];
        private readonly int[] _roundPos = new int[5];
        private bool _canSubmit;

        private string _inputTextBox, _displayMainImage, _firMainImage, _secMainImage, _thiMainImage, _fouMainImage,
            _roundText, _outputHighlightImage, _lightImage, _outputText;

        private int _roundNum;

        public MemoryModuleVM() {
            _roundNum = 1;
            RoundText = "Round 1/5";
            _canSubmit = false;
            LightImage = "../../Resources/memory/light_1.png";
        }

        public string InputTextBox {
            get => _inputTextBox;
            set {
                _inputTextBox = VerifyInput(value);
                RaisePropertyChangedEvent("InputTextBox");
            }
        }

        private string VerifyInput(string input) {
            switch (input.Length) {
            case 0:
                DisplayMainImage = "NULL";
                FirMainImage = "NULL";
                SecMainImage = "NULL";
                ThiMainImage = "NULL";
                FouMainImage = "NULL";
                break;
            case 1:
                if (input[0] != '1' && input[0] != '2' && input[0] != '3' && input[0] != '4') {
                    input = input.Remove(input.Length - 1);
                    DisplayMainImage = "NULL";
                } else {
                    DisplayMainImage = "../../Resources/memory/main_" + input[0] + ".png";
                }

                FirMainImage = "NULL";
                SecMainImage = "NULL";
                ThiMainImage = "NULL";
                FouMainImage = "NULL";
                OutputText = "";
                OutputHighlightImage = "NULL";

                break;
            case 2:
                if (input[1] != '1' && input[1] != '2' && input[1] != '3' && input[1] != '4') {
                    input = input.Remove(input.Length - 1);
                    FirMainImage = "NULL";
                } else {
                    FirMainImage = "../../Resources/memory/fir_" + input[1] + ".png";
                }

                SecMainImage = "NULL";
                ThiMainImage = "NULL";
                FouMainImage = "NULL";
                OutputText = "";
                OutputHighlightImage = "NULL";

                break;
            case 3:
                if (input[2] != '1' && input[2] != '2' && input[2] != '3' && input[2] != '4'
                    || input[2] == input[1]) {
                    input = input.Remove(input.Length - 1);
                    SecMainImage = "NULL";
                } else {
                    SecMainImage = "../../Resources/memory/sec_" + input[2] + ".png";
                }

                ThiMainImage = "NULL";
                FouMainImage = "NULL";
                OutputText = "";
                OutputHighlightImage = "NULL";

                break;
            case 4:
                if (input[3] != '1' && input[3] != '2' && input[3] != '3' && input[3] != '4'
                    || input[3] == input[1] || input[3] == input[2]) {
                    input = input.Remove(input.Length - 1);
                    ThiMainImage = "NULL";
                } else {
                    ThiMainImage = "../../Resources/memory/thi_" + input[3] + ".png";

                    char lastNum;
                    if (input[1] != '1' && input[2] != '1' && input[3] != '1') {
                        lastNum = '1';
                    } else if (input[1] != '2' && input[2] != '2' && input[3] != '2') {
                        lastNum = '2';
                    } else if (input[1] != '3' && input[2] != '3' && input[3] != '3') {
                        lastNum = '3';
                    } else {
                        lastNum = '4';
                    }

                    FouMainImage = "../../Resources/memory/fou_" + lastNum + ".png";

                    /* Wtf? Really Robert... fix this */
                    _roundLogic[_roundNum - 1, 0] = int.Parse(input[0].ToString());
                    _roundLogic[_roundNum - 1, 1] = int.Parse(input[1].ToString());
                    _roundLogic[_roundNum - 1, 2] = int.Parse(input[2].ToString());
                    _roundLogic[_roundNum - 1, 3] = int.Parse(input[3].ToString());
                    _roundLogic[_roundNum - 1, 4] = int.Parse(lastNum.ToString());

                    _canSubmit = true;
                    OutputLogic();
                }

                break;
            }

            return input;
        }

        private void OutputLogic() {
            switch (_roundNum) {
            case 1:
                switch (_roundLogic[0, 0]) {
                /* Position 2 */
                case 1:
                case 2:
                    _roundPos[0] = 2;
                    _roundLab[0] = _roundLogic[0, 2];
                    break;
                /* Position 3 */
                case 3:
                    _roundPos[0] = 3;
                    _roundLab[0] = _roundLogic[0, 3];
                    break;
                /* Position 4 */
                case 4:
                    _roundPos[0] = 4;
                    _roundLab[0] = _roundLogic[0, 4];
                    break;
                }

                OutputText = "Click on: " + _roundLab[0];
                OutputHighlightImage = "../../Resources/memory/out_" + _roundPos[0] + ".png";
                Console.WriteLine("First Round pos: " + _roundPos[0] + ", act: " + _roundLab[0]);

                break;
            case 2:
                switch (_roundLogic[1, 0]) {
                /* Labeled 4 */
                case 1:
                    if (_roundLogic[1, 1] == 4) {
                        _roundPos[1] = 1;
                    } else if (_roundLogic[1, 2] == 4) {
                        _roundPos[1] = 2;
                    } else if (_roundLogic[1, 3] == 4) {
                        _roundPos[1] = 3;
                    } else {
                        _roundPos[1] = 4;
                    }

                    _roundLab[1] = 4;
                    break;
                /* Same position as stage 1 */
                case 2:
                case 4:
                    _roundPos[1] = _roundPos[0];
                    _roundLab[1] = _roundLogic[1, _roundPos[0]];
                    break;
                /* Position 1 */
                case 3:
                    _roundPos[1] = 1;
                    _roundLab[1] = _roundLogic[1, 1];
                    break;
                }

                OutputText = "Click on: " + _roundLab[1];
                OutputHighlightImage = "../../Resources/memory/out_" + _roundPos[1] + ".png";
                Console.WriteLine("Second Round pos: " + _roundPos[1] + ", act: " + _roundLab[1]);

                break;
            case 3:
                switch (_roundLogic[2, 0]) {
                /* Same label as stage 2 */
                case 1:
                    _roundLab[2] = _roundLab[1];

                    break;
                /* Same label as stage 1 */
                case 2:
                    break;
                /* Position 3 */
                case 3:
                    OutputText = "Click on: " + _roundLogic[2, 3];
                    OutputHighlightImage = "../../Resources/memory/out_thi.png";
                    _roundPos[2] = 1;
                    _roundLab[2] = _roundLogic[2, 3];
                    break;
                /* Labeled 4 */
                case 4:
                    break;
                }

                OutputText = "Click on: " + _roundLab[2];
                OutputHighlightImage = "../../Resources/memory/out_" + _roundPos[2] + ".png";
                Console.WriteLine("Third Round pos: " + _roundPos[2] + ", act: " + _roundLab[2]);

                break;
            case 4:
                switch (_roundLogic[3, 0]) {
                /* Same position as stage 1 */
                case 1:
                    break;
                /* Position 1 */
                case 2:
                    break;
                /* Same position as stage 2 */
                case 3:
                case 4:
                    break;
                }

                OutputText = "Click on: " + _roundLab[3];
                OutputHighlightImage = "../../Resources/memory/out_" + _roundPos[3] + ".png";
                Console.WriteLine("Fourth Round pos: " + _roundPos[3] + ", act: " + _roundLab[3]);

                break;
            case 5:
                switch (_roundLogic[4, 0]) {
                /* Same label as stage 1 */
                case 1:
                    break;
                /* Same label as stage 2 */
                case 2:
                    break;
                /* Same label as stage 4 */
                case 3:
                    break;
                /* Same label as stage 3 */
                case 4:
                    break;
                }

                OutputText = "Click on: " + _roundLab[4];
                OutputHighlightImage = "../../Resources/memory/out_" + _roundPos[4] + ".png";
                Console.WriteLine("Fifth Round pos: " + _roundPos[4] + ", act: " + _roundLab[4]);

                break;
            }
        }

# region Images

        public string RoundText {
            get => _roundText;
            set {
                _roundText = value;
                RaisePropertyChangedEvent("RoundText");
            }
        }

        public string OutputHighlightImage {
            get => _outputHighlightImage;
            set {
                _outputHighlightImage = value;
                RaisePropertyChangedEvent("OutputHighlightImage");
            }
        }

        public string OutputText {
            get => _outputText;
            set {
                _outputText = value;
                RaisePropertyChangedEvent("OutputText");
            }
        }

        public string LightImage {
            get => _lightImage;
            set {
                _lightImage = value;
                RaisePropertyChangedEvent("LightImage");
            }
        }

        public string DisplayMainImage {
            get => _displayMainImage;
            set {
                _displayMainImage = value;
                RaisePropertyChangedEvent("DisplayMainImage");
            }
        }

        public string FirMainImage {
            get => _firMainImage;
            set {
                _firMainImage = value;
                RaisePropertyChangedEvent("FirMainImage");
            }
        }

        public string SecMainImage {
            get => _secMainImage;
            set {
                _secMainImage = value;
                RaisePropertyChangedEvent("SecMainImage");
            }
        }

        public string ThiMainImage {
            get => _thiMainImage;
            set {
                _thiMainImage = value;
                RaisePropertyChangedEvent("ThiMainImage");
            }
        }

        public string FouMainImage {
            get => _fouMainImage;
            set {
                _fouMainImage = value;
                RaisePropertyChangedEvent("FouMainImage");
            }
        }

#endregion

#region Buttons

        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);

        private void ButtonLogic(object param) {
            if (param.ToString() == "submit" && _canSubmit && _roundNum < 5) {
                _roundNum++;
                RoundText = "Round " + _roundNum + "/5";
                _canSubmit = false;

                InputTextBox = "";
                DisplayMainImage = "NULL";
                FirMainImage = "NULL";
                SecMainImage = "NULL";
                ThiMainImage = "NULL";
                FouMainImage = "NULL";
                OutputHighlightImage = "NULL";
                OutputText = "";

                LightImage = "../../Resources/memory/light_" + _roundNum + ".png";
            }

            if (param.ToString() == "next" || param.ToString() == "prev") {
                var sound = new PlaySound("not_implemented");
                sound.Play();
            }
        }

        public ICommand ResetButtonCommand => new DelegateCommand(ResetButtonLogic, true);

        private void ResetButtonLogic(object param) {
            _roundNum = 1;
            RoundText = "Round 1/5";
            _canSubmit = false;

            InputTextBox = "";
            DisplayMainImage = "NULL";
            FirMainImage = "NULL";
            SecMainImage = "NULL";
            ThiMainImage = "NULL";
            FouMainImage = "NULL";
            OutputHighlightImage = "NULL";
            OutputText = "";
            LightImage = "../../Resources/memory/light_1.png";
        }

#endregion
    }
}