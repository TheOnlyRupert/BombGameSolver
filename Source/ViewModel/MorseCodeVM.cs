using System;
using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MorseCodeVM : BaseViewModel {
        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);

        private void ButtonLogic(object param) {
            Console.WriteLine(param);
        }
    }
}