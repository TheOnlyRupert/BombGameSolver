using System;
using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MemoryModuleVM : BaseViewModel {
        private readonly int[,] _memoryLogic = new int[5, 5];

        /* _memoryPosNum -> round pos, round lab */
        private readonly int[,] _memoryPosNum = new int[5, 2];
        private bool _canSubmit;

        private string _inputTextBox, _displayMainImage, _firMainImage, _secMainImage, _thiMainImage, _fouMainImage,
            _roundText, _outputHighlightImage, _lightImage, _outputText;

        /* round num -> 0 - 4 */
        private int _roundNum;

        public MemoryModuleVM() {
            _roundNum = 0;
            RoundText = "Round 1/5";
            _canSubmit = false;
            LightImage = "../../Resources/memory/light_1.png";

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
            simpleMessenger.PushMessage("KeyBindings_MemoryModule", null);
        }

        public string InputTextBox {
            get => _inputTextBox;
            set {
                _inputTextBox = VerifyInput(value);
                RaisePropertyChangedEvent("InputTextBox");
            }
        }

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

        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (ReferenceValues.CurrentModule == "../Modules/MemoryModule.xaml") {
                switch (e.PropertyName) {
                case "KEY_F12":
                    _roundNum = 0;
                    RoundText = "Round 1/5";
                    _canSubmit = false;
                    DisplayMainImage = FirMainImage =
                        SecMainImage = ThiMainImage = FouMainImage = OutputHighlightImage = "NULL";
                    InputTextBox = OutputText = "";
                    LightImage = "../../Resources/memory/light_1.png";
                    break;
                case "KEY_Enter":
                    ButtonLogic("submit");
                    break;
                }
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
                OutputText = "";
                OutputHighlightImage = "NULL";
                _canSubmit = false;
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
                _canSubmit = false;

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
                _canSubmit = false;

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
                _canSubmit = false;

                break;
            case 4:
                if (input[3] != '1' && input[3] != '2' && input[3] != '3' && input[3] != '4'
                    || input[3] == input[1] || input[3] == input[2] || input[2] == input[1]) {
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

                    Console.WriteLine(@"TEST");

                    /* Add inputs into respective array in _memoryLogic */
                    for (var i = 0; i < input.Length; i++) {
                        _memoryLogic[_roundNum, i] = int.Parse(input[i].ToString());
                    }

                    _memoryLogic[_roundNum, 4] = int.Parse(lastNum.ToString());

                    Console.WriteLine("Round " + _roundNum + " Logic: " + _memoryLogic[_roundNum, 0] + ", " +
                                      _memoryLogic[_roundNum, 1] +
                                      ", " + _memoryLogic[_roundNum, 2] + ", " + _memoryLogic[_roundNum, 3] + ", " +
                                      _memoryLogic[_roundNum, 4]);

                    _canSubmit = true;
                    OutputLogic();
                }

                break;
            }

            return input;
        }

        private void OutputLogic() {
            switch (_roundNum) {
            /* Real round 1 */
            case 0:
                switch (_memoryLogic[0, 0]) {
                /* Position 2 */
                case 1:
                case 2:
                    _memoryPosNum[0, 0] = 2;
                    _memoryPosNum[0, 1] = _memoryLogic[0, 2];
                    Console.WriteLine("Round #1: if 1 or 2, pos 2\nPos: " + _memoryPosNum[0, 0] + ", Num: " +
                                      _memoryPosNum[0, 1]);
                    break;
                /* Position 3 */
                case 3:
                    _memoryPosNum[0, 0] = 3;
                    _memoryPosNum[0, 1] = _memoryLogic[0, 3];
                    Console.WriteLine("Round #1: if 3, pos 3\nPos: " + _memoryPosNum[0, 0] + ", Num: " +
                                      _memoryPosNum[0, 1]);
                    break;
                /* Position 4 */
                case 4:
                    _memoryPosNum[0, 0] = 4;
                    _memoryPosNum[0, 1] = _memoryLogic[0, 4];
                    Console.WriteLine("Round #1: if 4, pos 4\nPos: " + _memoryPosNum[0, 0] + ", Num: " +
                                      _memoryPosNum[0, 1]);
                    break;
                }

                OutputText = "Click on: " + _memoryPosNum[0, 1];
                OutputHighlightImage = "../../Resources/memory/out_" + _memoryPosNum[0, 0] + ".png";

                break;
            /* Real round 2 */
            case 1:
                switch (_memoryLogic[1, 0]) {
                /* Labeled 4 */
                case 1:
                    for (var i = 1; i < 5; i++) {
                        if (_memoryLogic[1, i] == 4) {
                            _memoryPosNum[1, 0] = i;
                            _memoryPosNum[1, 1] = 4;
                            break;
                        }
                    }

                    Console.WriteLine("Round #2: if 1, label 4\nPos: " + _memoryPosNum[1, 0] + ", Num: " +
                                      _memoryPosNum[1, 1]);
                    break;
                /* Same position as stage 1 */
                case 2:
                case 4:
                    _memoryPosNum[1, 0] = _memoryPosNum[0, 0];
                    _memoryPosNum[1, 1] = _memoryLogic[1, _memoryPosNum[1, 0]];
                    Console.WriteLine("Round #2: if 2 or 4, pos as stage #1\nPos: " + _memoryPosNum[1, 0] + ", Num: " +
                                      _memoryPosNum[1, 1]);

                    break;
                /* Position 1 */
                case 3:
                    _memoryPosNum[1, 0] = 1;
                    _memoryPosNum[1, 1] = _memoryLogic[1, 1];
                    Console.WriteLine("Round #2: if 3, pos 1\nPos: " + _memoryPosNum[1, 0] + ", Num: " +
                                      _memoryPosNum[1, 1]);

                    break;
                }

                OutputText = "Click on: " + _memoryPosNum[1, 1];
                OutputHighlightImage = "../../Resources/memory/out_" + _memoryPosNum[1, 0] + ".png";

                break;
            /* Real round 3 */
            case 2:
                switch (_memoryLogic[2, 0]) {
                /* Same label as stage 2 */
                case 1:
                    _memoryPosNum[2, 1] = _memoryPosNum[1, 1];

                    for (var i = 1; i < 5; i++) {
                        if (_memoryLogic[2, i] == _memoryPosNum[2, 1]) {
                            _memoryPosNum[2, 0] = i;
                            break;
                        }
                    }

                    Console.WriteLine("Round #3: if 1, label as stage #2\nPos: " + _memoryPosNum[2, 0] + ", Num: " +
                                      _memoryPosNum[2, 1]);

                    break;
                /* Same label as stage 1 */
                case 2:
                    _memoryPosNum[2, 1] = _memoryPosNum[0, 1];

                    for (var i = 1; i < 5; i++) {
                        if (_memoryLogic[2, i] == _memoryPosNum[2, 1]) {
                            _memoryPosNum[2, 0] = i;
                            break;
                        }
                    }

                    Console.WriteLine("Round #3: if 2, label as stage #1\nPos: " + _memoryPosNum[2, 0] + ", Num: " +
                                      _memoryPosNum[2, 1]);

                    break;
                /* Position 3 */
                case 3:
                    _memoryPosNum[2, 0] = 3;
                    _memoryPosNum[2, 1] = _memoryLogic[2, 3];
                    Console.WriteLine("Round #3: if 3, pos 3\nPos: " + _memoryPosNum[2, 0] + ", Num: " +
                                      _memoryPosNum[2, 1]);

                    break;
                /* Labeled 4 */
                case 4:
                    for (var i = 1; i < 5; i++) {
                        if (_memoryLogic[2, i] == 4) {
                            _memoryPosNum[2, 0] = i;
                            _memoryPosNum[2, 1] = 4;
                            break;
                        }
                    }

                    Console.WriteLine("Round #4: if 4, label 4\nPos: " + _memoryPosNum[2, 0] + ", Num: " +
                                      _memoryPosNum[2, 1]);

                    break;
                }

                OutputText = "Click on: " + _memoryPosNum[2, 1];
                OutputHighlightImage = "../../Resources/memory/out_" + _memoryPosNum[2, 0] + ".png";

                break;
            /* Real round 4 */
            case 3:
                switch (_memoryLogic[3, 0]) {
                /* Same position as stage 1 */
                case 1:
                    _memoryPosNum[3, 0] = _memoryPosNum[0, 0];
                    _memoryPosNum[3, 1] = _memoryLogic[3, _memoryPosNum[0, 0]];
                    Console.WriteLine("Round #4: if 1, pos as stage #1\nPos: " + _memoryPosNum[3, 0] + ", Num: " +
                                      _memoryPosNum[3, 1]);

                    break;
                /* Position 1 */
                case 2:
                    _memoryPosNum[3, 0] = 1;
                    _memoryPosNum[3, 1] = _memoryLogic[3, 1];
                    Console.WriteLine("Round #4: if 2, pos 1\nPos: " + _memoryPosNum[3, 0] + ", Num: " +
                                      _memoryPosNum[3, 1]);

                    break;
                /* Same position as stage 2 */
                case 3:
                case 4:
                    _memoryPosNum[3, 0] = _memoryPosNum[1, 0];
                    _memoryPosNum[3, 1] = _memoryLogic[3, _memoryPosNum[0, 0]];
                    Console.WriteLine("Round #4: if 3 or 4, pos as stage #2\nPos: " + _memoryPosNum[3, 0] + ", Num: " +
                                      _memoryPosNum[3, 1]);

                    break;
                }

                OutputText = "Click on: " + _memoryPosNum[3, 1];
                OutputHighlightImage = "../../Resources/memory/out_" + _memoryPosNum[3, 0] + ".png";

                break;
            /* Real round 5 */
            case 4:
                switch (_memoryLogic[4, 0]) {
                /* Same label as stage 1 */
                case 1:
                    _memoryPosNum[4, 1] = _memoryPosNum[0, 1];

                    for (var i = 1; i < 5; i++) {
                        if (_memoryLogic[4, i] == _memoryPosNum[4, 1]) {
                            _memoryPosNum[4, 0] = i;
                            break;
                        }
                    }

                    Console.WriteLine("Round #5: if 1, label as stage #1\nPos: " + _memoryPosNum[4, 0] + ", Num: " +
                                      _memoryPosNum[4, 1]);
                    break;
                /* Same label as stage 2 */
                case 2:
                    _memoryPosNum[4, 1] = _memoryPosNum[1, 1];

                    for (var i = 1; i < 5; i++) {
                        if (_memoryLogic[4, i] == _memoryPosNum[4, 1]) {
                            _memoryPosNum[4, 0] = i;
                            break;
                        }
                    }

                    Console.WriteLine("Round #5: if 2, label as stage #2\nPos: " + _memoryPosNum[4, 0] + ", Num: " +
                                      _memoryPosNum[4, 1]);

                    break;
                /* Same label as stage 4 */
                case 3:
                    _memoryPosNum[4, 1] = _memoryPosNum[3, 1];

                    for (var i = 1; i < 5; i++) {
                        if (_memoryLogic[4, i] == _memoryPosNum[4, 1]) {
                            _memoryPosNum[4, 0] = i;
                            break;
                        }
                    }

                    Console.WriteLine("Round #5: if 3, label as stage #4\nPos: " + _memoryPosNum[4, 0] + ", Num: " +
                                      _memoryPosNum[4, 1]);

                    break;
                /* Same label as stage 3 */
                case 4:
                    _memoryPosNum[4, 1] = _memoryPosNum[2, 1];

                    for (var i = 1; i < 5; i++) {
                        if (_memoryLogic[4, i] == _memoryPosNum[4, 1]) {
                            _memoryPosNum[4, 0] = i;
                            break;
                        }
                    }

                    Console.WriteLine("Round #5: if 4, label as stage #3\nPos: " + _memoryPosNum[4, 0] + ", Num: " +
                                      _memoryPosNum[4, 1]);

                    break;
                }

                OutputText = "Click on: " + _memoryPosNum[4, 1];
                OutputHighlightImage = "../../Resources/memory/out_" + _memoryPosNum[4, 0] + ".png";

                break;
            }
        }

        private void ButtonLogic(object param) {
            if (param.ToString() == "submit" && _canSubmit && _roundNum < 4) {
                _roundNum++;
                RoundText = "Round " + (_roundNum + 1) + "/5";
                _canSubmit = false;

                InputTextBox = "";
                DisplayMainImage = "NULL";
                FirMainImage = "NULL";
                SecMainImage = "NULL";
                ThiMainImage = "NULL";
                FouMainImage = "NULL";
                OutputHighlightImage = "NULL";
                OutputText = "";

                LightImage = "../../Resources/memory/light_" + (_roundNum + 1) + ".png";
            }
        }
    }
}