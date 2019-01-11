using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class SimonSaysModuleVM : BaseViewModel {
        private string _currentStrikes, _blueOutput, _redOutput, _yellowOutput, _greenOutput;

        public SimonSaysModuleVM() {
            CurrentStrikes = "0";
            ButtonCommandLogic(CurrentStrikes);

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
            simpleMessenger.PushMessage("KeyBindings_SimonSaysModule", null);
        }

        public string CurrentStrikes {
            get => _currentStrikes;
            set {
                _currentStrikes = value;
                RaisePropertyChangedEvent("CurrentStrikes");
            }
        }

        public string RedOutput {
            get => _redOutput;
            set {
                _redOutput = value;
                RaisePropertyChangedEvent("RedOutput");
            }
        }

        public string YellowOutput {
            get => _yellowOutput;
            set {
                _yellowOutput = value;
                RaisePropertyChangedEvent("YellowOutput");
            }
        }

        public string GreenOutput {
            get => _greenOutput;
            set {
                _greenOutput = value;
                RaisePropertyChangedEvent("GreenOutput");
            }
        }

        public string BlueOutput {
            get => _blueOutput;
            set {
                _blueOutput = value;
                RaisePropertyChangedEvent("BlueOutput");
            }
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            /* Update view if SerialVowel from SettingsModule is changed */
            if (ReferenceValues.CurrentModule == "../Modules/SimonSaysModule.xaml") {
                switch (e.PropertyName) {
                case "SerialVowelLogic":
                    ButtonCommandLogic(CurrentStrikes);
                    break;
                case "KEY_NumPad1":
                    ButtonCommandLogic("1");
                    break;
                case "KEY_NumPad2":
                    ButtonCommandLogic("2");
                    break;
                case "KEY_NumPad0":
                case "KEY_F12":
                    ButtonCommandLogic("0");
                    break;
                }
            }
        }

        private void ButtonCommandLogic(object param) {
            CurrentStrikes = param.ToString();

            if (ReferenceValues.IsSerialVowel) {
                switch (CurrentStrikes) {
                case "0":
                    YellowOutput = "Green";
                    GreenOutput = "Yellow";
                    BlueOutput = "Red";
                    RedOutput = "Blue";
                    break;
                case "1":
                    YellowOutput = "Red";
                    GreenOutput = "Blue";
                    BlueOutput = "Green";
                    RedOutput = "Yellow";
                    break;
                case "2":
                    YellowOutput = "Blue";
                    GreenOutput = "Yellow";
                    BlueOutput = "Red";
                    RedOutput = "Green";
                    break;
                }
            } else {
                switch (CurrentStrikes) {
                case "0":
                    YellowOutput = "Red";
                    GreenOutput = "Green";
                    BlueOutput = "Yellow";
                    RedOutput = "Blue";
                    break;
                case "1":
                    YellowOutput = "Green";
                    GreenOutput = "Yellow";
                    BlueOutput = "Blue";
                    RedOutput = "Red";
                    break;
                case "2":
                    YellowOutput = "Red";
                    GreenOutput = "Blue";
                    BlueOutput = "Green";
                    RedOutput = "Yellow";
                    break;
                }
            }
        }
    }
}