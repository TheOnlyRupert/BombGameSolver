using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel;

public class PasswordsModuleVM : BaseViewModel {
    private static readonly string[] PasswordMasterList = {
        "about", "after", "again", "below", "could", "every", "first", "found", "great", "house", "large", "learn",
        "never", "other", "place", "plant", "point", "right", "small", "sound", "spell", "still", "study", "their",
        "there", "these", "thing", "think", "three", "water", "where", "which", "world", "would", "write"
    };

    private string _inputColumn0, _inputColumn1, _inputColumn2, _output;

    private string inputValues0 = "";
    private string inputValues1 = "";
    private string inputValues2 = "";
    private List<string> outputList0 = new();
    private List<string> outputList1 = new();
    private List<string> outputList2 = new();

    public PasswordsModuleVM() {
        CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
        simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        //TODO: SET COMMANDS
        simpleMessenger.PushMessage("KeyBindings_PasswordsModule", null);
    }

    public string InputColumn0 {
        get => _inputColumn0;
        set {
            _inputColumn0 = VerifyData(value, 0);
            outputList0 = new List<string>();
            SetOutput(0);
            RaisePropertyChangedEvent("InputColumn0");
        }
    }

    public string InputColumn1 {
        get => _inputColumn1;
        set {
            _inputColumn1 = VerifyData(value, 1);
            outputList1 = new List<string>();
            SetOutput(1);
            RaisePropertyChangedEvent("InputColumn1");
        }
    }

    public string InputColumn2 {
        get => _inputColumn2;
        set {
            _inputColumn2 = VerifyData(value, 2);
            outputList2 = new List<string>();
            SetOutput(2);
            RaisePropertyChangedEvent("InputColumn2");
        }
    }

    public string Output {
        get => _output;
        set {
            _output = value;
            RaisePropertyChangedEvent("Output");
        }
    }

    private string VerifyData(string value, int arrayID) {
        if (value.Length < 1) {
            return "";
        }

        const string pattern = @"^[a-z]+$";
        Regex regex = new(pattern);
        value = value.ToLower();

        /* If formatted wrong */
        if (!regex.IsMatch(value)) {
            value = value.Remove(value.Length - 1);
        }

        /* If dupe number */
        if (value.Length > 1) {
            string value2 = value;
            char lastIndex = value[value.Length - 1];
            value = value.Remove(value.Length - 1);

            if (!value.Contains(lastIndex)) {
                value = value2;
            }
        }

        /* Add to its respective array slot */
        switch (arrayID) {
        case 0:
            return inputValues0 = value;
        case 1:
            return inputValues1 = value;
        case 2:
            return inputValues2 = value;
        default:
            return "";
        }
    }

    private void SetOutput(int arrayID) {
        Output = "";

        /* First character of password */
        switch (arrayID) {
        case 0:

            for (int i = 0; i < inputValues0.Length; i++) {
                foreach (string password in PasswordMasterList) {
                    if (inputValues0[i] == password[0]) {
                        outputList0.Add(password);
                        Output += password + ", ";
                        Console.WriteLine(password);
                    }
                }
            }

            break;
        case 1:
            for (int i = 0; i < inputValues1.Length; i++) {
                foreach (string password in PasswordMasterList) {
                    if (inputValues1[i] == password[1]) {
                        outputList1.Add(password);
                    }
                }
            }

            /* Check if passwords match */
            foreach (string password in outputList0)
            foreach (string password2 in outputList1) {
                if (password == password2) {
                    Output += password + ", ";
                }
            }

            break;
        case 2:
            for (int i = 0; i < inputValues2.Length; i++) {
                foreach (string password in PasswordMasterList) {
                    if (inputValues2[i] == password[2]) {
                        outputList2.Add(password);
                    }
                }
            }

            /* Check if passwords match */
            foreach (string password in outputList0)
            foreach (string password2 in outputList1)
            foreach (string password3 in outputList2) {
                if (password == password2 && password == password3) {
                    Output += password + ", ";
                }
            }

            break;
        }

        /* Remove the ending comma */
        if (Output.Length > 5) {
            Output = Output.Remove(Output.Length - 2);
        }
    }

    private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
        if (ReferenceValues.CurrentModule == "../Modules/PasswordsModule.xaml") {
            if (e.PropertyName == "KEY_F12") {
                //TODO: This
            }
        }
    }
}