using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel; 

public class SimonSaysModuleVM : BaseViewModel {
    private string _currentStrikes,
        _currentViewType,
        _bluOutput,
        _redOutput,
        _yelOutput,
        _greOutput,
        _text_bluOutput,
        _text_redOutput,
        _text_yelOutput,
        _text_greOutput,
        _backgroundType;

    public SimonSaysModuleVM() {
        CurrentStrikes = "strike_0";
        CurrentViewType = "view_0";
        ButtonCommandLogic(CurrentStrikes);

        CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
        simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        simpleMessenger.PushMessage("KeyBindings_SimonSaysModule", null);
    }

    public string CurrentStrikes {
        get => _currentStrikes;
        set {
            _currentStrikes = value;
            RaisePropertyChangedEvent("CurrentStrikes");
        }
    }

    public string CurrentViewType {
        get => _currentViewType;
        set {
            _currentViewType = value;
            RaisePropertyChangedEvent("CurrentViewType");
        }
    }

    public string BackgroundType {
        get => _backgroundType;
        set {
            _backgroundType = value;
            RaisePropertyChangedEvent("BackgroundType");
        }
    }

    public string RedOutput {
        get => _redOutput;
        set {
            _redOutput = value;
            RaisePropertyChangedEvent("RedOutput");
        }
    }

    public string YelOutput {
        get => _yelOutput;
        set {
            _yelOutput = value;
            RaisePropertyChangedEvent("YelOutput");
        }
    }

    public string GreOutput {
        get => _greOutput;
        set {
            _greOutput = value;
            RaisePropertyChangedEvent("GreOutput");
        }
    }

    public string BluOutput {
        get => _bluOutput;
        set {
            _bluOutput = value;
            RaisePropertyChangedEvent("BluOutput");
        }
    }

    public string TextRedOutput {
        get => _text_redOutput;
        set {
            _text_redOutput = value;
            RaisePropertyChangedEvent("TextRedOutput");
        }
    }

    public string TextYelOutput {
        get => _text_yelOutput;
        set {
            _text_yelOutput = value;
            RaisePropertyChangedEvent("TextYelOutput");
        }
    }

    public string TextGreOutput {
        get => _text_greOutput;
        set {
            _text_greOutput = value;
            RaisePropertyChangedEvent("TextGreOutput");
        }
    }

    public string TextBluOutput {
        get => _text_bluOutput;
        set {
            _text_bluOutput = value;
            RaisePropertyChangedEvent("TextBluOutput");
        }
    }

    public ICommand ButtonCommand => new DelegateCommand(ButtonCommandLogic, true);

    private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
        /* Update view if SerialVowel from SettingsModule is changed */
        if (ReferenceValues.CurrentModule == "../Modules/SimonSaysModule.xaml") {
            switch (e.PropertyName) {
            case "SerialVowelLogic":
                ButtonCommandLogic(CurrentStrikes);
                break;
            case "KEY_NumPad1":
                ButtonCommandLogic("strike_1");
                break;
            case "KEY_NumPad2":
                ButtonCommandLogic("strike_2");
                break;
            case "KEY_NumPad0":
            case "KEY_F12":
                ButtonCommandLogic("strike_0");
                break;
            }
        }
    }

    private void ButtonCommandLogic(object param) {
        if (param.ToString() == "strike_0" || param.ToString() == "strike_1" || param.ToString() == "strike_2") {
            CurrentStrikes = param.ToString();
        } else {
            CurrentViewType = param.ToString();
        }

        /* Colored ViewType */
        switch (CurrentViewType) {
        case "view_0":
            BackgroundType = "../../Resources/simon_says/background_color.png";

            switch (CurrentStrikes) {
            case "strike_0":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/yel_to_gre.png";
                    GreOutput = "../../Resources/simon_says/gre_to_yel.png";
                    BluOutput = "../../Resources/simon_says/blu_to_red.png";
                    RedOutput = "../../Resources/simon_says/red_to_blu.png";

                    TextYelOutput = "../../Resources/simon_says/text_yel_to_gre.png";
                    TextGreOutput = "../../Resources/simon_says/text_gre_to_yel.png";
                    TextBluOutput = "../../Resources/simon_says/text_blu_to_red.png";
                    TextRedOutput = "../../Resources/simon_says/text_red_to_blu.png";
                } else {
                    YelOutput = "../../Resources/simon_says/yel_to_red.png";
                    GreOutput = "NULL";
                    BluOutput = "../../Resources/simon_says/blu_to_yel.png";
                    RedOutput = "../../Resources/simon_says/red_to_blu.png";

                    TextYelOutput = "../../Resources/simon_says/text_yel_to_red.png";
                    TextGreOutput = "NULL";
                    TextBluOutput = "../../Resources/simon_says/text_blu_to_yel.png";
                    TextRedOutput = "../../Resources/simon_says/text_red_to_blu.png";
                }

                break;
            case "strike_1":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/yel_to_red.png";
                    GreOutput = "../../Resources/simon_says/gre_to_blu.png";
                    BluOutput = "../../Resources/simon_says/blu_to_gre.png";
                    RedOutput = "../../Resources/simon_says/red_to_yel.png";

                    TextYelOutput = "../../Resources/simon_says/text_yel_to_red.png";
                    TextGreOutput = "../../Resources/simon_says/text_gre_to_blu.png";
                    TextBluOutput = "../../Resources/simon_says/text_blu_to_gre.png";
                    TextRedOutput = "../../Resources/simon_says/text_red_to_yel.png";
                } else {
                    YelOutput = "../../Resources/simon_says/yel_to_gre.png";
                    GreOutput = "../../Resources/simon_says/gre_to_yel.png";
                    BluOutput = "NULL";
                    RedOutput = "NULL";

                    TextYelOutput = "../../Resources/simon_says/text_yel_to_gre.png";
                    TextGreOutput = "../../Resources/simon_says/text_gre_to_yel.png";
                    TextBluOutput = "NULL";
                    TextRedOutput = "NULL";
                }

                break;
            case "strike_2":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/yel_to_blu.png";
                    GreOutput = "../../Resources/simon_says/gre_to_yel.png";
                    BluOutput = "../../Resources/simon_says/blu_to_red.png";
                    RedOutput = "../../Resources/simon_says/red_to_gre.png";

                    TextYelOutput = "../../Resources/simon_says/text_yel_to_blu.png";
                    TextGreOutput = "../../Resources/simon_says/text_gre_to_yel.png";
                    TextBluOutput = "../../Resources/simon_says/text_blu_to_red.png";
                    TextRedOutput = "../../Resources/simon_says/text_red_to_gre.png";
                } else {
                    YelOutput = "../../Resources/simon_says/yel_to_red.png";
                    GreOutput = "../../Resources/simon_says/gre_to_blu.png";
                    BluOutput = "../../Resources/simon_says/blu_to_gre.png";
                    RedOutput = "../../Resources/simon_says/red_to_yel.png";

                    TextYelOutput = "../../Resources/simon_says/text_yel_to_red.png";
                    TextGreOutput = "../../Resources/simon_says/text_gre_to_blu.png";
                    TextBluOutput = "../../Resources/simon_says/text_blu_to_gre.png";
                    TextRedOutput = "../../Resources/simon_says/text_red_to_yel.png";
                }

                break;
            }

            break;

        /* Up, Down, Left, Right ViewType */
        case "view_1":
            BackgroundType = "../../Resources/simon_says/background_directions.png";
            TextYelOutput = "NULL";
            TextGreOutput = "NULL";
            TextBluOutput = "NULL";
            TextRedOutput = "NULL";

            switch (CurrentStrikes) {
            case "strike_0":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/rig_to_dow.png";
                    GreOutput = "../../Resources/simon_says/dow_to_rig.png";
                    BluOutput = "../../Resources/simon_says/up_to_lef.png";
                    RedOutput = "../../Resources/simon_says/lef_to_up.png";
                } else {
                    YelOutput = "../../Resources/simon_says/rig_to_lef.png";
                    GreOutput = "NULL";
                    BluOutput = "../../Resources/simon_says/up_to_rig.png";
                    RedOutput = "../../Resources/simon_says/lef_to_up.png";
                }

                break;
            case "strike_1":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/rig_to_lef.png";
                    GreOutput = "../../Resources/simon_says/dow_to_up.png";
                    BluOutput = "../../Resources/simon_says/up_to_dow.png";
                    RedOutput = "../../Resources/simon_says/lef_to_rig.png";
                } else {
                    YelOutput = "../../Resources/simon_says/rig_to_dow.png";
                    GreOutput = "../../Resources/simon_says/dow_to_rig.png";
                    BluOutput = "NULL";
                    RedOutput = "NULL";
                }

                break;
            case "strike_2":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/rig_to_up.png";
                    GreOutput = "../../Resources/simon_says/dow_to_lef.png";
                    BluOutput = "../../Resources/simon_says/up_to_lef.png";
                    RedOutput = "../../Resources/simon_says/lef_to_dow.png";
                } else {
                    YelOutput = "../../Resources/simon_says/rig_to_lef.png";
                    GreOutput = "../../Resources/simon_says/dow_to_up.png";
                    BluOutput = "../../Resources/simon_says/up_to_dow.png";
                    RedOutput = "../../Resources/simon_says/lef_to_rig.png";
                }

                break;
            }

            break;

        /* North, South, East, and West ViewType */
        case "view_2":
            BackgroundType = "../../Resources/simon_says/background_nsew.png";
            TextYelOutput = "NULL";
            TextGreOutput = "NULL";
            TextBluOutput = "NULL";
            TextRedOutput = "NULL";

            switch (CurrentStrikes) {
            case "strike_0":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/eas_to_sou.png";
                    GreOutput = "../../Resources/simon_says/sou_to_eas.png";
                    BluOutput = "../../Resources/simon_says/nor_to_wes.png";
                    RedOutput = "../../Resources/simon_says/wes_to_nor.png";
                } else {
                    YelOutput = "../../Resources/simon_says/eas_to_wes.png";
                    GreOutput = "NULL";
                    BluOutput = "../../Resources/simon_says/nor_to_eas.png";
                    RedOutput = "../../Resources/simon_says/wes_to_nor.png";
                }

                break;
            case "strike_1":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/eas_to_wes.png";
                    GreOutput = "../../Resources/simon_says/sou_to_nor.png";
                    BluOutput = "../../Resources/simon_says/nor_to_sou.png";
                    RedOutput = "../../Resources/simon_says/wes_to_eas.png";
                } else {
                    YelOutput = "../../Resources/simon_says/eas_to_sou.png";
                    GreOutput = "../../Resources/simon_says/sou_to_eas.png";
                    BluOutput = "NULL";
                    RedOutput = "NULL";
                }

                break;
            case "strike_2":
                if (ReferenceValues.IsSerialVowel) {
                    YelOutput = "../../Resources/simon_says/eas_to_nor.png";
                    GreOutput = "../../Resources/simon_says/sou_to_eas.png";
                    BluOutput = "../../Resources/simon_says/nor_to_wes.png";
                    RedOutput = "../../Resources/simon_says/wes_to_sou.png";
                } else {
                    YelOutput = "../../Resources/simon_says/eas_to_wes.png";
                    GreOutput = "../../Resources/simon_says/sou_to_nor.png";
                    BluOutput = "../../Resources/simon_says/nor_to_sou.png";
                    RedOutput = "../../Resources/simon_says/wes_to_eas.png";
                }

                break;
            }

            break;
        }
    }
}