using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainWindowVM : BaseViewModel {
        private string _iconImage, _devLogWindowHeight;

        public MainWindowVM() {
            IconImage = "Resources/icons/nuke.png";
            DevLogWindowHeight = "0";

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public string IconImage {
            get => _iconImage;
            set {
                _iconImage = value;
                RaisePropertyChangedEvent("IconImage");
            }
        }

        public string DevLogWindowHeight {
            get => _devLogWindowHeight;
            set {
                _devLogWindowHeight = value;
                RaisePropertyChangedEvent("DevLogWindowHeight");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            /* Switch current module if requested */
            if (e.PropertyName == "DevButtonLogic") {
                if (ReferenceValues.IsDebugEnabled) {
                    DevLogWindowHeight = "200";
                } else {
                    DevLogWindowHeight = "0";
                }
            }
        }
    }
}