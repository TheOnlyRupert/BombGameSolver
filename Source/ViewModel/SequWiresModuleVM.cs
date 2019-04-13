using System;
using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class SequWiresModuleVM : BaseViewModel {
        private readonly int[] _blaWireStatic = {6, 5, 1, 5, 1, 4, 3, 2, 2};

        /* Alpha=0, Bravo=1, Charlie=2, Alpha+Bravo=3 Bravo+Charlie=4, Alpha+Charlie=5, All=6 */
        private readonly int[] _bluWireStatic = {1, 5, 1, 0, 1, 4, 2, 5, 0};
        private readonly int[] _redWireStatic = {2, 1, 0, 5, 1, 5, 6, 3, 1};
        private readonly int[] _roundCounter = {0, 0, 0};
        private bool _enableSoundsCheck;
        private string _outputTextBox, _bluRoundTextBox, _redRoundTextBox, _blaRoundTextBox;

        public SequWiresModuleVM() {
            BluRoundTextBox = _roundCounter[0].ToString();
            RedRoundTextBox = _roundCounter[1].ToString();
            BlaRoundTextBox = _roundCounter[2].ToString();
            EnableSoundsCheck = ReferenceValues.SequWiresSounds;

            CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
            simpleMessenger.PushMessage("KeyBindings_SequWiresModule", null);
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

        public bool EnableSoundsCheck {
            get => _enableSoundsCheck;
            set {
                if (_enableSoundsCheck == value) {
                    return;
                }

                _enableSoundsCheck = value;
                /* Change value if checkbox changes */
                Console.WriteLine(@"Changing setting SequWiresSounds to: " + _enableSoundsCheck);
                ReferenceValues.SequWiresSounds = _enableSoundsCheck;
                RaisePropertyChangedEvent("EnableSoundsCheck");
            }
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (ReferenceValues.CurrentModule == "../Modules/SequWiresModule.xaml") {
                switch (e.PropertyName) {
                case "KEY_NumPad1":
                    ButtonCommandLogic("blu_c");
                    break;
                case "KEY_NumPad2":
                    ButtonCommandLogic("red_c");
                    break;
                case "KEY_NumPad3":
                    ButtonCommandLogic("bla_c");
                    break;
                case "KEY_NumPad4":
                    ButtonCommandLogic("blu_b");
                    break;
                case "KEY_NumPad5":
                    ButtonCommandLogic("red_b");
                    break;
                case "KEY_NumPad6":
                    ButtonCommandLogic("bla_b");
                    break;
                case "KEY_NumPad7":
                    ButtonCommandLogic("blu_a");
                    break;
                case "KEY_NumPad8":
                    ButtonCommandLogic("red_a");
                    break;
                case "KEY_NumPad9":
                    ButtonCommandLogic("bla_a");
                    break;
                case "KEY_F12":
                    ResetButtonLogic();
                    break;
                }
            }
        }

        private void ButtonCommandLogic(object param) {
            PlaySound soundYes = new PlaySound("yes");
            PlaySound soundNo = new PlaySound("no");

            OutputTextBox = param.ToString();

            /* Remove 1x round from respective roundCounter */
            switch (OutputTextBox) {
            case "blu_del":
                _roundCounter[0]--;
                if (_roundCounter[0] < 0) {
                    _roundCounter[0] = 0;
                    OutputTextBox = "";
                } else {
                    OutputTextBox = "Removed 1x Blue";
                }

                break;
            case "red_del":
                _roundCounter[1]--;
                if (_roundCounter[1] < 0) {
                    _roundCounter[1] = 0;
                    OutputTextBox = "";
                } else {
                    OutputTextBox = "Removed 1x Red";
                }

                break;
            case "bla_del":
                _roundCounter[2]--;
                if (_roundCounter[2] < 0) {
                    _roundCounter[2] = 0;
                    OutputTextBox = "";
                } else {
                    OutputTextBox = "Removed 1x Black";
                }

                break;

            /* Check blues */
            case "blu_a":
                if (_roundCounter[0] < 9) {
                    if (_bluWireStatic[_roundCounter[0]] == 0 || _bluWireStatic[_roundCounter[0]] == 3 ||
                        _bluWireStatic[_roundCounter[0]] == 5 || _bluWireStatic[_roundCounter[0]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[0]++;
                } else {
                    _roundCounter[0] = 9;
                    OutputTextBox = "Max Blue";
                }

                break;
            case "blu_b":
                if (_roundCounter[0] < 9) {
                    if (_bluWireStatic[_roundCounter[0]] == 1 || _bluWireStatic[_roundCounter[0]] == 3 ||
                        _bluWireStatic[_roundCounter[0]] == 4 || _bluWireStatic[_roundCounter[0]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[0]++;
                } else {
                    _roundCounter[0] = 9;
                    OutputTextBox = "Max Blue";
                }

                break;
            case "blu_c":
                if (_roundCounter[0] < 9) {
                    if (_bluWireStatic[_roundCounter[0]] == 2 || _bluWireStatic[_roundCounter[0]] == 4 ||
                        _bluWireStatic[_roundCounter[0]] == 5 || _bluWireStatic[_roundCounter[0]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[0]++;
                } else {
                    _roundCounter[0] = 9;
                    OutputTextBox = "Max Blue";
                }

                break;

            /* Check Reds */
            case "red_a":
                if (_roundCounter[1] < 9) {
                    if (_redWireStatic[_roundCounter[1]] == 0 || _redWireStatic[_roundCounter[1]] == 3 ||
                        _redWireStatic[_roundCounter[1]] == 5 || _redWireStatic[_roundCounter[1]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[1]++;
                } else {
                    _roundCounter[1] = 9;
                    OutputTextBox = "Max Red";
                }

                break;
            case "red_b":
                if (_roundCounter[1] < 9) {
                    if (_redWireStatic[_roundCounter[1]] == 1 || _redWireStatic[_roundCounter[1]] == 3 ||
                        _redWireStatic[_roundCounter[1]] == 4 || _redWireStatic[_roundCounter[1]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[1]++;
                } else {
                    _roundCounter[1] = 9;
                    OutputTextBox = "Max Red";
                }

                break;
            case "red_c":
                if (_roundCounter[1] < 9) {
                    if (_redWireStatic[_roundCounter[1]] == 2 || _redWireStatic[_roundCounter[1]] == 4 ||
                        _redWireStatic[_roundCounter[1]] == 5 || _redWireStatic[_roundCounter[1]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[1]++;
                } else {
                    _roundCounter[1] = 9;
                    OutputTextBox = "Max Red";
                }

                break;

            /* check Blacks */
            case "bla_a":
                if (_roundCounter[2] < 9) {
                    if (_blaWireStatic[_roundCounter[2]] == 0 || _blaWireStatic[_roundCounter[2]] == 3 ||
                        _blaWireStatic[_roundCounter[2]] == 5 || _blaWireStatic[_roundCounter[2]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[2]++;
                } else {
                    _roundCounter[2] = 9;
                    OutputTextBox = "Max Black";
                }

                break;
            case "bla_b":
                if (_roundCounter[2] < 9) {
                    if (_blaWireStatic[_roundCounter[2]] == 1 || _blaWireStatic[_roundCounter[2]] == 3 ||
                        _blaWireStatic[_roundCounter[2]] == 4 || _blaWireStatic[_roundCounter[2]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[2]++;
                } else {
                    _roundCounter[2] = 9;
                    OutputTextBox = "Max Black";
                }

                break;
            case "bla_c":
                if (_roundCounter[2] < 9) {
                    if (_blaWireStatic[_roundCounter[2]] == 2 || _blaWireStatic[_roundCounter[2]] == 4 ||
                        _blaWireStatic[_roundCounter[2]] == 5 || _blaWireStatic[_roundCounter[2]] == 6) {
                        OutputTextBox = "TRUE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundYes.Play();
                        }
                    } else {
                        OutputTextBox = "FALSE";
                        if (ReferenceValues.SequWiresSounds) {
                            soundNo.Play();
                        }
                    }

                    _roundCounter[2]++;
                } else {
                    _roundCounter[2] = 9;
                    OutputTextBox = "Max Black";
                }

                break;
            }

            BluRoundTextBox = _roundCounter[0].ToString();
            RedRoundTextBox = _roundCounter[1].ToString();
            BlaRoundTextBox = _roundCounter[2].ToString();
        }

        private void ResetButtonLogic() {
            OutputTextBox = "Reset";
            _roundCounter[0] = 0;
            _roundCounter[1] = 0;
            _roundCounter[2] = 0;

            BluRoundTextBox = "0";
            RedRoundTextBox = "0";
            BlaRoundTextBox = "0";
        }
    }
}