using System;
using System.Windows.Input;
using BombGameSolver.Source.Logic;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class SettingsViewModel : BaseViewModel {
        private string _serialVowelButtonText,
            _serialEvenButtonText,
            _litCarButtonText,
            _litFrkButtonText,
            _parPortButtonText;

        public SettingsViewModel() {
            SerialVowelButtonText = "False";
            SerialEvenButtonText = "False";
            LitCarButtonText = "False";
            LitFrkButtonText = "False";
            ParPortButtonText = "False";
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
            SettingsLogic.IsSerialVowel = !SettingsLogic.IsSerialVowel;

            SerialVowelButtonText = SettingsLogic.IsSerialVowel ? "True" : "False";
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
            SettingsLogic.IsSerialEven = !SettingsLogic.IsSerialEven;

            SerialEvenButtonText = SettingsLogic.IsSerialEven ? "True" : "False";
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
            SettingsLogic.HasLitCar = !SettingsLogic.HasLitCar;

            LitCarButtonText = SettingsLogic.HasLitCar ? "True" : "False";
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
            SettingsLogic.HasLitFrk = !SettingsLogic.HasLitFrk;

            LitFrkButtonText = SettingsLogic.HasLitFrk ? "True" : "False";
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
            SettingsLogic.HasParPort = !SettingsLogic.HasParPort;

            ParPortButtonText = SettingsLogic.HasParPort ? "True" : "False";
        }

#endregion

#region ResetButton

        public ICommand ResetButtonCommand => new DelegateCommand(ResetButtonLogic, true);

        private void ResetButtonLogic(object param) {
            SettingsLogic.IsSerialVowel = SettingsLogic.IsSerialEven = SettingsLogic.HasLitCar =
                SettingsLogic.HasLitFrk = SettingsLogic.HasParPort = false;
            SerialVowelButtonText = SerialEvenButtonText = LitCarButtonText = LitFrkButtonText =
                ParPortButtonText = "False";
            BatteryAmountChanged = "0";
        }

#endregion

#region DevButton

        public ICommand DevButtonCommand => new DelegateCommand(DevButtonLogic, true);

        private void DevButtonLogic(object param) { }

#endregion

#region Battery

        public ICommand BatteryCommand => new DelegateCommand(BatteryLogic, true);

        private void BatteryLogic(object param) {
             BatteryAmountChanged = param.ToString();
        }

        public string BatteryAmountChanged {
            get => SettingsLogic.BatteryNum.ToString();
            set {
                try {
                    SettingsLogic.BatteryNum = int.Parse(value);
                } catch (Exception) {
                    SettingsLogic.BatteryNum = 0;
                }
                RaisePropertyChangedEvent("BatteryAmountChanged");
            }
        }

#endregion
    }
}