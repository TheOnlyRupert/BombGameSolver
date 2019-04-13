using System.Collections.Generic;
using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class KeypadsModuleVM : BaseViewModel {
        private readonly List<int> _nonDisabledColumns;

        private string _columnDisabled0, _columnDisabled1, _columnDisabled2, _columnDisabled3, _columnDisabled4,
            _columnDisabled5, _keypad_3_broken, _keypad_3_fancy, _keypad_6, _keypad_ae, _keypad_at, _keypad_balloon,
            _keypad_boobs, _keypad_c, _keypad_c_rev, _keypad_copyright, _keypad_e, _keypad_fork, _keypad_h, _keypad_hk,
            _keypad_kk, _keypad_lightning, _keypad_n, _keypad_omega, _keypad_paragraph, _keypad_pound, _keypad_pyramid,
            _keypad_question, _keypad_smile, _keypad_star_hol, _keypad_star_sol, _keypad_tb, _keypad_y;

        public KeypadsModuleVM() {
            _nonDisabledColumns = new List<int>();

            ColumnDisabled0 = ColumnDisabled1 = ColumnDisabled2 = ColumnDisabled3 = ColumnDisabled4 =
                ColumnDisabled5 = "False";

            CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);


        public string ColumnDisabled0 {
            get => _columnDisabled0;
            set {
                _columnDisabled0 = value;
                RaisePropertyChangedEvent("ColumnDisabled0");
            }
        }

        public string ColumnDisabled1 {
            get => _columnDisabled1;
            set {
                _columnDisabled1 = value;
                RaisePropertyChangedEvent("ColumnDisabled1");
            }
        }

        public string ColumnDisabled2 {
            get => _columnDisabled2;
            set {
                _columnDisabled2 = value;
                RaisePropertyChangedEvent("ColumnDisabled2");
            }
        }

        public string ColumnDisabled3 {
            get => _columnDisabled3;
            set {
                _columnDisabled3 = value;
                RaisePropertyChangedEvent("ColumnDisabled3");
            }
        }

        public string ColumnDisabled4 {
            get => _columnDisabled4;
            set {
                _columnDisabled4 = value;
                RaisePropertyChangedEvent("ColumnDisabled4");
            }
        }

        public string ColumnDisabled5 {
            get => _columnDisabled5;
            set {
                _columnDisabled5 = value;
                RaisePropertyChangedEvent("ColumnDisabled5");
            }
        }

        public string Keypad_3_Broken {
            get => _keypad_3_broken;
            set {
                _keypad_3_broken = value;
                RaisePropertyChangedEvent("Keypad_3_Broken");
            }
        }

        public string Keypad_3_Fancy {
            get => _keypad_3_fancy;
            set {
                _keypad_3_fancy = value;
                RaisePropertyChangedEvent("Keypad_3_Fancy");
            }
        }

        public string Keypad_6 {
            get => _keypad_6;
            set {
                _keypad_6 = value;
                RaisePropertyChangedEvent("Keypad_6");
            }
        }

        public string Keypad_Ae {
            get => _keypad_ae;
            set {
                _keypad_ae = value;
                RaisePropertyChangedEvent("Keypad_Ae");
            }
        }

        public string Keypad_At {
            get => _keypad_at;
            set {
                _keypad_at = value;
                RaisePropertyChangedEvent("Keypad_At");
            }
        }

        public string Keypad_Balloon {
            get => _keypad_balloon;
            set {
                _keypad_balloon = value;
                RaisePropertyChangedEvent("Keypad_Balloon");
            }
        }

        public string Keypad_Boobs {
            get => _keypad_boobs;
            set {
                _keypad_boobs = value;
                RaisePropertyChangedEvent("Keypad_Boobs");
            }
        }

        public string Keypad_C {
            get => _keypad_c;
            set {
                _keypad_c = value;
                RaisePropertyChangedEvent("Keypad_C");
            }
        }

        public string Keypad_C_Rev {
            get => _keypad_c_rev;
            set {
                _keypad_c_rev = value;
                RaisePropertyChangedEvent("Keypad_C_Rev");
            }
        }

        public string Keypad_Copyright {
            get => _keypad_copyright;
            set {
                _keypad_copyright = value;
                RaisePropertyChangedEvent("Keypad_Copyright");
            }
        }

        public string Keypad_E {
            get => _keypad_e;
            set {
                _keypad_e = value;
                RaisePropertyChangedEvent("Keypad_E");
            }
        }

        public string Keypad_Fork {
            get => _keypad_fork;
            set {
                _keypad_fork = value;
                RaisePropertyChangedEvent("Keypad_Fork");
            }
        }

        public string Keypad_H {
            get => _keypad_h;
            set {
                _keypad_h = value;
                RaisePropertyChangedEvent("Keypad_H");
            }
        }

        public string Keypad_Hk {
            get => _keypad_hk;
            set {
                _keypad_hk = value;
                RaisePropertyChangedEvent("Keypad_Hk");
            }
        }

        public string Keypad_Kk {
            get => _keypad_kk;
            set {
                _keypad_kk = value;
                RaisePropertyChangedEvent("Keypad_Kk");
            }
        }

        public string Keypad_Lightning {
            get => _keypad_lightning;
            set {
                _keypad_lightning = value;
                RaisePropertyChangedEvent("Keypad_Lightning");
            }
        }

        public string Keypad_N {
            get => _keypad_n;
            set {
                _keypad_n = value;
                RaisePropertyChangedEvent("Keypad_N");
            }
        }

        public string Keypad_Omega {
            get => _keypad_omega;
            set {
                _keypad_omega = value;
                RaisePropertyChangedEvent("Keypad_Omega");
            }
        }

        public string Keypad_Paragraph {
            get => _keypad_paragraph;
            set {
                _keypad_paragraph = value;
                RaisePropertyChangedEvent("Keypad_Paragraph");
            }
        }

        public string Keypad_Pound {
            get => _keypad_pound;
            set {
                _keypad_pound = value;
                RaisePropertyChangedEvent("Keypad_Pound");
            }
        }

        public string Keypad_Pyramid {
            get => _keypad_pyramid;
            set {
                _keypad_pyramid = value;
                RaisePropertyChangedEvent("Keypad_Pyramid");
            }
        }

        public string Keypad_Question {
            get => _keypad_question;
            set {
                _keypad_question = value;
                RaisePropertyChangedEvent("Keypad_Question");
            }
        }

        public string Keypad_Smile {
            get => _keypad_smile;
            set {
                _keypad_smile = value;
                RaisePropertyChangedEvent("Keypad_Smile");
            }
        }

        public string Keypad_Star_Hol {
            get => _keypad_star_hol;
            set {
                _keypad_star_hol = value;
                RaisePropertyChangedEvent("Keypad_Star_Hol");
            }
        }

        public string Keypad_Star_Sol {
            get => _keypad_star_sol;
            set {
                _keypad_star_sol = value;
                RaisePropertyChangedEvent("Keypad_Star_Sol");
            }
        }

        public string Keypad_Tb {
            get => _keypad_tb;
            set {
                _keypad_tb = value;
                RaisePropertyChangedEvent("Keypad_Tb");
            }
        }

        public string Keypad_Y {
            get => _keypad_y;
            set {
                _keypad_y = value;
                RaisePropertyChangedEvent("Keypad_Y");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            if (ReferenceValues.CurrentModule == "../Modules/KeypadsModule.xaml") {
                if (e.PropertyName == "KEY_F12") {
                    ResetButtonLogic();
                }
            }
        }

        private void ButtonLogic(object param) {
            int index;

            switch (param) {
            case "balloon":
                if (Keypad_Balloon == "True") {
                    Keypad_Balloon = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(0));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(1));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(0);
                    _nonDisabledColumns.Add(1);
                    Keypad_Balloon = "True";
                }

                break;
            case "pyramid":
                if (Keypad_Pyramid == "True") {
                    Keypad_Pyramid = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(0));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(0);
                    Keypad_Pyramid = "True";
                }

                break;
            case "y":
                if (Keypad_Y == "True") {
                    Keypad_Y = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(0));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(2));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(0);
                    _nonDisabledColumns.Add(2);
                    Keypad_Y = "True";
                }

                break;
            case "lightning":
                if (Keypad_Lightning == "True") {
                    Keypad_Lightning = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(0));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(0);
                    Keypad_Lightning = "True";
                }

                break;
            case "hk":
                if (Keypad_Hk == "True") {
                    Keypad_Hk = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(0));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(3));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(0);
                    _nonDisabledColumns.Add(3);
                    Keypad_Hk = "True";
                }

                break;
            case "h":
                if (Keypad_H == "True") {
                    Keypad_H = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(0));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(1));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(0);
                    _nonDisabledColumns.Add(1);
                    Keypad_H = "True";
                }

                break;
            case "c_rev":
                if (Keypad_C_Rev == "True") {
                    Keypad_C_Rev = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(0));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(1));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(0);
                    _nonDisabledColumns.Add(1);
                    Keypad_C_Rev = "True";
                }

                break;
            case "e":
                if (Keypad_E == "True") {
                    Keypad_E = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(1));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(5));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(1);
                    _nonDisabledColumns.Add(5);
                    Keypad_E = "True";
                }

                break;
            case "at":
                if (Keypad_At == "True") {
                    Keypad_At = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(1));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(2));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(1);
                    _nonDisabledColumns.Add(2);
                    Keypad_At = "True";
                }

                break;
            case "star_hol":
                if (Keypad_Star_Hol == "True") {
                    Keypad_Star_Hol = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(1));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(2));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(1);
                    _nonDisabledColumns.Add(2);
                    Keypad_Star_Hol = "True";
                }

                break;
            case "question":
                if (Keypad_Question == "True") {
                    Keypad_Question = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(1));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(3));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(1);
                    _nonDisabledColumns.Add(3);
                    Keypad_Question = "True";
                }

                break;
            case "copyright":
                if (Keypad_Copyright == "True") {
                    Keypad_Copyright = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(2));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(2);
                    Keypad_Copyright = "True";
                }

                break;
            case "boobs":
                if (Keypad_Boobs == "True") {
                    Keypad_Boobs = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(2));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(2);
                    Keypad_Boobs = "True";
                }

                break;
            case "kk":
                if (Keypad_Kk == "True") {
                    Keypad_Kk = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(2));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(3));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(2);
                    _nonDisabledColumns.Add(3);
                    Keypad_Kk = "True";
                }

                break;
            case "3_broken":
                if (Keypad_3_Broken == "True") {
                    Keypad_3_Broken = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(2));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(2);
                    Keypad_3_Broken = "True";
                }

                break;
            case "6":
                if (Keypad_6 == "True") {
                    Keypad_6 = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(3));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(5));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(3);
                    _nonDisabledColumns.Add(5);
                    Keypad_6 = "True";
                }

                break;
            case "paragraph":
                if (Keypad_Paragraph == "True") {
                    Keypad_Paragraph = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(3));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(4));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(3);
                    _nonDisabledColumns.Add(4);
                    Keypad_Paragraph = "True";
                }

                break;
            case "tb":
                if (Keypad_Tb == "True") {
                    Keypad_Tb = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(3));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(4));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(3);
                    _nonDisabledColumns.Add(4);
                    Keypad_Tb = "True";
                }

                break;
            case "smile":
                if (Keypad_Smile == "True") {
                    Keypad_Smile = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(3));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(4));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(3);
                    _nonDisabledColumns.Add(4);
                    Keypad_Smile = "True";
                }

                break;
            case "fork":
                if (Keypad_Fork == "True") {
                    Keypad_Fork = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(4));
                    _nonDisabledColumns.Remove(index);
                    index = _nonDisabledColumns.Find(x => x.Equals(5));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(4);
                    _nonDisabledColumns.Add(5);
                    Keypad_Fork = "True";
                }

                break;
            case "c":
                if (Keypad_C == "True") {
                    Keypad_C = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(4));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(4);
                    Keypad_C = "True";
                }

                break;
            case "3_fancy":
                if (Keypad_3_Fancy == "True") {
                    Keypad_3_Fancy = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(4));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(4);
                    Keypad_3_Fancy = "True";
                }

                break;
            case "star_sol":
                if (Keypad_Star_Sol == "True") {
                    Keypad_Star_Sol = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(4));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(4);
                    Keypad_Star_Sol = "True";
                }

                break;
            case "pound":
                if (Keypad_Pound == "True") {
                    Keypad_Pound = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(5));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(5);
                    Keypad_Pound = "True";
                }

                break;
            case "ae":
                if (Keypad_Ae == "True") {
                    Keypad_Ae = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(5));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(5);
                    Keypad_Ae = "True";
                }

                break;
            case "n":
                if (Keypad_N == "True") {
                    Keypad_N = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(5));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(5);
                    Keypad_N = "True";
                }

                break;
            case "omega":
                if (Keypad_Omega == "True") {
                    Keypad_Omega = "False";
                    index = _nonDisabledColumns.Find(x => x.Equals(5));
                    _nonDisabledColumns.Remove(index);
                } else {
                    _nonDisabledColumns.Add(5);
                    Keypad_Omega = "True";
                }

                break;
            }

            if (_nonDisabledColumns.Count > 0) {
                ColumnDisabled0 = "True";
                ColumnDisabled1 = "True";
                ColumnDisabled2 = "True";
                ColumnDisabled3 = "True";
                ColumnDisabled4 = "True";
                ColumnDisabled5 = "True";
            } else {
                ColumnDisabled0 = "False";
                ColumnDisabled1 = "False";
                ColumnDisabled2 = "False";
                ColumnDisabled3 = "False";
                ColumnDisabled4 = "False";
                ColumnDisabled5 = "False";
            }

            /* Disable any columns added to the list */
            foreach (int column in _nonDisabledColumns) {
                switch (column) {
                case 0:
                    ColumnDisabled0 = "False";
                    break;
                case 1:
                    ColumnDisabled1 = "False";
                    break;
                case 2:
                    ColumnDisabled2 = "False";
                    break;
                case 3:
                    ColumnDisabled3 = "False";
                    break;
                case 4:
                    ColumnDisabled4 = "False";
                    break;
                case 5:
                    ColumnDisabled5 = "False";
                    break;
                }
            }
        }

        private void ResetButtonLogic() {
            _nonDisabledColumns.Clear();

            ColumnDisabled0 = ColumnDisabled1 = ColumnDisabled2 = ColumnDisabled3 = ColumnDisabled4 = ColumnDisabled5 =
                Keypad_6 = Keypad_3_Broken = Keypad_3_Fancy = Keypad_Ae = Keypad_At = Keypad_Balloon = Keypad_Boobs =
                    Keypad_C = Keypad_Copyright = Keypad_E = Keypad_Fork = Keypad_H = Keypad_Hk = Keypad_Kk =
                        Keypad_Lightning = Keypad_N = Keypad_Omega = Keypad_Paragraph = Keypad_Pound =
                            Keypad_Pyramid = Keypad_Question = Keypad_Smile = Keypad_Tb =
                                Keypad_Y = Keypad_C_Rev = Keypad_Star_Hol = Keypad_Star_Sol = "False";
        }
    }
}