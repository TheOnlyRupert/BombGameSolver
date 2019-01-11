using System;
using System.Windows.Input;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainWindowVM : BaseViewModel {
        private readonly CrossViewMessenger _crossViewMessenger;
        private string _iconImage, _devLogWindowHeight;

        private Key _key_numpad1, _key_numpad2, _key_numpad3, _key_numpad4, _key_numpad5, _key_numpad6, _key_numpad7,
            _key_numpad8, _key_numpad9, _key_numpad0,
            _key_D1, _key_D2, _key_D3, _key_D4, _key_D5, _key_D6, _key_D7, _key_D8, _key_D9, _key_D0;

        public MainWindowVM() {
            IconImage = "Resources/icons/icon.png";
            DevLogWindowHeight = "0";

            _crossViewMessenger = CrossViewMessenger.Instance;
            _crossViewMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public string IconImage {
            get => _iconImage;
            set {
                _iconImage = value;
                RaisePropertyChangedEvent("IconImage");
            }
        }

        public Key Key_NumPad1 {
            get => _key_numpad1;
            set {
                _key_numpad1 = value;
                RaisePropertyChangedEvent("Key_NumPad1");
            }
        }

        public Key Key_NumPad2 {
            get => _key_numpad2;
            set {
                _key_numpad2 = value;
                RaisePropertyChangedEvent("Key_NumPad2");
            }
        }

        public Key Key_NumPad3 {
            get => _key_numpad3;
            set {
                _key_numpad3 = value;
                RaisePropertyChangedEvent("Key_NumPad3");
            }
        }

        public Key Key_NumPad4 {
            get => _key_numpad4;
            set {
                _key_numpad4 = value;
                RaisePropertyChangedEvent("Key_NumPad4");
            }
        }

        public Key Key_NumPad5 {
            get => _key_numpad5;
            set {
                _key_numpad5 = value;
                RaisePropertyChangedEvent("Key_NumPad5");
            }
        }

        public Key Key_NumPad6 {
            get => _key_numpad6;
            set {
                _key_numpad6 = value;
                RaisePropertyChangedEvent("Key_NumPad6");
            }
        }

        public Key Key_NumPad7 {
            get => _key_numpad7;
            set {
                _key_numpad7 = value;
                RaisePropertyChangedEvent("Key_NumPad7");
            }
        }

        public Key Key_NumPad8 {
            get => _key_numpad8;
            set {
                _key_numpad8 = value;
                RaisePropertyChangedEvent("Key_NumPad8");
            }
        }

        public Key Key_NumPad9 {
            get => _key_numpad9;
            set {
                _key_numpad9 = value;
                RaisePropertyChangedEvent("Key_NumPad9");
            }
        }

        public Key Key_NumPad0 {
            get => _key_numpad0;
            set {
                _key_numpad0 = value;
                RaisePropertyChangedEvent("Key_NumPad0");
            }
        }

        public Key Key_D1 {
            get => _key_D1;
            set {
                _key_D1 = value;
                RaisePropertyChangedEvent("Key_D1");
            }
        }

        public Key Key_D2 {
            get => _key_D2;
            set {
                _key_D2 = value;
                RaisePropertyChangedEvent("Key_D2");
            }
        }

        public Key Key_D3 {
            get => _key_D3;
            set {
                _key_D3 = value;
                RaisePropertyChangedEvent("Key_D3");
            }
        }

        public Key Key_D4 {
            get => _key_D4;
            set {
                _key_D4 = value;
                RaisePropertyChangedEvent("Key_D4");
            }
        }

        public Key Key_D5 {
            get => _key_D5;
            set {
                _key_D5 = value;
                RaisePropertyChangedEvent("Key_D5");
            }
        }

        public Key Key_D6 {
            get => _key_D6;
            set {
                _key_D6 = value;
                RaisePropertyChangedEvent("Key_D6");
            }
        }

        public Key Key_D7 {
            get => _key_D7;
            set {
                _key_D7 = value;
                RaisePropertyChangedEvent("Key_D7");
            }
        }

        public Key Key_D8 {
            get => _key_D8;
            set {
                _key_D8 = value;
                RaisePropertyChangedEvent("Key_D8");
            }
        }

        public Key Key_D9 {
            get => _key_D9;
            set {
                _key_D9 = value;
                RaisePropertyChangedEvent("Key_D9");
            }
        }

        public Key Key_D0 {
            get => _key_D0;
            set {
                _key_D0 = value;
                RaisePropertyChangedEvent("Key_D0");
            }
        }

        public string DevLogWindowHeight {
            get => _devLogWindowHeight;
            set {
                _devLogWindowHeight = value;
                RaisePropertyChangedEvent("DevLogWindowHeight");
            }
        }

        public ICommand GlobalKeyboardListener => new DelegateCommand(GlobalKeyboardListenerLogic, true);

        private void GlobalKeyboardListenerLogic(object obj) {
            _crossViewMessenger.PushMessage("KEY_" + obj, null);
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            switch (e.PropertyName) {
            /* Switch current module if requested */
            case "DevButtonLogic":
                DevLogWindowHeight = ReferenceValues.IsDebugEnabled ? "200" : "0";
                break;
            case "KeyBindings_NormWiresModule":
                Console.WriteLine(@"Switching Key bindings to NormWiresModule");
                Key_D1 = Key.D1;
                Key_NumPad1 = Key.NumPad1;
                Key_D2 = Key.D2;
                Key_NumPad2 = Key.NumPad2;
                Key_D3 = Key.D3;
                Key_NumPad3 = Key.NumPad3;
                Key_D4 = Key.D4;
                Key_NumPad4 = Key.NumPad4;
                Key_D5 = Key.D5;
                Key_NumPad5 = Key.NumPad5;
                break;
            case "KeyBindings_BigButtonModule":
                Console.WriteLine(@"Switching Key bindings to BigButtonModule");
                Key_D1 = Key.D1;
                Key_NumPad1 = Key.NumPad1;
                Key_D2 = Key.D2;
                Key_NumPad2 = Key.NumPad2;
                Key_D3 = Key.D3;
                Key_NumPad3 = Key.NumPad3;
                Key_D4 = Key.D4;
                Key_NumPad4 = Key.NumPad4;
                Key_D7 = Key.D7;
                Key_NumPad7 = Key.NumPad7;
                Key_D8 = Key.D8;
                Key_NumPad8 = Key.NumPad8;
                Key_D9 = Key.D9;
                Key_NumPad9 = Key.NumPad9;
                Key_D0 = Key.D0;
                Key_NumPad0 = Key.NumPad0;
                break;
            case "KeyBindings_MazeModule":
                Console.WriteLine(@"Switching Key bindings to MazeModule");
                Key_D1 = Key.None;
                Key_NumPad1 = Key.None;
                Key_D2 = Key.None;
                Key_NumPad2 = Key.None;
                Key_D3 = Key.None;
                Key_NumPad3 = Key.None;
                Key_D4 = Key.None;
                Key_NumPad4 = Key.None;
                Key_D5 = Key.None;
                Key_NumPad5 = Key.None;
                Key_D6 = Key.None;
                Key_NumPad6 = Key.None;
                break;
            case "KeyBindings_SequWiresModule":
                Console.WriteLine(@"Switching Key bindings to SequWiresModule");
                Key_D1 = Key.D1;
                Key_NumPad1 = Key.NumPad1;
                Key_D2 = Key.D2;
                Key_NumPad2 = Key.NumPad2;
                Key_D3 = Key.D3;
                Key_NumPad3 = Key.NumPad3;
                Key_D4 = Key.D4;
                Key_NumPad4 = Key.NumPad4;
                Key_D5 = Key.D5;
                Key_NumPad5 = Key.NumPad5;
                Key_D6 = Key.D6;
                Key_NumPad6 = Key.NumPad6;
                Key_D7 = Key.D7;
                Key_NumPad7 = Key.NumPad7;
                Key_D8 = Key.D8;
                Key_NumPad8 = Key.NumPad8;
                Key_D9 = Key.D9;
                Key_NumPad9 = Key.NumPad9;
                break;
            case "KeyBindings_MemoryModule":
                Console.WriteLine(@"Switching Key bindings to MemoryModule");
                Key_D1 = Key.None;
                Key_NumPad1 = Key.None;
                Key_D2 = Key.None;
                Key_NumPad2 = Key.None;
                Key_D3 = Key.None;
                Key_NumPad3 = Key.None;
                Key_D4 = Key.None;
                Key_NumPad4 = Key.None;
                break;
            case "KeyBindings_SimonSaysModule":
                Console.WriteLine(@"Switching Key bindings to SimonSaysModule");
                Key_D0 = Key.D0;
                Key_NumPad0 = Key.NumPad0;
                Key_D1 = Key.D1;
                Key_NumPad1 = Key.NumPad1;
                Key_D2 = Key.D2;
                Key_NumPad2 = Key.NumPad2;
                break;
            }
        }
    }
}