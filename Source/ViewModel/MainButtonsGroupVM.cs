using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainButtonsGroupVM : BaseViewModel {
        private readonly CrossViewMessenger _crossViewMessenger;
        private string _helpText;

        public MainButtonsGroupVM() {
            _crossViewMessenger = CrossViewMessenger.Instance;
            HelpText = "Global Help";
        }

        public string HelpText {
            get => _helpText;
            set {
                _helpText = value;
                RaisePropertyChangedEvent("HelpText");
            }
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

        private void ButtonCommandLogic(object param) {
            switch (param) {
            case "main":
                /* Just press Tab... nothing else needed */
                _crossViewMessenger.PushMessage("KEY_Tab", null);
                break;

            case "reset":
                /* Just press f12... nothing else needed */
                _crossViewMessenger.PushMessage("KEY_F12", null);
                break;

            /* Get current module and display help for that module only */
            case "help":
                switch (ReferenceValues.CurrentModule) {
                case "../Modules/BigButtonModule.xaml":
                    ReferenceValues.CurrentModule = "../Modules/Help/BigButtonModuleHelp.xaml";
                    _crossViewMessenger.PushMessage("SwitchCurrentModule", null);
                    HelpText = "Back";
                    break;
                case "../Modules/Help/BigButtonModuleHelp.xaml":
                    ReferenceValues.CurrentModule = "../Modules/BigButtonModule.xaml";
                    _crossViewMessenger.PushMessage("SwitchCurrentModule", null);
                    HelpText = "Module Help";
                    break;
                }

                break;
            }
        }
    }
}