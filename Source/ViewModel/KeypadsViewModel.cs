using System;
using System.Windows.Input;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class KeypadsViewModel : BaseViewModel {
        private string _columnDisabled0,
            _columnDisabled1,
            _columnDisabled2,
            _columnDisabled3,
            _columnDisabled4,
            _columnDisabled5;

        private string[] _valueOfKeypad_3_Broken = {"24"};
        private string[] _valueOfKeypad_3_Fancy = {"45"};
        private string[] _valueOfKeypad_6 = {"30", "50"};
        private string[] _valueOfKeypad_Ae = {"53"};
        private string[] _valueOfKeypad_At = {"13", "22"};
        private string[] _valueOfKeypad_Balloon = {"00", "11"};
        private string[] _valueOfKeypad_Boobs = {"21"};
        private string[] _valueOfKeypad_C = {"43"};
        private string[] _valueOfKeypad_C_Rev = {"06", "12"};
        private string[] _valueOfKeypad_Copyright = {"20"};
        private string[] _valueOfKeypad_E = {"10", "51"};
        private string[] _valueOfKeypad_Fork = {"40", "54"};
        private string[] _valueOfKeypad_H = {"05"};
        private string[] _valueOfKeypad_Hk = {"04", "33"};
        private string[] _valueOfKeypad_Kk = {"23", "34"};
        private string[] _valueOfKeypad_Lightning = {"03", "15"};
        private string[] _valueOfKeypad_N = {"55"};
        private string[] _valueOfKeypad_Omega = {"56"};
        private string[] _valueOfKeypad_Paragraph = {"31", "44"};
        private string[] _valueOfKeypad_Pound = {"52"};
        private string[] _valueOfKeypad_Pyramid = {"01"};
        private string[] _valueOfKeypad_Question = {"16", "35"};
        private string[] _valueOfKeypad_Smile = {"36", "41"};
        private string[] _valueOfKeypad_Star_Hol = {"14", "26"};
        private string[] _valueOfKeypad_Star_Sol = {"46"};
        private string[] _valueOfKeypad_Tb = {"32", "42"};
        private string[] _valueOfKeypad_Y = {"02", "25"};

        private string[] _keypadInput = {"", "", "", ""};

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

        public KeypadsViewModel() {
            ColumnDisabled0 = "False";
            ColumnDisabled1 = "False";
            ColumnDisabled2 = "False";
            ColumnDisabled3 = "False";
            ColumnDisabled4 = "False";
            ColumnDisabled5 = "False";
        }

        public ICommand ButtonCommand => new DelegateCommand(ButtonLogic, true);

        private void ButtonLogic(object param) {
            /* First, check if button is not in a disabled column (if it is, just ignore it) */
            if ((param.ToString()[0] == '0' && ColumnDisabled0 == "True") ||
                (param.ToString()[0] == '1' && ColumnDisabled1 == "True") ||
                (param.ToString()[0] == '2' && ColumnDisabled2 == "True") ||
                (param.ToString()[0] == '3' && ColumnDisabled3 == "True") ||
                (param.ToString()[0] == '4' && ColumnDisabled4 == "True") ||
                (param.ToString()[0] == '5' && ColumnDisabled5 == "True")) {
                return;
            }

            /* Check actual button being clicked on... if button is not already checked,
             highlight all matching buttons and disable the columns not in use. */
            else {

            }

            /* If button is already checked, return back to normal and enable the disabled columns */


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
                RaisePropertyChangedEvent("Keypad_HK");
            }
        }

        public string Keypad_Kk {
            get => _keypad_kk;
            set {
                _keypad_kk = value;
                RaisePropertyChangedEvent("Keypad_KK");
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