using System;
using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class NormWiresViewModel : BaseViewModel {
        private int _roundCounter;

        private string _wire1Image,
            _wire2Image,
            _wire3Image,
            _wire4Image,
            _wire5Image,
            _wire6Image,
            _wireBrokenImage,
            _outputText;

        private string[] _wireArray = {"", "", "", "", "", ""};

        public NormWiresViewModel() {
            RoundCounter = 0;

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
            simpleMessenger.PushMessage("KeyBindings_NormWiresModule", null);
        }

        public int RoundCounter {
            get => _roundCounter;
            set {
                _roundCounter = value;
                RaisePropertyChangedEvent("RoundCounter");
            }
        }

        public string Wire1View {
            get => _wire1Image;
            set {
                _wire1Image = value;
                RaisePropertyChangedEvent("Wire1View");
            }
        }

        public string Wire2View {
            get => _wire2Image;
            set {
                _wire2Image = value;
                RaisePropertyChangedEvent("Wire2View");
            }
        }

        public string Wire3View {
            get => _wire3Image;
            set {
                _wire3Image = value;
                RaisePropertyChangedEvent("Wire3View");
            }
        }

        public string Wire4View {
            get => _wire4Image;
            set {
                _wire4Image = value;
                RaisePropertyChangedEvent("Wire4View");
            }
        }

        public string Wire5View {
            get => _wire5Image;
            set {
                _wire5Image = value;
                RaisePropertyChangedEvent("Wire5View");
            }
        }

        public string Wire6View {
            get => _wire6Image;
            set {
                _wire6Image = value;
                RaisePropertyChangedEvent("Wire6View");
            }
        }

        public string WireBrokenView {
            get => _wireBrokenImage;
            set {
                _wireBrokenImage = value;
                RaisePropertyChangedEvent("WireBrokenView");
            }
        }

        public string OutputText {
            get => _outputText;
            set {
                _outputText = value;
                RaisePropertyChangedEvent("OutputText");
            }
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (ReferenceValues.CurrentModule == "../Modules/NormWiresModule.xaml") {
                switch (e.PropertyName) {
                case "SerialEvenLogic":
                    ButtonLogic("update");
                    break;
                case "KEY_NumPad1":
                    ButtonLogic("whi");
                    break;
                case "KEY_NumPad2":
                    ButtonLogic("yel");
                    break;
                case "KEY_NumPad3":
                    ButtonLogic("blu");
                    break;
                case "KEY_NumPad4":
                    ButtonLogic("red");
                    break;
                case "KEY_NumPad5":
                    ButtonLogic("bla");
                    break;
                case "KEY_Back":
                    ButtonLogic("delete");
                    break;
                case "KEY_F12":
                    ResetButtonLogic();
                    break;
                }
            }
        }

        private void ButtonLogic(object param) {
            /* Clear entry button */
            if (param.ToString() == "delete") {
                RoundCounter--;
                if (RoundCounter < 0) {
                    RoundCounter = 0;
                }

                _wireArray[RoundCounter] = "";
                OutputText = "";
            }
            /* Normal execute */
            else if (param.ToString() == "update") {
                //continue
            } else if (RoundCounter < 6) {
                _wireArray[RoundCounter] = param.ToString();
                RoundCounter++;
            } else {
                return;
            }

            /* Display wires */
            Wire1View = "../../Resources/normal_wires/wire_1_" + _wireArray[0] + ".png";
            Wire2View = "../../Resources/normal_wires/wire_2_" + _wireArray[1] + ".png";
            Wire3View = "../../Resources/normal_wires/wire_3_" + _wireArray[2] + ".png";
            Wire4View = "../../Resources/normal_wires/wire_4_" + _wireArray[3] + ".png";
            Wire5View = "../../Resources/normal_wires/wire_5_" + _wireArray[4] + ".png";
            Wire6View = "../../Resources/normal_wires/wire_6_" + _wireArray[5] + ".png";
            WireBrokenView = "NULL";

            /* Logic of wire order */
            switch (RoundCounter) {
            case 3:
                /* If no red -> cut 2nd */
                if (_wireArray[0] != "red" && _wireArray[1] != "red" && _wireArray[2] != "red") {
                    Console.WriteLine(@"[3x] No red -> Cut Second");
                    OutputText = "Second";
                    WireBrokenView = "../../Resources/normal_wires/wire_2_broken.png";
                }
                /* Blue, blue, red -> cut 2nd */
                else if (_wireArray[0] == "blu" && _wireArray[1] == "blu" && _wireArray[2] == "red") {
                    Console.WriteLine(@"[3x] Blue, Blue, Red -> Cut Second");
                    OutputText = "Second";
                    WireBrokenView = "../../Resources/normal_wires/wire_2_broken.png";
                }
                /* Else -> cut 3rd */
                else {
                    Console.WriteLine(@"[3x] Else -> Cut Last");
                    OutputText = "Last";
                    WireBrokenView = "../../Resources/normal_wires/wire_3_broken.png";
                }

                break;
            case 4:
                /* If 2+ red && serial odd -> cut last red */
                var temp = 0;
                foreach (var str in _wireArray) {
                    if (str == "red") {
                        temp++;
                    }
                }

                if (temp > 1 && !ReferenceValues.IsSerialEven) {
                    Console.WriteLine(@"[4x] 2+ Red && Serial Odd -> Cut Last Red");

                    /* Get largest value of wireArray that has a red wire */
                    for (var i = 3; i < 4; i--) {
                        if (_wireArray[i] == "red") {
                            /* Don't check for 1st wire... because like logic */
                            switch (i) {
                            case 3:
                                WireBrokenView = "../../Resources/normal_wires/wire_4_broken.png";
                                OutputText = "Last";
                                break;
                            case 2:
                                WireBrokenView = "../../Resources/normal_wires/wire_3_broken.png";
                                OutputText = "Third";
                                break;
                            case 1:
                                WireBrokenView = "../../Resources/normal_wires/wire_2_broken.png";
                                OutputText = "Second";
                                break;
                            }

                            break;
                        }
                    }

                    return;
                }
                /* If last is yellow && no red -> cut first */
                else if (_wireArray[0] != "red" && _wireArray[1] != "red" && _wireArray[2] != "red" &&
                         _wireArray[3] == "yel") {
                    Console.WriteLine(@"[4x] Last is Yellow && No Red -> Cut First");
                    WireBrokenView = "../../Resources/normal_wires/wire_1_broken.png";
                    OutputText = "First";
                    return;
                }

                /* If 1x blue -> cut first */
                temp = 0;
                foreach (var str in _wireArray) {
                    if (str == "blu") {
                        temp++;
                    }
                }

                if (temp == 1) {
                    Console.WriteLine(@"[4x] 1x Blue -> Cut First");
                    WireBrokenView = "../../Resources/normal_wires/wire_1_broken.png";
                    OutputText = "First";
                    return;
                }

                /* If 2+ yellow -> cut last */
                temp = 0;
                foreach (var str in _wireArray) {
                    if (str == "yel") {
                        temp++;
                    }
                }

                if (temp > 1) {
                    Console.WriteLine(@"[4x] 2+ Yellow -> Cut Last");
                    WireBrokenView = "../../Resources/normal_wires/wire_4_broken.png";
                    OutputText = "Last";
                }
                /* Else -> Cut last */
                else {
                    Console.WriteLine(@"[4x] Else -> Cut Second");
                    WireBrokenView = "../../Resources/normal_wires/wire_2_broken.png";
                    OutputText = "Second";
                }

                break;
            case 5:
                /* If Last is Black && Serial Odd -> Cut Fourth */
                if (_wireArray[4] == "bla" && !ReferenceValues.IsSerialEven) {
                    Console.WriteLine(@"[5x] Last is Black && Serial Odd -> Cut Fourth");
                    OutputText = "Fourth";
                    WireBrokenView = "../../Resources/normal_wires/wire_4_broken.png";
                    break;
                }

                /* If 1x Red && 2+ Yellow -> Cut First */
                temp = 0;
                foreach (var str in _wireArray) {
                    if (str == "red") {
                        temp++;
                    }
                }

                if (temp == 1) {
                    temp = 0;
                    foreach (var str in _wireArray) {
                        if (str == "yel") {
                            temp++;
                        }
                    }

                    if (temp > 1) {
                        Console.WriteLine(@"[5x] 1x Red && 2+ Yellow -> Cut First");
                        OutputText = "First";
                        WireBrokenView = "../../Resources/normal_wires/wire_1_broken.png";
                    }
                }
                /* If No Black -> Cut Second */
                else if (_wireArray[0] != "bla" && _wireArray[1] != "bla" && _wireArray[2] != "bla" &&
                         _wireArray[3] != "bla" && _wireArray[4] != "bla") {
                    Console.WriteLine(@"[5x] No Black -> Cut Second");
                    OutputText = "Second";
                    WireBrokenView = "../../Resources/normal_wires/wire_2_broken.png";
                }
                /* Else -> Cut First */
                else {
                    Console.WriteLine(@"[5x] Else -> Cut First");
                    OutputText = "First";
                    WireBrokenView = "../../Resources/normal_wires/wire_1_broken.png";
                }

                break;
            case 6:
                /* If No Yellow && Serial Odd -> Cut Third */
                if (_wireArray[0] != "yel" && _wireArray[1] != "yel" && _wireArray[2] != "yel" &&
                    _wireArray[3] != "yel" && _wireArray[4] != "yel" && _wireArray[5] != "yel" &&
                    !ReferenceValues.IsSerialEven) {
                    Console.WriteLine(@"[6x] No Yellow && Serial Odd -> Cut Third");
                    OutputText = "Third";
                    WireBrokenView = "../../Resources/normal_wires/wire_3_broken.png";
                    break;
                }

                /* If 1x Yellow and 2+ White -> Cut Fourth */
                temp = 0;
                foreach (var str in _wireArray) {
                    if (str == "yel") {
                        temp++;
                    }
                }

                if (temp == 1) {
                    temp = 0;
                    foreach (var str in _wireArray) {
                        if (str == "whi") {
                            temp++;
                        }
                    }
                } else {
                    temp = 0;
                }

                if (temp > 1) {
                    Console.WriteLine(@"[6x] 1x Yellow and 2+ White -> Cut Fourth");
                    OutputText = "Fourth";
                    WireBrokenView = "../../Resources/normal_wires/wire_4_broken.png";
                }
                /* If No Red -> Cut Last */
                else if (_wireArray[0] != "red" && _wireArray[1] != "red" && _wireArray[2] != "red" &&
                         _wireArray[3] != "red" && _wireArray[4] != "red" && _wireArray[5] != "red") {
                    Console.WriteLine(@"[6x] If No Red -> Cut Last");
                    OutputText = "Last";
                    WireBrokenView = "../../Resources/normal_wires/wire_6_broken.png";
                }
                /* Else -> Cut Fourth */
                else {
                    Console.WriteLine(@"[6x] Else -> Cut Fourth");
                    OutputText = "Fourth";
                    WireBrokenView = "../../Resources/normal_wires/wire_4_broken.png";
                }

                break;
            }
        }

        private void ResetButtonLogic() {
            RoundCounter = 0;
            _wireArray = new[] {"", "", "", "", "", ""};
            OutputText = "";
            ButtonLogic("update");
        }
    }
}