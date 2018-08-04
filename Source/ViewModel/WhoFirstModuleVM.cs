using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class WhoFirstModuleVM : BaseViewModel {
        private string _outputTextBox, _currentValue;

        public string OutputTextBox {
            get => _outputTextBox;
            set {
                _outputTextBox = value;
                RaisePropertyChangedEvent("OutputTextBox");
            }
        }

        public string CurrentValue {
            get => _currentValue;
            set {
                _currentValue = value;
                RaisePropertyChangedEvent("CurrentValue");
            }
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

        private void ButtonCommandLogic(object param) {
            CurrentValue = param.ToString();

            switch (CurrentValue) {
            case "blank":
                OutputTextBox = "WAIT,  RIGHT,  OKAY,  MIDDLE,  BLANK";
                break;
            case "done":
                OutputTextBox =
                    "SURE,  UH HUH,  NEXT,  WHAT?,  YOUR,  UR,  YOU'RE,  HOLD,  LIKE,  YOU,  U,  YOU ARE,  UH UH,  DONE";
                break;
            case "first":
                OutputTextBox =
                    "LEFT,  OKAY,  YES,  MIDDLE,  NO,  RIGHT,  NOTHING,  UHHH,  WAIT,  READY,  BLANK,  WHAT,  PRESS,  FIRST";
                break;
            case "hold":
                OutputTextBox = "YOU ARE,  U,  DONE,  UH UH,  YOU,  UR,  SURE,  WHAT?  YOU'RE,  NEXT,  HOLD";
                break;
            case "left":
                OutputTextBox = "RIGHT,  LEFT";
                break;
            case "like":
                OutputTextBox = "YOU'RE,  NEXT,  U,  UR,  HOLD,  DONE,  UH UH,  WHAT?,  UH HUH,  YOU,  LIKE";
                break;
            case "middle":
                OutputTextBox = "BLANK,  READY,  OKAY,  WHAT,  NOTHING,  PRESS,  NO,  WAIT,  LEFT,  MIDDLE";
                break;
            case "next":
                OutputTextBox = "WHAT?,  UH HUH,  UH UH,  YOUR,  HOLD,  SURE,  NEXT";
                break;
            case "no":
                OutputTextBox =
                    "BLANK,  UHHH,  WAIT,  FIRST,  WHAT,  READY,  RIGHT,  YES,  NOTHING,  LEFT,  PRESS,  OKAY,  NO";
                break;
            case "nothing":
                OutputTextBox =
                    "UHHH,  RIGHT,  OKAY,  MIDDLE,  YES,  BLANK,  NO,  PRESS,  LEFT,  WHAT,  WAIT,  FIRST,  NOTHING";
                break;
            case "okay":
                OutputTextBox = "MIDDLE,  NO,  FIRST,  YES,  UHHH,  NOTHING,  WAIT,  OKAY";
                break;
            case "press":
                OutputTextBox = "RIGHT,  MIDDLE,  YES,  READY,  PRESS";
                break;
            case "ready":
                OutputTextBox = "YES,  OKAY,  WHAT,  MIDDLE,  LEFT,  PRESS,  RIGHT,  BLANK,  READY";
                break;
            case "right":
                OutputTextBox = "YES,  NOTHING,  READY,  PRESS,  NO,  WAIT,  WHAT,  RIGHT";
                break;
            case "sure":
                OutputTextBox = "YOU ARE,  DONE,  LIKE,  YOU'RE,  YOU,  HOLD,  UH HUH,  UR,  SURE";
                break;
            case "u":
                OutputTextBox = "UH HUH,  SURE,  NEXT,  WHAT?,  YOU'RE,  UR,  UH UH,  DONE,  U";
                break;
            case "ur":
                OutputTextBox = "DONE,  U,  UR";
                break;
            case "uhhuh":
                OutputTextBox = "UH HUH";
                break;
            case "uhuh":
                OutputTextBox = "UR,  U,  YOU ARE,  YOU'RE,  NEXT,  UH UH";
                break;
            case "uhhh":
                OutputTextBox = "READY,  NOTHING,  LEFT,  WHAT,  OKAY,  YES,  RIGHT,  NO,  PRESS,  BLANK,  UHHH";
                break;
            case "wait":
                OutputTextBox = "UHHH,  NO,  BLANK,  OKAY,  YES,  LEFT,  FIRST,  PRESS,  WHAT,  WAIT";
                break;
            case "what":
                OutputTextBox = "UHHH,  WHAT";
                break;
            case "what?":
                OutputTextBox =
                    "YOU,  HOLD,  YOU'RE,  YOUR,  U,  DONE,  UH UH,  LIKE,  YOU ARE,  UH HUH,  UR,  NEXT,  WHAT?";
                break;
            case "yes":
                OutputTextBox = "OKAY,  RIGHT,  UHHH,  MIDDLE,  FIRST,  WHAT,  PRESS,  READY,  NOTHING,  YES";
                break;
            case "you":
                OutputTextBox = "SURE,  YOU ARE,  YOUR,  YOU'RE,  NEXT,  UH HUH,  UR,  HOLD,  WHAT?,  YOU";
                break;
            case "youare":
                OutputTextBox =
                    "YOUR,  NEXT,  LIKE,  UH HUH,  WHAT?,  DONE,  UH UH,  HOLD,  YOU,  U,  YOU'RE,  SURE,  UR,  YOU ARE";
                break;
            case "you're":
                OutputTextBox = "YOU,  YOU'RE";
                break;
            case "your":
                OutputTextBox = "UH UH,  YOU ARE,  UH HUH,  YOUR";
                break;
            }
        }
    }
}