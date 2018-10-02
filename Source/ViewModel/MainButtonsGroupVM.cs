using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainButtonsGroupVM : BaseViewModel {
        private readonly CrossViewMessenger _crossViewMessenger;

        public MainButtonsGroupVM() {
            _crossViewMessenger = CrossViewMessenger.Instance;
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

        private void ButtonCommandLogic(object param) {
            ReferenceValues.CurrentModule = "../Modules/ModuleSwitcher.xaml";
            _crossViewMessenger.PushMessage("SwitchCurrentModule", null);
            _crossViewMessenger.PushMessage("UpdateDebugTextOutput", "[MainButtonsGroupVM] Module switch to: MainMenu");
        }
    }
}