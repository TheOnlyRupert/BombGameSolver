using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class ModuleSwitcherVM : BaseViewModel {
        private readonly CrossViewMessenger _crossViewMessenger;

        public ModuleSwitcherVM() {
            _crossViewMessenger = CrossViewMessenger.Instance;
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

        private void ButtonCommandLogic(object param) {
            ReferenceValues.CurrentModule = "../Modules/" + param + ".xaml";
            _crossViewMessenger.PushMessage("SwitchCurrentModule", null);
        }
    }
}