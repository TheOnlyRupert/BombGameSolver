using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class KeypadsModuleVM : BaseViewModel {
        private string _columnDisabled0,
            _columnDisabled1,
            _columnDisabled2,
            _columnDisabled3,
            _columnDisabled4,
            _columnDisabled5;

        private string _keypad_3_broken,
            _keypad_3_fancy,
            _keypad_6,
            _keypad_ae,
            _keypad_at,
            _keypad_balloon,
            _keypad_boobs,
            _keypad_c,
            _keypad_c_rev,
            _keypad_copyright,
            _keypad_e,
            _keypad_fork,
            _keypad_h,
            _keypad_hk,
            _keypad_kk,
            _keypad_lightning,
            _keypad_n,
            _keypad_omega,
            _keypad_paragraph,
            _keypad_pound,
            _keypad_pyramid,
            _keypad_question,
            _keypad_smile,
            _keypad_star_hol,
            _keypad_star_sol,
            _keypad_tb,
            _keypad_y;

        public KeypadsModuleVM() {
            ColumnDisabled0 = "False";
            ColumnDisabled1 = "False";
            ColumnDisabled2 = "False";
            ColumnDisabled3 = "False";
            ColumnDisabled4 = "False";
            ColumnDisabled5 = "False";
        }

        public ICommand ResetButtonCommand => new DelegateCommand(ResetButtonLogic, true);

        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);

        private void ResetButtonLogic(object param) {
            //ColumnDisabled0 = "False";
            //ColumnDisabled1 = "False";
            //ColumnDisabled2 = "False";
            //ColumnDisabled3 = "False";
            //ColumnDisabled4 = "False";
            //ColumnDisabled5 = "False";
            Keypad_6 = "False";
            Keypad_3_Broken = "False";
            Keypad_3_Fancy = "False";
            Keypad_Ae = "False";
            Keypad_At = "False";
            Keypad_Balloon = "False";
            Keypad_Boobs = "False";
            Keypad_C = "False";
            Keypad_Copyright = "False";
            Keypad_E = "False";
            Keypad_Fork = "False";
            Keypad_H = "False";
            Keypad_Hk = "False";
            Keypad_Kk = "False";
            Keypad_Lightning = "False";
            Keypad_N = "False";
            Keypad_Omega = "False";
            Keypad_Paragraph = "False";
            Keypad_Pound = "False";
            Keypad_Pyramid = "False";
            Keypad_Question = "False";
            Keypad_Smile = "False";
            Keypad_Tb = "False";
            Keypad_Y = "False";
            Keypad_C_Rev = "False";
            Keypad_Star_Hol = "False";
            Keypad_Star_Sol = "False";
        }

        private void ButtonLogic(object param) {
            switch (param) {
            case "balloon":
                if (Keypad_Balloon == "True") {
                    Keypad_Balloon = "False";
                } else {
                    Keypad_Balloon = "True";
                }

                break;
            case "pyramid":
                if (Keypad_Pyramid == "True") {
                    Keypad_Pyramid = "False";
                } else {
                    Keypad_Pyramid = "True";
                }

                break;
            case "y":
                if (Keypad_Y == "True") {
                    Keypad_Y = "False";
                } else {
                    Keypad_Y = "True";
                }

                break;
            case "lightning":
                if (Keypad_Lightning == "True") {
                    Keypad_Lightning = "False";
                } else {
                    Keypad_Lightning = "True";
                }

                break;
            case "hk":
                if (Keypad_Hk == "True") {
                    Keypad_Hk = "False";
                } else {
                    Keypad_Hk = "True";
                }

                break;
            case "h":
                if (Keypad_H == "True") {
                    Keypad_H = "False";
                } else {
                    Keypad_H = "True";
                }

                break;
            case "c_rev":
                if (Keypad_C_Rev == "True") {
                    Keypad_C_Rev = "False";
                } else {
                    Keypad_C_Rev = "True";
                }

                break;
            case "e":
                if (Keypad_E == "True") {
                    Keypad_E = "False";
                } else {
                    Keypad_E = "True";
                }

                break;
            case "at":
                if (Keypad_At == "True") {
                    Keypad_At = "False";
                } else {
                    Keypad_At = "True";
                }

                break;
            case "star_hol":
                if (Keypad_Star_Hol == "True") {
                    Keypad_Star_Hol = "False";
                } else {
                    Keypad_Star_Hol = "True";
                }

                break;
            case "question":
                if (Keypad_Question == "True") {
                    Keypad_Question = "False";
                } else {
                    Keypad_Question = "True";
                }

                break;
            case "copyright":
                if (Keypad_Copyright == "True") {
                    Keypad_Copyright = "False";
                } else {
                    Keypad_Copyright = "True";
                }

                break;
            case "boobs":
                if (Keypad_Boobs == "True") {
                    Keypad_Boobs = "False";
                } else {
                    Keypad_Boobs = "True";
                }

                break;
            case "3_broken":
                if (Keypad_3_Broken == "True") {
                    Keypad_3_Broken = "False";
                } else {
                    Keypad_3_Broken = "True";
                }

                break;
            case "6":
                if (Keypad_6 == "True") {
                    Keypad_6 = "False";
                } else {
                    Keypad_6 = "True";
                }

                break;
            case "paragraph":
                if (Keypad_Paragraph == "True") {
                    Keypad_Paragraph = "False";
                } else {
                    Keypad_Paragraph = "True";
                }

                break;
            case "tb":
                if (Keypad_Tb == "True") {
                    Keypad_Tb = "False";
                } else {
                    Keypad_Tb = "True";
                }

                break;
            case "kk":
                if (Keypad_Kk == "True") {
                    Keypad_Kk = "False";
                } else {
                    Keypad_Kk = "True";
                }

                break;
            case "smile":
                if (Keypad_Smile == "True") {
                    Keypad_Smile = "False";
                } else {
                    Keypad_Smile = "True";
                }

                break;
            case "fork":
                if (Keypad_Fork == "True") {
                    Keypad_Fork = "False";
                } else {
                    Keypad_Fork = "True";
                }

                break;
            case "c":
                if (Keypad_C == "True") {
                    Keypad_C = "False";
                } else {
                    Keypad_C = "True";
                }

                break;
            case "3_fancy":
                if (Keypad_3_Fancy == "True") {
                    Keypad_3_Fancy = "False";
                } else {
                    Keypad_3_Fancy = "True";
                }

                break;
            case "star_sol":
                if (Keypad_Star_Sol == "True") {
                    Keypad_Star_Sol = "False";
                } else {
                    Keypad_Star_Sol = "True";
                }

                break;
            case "pound":
                if (Keypad_Pound == "True") {
                    Keypad_Pound = "False";
                } else {
                    Keypad_Pound = "True";
                }

                break;
            case "ae":
                if (Keypad_Ae == "True") {
                    Keypad_Ae = "False";
                } else {
                    Keypad_Ae = "True";
                }

                break;
            case "n":
                if (Keypad_N == "True") {
                    Keypad_N = "False";
                } else {
                    Keypad_N = "True";
                }

                break;
            case "omega":
                if (Keypad_Omega == "True") {
                    Keypad_Omega = "False";
                } else {
                    Keypad_Omega = "True";
                }

                break;
            }
        }

#region Columns

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

#endregion

#region Keypads

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

#endregion
    }
}