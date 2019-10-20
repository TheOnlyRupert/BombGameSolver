using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainDisplayGroupVM : BaseViewModel {
        private readonly CrossViewMessenger _crossViewMessenger;
        private string _currentModule;

        public MainDisplayGroupVM() {
            _crossViewMessenger = CrossViewMessenger.Instance;
            _currentModule = "../Modules/ModuleSwitcher.xaml";

            CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public string CurrentModule {
            get => _currentModule;
            set {
                _currentModule = value;
                ReferenceValues.CurrentModule = value;
                RaisePropertyChangedEvent("CurrentModule");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            /* Switch current module if requested */
            if (e.PropertyName == "SwitchCurrentModule") {
                _crossViewMessenger.PushMessage("AddDebugText", "Switching from " + CurrentModule + @" to " + ReferenceValues.CurrentModule);
                CurrentModule = ReferenceValues.CurrentModule;
            } else if (e.PropertyName == "KEY_F1" && CurrentModule != "../Modules/ModuleSwitcher.xaml") {
                _crossViewMessenger.PushMessage("AddDebugText", "Switching from " + ReferenceValues.CurrentModule + " to " + "../Modules/ModuleSwitcher.xaml");
                CurrentModule = "../Modules/ModuleSwitcher.xaml";
            }
        }
    }
}