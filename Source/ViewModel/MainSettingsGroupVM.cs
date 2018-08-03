using System;
using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainSettingsGroupVM : BaseViewModel {
        private readonly CrossViewMessenger _crossViewMessenger;
        private bool _isDevEnabled;

        private string _serialVowelButtonText,
            _serialEvenButtonText,
            _litCarButtonText,
            _litFrkButtonText,
            _parPortButtonText;

        public MainSettingsGroupVM() {
            SerialVowelButtonText = "False";
            SerialEvenButtonText = "False";
            LitCarButtonText = "False";
            LitFrkButtonText = "False";
            ParPortButtonText = "False";

            _crossViewMessenger = CrossViewMessenger.Instance;
        }

#region SerialVowel

        public string SerialVowelButtonText {
            get => _serialVowelButtonText;
            set {
                _serialVowelButtonText = value;
                RaisePropertyChangedEvent("SerialVowelButtonText");
            }
        }

        public ICommand SerialVowelButtonCommand => new DelegateCommand(SerialVowelLogic, true);

        private void SerialVowelLogic(object param) {
            ReferenceValues.IsSerialVowel = !ReferenceValues.IsSerialVowel;

            SerialVowelButtonText = ReferenceValues.IsSerialVowel ? "True" : "False";
        }

#endregion

#region SerialEven

        public string SerialEvenButtonText {
            get => _serialEvenButtonText;
            set {
                _serialEvenButtonText = value;
                RaisePropertyChangedEvent("SerialEvenButtonText");
            }
        }

        public ICommand SerialEvenButtonCommand => new DelegateCommand(SerialEvenLogic, true);

        private void SerialEvenLogic(object param) {
            ReferenceValues.IsSerialEven = !ReferenceValues.IsSerialEven;

            SerialEvenButtonText = ReferenceValues.IsSerialEven ? "True" : "False";
        }

#endregion

#region LitCAR

        public string LitCarButtonText {
            get => _litCarButtonText;
            set {
                _litCarButtonText = value;
                RaisePropertyChangedEvent("LitCarButtonText");
            }
        }

        public ICommand LitCarButtonCommand => new DelegateCommand(LitCarLogic, true);

        private void LitCarLogic(object param) {
            ReferenceValues.HasLitCar = !ReferenceValues.HasLitCar;

            LitCarButtonText = ReferenceValues.HasLitCar ? "True" : "False";
            _crossViewMessenger.PushMessage("LitCarButtonText", null);
        }

#endregion

#region LitFRK

        public string LitFrkButtonText {
            get => _litFrkButtonText;
            set {
                _litFrkButtonText = value;
                RaisePropertyChangedEvent("LitFrkButtonText");
            }
        }

        public ICommand LitFrkButtonCommand => new DelegateCommand(LitFrkLogic, true);

        private void LitFrkLogic(object param) {
            ReferenceValues.HasLitFrk = !ReferenceValues.HasLitFrk;

            LitFrkButtonText = ReferenceValues.HasLitFrk ? "True" : "False";
            _crossViewMessenger.PushMessage("LitFrkButtonText", null);
        }

#endregion

#region ParallelPort

        public string ParPortButtonText {
            get => _parPortButtonText;
            set {
                _parPortButtonText = value;
                RaisePropertyChangedEvent("ParPortButtonText");
            }
        }

        public ICommand ParPortButtonCommand => new DelegateCommand(ParPortLogic, true);

        private void ParPortLogic(object param) {
            ReferenceValues.HasParPort = !ReferenceValues.HasParPort;

            ParPortButtonText = ReferenceValues.HasParPort ? "True" : "False";
        }

#endregion

#region ResetButton

        public ICommand ResetButtonCommand => new DelegateCommand(ResetButtonLogic, true);

        private void ResetButtonLogic(object param) {
            ReferenceValues.IsSerialVowel = ReferenceValues.IsSerialEven = ReferenceValues.HasLitCar =
                ReferenceValues.HasLitFrk = ReferenceValues.HasParPort = false;
            SerialVowelButtonText = SerialEvenButtonText = LitCarButtonText = LitFrkButtonText =
                ParPortButtonText = "False";
            BatteryAmountChanged = "0";
        }

#endregion

#region DevButton

        public ICommand DevButtonCommand => new DelegateCommand(DevButtonLogic, true);

        private void DevButtonLogic(object param) {
            _isDevEnabled = !_isDevEnabled;
            ReferenceValues.IsDebugEnabled = _isDevEnabled;
            _crossViewMessenger.PushMessage("DevButtonLogic", null);
        }

#endregion

#region Battery

        public ICommand BatteryCommand => new DelegateCommand(BatteryLogic, true);

        private void BatteryLogic(object param) {
            BatteryAmountChanged = param.ToString();
        }

        public string BatteryAmountChanged {
            get => ReferenceValues.BatteryNum.ToString();
            set {
                try {
                    ReferenceValues.BatteryNum = int.Parse(value);
                } catch (Exception) {
                    ReferenceValues.BatteryNum = 0;
                }

                _crossViewMessenger.PushMessage("BatteryAmountChanged", null);
                RaisePropertyChangedEvent("BatteryAmountChanged");
            }
        }

#endregion
    }
}