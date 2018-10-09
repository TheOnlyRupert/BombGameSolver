using System;
using System.Media;
using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class SequWiresModuleVM : BaseViewModel {
        private string _outputTextBox, _bluRoundTextBox, _redRoundTextBox, _blaRoundTextBox;
        private int[] roundCounter = {0, 0, 0};

        /* Alpha=0, Bravo=1, Charlie=2, Alpha+Bravo=3 Bravo+Charlie=4, Alpha+Charlie=5, All=6*/
        private readonly int[] _bluWireStatic = {1, 5, 1, 0, 1, 4, 2, 5, 0};
        private readonly int[] _redWireStatic = {2, 1, 0, 5, 1, 5, 6, 3, 1};
        private readonly int[] _blaWireStatic = {6, 5, 1, 5, 1, 4, 3, 2, 2};

        public SequWiresModuleVM() {
            BluRoundTextBox = roundCounter[0].ToString();
            RedRoundTextBox = roundCounter[1].ToString();
            BlaRoundTextBox = roundCounter[2].ToString();
        }

        public string OutputTextBox {
            get => _outputTextBox;
            set {
                _outputTextBox = value;
                RaisePropertyChangedEvent("OutputTextBox");
            }
        }

        public string BluRoundTextBox {
            get => _bluRoundTextBox;
            set {
                _bluRoundTextBox = value;
                RaisePropertyChangedEvent("BluRoundTextBox");
            }
        }

        public string RedRoundTextBox {
            get => _redRoundTextBox;
            set {
                _redRoundTextBox = value;
                RaisePropertyChangedEvent("RedRoundTextBox");
            }
        }

        public string BlaRoundTextBox {
            get => _blaRoundTextBox;
            set {
                _blaRoundTextBox = value;
                RaisePropertyChangedEvent("BlaRoundTextBox");
            }
        }

        public ICommand ResetButtonCommand => new DelegateCommand(ResetButtonLogic, true);
        private void ResetButtonLogic(object param) {
            OutputTextBox = "Reset";
            roundCounter[0] = 0;
            roundCounter[1] = 0;
            roundCounter[2] = 0;

            BluRoundTextBox = "0";
            RedRoundTextBox = "0";
            BlaRoundTextBox = "0";
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);
        private void ButtonCommandLogic(object param) {
            OutputTextBox = param.ToString();

            /* Remove 1x round from respective roundCounter */
            switch (OutputTextBox) {
            case "blu_del":
                roundCounter[0]--;
                if (roundCounter[0] < 0) {
                    roundCounter[0] = 0;
                } else {
                    OutputTextBox = "REMOVED BLUE";
                }
                break;
            case "red_del":
                roundCounter[1]--;
                if (roundCounter[1] < 0) {
                    roundCounter[1] = 0;
                } else {
                    OutputTextBox = "REMOVED RED";
                }
                break;
            case "bla_del":
                roundCounter[2]--;
                if (roundCounter[2] < 0) {
                    roundCounter[2] = 0;
                }
                else {
                    OutputTextBox = "REMOVED BLACK";
                }
                break;
            }

            switch (OutputTextBox) {
            /* Check blues */
            case "blu_a":
                if (roundCounter[0] < 9) {
                    if (_bluWireStatic[roundCounter[0]] == 0 || _bluWireStatic[roundCounter[0]] == 3 ||
                        _bluWireStatic[roundCounter[0]] == 5 || _bluWireStatic[roundCounter[0]] == 6) {
                        OutputTextBox = "TRUE";
                    } else {
                        OutputTextBox = "FALSE";
                    }
                    roundCounter[0]++;
                } else {
                    roundCounter[0] = 9;
                    OutputTextBox = "EXCEEDED_MAX_BLUE";
                }
                break;
            case "blu_b":
                if (roundCounter[0] < 9) {
                    if (_bluWireStatic[roundCounter[0]] == 1 || _bluWireStatic[roundCounter[0]] == 3 ||
                        _bluWireStatic[roundCounter[0]] == 4 || _bluWireStatic[roundCounter[0]] == 6) {
                        OutputTextBox = "TRUE";
                    } else {
                        OutputTextBox = "FALSE";
                    }
                    roundCounter[0]++;
                } else {
                    roundCounter[0] = 9;
                    OutputTextBox = "EXCEEDED_MAX_BLUE";
                }
                break;
            case "blu_c":
                if (roundCounter[0] < 9) {
                    if (_bluWireStatic[roundCounter[0]] == 2 || _bluWireStatic[roundCounter[0]] == 4 ||
                        _bluWireStatic[roundCounter[0]] == 5 || _bluWireStatic[roundCounter[0]] == 6) {
                        OutputTextBox = "TRUE";
                    } else {
                        OutputTextBox = "FALSE";
                    }
                    roundCounter[0]++;
                } else {
                    roundCounter[0] = 9;
                    OutputTextBox = "EXCEEDED_MAX_BLUE";
                }
                break;

            /* Check Reds */
            case "red_a":
                if (roundCounter[1] < 9) {
                    if (_bluWireStatic[roundCounter[1]] == 0 || _redWireStatic[roundCounter[1]] == 3 ||
                        _bluWireStatic[roundCounter[1]] == 5 || _redWireStatic[roundCounter[1]] == 6) {
                        OutputTextBox = "TRUE";

                    } else {
                        OutputTextBox = "FALSE";
                    }
                    roundCounter[1]++;
                } else {
                    roundCounter[1] = 9;
                    OutputTextBox = "EXCEEDED_MAX_RED";
                }
                break;
            case "red_b":
                roundCounter[1]++;
                if (roundCounter[1] < 9) {
                    if (_bluWireStatic[roundCounter[1]] == 1 || _redWireStatic[roundCounter[1]] == 3 ||
                        _bluWireStatic[roundCounter[1]] == 4 || _redWireStatic[roundCounter[1]] == 6) {
                        OutputTextBox = "TRUE";
                    } else {
                        OutputTextBox = "FALSE";
                    }
                } else {
                    roundCounter[1] = 9;
                    OutputTextBox = "EXCEEDED_MAX_RED";
                }
                break;
            case "red_c":
                roundCounter[1]++;
                if (roundCounter[1] < 9) {
                    if (_bluWireStatic[roundCounter[1]] == 2 || _redWireStatic[roundCounter[1]] == 4 ||
                        _bluWireStatic[roundCounter[1]] == 5 || _redWireStatic[roundCounter[1]] == 6) {
                        OutputTextBox = "TRUE";
                    } else {
                        OutputTextBox = "FALSE";
                    }
                } else {
                    roundCounter[1] = 9;
                    OutputTextBox = "EXCEEDED_MAX_RED";
                }
                break;

            /* check Blacks */
            case "bla_a":
                roundCounter[2]++;
                if (roundCounter[2] < 9) {
                    if (_bluWireStatic[roundCounter[2]] == 0 || _blaWireStatic[roundCounter[2]] == 3 ||
                        _bluWireStatic[roundCounter[2]] == 5 || _blaWireStatic[roundCounter[2]] == 6) {
                        OutputTextBox = "TRUE";
                    } else {
                        OutputTextBox = "FALSE";
                    }
                } else {
                    roundCounter[2] = 9;
                    OutputTextBox = "EXCEEDED_MAX_BLACK";
                }
                break;
            case "bla_b":
                roundCounter[2]++;
                if (roundCounter[2] < 9) {
                    if (_bluWireStatic[roundCounter[2]] == 1 || _blaWireStatic[roundCounter[2]] == 3 ||
                        _bluWireStatic[roundCounter[2]] == 4 || _blaWireStatic[roundCounter[2]] == 6) {
                        OutputTextBox = "TRUE";
                    } else {
                        OutputTextBox = "FALSE";
                    }
                } else {
                    roundCounter[2] = 9;
                    OutputTextBox = "EXCEEDED_MAX_BLACK";
                }
                break;
            case "bla_c":
                roundCounter[2]++;
                if (roundCounter[2] < 9) {
                    if (_bluWireStatic[roundCounter[2]] == 2 || _blaWireStatic[roundCounter[2]] == 4 ||
                        _bluWireStatic[roundCounter[2]] == 5 || _blaWireStatic[roundCounter[2]] == 6) {
                        OutputTextBox = "TRUE";
                    } else {
                        OutputTextBox = "FALSE";
                    }
                } else {
                    roundCounter[2] = 9;
                    OutputTextBox = "EXCEEDED_MAX_BLACK";
                }
                break;
            }

            BluRoundTextBox = roundCounter[0].ToString();
            RedRoundTextBox = roundCounter[1].ToString();
            BlaRoundTextBox = roundCounter[2].ToString();
        }
    }
}