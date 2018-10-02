using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class ButtonModuleVM : BaseViewModel {
        private string _buttonColor, _buttonText, _outputText, _buttonImage;
        //private readonly CrossViewMessenger _crossViewMessenger;

        public ButtonModuleVM() {
            _buttonColor = "Red";
            _buttonText = "Hold";
            _outputText = "Immediately";
            _buttonImage = "../../Resources/button/button_Red.png";

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
            //_crossViewMessenger = CrossViewMessenger.Instance;
        }

        public string ButtonColor {
            get => _buttonColor;
            set {
                _buttonColor = value;
                ButtonImage = "../../Resources/button/button_" + ButtonColor + ".png";
                RaisePropertyChangedEvent("ButtonColor");
            }
        }

        public string ButtonText {
            get => _buttonText;
            set {
                _buttonText = value;
                RaisePropertyChangedEvent("ButtonText");
            }
        }

        public string OutputText {
            get => _outputText;
            set {
                _outputText = value;
                RaisePropertyChangedEvent("OutputText");
            }
        }

        public string ButtonImage {
            get => _buttonImage;
            set {
                _buttonImage = value;
                RaisePropertyChangedEvent("ButtonImage");
            }
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);


        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            /* Update button if BatteryAmount, litCAR, or litFRK from SettingsModule are changed */
            if (e.PropertyName == "BatteryAmountChanged" || e.PropertyName == "LitCarLogic" ||
                e.PropertyName == "LitFrkLogic") {
                ButtonLogic("null");
            }
        }

        private void ButtonLogic(object param) {
            switch (param.ToString()) {
            case "White":
            case "Yellow":
            case "Blue":
            case "Red":
                ButtonColor = param.ToString();
                break;
            case "Abort":
            case "Press":
            case "Hold":
            case "Detonate":
                ButtonText = param.ToString();
                break;
            }

            /* Red & Hold -> Immediately */
            if (ButtonColor == "Red" && ButtonText == "Hold") {
                //_crossViewMessenger.PushMessage("UpdateDebugTextOutput", "[ButtonModuleVM] Red & Hold -> Immediately");
                OutputText = "Immediately";
            }
            /* Detonate & 2+ Batteries -> Immediate */
            else if (ButtonText == "Detonate" && ReferenceValues.BatteryNum > 1) {
                //_crossViewMessenger.PushMessage("UpdateDebugTextOutput",
                                                //"[ButtonModuleVM] Detonate & 2+ Batteries -> Immediate");
                OutputText = "Immediately";
            }
            /* Blue & Abort -> Hold */
            else if (ButtonColor == "Blue" && ButtonText == "Abort") {
                //_crossViewMessenger.PushMessage("UpdateDebugTextOutput", "[ButtonModuleVM] Blue & Abort -> Hold");
                OutputText = "Hold";
            }
            /* White & CAR -> Hold */
            else if (ButtonColor == "White" && ReferenceValues.HasLitCar) {
                //_crossViewMessenger.PushMessage("UpdateDebugTextOutput", "[ButtonModuleVM] White & CAR -> Hold");
                OutputText = "Hold";
            }
            /* FRK & 3+ Batteries -> Immediately */
            else if (ReferenceValues.HasLitFrk && ReferenceValues.BatteryNum == 3) {
                //_crossViewMessenger.PushMessage("UpdateDebugTextOutput",
                //                                "[ButtonModuleVM] FRK & 3+ Batteries -> Immediately");
                OutputText = "Immediately";
            }
            /* Else -> Hold */
            else {
                //_crossViewMessenger.PushMessage("UpdateDebugTextOutput", "[ButtonModuleVM] Else -> Hold");
                OutputText = "Hold";
            }
        }
    }
}