using System;
using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel;

public class CompWiresModuleVM : BaseViewModel {
    private bool _isLedOn, _isStarOn;

    private string _wireImage,
        _ledImage,
        _starImage,
        _ledButtonText,
        _starButtonText,
        _brokenWireImage,
        _outputText,
        _wireColor;

    public CompWiresModuleVM() {
        WireImage = "../../Resources/comp_wires/wire_whi.png";
        LedButtonText = "LED OFF (5)";
        StarButtonText = "Star OFF (6)";
        _wireColor = "white";
        WireLogic();

        CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
        simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
    }

    public string WireImage {
        get => _wireImage;
        set {
            _wireImage = value;
            RaisePropertyChangedEvent("WireImage");
        }
    }

    public string LedImage {
        get => _ledImage;
        set {
            _ledImage = value;
            RaisePropertyChangedEvent("LedImage");
        }
    }

    public string StarImage {
        get => _starImage;
        set {
            _starImage = value;
            RaisePropertyChangedEvent("StarImage");
        }
    }

    public string LedButtonText {
        get => _ledButtonText;
        set {
            _ledButtonText = value;
            RaisePropertyChangedEvent("LedButtonText");
        }
    }

    public string StarButtonText {
        get => _starButtonText;
        set {
            _starButtonText = value;
            RaisePropertyChangedEvent("StarButtonText");
        }
    }

    public string BrokenWireImage {
        get => _brokenWireImage;
        set {
            _brokenWireImage = value;
            RaisePropertyChangedEvent("BrokenWireImage");
        }
    }

    public string OutputText {
        get => _outputText;
        set {
            _outputText = value;
            RaisePropertyChangedEvent("OutputText");
        }
    }

    public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

    private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
        /* Update wires if SerialEven, BatteryAmount, or ParPort buttons from SettingsModule are changed */
        if (ReferenceValues.CurrentModule == "../Modules/CompWiresModule.xaml") {
            switch (e.PropertyName) {
            case "SerialEvenLogic":
            case "BatteryAmountChanged":
            case "ParPortLogic":
                WireLogic();
                break;
            case "KEY_NumPad1":
                ButtonCommandLogic("white");
                break;
            case "KEY_NumPad2":
                ButtonCommandLogic("blue");
                break;
            case "KEY_NumPad3":
                ButtonCommandLogic("red");
                break;
            case "KEY_NumPad4":
                ButtonCommandLogic("bluered");
                break;
            case "KEY_NumPad5":
                ButtonCommandLogic("led");
                break;
            case "KEY_NumPad6":
                ButtonCommandLogic("star");
                break;
            case "KEY_F12":
                ResetButtonLogic();
                break;
            }
        }
    }

    private void ButtonCommandLogic(object param) {
        switch (param.ToString()) {
        case "led":
            if (LedButtonText == "LED ON (5)") {
                LedButtonText = "LED OFF (5)";
                LedImage = "NULL";
                _isLedOn = false;
            } else {
                LedButtonText = "LED ON (5)";
                LedImage = "../../Resources/comp_wires/led_on.png";
                _isLedOn = true;
            }

            break;
        case "star":
            if (StarButtonText == "Star ON (6)") {
                StarButtonText = "Star OFF (6)";
                StarImage = "NULL";
                _isStarOn = false;
            } else {
                StarButtonText = "Star ON (6)";
                StarImage = "../../Resources/comp_wires/star_on.png";
                _isStarOn = true;
            }

            break;
        case "white":
            WireImage = "../../Resources/comp_wires/wire_whi.png";
            _wireColor = "white";
            break;
        case "blue":
            WireImage = "../../Resources/comp_wires/wire_blu.png";
            _wireColor = "blue";
            break;
        case "red":
            WireImage = "../../Resources/comp_wires/wire_red.png";
            _wireColor = "red";
            break;
        case "bluered":
            WireImage = "../../Resources/comp_wires/wire_blu_red.png";
            _wireColor = "bluered";
            break;
        }

        WireLogic();
    }

    private void WireLogic() {
        Console.WriteLine(@"Wire: {_wireColor}, LED: {_isLedOn}, Star: {_isStarOn}");

        switch (_wireColor) {
        case "white":
            /* LED FALSE, Star FALSE -> Yes */
            if (!_isLedOn && !_isStarOn) {
                BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                OutputText = "Cut";
            }
            /* LED TRUE, Star FALSE -> No */
            else if (_isLedOn && !_isStarOn) {
                BrokenWireImage = "NULL";
                OutputText = "Do Not Cut";
            }
            /* LED FALSE, Star TRUE -> Yes */
            else if (!_isLedOn && _isStarOn) {
                BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                OutputText = "Cut";
            }
            /* LED TRUE, Star TRUE -> Yes if 2+ batteries */
            else if (_isLedOn && _isStarOn) {
                if (ReferenceValues.BatteryNum > 1) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }

            break;

        case "blue":
            /* LED FALSE, Star FALSE -> Yes if even serial */
            if (!_isLedOn && !_isStarOn) {
                if (ReferenceValues.IsSerialEven) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }
            /* LED TRUE, Star FALSE -> Yes if par port */
            else if (_isLedOn && !_isStarOn) {
                if (ReferenceValues.HasParPort) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }
            /* LED FALSE, Star TRUE -> No */
            else if (!_isLedOn && _isStarOn) {
                BrokenWireImage = "NULL";
                OutputText = "Do Not Cut";
            }
            /* LED TRUE, Star TRUE -> Yes if par port */
            else if (_isLedOn && _isStarOn) {
                if (ReferenceValues.HasParPort) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }

            break;

        case "red":
            /* LED FALSE, Star FALSE -> Yes if even serial */
            if (!_isLedOn && !_isStarOn) {
                if (ReferenceValues.IsSerialEven) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }
            /* LED TRUE, Star FALSE -> Yes if 2+ batteries */
            else if (_isLedOn && !_isStarOn) {
                if (ReferenceValues.BatteryNum > 1) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }
            /* LED FALSE, Star TRUE -> Yes*/
            else if (!_isLedOn && _isStarOn) {
                BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                OutputText = "Cut";
            }
            /* LED TRUE, Star TRUE -> Yes if 2+ batteries */
            else if (_isLedOn && _isStarOn) {
                if (ReferenceValues.BatteryNum > 1) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }

            break;

        case "bluered":
            /* LED FALSE, Star FALSE -> Yes if even serial */
            if (!_isLedOn && !_isStarOn) {
                if (ReferenceValues.IsSerialEven) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }
            /* LED TRUE, Star FALSE -> Yes if even serial */
            else if (_isLedOn && !_isStarOn) {
                if (ReferenceValues.IsSerialEven) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }
            /* LED FALSE, Star TRUE -> Yes if par port */
            else if (!_isLedOn && _isStarOn) {
                if (ReferenceValues.HasParPort) {
                    BrokenWireImage = "../../Resources/comp_wires/wire_broken.png";
                    OutputText = "Cut";
                } else {
                    BrokenWireImage = "NULL";
                    OutputText = "Do Not Cut";
                }
            }
            /* LED TRUE, Star TRUE -> No */
            else if (_isLedOn && _isStarOn) {
                BrokenWireImage = "NULL";
                OutputText = "Do Not Cut";
            }

            break;
        }
    }

    private void ResetButtonLogic() {
        _isLedOn = _isStarOn = false;
        LedButtonText = "LED OFF (5)";
        LedImage = "NULL";
        StarButtonText = "Star OFF (5)";
        StarImage = "NULL";

        WireImage = "../../Resources/comp_wires/wire_whi.png";
        _wireColor = "white";
        WireLogic();
    }
}