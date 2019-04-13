using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainDebugGroupVM : BaseViewModel {
        private string _debugTextOutput, _caretIndexPos;

        public MainDebugGroupVM() {
            DebugTextOutput = ReferenceValues.COPYRIGHT + "\n\n";

            CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public string DebugTextOutput {
            get => _debugTextOutput;
            set {
                _debugTextOutput = value;
                RaisePropertyChangedEvent("DebugTextOutput");
            }
        }

        public string CaretIndexPos {
            get => _caretIndexPos;
            set {
                _caretIndexPos = value;
                RaisePropertyChangedEvent("DebugTextOutput");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (e.PropertyName == "UpdateDebugTextOutput") {
                DebugTextOutput = DebugTextOutput + "\n" + e.Value;
                CaretIndexPos = DebugTextOutput.Length.ToString();
            }
        }
    }
}