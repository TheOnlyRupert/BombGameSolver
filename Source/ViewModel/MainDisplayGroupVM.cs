using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainDisplayGroupVM : BaseViewModel {
        private string _currentModule;

        public MainDisplayGroupVM() {
            _currentModule = "../Modules/ModuleSwitcher.xaml";

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public string CurrentModule {
            get => _currentModule;
            set {
                _currentModule = value;
                RaisePropertyChangedEvent("CurrentModule");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            /* Switch current module if requested */
            if (e.PropertyName == "SwitchCurrentModule") {
                CurrentModule = ReferenceValues.CurrentModule;
            }
        }
    }
}