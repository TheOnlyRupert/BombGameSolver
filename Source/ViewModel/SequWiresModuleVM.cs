using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class SequWiresModuleVM : BaseViewModel {
        private string _outputTextBox;

        public string OutputTextBox {
            get => _outputTextBox;
            set {
                _outputTextBox = value;
                RaisePropertyChangedEvent("OutputTextBox");
            }
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

        private void ButtonCommandLogic(object param) {
            OutputTextBox = param.ToString();
        }
    }
}