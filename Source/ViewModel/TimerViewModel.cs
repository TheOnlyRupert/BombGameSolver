using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class TimerViewModel : BaseViewModel {
        private string _lButtonText;
        private string _rButtonText;
        private int _startTime;

        /* Do not assign outside of getter/setter */
        private string _timerDisplay;

        /* 0: Stopped,  1: Running,  2: Paused */
        private int _timerState;

        public TimerViewModel() {
            TimerDisplay = "05:00";
            LButtonText = "Start";
            RButtonText = "Reset";
        }

        public string TimerDisplay {
            get => _timerDisplay;
            set {
                _timerDisplay = value;
                RaisePropertyChangedEvent("TimerDisplay");
            }
        }

        public ICommand AddTimeCommand => new DelegateCommand(AddTime, true);

        public ICommand RemTimeCommand => new DelegateCommand(RemTime, true);

        public ICommand LButtonCommand => new DelegateCommand(LButtonLogic, true);

        public ICommand RButtonCommand => new DelegateCommand(RButtonLogic, true);

        public string LButtonText {
            get => _lButtonText;
            set {
                _lButtonText = value;
                RaisePropertyChangedEvent("LButtonText");
            }
        }

        public string RButtonText {
            get => _rButtonText;
            set {
                _rButtonText = value;
                RaisePropertyChangedEvent("RButtonText");
            }
        }

        private void AddTime(object param) {
            if (_timerState == 0) {
                _startTime = _startTime + 15;
                TimerDisplay = _startTime.ToString();
            }
        }

        private void RemTime(object param) {
            if (_timerState == 0) {
                _startTime = _startTime - 15;
                TimerDisplay = _startTime.ToString();
            }
        }

        private void LButtonLogic(object param) {
            switch (_timerState) {
            case 0:
                _timerState = 1;
                LButtonText = "Stop";
                RButtonText = "Pause";
                TimerDisplay = "RUN";
                break;
            case 1:
            case 2:
                _timerState = 0;
                LButtonText = "Start";
                RButtonText = "Reset";
                TimerDisplay = "STO";
                break;
            }
        }

        private void RButtonLogic(object param) {
            switch (_timerState) {
            case 0:
                TimerDisplay = "05:00";
                break;
            case 1:
                _timerState = 2;
                LButtonText = "Stop";
                RButtonText = "Resume";
                TimerDisplay = "PAU";
                break;
            case 2:
                _timerState = 1;
                LButtonText = "Stop";
                RButtonText = "Pause";
                TimerDisplay = "RUN";
                break;
            }
        }
    }
}