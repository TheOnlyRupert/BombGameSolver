using System;
using BombGameSolver.Source.Reference;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel {
    public class MainDisplayGroupVM : BaseViewModel {
        private string _currentModule;

        public MainDisplayGroupVM() {
            _currentModule = "../Modules/ModuleSwitcher.xaml";

            var simpleMessenger = CrossViewMessenger.Instance;
            simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        }

        public string CurrentModule {
            get => _currentModule;
            set {
                _currentModule = value;
                ReferenceValues.CurrentModule = value;
                RaisePropertyChangedEvent("CurrentModule");
            }
        }

        private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
            /* Switch current module if requested */
            if (e.PropertyName == "SwitchCurrentModule") {
                Console.WriteLine(@"Switching from " + CurrentModule + @" to " + ReferenceValues.CurrentModule);
                CurrentModule = ReferenceValues.CurrentModule;
            } else if (e.PropertyName == "KEY_Tab" && CurrentModule != "../Modules/ModuleSwitcher.xaml") {
                Console.WriteLine(@"Switching from " + ReferenceValues.CurrentModule + @" to " +
                                  @"../Modules/ModuleSwitcher.xaml");
                CurrentModule = "../Modules/ModuleSwitcher.xaml";
            }
        }
    }
}