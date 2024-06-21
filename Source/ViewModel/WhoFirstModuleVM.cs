using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel;

public class WhoFirstModuleVM : BaseViewModel {
    private string _button_Blank,
        _button_Done,
        _button_First,
        _button_Hold,
        _button_Left,
        _button_Like,
        _button_Middle,
        _button_Next,
        _button_No,
        _button_Nothing,
        _button_Okay,
        _button_Press,
        _button_Ready,
        _button_Right,
        _button_Sure,
        _button_U,
        _button_Ur,
        _button_Uhhh,
        _button_Uh_Uh,
        _button_Uh_Huh,
        _button_Wait,
        _button_What,
        _button_WhatQuestion,
        _button_Yes,
        _button_You,
        _button_Your,
        _button_YoureMarked,
        _button_You_Are;

    private string _outputTextBox, _currentValue;

    public WhoFirstModuleVM() {
        ButtonCommandLogic("blank");
    }

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
            ResetAll();
            OutputTextBox = "WAIT,  RIGHT,  OKAY,  MIDDLE,  BLANK";
            Button_Blank = "True";
            break;
        case "done":
            ResetAll();
            OutputTextBox =
                "SURE,  UH HUH,  NEXT,  WHAT?,  YOUR,  UR,  YOU'RE,  HOLD,  LIKE,  YOU,  U,  YOU ARE,  UH UH,  DONE";
            Button_Done = "True";
            break;
        case "first":
            ResetAll();
            OutputTextBox =
                "LEFT,  OKAY,  YES,  MIDDLE,  NO,  RIGHT,  NOTHING,  UHHH,  WAIT,  READY,  BLANK,  WHAT,  PRESS,  FIRST";
            Button_First = "True";
            break;
        case "hold":
            ResetAll();
            OutputTextBox = "YOU ARE,  U,  DONE,  UH UH,  YOU,  UR,  SURE,  WHAT?  YOU'RE,  NEXT,  HOLD";
            Button_Hold = "True";
            break;
        case "left":
            ResetAll();
            OutputTextBox = "RIGHT,  LEFT";
            Button_Left = "True";
            break;
        case "like":
            ResetAll();
            OutputTextBox = "YOU'RE,  NEXT,  U,  UR,  HOLD,  DONE,  UH UH,  WHAT?,  UH HUH,  YOU,  LIKE";
            Button_Like = "True";
            break;
        case "middle":
            ResetAll();
            OutputTextBox = "BLANK,  READY,  OKAY,  WHAT,  NOTHING,  PRESS,  NO,  WAIT,  LEFT,  MIDDLE";
            Button_Middle = "True";
            break;
        case "next":
            ResetAll();
            OutputTextBox = "WHAT?,  UH HUH,  UH UH,  YOUR,  HOLD,  SURE,  NEXT";
            Button_Next = "True";
            break;
        case "no":
            ResetAll();
            OutputTextBox =
                "BLANK,  UHHH,  WAIT,  FIRST,  WHAT,  READY,  RIGHT,  YES,  NOTHING,  LEFT,  PRESS,  OKAY,  NO";
            Button_No = "True";
            break;
        case "nothing":
            ResetAll();
            OutputTextBox =
                "UHHH,  RIGHT,  OKAY,  MIDDLE,  YES,  BLANK,  NO,  PRESS,  LEFT,  WHAT,  WAIT,  FIRST,  NOTHING";
            Button_Nothing = "True";
            break;
        case "okay":
            ResetAll();
            OutputTextBox = "MIDDLE,  NO,  FIRST,  YES,  UHHH,  NOTHING,  WAIT,  OKAY";
            Button_Okay = "True";
            break;
        case "press":
            ResetAll();
            OutputTextBox = "RIGHT,  MIDDLE,  YES,  READY,  PRESS";
            Button_Press = "True";
            break;
        case "ready":
            ResetAll();
            OutputTextBox = "YES,  OKAY,  WHAT,  MIDDLE,  LEFT,  PRESS,  RIGHT,  BLANK,  READY";
            Button_Ready = "True";
            break;
        case "right":
            ResetAll();
            OutputTextBox = "YES,  NOTHING,  READY,  PRESS,  NO,  WAIT,  WHAT,  RIGHT";
            Button_Right = "True";
            break;
        case "sure":
            ResetAll();
            OutputTextBox = "YOU ARE,  DONE,  LIKE,  YOU'RE,  YOU,  HOLD,  UH HUH,  UR,  SURE";
            Button_Sure = "True";
            break;
        case "u":
            ResetAll();
            OutputTextBox = "UH HUH,  SURE,  NEXT,  WHAT?,  YOU'RE,  UR,  UH UH,  DONE,  U";
            Button_U = "True";
            break;
        case "ur":
            ResetAll();
            OutputTextBox = "DONE,  U,  UR";
            Button_Ur = "True";
            break;
        case "uhhuh":
            ResetAll();
            OutputTextBox = "UH HUH";
            Button_Uh_Huh = "True";
            break;
        case "uhuh":
            ResetAll();
            OutputTextBox = "UR,  U,  YOU ARE,  YOU'RE,  NEXT,  UH UH";
            Button_Uh_Uh = "True";
            break;
        case "uhhh":
            ResetAll();
            OutputTextBox = "READY,  NOTHING,  LEFT,  WHAT,  OKAY,  YES,  RIGHT,  NO,  PRESS,  BLANK,  UHHH";
            Button_Uhhh = "True";
            break;
        case "wait":
            ResetAll();
            OutputTextBox = "UHHH,  NO,  BLANK,  OKAY,  YES,  LEFT,  FIRST,  PRESS,  WHAT,  WAIT";
            Button_Wait = "True";
            break;
        case "what":
            ResetAll();
            OutputTextBox = "UHHH,  WHAT";
            Button_What = "True";
            break;
        case "what?":
            ResetAll();
            OutputTextBox =
                "YOU,  HOLD,  YOU'RE,  YOUR,  U,  DONE,  UH UH,  LIKE,  YOU ARE,  UH HUH,  UR,  NEXT,  WHAT?";
            Button_WhatQuestion = "True";
            break;
        case "yes":
            ResetAll();
            OutputTextBox = "OKAY,  RIGHT,  UHHH,  MIDDLE,  FIRST,  WHAT,  PRESS,  READY,  NOTHING,  YES";
            Button_Yes = "True";
            break;
        case "you":
            ResetAll();
            OutputTextBox = "SURE,  YOU ARE,  YOUR,  YOU'RE,  NEXT,  UH HUH,  UR,  HOLD,  WHAT?,  YOU";
            Button_You = "True";
            break;
        case "youare":
            ResetAll();
            OutputTextBox =
                "YOUR,  NEXT,  LIKE,  UH HUH,  WHAT?,  DONE,  UH UH,  HOLD,  YOU,  U,  YOU'RE,  SURE,  UR,  YOU ARE";
            Button_You_Are = "True";
            break;
        case "you're":
            ResetAll();
            OutputTextBox = "YOU,  YOU'RE";
            Button_YoureMarked = "True";
            break;
        case "your":
            ResetAll();
            OutputTextBox = "UH UH,  YOU ARE,  UH HUH,  YOUR";
            Button_Your = "True";
            break;
        }
    }

    private void ResetAll() {
        Button_Blank = Button_Done = Button_First = Button_Hold = Button_Left = Button_Like = Button_Middle =
            Button_Next = Button_No = Button_Nothing = Button_Okay = Button_Press = Button_Ready = Button_Right =
                Button_Sure = Button_U = Button_Ur = Button_Uhhh = Button_Uh_Uh = Button_Uh_Huh =
                    Button_Wait = Button_What = Button_WhatQuestion = Button_Yes =
                        Button_You = Button_Your = Button_YoureMarked = Button_You_Are = "False";
    }

    #region ButtonTrueFalse

    public string Button_Blank {
        get => _button_Blank;
        set {
            _button_Blank = value;
            RaisePropertyChangedEvent("Button_Blank");
        }
    }

    public string Button_Done {
        get => _button_Done;
        set {
            _button_Done = value;
            RaisePropertyChangedEvent("Button_Done");
        }
    }

    public string Button_First {
        get => _button_First;
        set {
            _button_First = value;
            RaisePropertyChangedEvent("Button_First");
        }
    }

    public string Button_Hold {
        get => _button_Hold;
        set {
            _button_Hold = value;
            RaisePropertyChangedEvent("Button_Hold");
        }
    }

    public string Button_Left {
        get => _button_Left;
        set {
            _button_Left = value;
            RaisePropertyChangedEvent("Button_Left");
        }
    }

    public string Button_Like {
        get => _button_Like;
        set {
            _button_Like = value;
            RaisePropertyChangedEvent("Button_Like");
        }
    }

    public string Button_Middle {
        get => _button_Middle;
        set {
            _button_Middle = value;
            RaisePropertyChangedEvent("Button_Middle");
        }
    }

    public string Button_Next {
        get => _button_Next;
        set {
            _button_Next = value;
            RaisePropertyChangedEvent("Button_Next");
        }
    }

    public string Button_No {
        get => _button_No;
        set {
            _button_No = value;
            RaisePropertyChangedEvent("Button_No");
        }
    }

    public string Button_Nothing {
        get => _button_Nothing;
        set {
            _button_Nothing = value;
            RaisePropertyChangedEvent("Button_Nothing");
        }
    }

    public string Button_Okay {
        get => _button_Okay;
        set {
            _button_Okay = value;
            RaisePropertyChangedEvent("Button_Okay");
        }
    }

    public string Button_Press {
        get => _button_Press;
        set {
            _button_Press = value;
            RaisePropertyChangedEvent("Button_Press");
        }
    }

    public string Button_Ready {
        get => _button_Ready;
        set {
            _button_Ready = value;
            RaisePropertyChangedEvent("Button_Ready");
        }
    }

    public string Button_Right {
        get => _button_Right;
        set {
            _button_Right = value;
            RaisePropertyChangedEvent("Button_Right");
        }
    }

    public string Button_Sure {
        get => _button_Sure;
        set {
            _button_Sure = value;
            RaisePropertyChangedEvent("Button_Sure");
        }
    }

    public string Button_U {
        get => _button_U;
        set {
            _button_U = value;
            RaisePropertyChangedEvent("Button_U");
        }
    }

    public string Button_Ur {
        get => _button_Ur;
        set {
            _button_Ur = value;
            RaisePropertyChangedEvent("Button_Ur");
        }
    }

    public string Button_Uhhh {
        get => _button_Uhhh;
        set {
            _button_Uhhh = value;
            RaisePropertyChangedEvent("Button_Uhhh");
        }
    }

    public string Button_Uh_Uh {
        get => _button_Uh_Uh;
        set {
            _button_Uh_Uh = value;
            RaisePropertyChangedEvent("Button_Uh_Uh");
        }
    }

    public string Button_Uh_Huh {
        get => _button_Uh_Huh;
        set {
            _button_Uh_Huh = value;
            RaisePropertyChangedEvent("Button_Uh_Huh");
        }
    }

    public string Button_Wait {
        get => _button_Wait;
        set {
            _button_Wait = value;
            RaisePropertyChangedEvent("Button_Wait");
        }
    }

    public string Button_What {
        get => _button_What;
        set {
            _button_What = value;
            RaisePropertyChangedEvent("Button_What");
        }
    }

    public string Button_WhatQuestion {
        get => _button_WhatQuestion;
        set {
            _button_WhatQuestion = value;
            RaisePropertyChangedEvent("Button_WhatQuestion");
        }
    }

    public string Button_Yes {
        get => _button_Yes;
        set {
            _button_Yes = value;
            RaisePropertyChangedEvent("Button_Yes");
        }
    }

    public string Button_You {
        get => _button_You;
        set {
            _button_You = value;
            RaisePropertyChangedEvent("Button_You");
        }
    }

    public string Button_Your {
        get => _button_Your;
        set {
            _button_Your = value;
            RaisePropertyChangedEvent("Button_Your");
        }
    }

    public string Button_YoureMarked {
        get => _button_YoureMarked;
        set {
            _button_YoureMarked = value;
            RaisePropertyChangedEvent("Button_YoureMarked");
        }
    }

    public string Button_You_Are {
        get => _button_You_Are;
        set {
            _button_You_Are = value;
            RaisePropertyChangedEvent("Button_You_Are");
        }
    }

    #endregion
}