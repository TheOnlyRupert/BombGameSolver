using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel; 

public class BigButtonModuleVM : BaseViewModel {
    private string _buttonColor, _buttonText, _outputText, _buttonImage;

    public BigButtonModuleVM() {
        ButtonColor = "Red";
        ButtonText = "Hold";
        OutputText = "Immediately";
        ButtonImage = "../../Resources/button/button_Red.png";

        CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
        simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        simpleMessenger.PushMessage("KeyBindings_BigButtonModule", null);
    }

    public string ButtonColor {
        get => _buttonColor;
        set {
            _buttonColor = value;
            ButtonImage = "../../Resources/button/button_" + ButtonColor + ".png";
            RaisePropertyChangedEvent("ButtonColor");
        }
    }

    public string ButtonText {
        get => _buttonText;
        set {
            _buttonText = value;
            RaisePropertyChangedEvent("ButtonText");
        }
    }

    public string OutputText {
        get => _outputText;
        set {
            _outputText = value;
            RaisePropertyChangedEvent("OutputText");
        }
    }

    public string ButtonImage {
        get => _buttonImage;
        set {
            _buttonImage = value;
            RaisePropertyChangedEvent("ButtonImage");
        }
    }

    public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);

    private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
        /* Update button if BatteryAmount, litCAR, or litFRK from SettingsModule are changed */
        if (ReferenceValues.CurrentModule == "../Modules/BigButtonModule.xaml") {
            switch (e.PropertyName) {
            case "BatteryAmountChanged":
            case "LitCarLogic":
            case "LitFrkLogic":
                ButtonLogic("null");
                break;
            case "KEY_NumPad1":
                ButtonLogic("White");
                break;
            case "KEY_NumPad2":
                ButtonLogic("Yellow");
                break;
            case "KEY_NumPad3":
                ButtonLogic("Blue");
                break;
            case "KEY_NumPad4":
                ButtonLogic("Red");
                break;
            case "KEY_NumPad7":
                ButtonLogic("Abort");
                break;
            case "KEY_NumPad8":
                ButtonLogic("Press");
                break;
            case "KEY_NumPad9":
                ButtonLogic("Hold");
                break;
            case "KEY_NumPad0":
                ButtonLogic("Detonate");
                break;
            }
        }
    }

    private void ButtonLogic(object param) {
        switch (param.ToString()) {
        case "White":
        case "Yellow":
        case "Blue":
        case "Red":
            ButtonColor = param.ToString();
            break;
        case "Abort":
        case "Press":
        case "Hold":
        case "Detonate":
            ButtonText = param.ToString();
            break;
        }

        /* Red & Hold -> Immediately */
        if (ButtonColor == "Red" && ButtonText == "Hold") {
            OutputText = "Immediately";
        }
        /* Detonate & 2+ Batteries -> Immediate */
        else if (ButtonText == "Detonate" && ReferenceValues.BatteryNum > 1) {
            OutputText = "Immediately";
        }
        /* Blue & Abort -> Hold */
        else if (ButtonColor == "Blue" && ButtonText == "Abort") {
            OutputText = "Hold";
        }
        /* White & CAR -> Hold */
        else if (ButtonColor == "White" && ReferenceValues.HasLitCar) {
            OutputText = "Hold";
        }
        /* FRK & 3+ Batteries -> Immediately */
        else if (ReferenceValues.HasLitFrk && ReferenceValues.BatteryNum == 3) {
            OutputText = "Immediately";
        }
        /* Else -> Hold */
        else {
            OutputText = "Hold";
        }
    }
}