using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainDebugGroupVM : BaseViewModel {
        private string _debugTextOutput;

        public MainDebugGroupVM() {
            DebugTextOutput = "Copyright © 2018 Robert Higgins\n\n\n";

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public string DebugTextOutput {
            get => _debugTextOutput;
            set {
                _debugTextOutput = value;
                RaisePropertyChangedEvent("DebugTextOutput");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (e.PropertyName == "UpdateDebugTextOutput") {
                DebugTextOutput = DebugTextOutput + e.Value;
            }
        }
    }
}