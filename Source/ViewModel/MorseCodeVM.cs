using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MorseCodeVM : BaseViewModel {
        private string _button_1b,
            _button_1f,
            _button_1h,
            _button_1l,
            _button_1s,
            _button_1t,
            _button_1v,
            _button_2e,
            _button_2i,
            _button_2o,
            _button_2r,
            _button_2h,
            _button_2l,
            _button_2t,
            _button_3m,
            _button_3x,
            _button_3e,
            _button_3i,
            _button_3r,
            _outputText,
            _columnDisabled2a,
            _columnDisabled2b,
            _columnDisabled3a,
            _columnDisabled3b,
            _columnDisabled3c,
            _columnDisabled3d;

        private bool[] isColumnSet;

        public MorseCodeVM() {
            ColumnDisabled2a = ColumnDisabled2b = ColumnDisabled3a = ColumnDisabled3b = ColumnDisabled3c =
                ColumnDisabled3d = "True";
            isColumnSet = new[] {false, false, false};

            CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (ReferenceValues.CurrentModule == "../Modules/MorseCodeModule.xaml") {
                switch (e.PropertyName) {
                case "KEY_F12":
                    ResetButtonLogic();
                    break;
                }
            }
        }

        private void ButtonLogic(object param) {
            switch (param) {
            case "1b":
                if (Button_1b == "True") {
                    ResetButtonLogic();
                } else {
                    if (isColumnSet[0]) {
                        ResetButtonLogic();
                    }

                    Button_1b = "True";
                    ColumnDisabled2a = "False";
                    isColumnSet[0] = true;
                }

                break;
            case "1f":
                if (Button_1f == "True") {
                    ResetButtonLogic();
                } else {
                    if (isColumnSet[0]) {
                        ResetButtonLogic();
                    }

                    Button_1f = "True";
                    isColumnSet[0] = true;
                    OutputText = "3.555";
                }

                break;
            case "1h":
                if (Button_1h == "True") {
                    ResetButtonLogic();
                } else {
                    if (isColumnSet[0]) {
                        ResetButtonLogic();
                    }

                    Button_1h = "True";
                    isColumnSet[0] = true;
                    OutputText = "3.515";
                }

                break;
            case "1l":
                if (Button_1l == "True") {
                    ResetButtonLogic();
                } else {
                    if (isColumnSet[0]) {
                        ResetButtonLogic();
                    }

                    Button_1l = "True";
                    isColumnSet[0] = true;
                    OutputText = "3.542";
                }

                break;
            case "1s":
                if (Button_1s == "True") {
                    ResetButtonLogic();
                } else {
                    if (isColumnSet[0]) {
                        ResetButtonLogic();
                    }

                    Button_1s = "True";
                    ColumnDisabled2b = "False";
                    isColumnSet[0] = true;
                }

                break;
            case "1t":
                if (Button_1t == "True") {
                    ResetButtonLogic();
                } else {
                    if (isColumnSet[0]) {
                        ResetButtonLogic();
                    }

                    Button_1t = "True";
                    isColumnSet[0] = true;
                    OutputText = "3.532";
                }

                break;
            case "1v":
                if (Button_1v == "True") {
                    ResetButtonLogic();
                } else {
                    if (isColumnSet[0]) {
                        ResetButtonLogic();
                    }

                    Button_1v = "True";
                    isColumnSet[0] = true;
                    OutputText = "3.595";
                }

                break;

            case "2e":
                if (Button_1b == "True") {
                    if (Button_2e == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1b");
                    } else {
                        if (isColumnSet[1]) {
                            ResetButtonLogic();
                            ButtonLogic("1b");
                        }

                        Button_2e = "True";
                        OutputText = "3.600";
                        isColumnSet[1] = true;
                    }
                }

                break;
            case "2i":
                if (Button_1b == "True") {
                    if (Button_2i == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1b");
                    } else {
                        if (isColumnSet[1]) {
                            ResetButtonLogic();
                            ButtonLogic("1b");
                        }

                        Button_2i = "True";
                        isColumnSet[1] = true;
                        OutputText = "3.552";
                    }
                }

                break;

            case "2o":
                if (Button_1b == "True") {
                    if (Button_2o == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1b");
                    } else {
                        if (isColumnSet[1]) {
                            ResetButtonLogic();
                            ButtonLogic("1b");
                        }

                        Button_2o = "True";
                        isColumnSet[1] = true;
                        ColumnDisabled3a = "False";
                    }
                }

                break;

            case "2r":
                if (Button_1b == "True") {
                    if (Button_2r == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1b");
                    } else {
                        if (isColumnSet[1]) {
                            ResetButtonLogic();
                            ButtonLogic("1b");
                        }

                        Button_2r = "True";
                        isColumnSet[1] = true;
                        ColumnDisabled3b = ColumnDisabled3c = "False";
                    }
                }

                break;

            case "2h":
                if (Button_1s == "True") {
                    if (Button_2h == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1s");
                    } else {
                        if (isColumnSet[1]) {
                            ResetButtonLogic();
                            ButtonLogic("1s");
                        }

                        Button_2h = "True";
                        isColumnSet[1] = true;
                        OutputText = "3.505";
                    }
                }

                break;

            case "2l":
                if (Button_1s == "True") {
                    if (Button_2l == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1s");
                    } else {
                        if (isColumnSet[1]) {
                            ResetButtonLogic();
                            ButtonLogic("1s");
                        }

                        Button_2l = "True";
                        isColumnSet[1] = true;
                        OutputText = "3.522";
                    }
                }

                break;

            case "2t":
                if (Button_1s == "True") {
                    if (Button_2t == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1s");
                    } else {
                        if (isColumnSet[1]) {
                            ResetButtonLogic();
                            ButtonLogic("1s");
                        }

                        Button_2t = "True";
                        isColumnSet[1] = true;
                        ColumnDisabled3b = ColumnDisabled3c = ColumnDisabled3d = "False";
                    }
                }

                break;

            case "3m":
                if (Button_2o == "True") {
                    if (Button_3m == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1b");
                        ButtonLogic("2o");
                    } else {
                        if (isColumnSet[2]) {
                            ResetButtonLogic();
                            ButtonLogic("1b");
                            ButtonLogic("2o");
                        }

                        Button_3m = "True";
                        isColumnSet[2] = true;
                        OutputText = "3.565";
                    }
                }

                break;

            case "3x":
                if (Button_2o == "True") {
                    if (Button_3x == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1b");
                        ButtonLogic("2o");
                    } else {
                        if (isColumnSet[2]) {
                            ResetButtonLogic();
                            ButtonLogic("1b");
                            ButtonLogic("2o");
                        }

                        Button_3x = "True";
                        isColumnSet[2] = true;
                        OutputText = "3.535";
                    }
                }

                break;

            case "3e":
                /* BR or ST */
                if (Button_2r == "True" || Button_2t == "True") {
                    if (Button_3e == "True") {
                        if (Button_2r == "True") {
                            ResetButtonLogic();
                            ButtonLogic("1b");
                            ButtonLogic("2r");
                        } else {
                            ResetButtonLogic();
                            ButtonLogic("1s");
                            ButtonLogic("2t");
                        }
                    } else {
                        if (isColumnSet[2]) {
                            if (Button_2r == "True") {
                                ResetButtonLogic();
                                ButtonLogic("1b");
                                ButtonLogic("2r");
                            } else {
                                ResetButtonLogic();
                                ButtonLogic("1s");
                                ButtonLogic("2t");
                            }
                        }

                        Button_3e = "True";
                        isColumnSet[2] = true;
                        OutputText = Button_2r == "True" ? "3.572" : "3.582";
                    }
                }

                break;

            case "3i":
                /* BR or ST */
                if (Button_2r == "True" || Button_2t == "True") {
                    if (Button_3i == "True") {
                        if (Button_2r == "True") {
                            ResetButtonLogic();
                            ButtonLogic("1b");
                            ButtonLogic("2r");
                        } else {
                            ResetButtonLogic();
                            ButtonLogic("1s");
                            ButtonLogic("2t");
                        }
                    } else {
                        if (isColumnSet[2]) {
                            if (Button_2r == "True") {
                                ResetButtonLogic();
                                ButtonLogic("1b");
                                ButtonLogic("2r");
                            } else {
                                ResetButtonLogic();
                                ButtonLogic("1s");
                                ButtonLogic("2t");
                            }
                        }

                        Button_3i = "True";
                        isColumnSet[2] = true;
                        OutputText = Button_2r == "True" ? "3.575" : "3.592";
                    }
                }

                break;

            case "3r":
                if (Button_2t == "True") {
                    if (Button_3r == "True") {
                        ResetButtonLogic();
                        ButtonLogic("1s");
                        ButtonLogic("2t");
                    } else {
                        if (isColumnSet[2]) {
                            ResetButtonLogic();
                            ButtonLogic("1s");
                            ButtonLogic("2t");
                        }

                        Button_3r = "True";
                        isColumnSet[2] = true;
                        OutputText = "3.545";
                    }
                }

                break;
            }
        }

        private void ResetButtonLogic() {
            Button_1b = Button_1f = Button_1h = Button_1l = Button_1s = Button_1t = Button_1v = Button_2e =
                Button_2i = Button_2o = Button_2r = Button_2h = Button_2l = Button_2t = Button_3m = Button_3x =
                    Button_3e = Button_3i = Button_3r = "False";
            ColumnDisabled2a = ColumnDisabled2b = ColumnDisabled3a = ColumnDisabled3b = ColumnDisabled3c =
                ColumnDisabled3d = "True";
            isColumnSet = new[] {false, false, false};
            OutputText = "";
        }

        #region Buttons

        public string OutputText {
            get => _outputText;
            set {
                _outputText = value;
                RaisePropertyChangedEvent("OutputText");
            }
        }

        public string Button_1b {
            get => _button_1b;
            set {
                _button_1b = value;
                RaisePropertyChangedEvent("Button_1b");
            }
        }

        public string Button_1f {
            get => _button_1f;
            set {
                _button_1f = value;
                RaisePropertyChangedEvent("Button_1f");
            }
        }

        public string Button_1h {
            get => _button_1h;
            set {
                _button_1h = value;
                RaisePropertyChangedEvent("Button_1h");
            }
        }

        public string Button_1l {
            get => _button_1l;
            set {
                _button_1l = value;
                RaisePropertyChangedEvent("Button_1l");
            }
        }

        public string Button_1s {
            get => _button_1s;
            set {
                _button_1s = value;
                RaisePropertyChangedEvent("Button_1s");
            }
        }

        public string Button_1t {
            get => _button_1t;
            set {
                _button_1t = value;
                RaisePropertyChangedEvent("Button_1t");
            }
        }

        public string Button_1v {
            get => _button_1v;
            set {
                _button_1v = value;
                RaisePropertyChangedEvent("Button_1v");
            }
        }

        public string Button_2e {
            get => _button_2e;
            set {
                _button_2e = value;
                RaisePropertyChangedEvent("Button_2e");
            }
        }

        public string Button_2i {
            get => _button_2i;
            set {
                _button_2i = value;
                RaisePropertyChangedEvent("Button_2i");
            }
        }

        public string Button_2o {
            get => _button_2o;
            set {
                _button_2o = value;
                RaisePropertyChangedEvent("Button_2o");
            }
        }

        public string Button_2r {
            get => _button_2r;
            set {
                _button_2r = value;
                RaisePropertyChangedEvent("Button_2r");
            }
        }

        public string Button_2h {
            get => _button_2h;
            set {
                _button_2h = value;
                RaisePropertyChangedEvent("Button_2h");
            }
        }

        public string Button_2l {
            get => _button_2l;
            set {
                _button_2l = value;
                RaisePropertyChangedEvent("Button_2l");
            }
        }

        public string Button_2t {
            get => _button_2t;
            set {
                _button_2t = value;
                RaisePropertyChangedEvent("Button_2t");
            }
        }

        public string Button_3m {
            get => _button_3m;
            set {
                _button_3m = value;
                RaisePropertyChangedEvent("Button_3m");
            }
        }

        public string Button_3x {
            get => _button_3x;
            set {
                _button_3x = value;
                RaisePropertyChangedEvent("Button_3x");
            }
        }

        public string Button_3e {
            get => _button_3e;
            set {
                _button_3e = value;
                RaisePropertyChangedEvent("Button_3e");
            }
        }

        public string Button_3i {
            get => _button_3i;
            set {
                _button_3i = value;
                RaisePropertyChangedEvent("Button_3i");
            }
        }

        public string Button_3r {
            get => _button_3r;
            set {
                _button_3r = value;
                RaisePropertyChangedEvent("Button_3r");
            }
        }

        public string ColumnDisabled2a {
            get => _columnDisabled2a;
            set {
                _columnDisabled2a = value;
                RaisePropertyChangedEvent("ColumnDisabled2a");
            }
        }

        public string ColumnDisabled2b {
            get => _columnDisabled2b;
            set {
                _columnDisabled2b = value;
                RaisePropertyChangedEvent("ColumnDisabled2b");
            }
        }

        public string ColumnDisabled3a {
            get => _columnDisabled3a;
            set {
                _columnDisabled3a = value;
                RaisePropertyChangedEvent("ColumnDisabled3a");
            }
        }

        public string ColumnDisabled3b {
            get => _columnDisabled3b;
            set {
                _columnDisabled3b = value;
                RaisePropertyChangedEvent("ColumnDisabled3b");
            }
        }


        public string ColumnDisabled3c {
            get => _columnDisabled3c;
            set {
                _columnDisabled3c = value;
                RaisePropertyChangedEvent("ColumnDisabled3c");
            }
        }


        public string ColumnDisabled3d {
            get => _columnDisabled3d;
            set {
                _columnDisabled3d = value;
                RaisePropertyChangedEvent("ColumnDisabled3d");
            }
        }

        #endregion
    }
}