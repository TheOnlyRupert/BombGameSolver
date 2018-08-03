using System;

namespace BombGameSolver.Source {
    public class CrossViewMessenger {
        private static CrossViewMessenger _instance;
        public static CrossViewMessenger Instance => _instance ?? (_instance = new CrossViewMessenger());

        public event EventHandler<MessageValueChangedEventArgs> MessageValueChanged;

        public void PushMessage(string propertyName, string value) {
            MessageValueChanged?.Invoke(this, new MessageValueChangedEventArgs {
                PropertyName = propertyName
            });
        }
    }
}

public class MessageValueChangedEventArgs : EventArgs {
    public string PropertyName { get; set; }
    public string Value { get; set; }
}