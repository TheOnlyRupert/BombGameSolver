using System.Collections.Generic;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainDebugGroupVM : BaseViewModel {
        private string _debugTextOutput, _caretIndexPos;
        private List<string> TextList = new List<string>();

        public MainDebugGroupVM() {
            //TextList.Add(ReferenceValues.COPYRIGHT);
            DebugTextOutput = ReferenceValues.COPYRIGHT + ",  v" + ReferenceValues.VERSION + "\n\n";

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
            //TODO: This is way too slow...
            if (e.PropertyName == "AddDebugText") {
                /*
                TextList.Add("[INFO] " + DateTime.Now.ToString("HH:mm:ss") + "] " + e.Value);

                foreach (string line in TextList) {
                    DebugTextOutput += line + "\n";
                }

                CaretIndexPos = DebugTextOutput.Length.ToString();
                */
            }
        }
    }
}