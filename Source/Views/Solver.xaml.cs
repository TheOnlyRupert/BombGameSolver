using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BombGameSolver.Source.Views {
    public partial class Solver {
        private readonly int[] _coloredButtonLayout = {-1, -1};

        private readonly int[,] _keypadFinal = {
            {12, 5, 20, 13, 18, 14, 11}, {9, 12, 11, 7, 22, 14, 8},
            {26, 24, 7, 19, 1, 20, 22}, {3, 16, 17, 18, 19, 8, 23}, {4, 23, 17, 10, 16, 2, 21},
            {3, 9, 25, 6, 4, 15, 27}
        };

        private readonly int[] _keypadValues = new int[4];
        private readonly int[] _normalWiresWireLayout = new int[6];
        private bool _complicatedWireLed;
        private bool _complicatedWireStar;
        private int _complicatedWireType;
        private bool _isMorseModeB;
        private bool _isSerialEven;
        private bool _isSerialVowel;
        private int _keypadRound;
        private int[,] _memory = {{0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}};
        private int _memoryRound = 1;
        private int _normalWiresTotal;
        private string[] _simonSaysOrder = new string[4];
        private bool _whoOnFirstView;
        private int[] _wireSeqTotals = new int[3];

        public Solver() {
            InitializeComponent();

            BackgroundImage.ImageSource = new BitmapImage( new Uri(
                "pack://application:,,,/Resources/background.png", UriKind.RelativeOrAbsolute));
        }

        #region Bomb_Setup

        /* Finish Setting Up Bomb... Main Module View */
        private void InitialContinueButton_OnClick(object sender, RoutedEventArgs e) {
            BombSetupView.Visibility = Visibility.Hidden;
            MainButtonsView.Visibility = Visibility.Visible;
            NormalWiresView.Visibility = Visibility.Hidden;
            ColoredButtonView.Visibility = Visibility.Hidden;
            SimonSaysView.Visibility = Visibility.Hidden;
            MemoryView.Visibility = Visibility.Hidden;
            ComplicatedWiresView.Visibility = Visibility.Hidden;
            WireSequenceView.Visibility = Visibility.Hidden;
            WhoOnFirstView.Visibility = Visibility.Hidden;
            MazeView.Visibility = Visibility.Hidden;
            MorseCodeView.Visibility = Visibility.Hidden;
            PasswordView.Visibility = Visibility.Hidden;
            KeypadView.Visibility = Visibility.Hidden;
            PosKnobView.Visibility = Visibility.Hidden;
        }

        /* Return to Bomb Setup View */
        private void BackSetupButton_OnClick(object sender, RoutedEventArgs e) {
            BombSetupView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        /* Get Serial Number odd/even AND Get Vowels true/false  */
        private void SerialInput_OnTextChanged(object sender, TextChangedEventArgs e) {
            if (SerialInput.Text.Length == 6) {
                /* Get odd/even bool from 6th char of serial */
                if (char.IsNumber(SerialInput.Text[5])) {
                    _isSerialEven = SerialInput.Text[5] % 2 == 0;
                    InitialContinueButton.IsEnabled = true;
                }

                /* Check if serial contains a vowel */
                char[] vowels = {'a', 'e', 'i', 'o', 'u'};
                foreach (var vowel in vowels)
                    if (SerialInput.Text.ToLower().Contains(vowel)) {
                        _isSerialVowel = true;
                        return;
                    }

                _isSerialVowel = false;
            } else {
                InitialContinueButton.IsEnabled = false;
            }
        }

        #endregion

        #region Normal_Wires

        /* Normal Wires View */
        private void NormalWiresButton_OnClick(object sender, RoutedEventArgs e) {
            MainButtonsView.Visibility = Visibility.Hidden;
            NormalWiresView.Visibility = Visibility.Visible;
        }

        /* NORMAL WIRES LOGIC -- white 0, blue 1, red 2, yellow 3, black 4 */
        private void NormalWiresChecker() {
            if (_normalWiresTotal > 5) {
                NormalWiresWhiteButton.IsEnabled = false;
                NormalWiresBlueButton.IsEnabled = false;
                NormalWiresRedButton.IsEnabled = false;
                NormalWiresYellowButton.IsEnabled = false;
                NormalWiresBlackButton.IsEnabled = false;
            } else {
                NormalWiresWhiteButton.IsEnabled = true;
                NormalWiresBlueButton.IsEnabled = true;
                NormalWiresRedButton.IsEnabled = true;
                NormalWiresYellowButton.IsEnabled = true;
                NormalWiresBlackButton.IsEnabled = true;
            }

            NormalWiresConfirmButton.IsEnabled = _normalWiresTotal > 2;
        }

        private void NormalWires_ClearButton_OnClick(object sender, RoutedEventArgs e) {
            _normalWiresTotal = 0;
            NormalWiresOrderTextbox.Text = "";
            NormalWiresTotalTextbox.Text = "0";
            NormalWiresOutputTextBox.Text = "";

            /* Re-enable buttons */
            NormalWiresChecker();
        }

        private void NormalWiresWhiteButton_OnClick(object sender, RoutedEventArgs e) {
            /* Add white wire to array */
            _normalWiresWireLayout[_normalWiresTotal] = 0;
            _normalWiresTotal++;
            NormalWiresChecker();

            NormalWiresOrderTextbox.Text = NormalWiresOrderTextbox.Text + " White ";
            NormalWiresTotalTextbox.Text = _normalWiresTotal.ToString();
        }

        private void NormalWiresBlueButton_OnClick(object sender, RoutedEventArgs e) {
            /* Add blue wire to array */
            _normalWiresWireLayout[_normalWiresTotal] = 1;
            _normalWiresTotal++;
            NormalWiresChecker();

            NormalWiresOrderTextbox.Text = NormalWiresOrderTextbox.Text + " Blue ";
            NormalWiresTotalTextbox.Text = _normalWiresTotal.ToString();
        }

        private void NormalWiresRedButton_OnClick(object sender, RoutedEventArgs e) {
            /* Add red wire to array */
            _normalWiresWireLayout[_normalWiresTotal] = 2;
            _normalWiresTotal++;
            NormalWiresChecker();

            NormalWiresOrderTextbox.Text = NormalWiresOrderTextbox.Text + " Red ";
            NormalWiresTotalTextbox.Text = _normalWiresTotal.ToString();
        }

        private void NormalWiresYellowButton_OnClick(object sender, RoutedEventArgs e) {
            /* Add yellow wire to array */
            _normalWiresWireLayout[_normalWiresTotal] = 3;
            _normalWiresTotal++;
            NormalWiresChecker();

            NormalWiresOrderTextbox.Text = NormalWiresOrderTextbox.Text + " Yellow ";
            NormalWiresTotalTextbox.Text = _normalWiresTotal.ToString();
        }

        private void NormalWiresBlackButton_OnClick(object sender, RoutedEventArgs e) {
            /* Add black wire to array */
            _normalWiresWireLayout[_normalWiresTotal] = 4;
            _normalWiresTotal++;
            NormalWiresChecker();

            NormalWiresOrderTextbox.Text = NormalWiresOrderTextbox.Text + " Black ";
            NormalWiresTotalTextbox.Text = _normalWiresTotal.ToString();
        }

        private void NormalWiresConfirmButton_OnClick(object sender, RoutedEventArgs e) {
            int tempInt;
            bool isTrue;

            /* 3 WIRES */
            if (_normalWiresTotal == 3) {
                /* If no red wires, cut the second wire */
                if (_normalWiresWireLayout[0] != 2 && _normalWiresWireLayout[1] != 2 &&
                    _normalWiresWireLayout[2] != 2) {
                    Console.WriteLine(
                        "Normal Wires | 3x Wires | Condition 1 - \"If no red wires, cut the second wire\"");
                    NormalWiresOutputTextBox.Text = "Second Wire";

                    /* If last wire is white, cut the last wire */
                } else if (_normalWiresWireLayout[2] == 0) {
                    Console.WriteLine(
                        "Normal Wires | 3x Wires | Condition 2 - \"If last wire is white, cut the last wire\"");
                    NormalWiresOutputTextBox.Text = "Last Wire";
                } else {
                    tempInt = 0;
                    foreach (var temp in _normalWiresWireLayout)
                        if (temp == 1)
                            tempInt++;

                    /* If more than one blue wire, cut the last blue wire */
                    if (tempInt > 1) {
                        Console.WriteLine(
                            "Normal Wires | 3x Wires | Condition 3 - \"If more than one blue wire, cut the last blue wire\"");
                        NormalWiresOutputTextBox.Text = "Last BLUE wire";

                        /* Else, Cut the last wire */
                    } else {
                        Console.WriteLine("Normal Wires | 3x Wires | Condition 4 - \"Cut the last wire\"");
                        NormalWiresOutputTextBox.Text = "Last Wire";
                    }
                }

                /* 4 WIRES */
            } else if (_normalWiresTotal == 4) {
                tempInt = 0;
                foreach (var temp in _normalWiresWireLayout)
                    if (temp == 2)
                        tempInt++;

                /* If more than one red wire AND serial is odd, cut the last red wire */
                if (tempInt > 1 && !_isSerialEven) {
                    Console.WriteLine(
                        "Normal Wires | 4x Wires | Condition 1 - \"If more than one red wire AND serial is odd, cut the last red wire\"");
                    NormalWiresOutputTextBox.Text = "Last RED Wire";

                    /* If the last wire is yellow AND no red wires, cut the first wire */
                } else if (_normalWiresWireLayout[3] == 3 && _normalWiresWireLayout[0] != 2 &&
                           _normalWiresWireLayout[1] != 2 && _normalWiresWireLayout[2] != 2) {
                    Console.WriteLine(
                        "Normal Wires | 4x Wires | Condition 2 - \"If the last wire is yellow AND no red wires, cut the first wire\"");
                    NormalWiresOutputTextBox.Text = "First Wire";
                } else {
                    tempInt = 0;
                    foreach (var temp in _normalWiresWireLayout)
                        if (temp == 1)
                            tempInt++;

                    /* If there is one blue wire, cut the first wire */
                    if (tempInt == 1) {
                        Console.WriteLine(
                            "Normal Wires | 4x Wires | Condition 3 - \"If there is one blue wire, cut the first wire\"");
                        NormalWiresOutputTextBox.Text = "First Wire";
                    } else {
                        tempInt = 0;
                        foreach (var temp in _normalWiresWireLayout)
                            if (temp == 3)
                                tempInt++;

                        /* If there is more than one yellow, cut the last wire */
                        if (tempInt > 1) {
                            Console.WriteLine(
                                "Normal Wires | 4x Wires | Condition 4 - \"If there is more than one yellow, cut the last wire\"");
                            NormalWiresOutputTextBox.Text = "Last Wire";

                            /* Else, Cut the second wire */
                        } else {
                            Console.WriteLine("Normal Wires | 4x Wires | Condition 5 - \"Cut the second wire\"");
                            NormalWiresOutputTextBox.Text = "Second Wire";
                        }
                    }
                }

                /* 5 WIRES */
            } else if (_normalWiresTotal == 5) {
                /* If last wire is black and the last digit of the serial number is odd, cut the fourth wire */
                if (_normalWiresWireLayout[4] == 4 && !_isSerialEven) {
                    Console.WriteLine(
                        "Normal Wires | 5x Wires | Condition 1 - \"If last wire is black and the last digit of the serial number is odd, cut the fourth wire\"");
                    NormalWiresOutputTextBox.Text = "Fourth Wire";
                } else {
                    tempInt = 0;
                    /* Check red occurance */
                    foreach (var temp in _normalWiresWireLayout)
                        if (temp == 2)
                            tempInt++;

                    isTrue = tempInt == 1;
                    tempInt = 0;

                    /* Check yellow occurance */
                    foreach (var temp in _normalWiresWireLayout)
                        if (temp == 3)
                            tempInt++;

                    /* If there is one red wire AND more than one yellow wire, cut the first wire */
                    if (tempInt > 1 && isTrue) {
                        Console.WriteLine(
                            "Normal Wires | 5x Wires | Condition 2 - \"If there is one red wire AND more than one yellow wire, cut the first wire\"");
                        NormalWiresOutputTextBox.Text = "First Wire";

                        /* If there are no black wires, cut the second wire */
                    } else if (_normalWiresWireLayout[0] != 4 && _normalWiresWireLayout[1] != 4 &&
                               _normalWiresWireLayout[2] != 4 && _normalWiresWireLayout[3] != 4 &&
                               _normalWiresWireLayout[4] != 4) {
                        Console.WriteLine(
                            "Normal Wires | 5x Wires | Condition 3 - \"If there are no black wires, cut the second wire\"");
                        NormalWiresOutputTextBox.Text = "Second Wire";

                        /* Else, Cut the first wire */
                    } else {
                        Console.WriteLine("Normal Wires | 5x Wires | Condition 4 - \"Cut the first wire\"");
                        NormalWiresOutputTextBox.Text = "First Wire";
                    }
                }

                /* 6 WIRES */
            } else if (_normalWiresTotal == 6) {
                tempInt = 0;
                foreach (var temp in _normalWiresWireLayout)
                    if (temp == 3)
                        tempInt++;

                /* If no yellow wires AND serial is odd, cut the third wire */
                if (tempInt == 0 && !_isSerialEven) {
                    Console.WriteLine(
                        "Normal Wires | 6x Wires | Condition 1 - \"If no yellow wires AND serial is odd, cut the third wire\"");
                    NormalWiresOutputTextBox.Text = "Third Wire";
                } else {
                    tempInt = 0;
                    /* Check yellow occurance */
                    foreach (var temp in _normalWiresWireLayout)
                        if (temp == 3)
                            tempInt++;

                    isTrue = tempInt == 1;
                    tempInt = 0;

                    /* Check white occurance */
                    foreach (var temp in _normalWiresWireLayout)
                        if (temp == 0)
                            tempInt++;

                    /* If there is one yellow wire AND more than one white wire, cut the fourth wire */
                    if (tempInt > 1 && isTrue) {
                        Console.WriteLine(
                            "Normal Wires | 6x Wires | Condition 2 - \"If there is one yellow wire AND more than one white wire, cut the fourth wire\"");
                        NormalWiresOutputTextBox.Text = "Fourth Wire";
                    } else {
                        tempInt = 0;
                        foreach (var temp in _normalWiresWireLayout)
                            if (temp == 2)
                                tempInt++;

                        /* If there are no red wires, cut the last wire */
                        if (tempInt == 0) {
                            Console.WriteLine(
                                "Normal Wires | 6x Wires | Condition 3 - \"If there are no red wires, cut the last wire\"");
                            NormalWiresOutputTextBox.Text = "Last Wire";

                            /* Else, Cut the fourth wire */
                        } else {
                            Console.WriteLine("Normal Wires | 6x Wires | Condition 4 - \"Cut the fourth wire\"");
                            NormalWiresOutputTextBox.Text = "Fourth Wire";
                        }
                    }
                }
            }

            NormalWiresConfirmButton.IsEnabled = false;
            NormalWiresWhiteButton.IsEnabled = false;
            NormalWiresBlueButton.IsEnabled = false;
            NormalWiresRedButton.IsEnabled = false;
            NormalWiresYellowButton.IsEnabled = false;
            NormalWiresBlackButton.IsEnabled = false;
        }

        #endregion

        #region Password

        private void PasswordButton_OnClick(object sender, RoutedEventArgs e) {
            PasswordView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Positional_Knob

        private void PosKnob_OnClick(object sender, RoutedEventArgs e) {
            PosKnobView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Colored_Button

        private void ColoredWiresButton_OnClick(object sender, RoutedEventArgs e) {
            MainButtonsView.Visibility = Visibility.Hidden;
            ColoredButtonView.Visibility = Visibility.Visible;
        }

        /* Blue 0, Red 1, White 2, Yellow 3, Abort 0, Detonate 1, Hold 2, Press 3 */
        private void ColoredButtonLogic() {
            if (_coloredButtonLayout[0] >= 0 && _coloredButtonLayout[1] >= 0) {
                /* If BLUE "Abort", continue below */
                if (_coloredButtonLayout[0] == 0 && _coloredButtonLayout[1] == 0)
                    ColoredButtonOutputTextBox.Text = "Hold Button for Color";
                /* If more than 1 battery on the bomb AND "Detonate", press and release */
                else if (BatterySlider.Value > 1 && _coloredButtonLayout[1] == 1)
                    ColoredButtonOutputTextBox.Text = "Press and Release";
                /* If WHITE AND lit CAR, continue below */
                else if (_coloredButtonLayout[0] == 2 && IsCaRon.IsChecked == true)
                    ColoredButtonOutputTextBox.Text = "Hold Button for Color";
                /* If more than 2 batteries AND lit FRK, press and release */
                else if (BatterySlider.Value > 2 && IsFrKon.IsChecked == true)
                    ColoredButtonOutputTextBox.Text = "Press and Release";
                /* If YELLOW, continue below */
                else if (_coloredButtonLayout[0] == 3)
                    ColoredButtonOutputTextBox.Text = "Hold Button for Color";
                /* If RED "Hold", press and release */
                else if (_coloredButtonLayout[0] == 1 && _coloredButtonLayout[1] == 2)
                    ColoredButtonOutputTextBox.Text = "Press and Release";
                /* Else, continue below */
                else
                    ColoredButtonOutputTextBox.Text = "Hold Button for Color";
            }

            if (_coloredButtonLayout[0] != -1) {
                ColoredButtonBlueButton.IsEnabled = false;
                ColoredButtonRedButton.IsEnabled = false;
                ColoredButtonWhiteButton.IsEnabled = false;
                ColoredButtonYellowButton.IsEnabled = false;
            } else {
                ColoredButtonBlueButton.IsEnabled = true;
                ColoredButtonRedButton.IsEnabled = true;
                ColoredButtonWhiteButton.IsEnabled = true;
                ColoredButtonYellowButton.IsEnabled = true;
            }

            if (_coloredButtonLayout[1] != -1) {
                ColoredButtonAbortButton.IsEnabled = false;
                ColoredButtonDetonateButton.IsEnabled = false;
                ColoredButtonHoldButton.IsEnabled = false;
                ColoredButtonPressButton.IsEnabled = false;
            } else {
                ColoredButtonAbortButton.IsEnabled = true;
                ColoredButtonDetonateButton.IsEnabled = true;
                ColoredButtonHoldButton.IsEnabled = true;
                ColoredButtonPressButton.IsEnabled = true;
            }
        }

        private void ColoredButton_ClearButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[0] = -1;
            _coloredButtonLayout[1] = -1;
            ColoredButtonColorTextbox.Text = "";
            ColoredButtonTextTextbox.Text = "";
            ColoredButtonOutputTextBox.Text = "";

            ColoredButtonLogic();
        }

        private void ColoredButtonBlueButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[0] = 0;
            ColoredButtonColorTextbox.Text = "Blue";
            ColoredButtonLogic();
        }

        private void ColoredButtonRedButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[0] = 1;
            ColoredButtonColorTextbox.Text = "Red";
            ColoredButtonLogic();
        }

        private void ColoredButtonWhiteButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[0] = 2;
            ColoredButtonColorTextbox.Text = "White";
            ColoredButtonLogic();
        }

        private void ColoredButtonYellowButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[0] = 3;
            ColoredButtonColorTextbox.Text = "Yellow";
            ColoredButtonLogic();
        }

        private void ColoredButtonAbortButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[1] = 0;
            ColoredButtonTextTextbox.Text = "Abort";
            ColoredButtonLogic();
        }

        private void ColoredButtonDetonateButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[1] = 1;
            ColoredButtonTextTextbox.Text = "Detonate";
            ColoredButtonLogic();
        }

        private void ColoredButtonHoldButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[1] = 2;
            ColoredButtonTextTextbox.Text = "Hold";
            ColoredButtonLogic();
        }

        private void ColoredButtonPressButton_OnClick(object sender, RoutedEventArgs e) {
            _coloredButtonLayout[1] = 3;
            ColoredButtonTextTextbox.Text = "Press";
            ColoredButtonLogic();
        }

        #endregion

        #region Simon_Says

        private void SimonSaysButton_OnClick(object sender, RoutedEventArgs e) {
            SimonSaysView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;

            SimonSaysLogic();
        }

        private void SimonSaysLogic() {
            /* Switch statement for different strike values
             * Blue 0, Green 1, Red 2, Yellow 3 */
            switch (StrikeSlider.Value) {
                case 0:
                    if (_isSerialVowel) {
                        _simonSaysOrder = new[] {"Red", "Yellow", "Blue", "Green"};
                        SimonSaysBlueTextbox.Foreground = Brushes.White;
                        SimonSaysBlueTextbox.Background = Brushes.Red;
                        SimonSaysGreenTextbox.Foreground = Brushes.Black;
                        SimonSaysGreenTextbox.Background = Brushes.Yellow;
                        SimonSaysRedTextbox.Foreground = Brushes.White;
                        SimonSaysRedTextbox.Background = Brushes.Blue;
                        SimonSaysYellowTextbox.Foreground = Brushes.White;
                        SimonSaysYellowTextbox.Background = Brushes.Green;
                    } else {
                        _simonSaysOrder = new[] {"Yellow", "Green", "Blue", "Red"};
                        SimonSaysBlueTextbox.Foreground = Brushes.Black;
                        SimonSaysBlueTextbox.Background = Brushes.Yellow;
                        SimonSaysGreenTextbox.Foreground = Brushes.White;
                        SimonSaysGreenTextbox.Background = Brushes.Green;
                        SimonSaysRedTextbox.Foreground = Brushes.White;
                        SimonSaysRedTextbox.Background = Brushes.Blue;
                        SimonSaysYellowTextbox.Foreground = Brushes.White;
                        SimonSaysYellowTextbox.Background = Brushes.Red;
                    }

                    break;
                case 1:
                    if (_isSerialVowel) {
                        _simonSaysOrder = new[] {"Green", "Blue", "Yellow", "Red"};
                        SimonSaysBlueTextbox.Foreground = Brushes.White;
                        SimonSaysBlueTextbox.Background = Brushes.Green;
                        SimonSaysGreenTextbox.Foreground = Brushes.White;
                        SimonSaysGreenTextbox.Background = Brushes.Blue;
                        SimonSaysRedTextbox.Foreground = Brushes.Black;
                        SimonSaysRedTextbox.Background = Brushes.Yellow;
                        SimonSaysYellowTextbox.Foreground = Brushes.White;
                        SimonSaysYellowTextbox.Background = Brushes.Red;
                    } else {
                        _simonSaysOrder = new[] {"Blue", "Yellow", "Red", "Green"};
                        SimonSaysBlueTextbox.Foreground = Brushes.White;
                        SimonSaysBlueTextbox.Background = Brushes.Blue;
                        SimonSaysGreenTextbox.Foreground = Brushes.Black;
                        SimonSaysGreenTextbox.Background = Brushes.Yellow;
                        SimonSaysRedTextbox.Foreground = Brushes.White;
                        SimonSaysRedTextbox.Background = Brushes.Red;
                        SimonSaysYellowTextbox.Foreground = Brushes.White;
                        SimonSaysYellowTextbox.Background = Brushes.Green;
                    }

                    break;
                case 2:
                    if (_isSerialVowel) {
                        _simonSaysOrder = new[] {"Red", "Yellow", "Green", "Blue"};
                        SimonSaysBlueTextbox.Foreground = Brushes.White;
                        SimonSaysBlueTextbox.Background = Brushes.Red;
                        SimonSaysGreenTextbox.Foreground = Brushes.Black;
                        SimonSaysGreenTextbox.Background = Brushes.Yellow;
                        SimonSaysRedTextbox.Foreground = Brushes.White;
                        SimonSaysRedTextbox.Background = Brushes.Green;
                        SimonSaysYellowTextbox.Foreground = Brushes.White;
                        SimonSaysYellowTextbox.Background = Brushes.Blue;
                    } else {
                        _simonSaysOrder = new[] {"Green", "Blue", "Yellow", "Red"};
                        SimonSaysBlueTextbox.Foreground = Brushes.White;
                        SimonSaysBlueTextbox.Background = Brushes.Green;
                        SimonSaysGreenTextbox.Foreground = Brushes.White;
                        SimonSaysGreenTextbox.Background = Brushes.Blue;
                        SimonSaysRedTextbox.Foreground = Brushes.Black;
                        SimonSaysRedTextbox.Background = Brushes.Yellow;
                        SimonSaysYellowTextbox.Foreground = Brushes.White;
                        SimonSaysYellowTextbox.Background = Brushes.Red;
                    }

                    break;
            }

            SimonSaysBlueTextbox.Text = _simonSaysOrder[0];
            SimonSaysGreenTextbox.Text = _simonSaysOrder[1];
            SimonSaysRedTextbox.Text = _simonSaysOrder[2];
            SimonSaysYellowTextbox.Text = _simonSaysOrder[3];
        }

        private void StrikeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            SimonSaysLogic();
        }

        #endregion

        #region Memory

        private void MemoryButton_OnClick(object sender, RoutedEventArgs e) {
            MemoryView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        private void MemoryLogic() {
            /* Populate temp array with 5 values from input textbox */
            var temp = new int[5];

            for (var i = 0;
                i < MemoryInputTextBox.Text.Length;
                i++) //TODO: Fix this sub 48 from total.... wtf is this doing?
                temp[i] = MemoryInputTextBox.Text[i] - 48;

            switch (_memoryRound) {
                case 1:
                    MemoryCurrentRoundTextBox.Text = "20% Done";

                    /* 1, 2 - Second position */
                    if (temp[0] == 1 || temp[0] == 2) {
                        MemoryOutputTextBox.Text = "Click on " + temp[2];
                        _memory[0, 0] = 2;
                        _memory[0, 1] = temp[2];

                        /* 3 - Third position */
                    } else if (temp[0] == 3) {
                        MemoryOutputTextBox.Text = "Click on " + temp[3];
                        _memory[0, 0] = 3;
                        _memory[0, 1] = temp[3];

                        /* 4 - Fourth position */
                    } else {
                        MemoryOutputTextBox.Text = "Click on " + temp[4];
                        _memory[0, 0] = 4;
                        _memory[0, 1] = temp[4];
                    }

                    Console.WriteLine("[Round 1]: " + temp[0] + temp[1] + temp[2] + temp[3] + temp[4] +
                                      "  Pos: " + _memory[0, 0] + ", Num: " + _memory[0, 1]);
                    break;
                case 2:
                    MemoryCurrentRoundTextBox.Text = "40% Done";

                    /* 1 -> Labeled "4" */
                    if (temp[0] == 1) {
                        MemoryOutputTextBox.Text = "Click on 4";
                        _memory[1, 1] = 4;

                        /* Find label "4" and add to array */
                        for (var i = 1; i <= temp.Length; i++)
                            if (temp[i] == 4) {
                                /* Get pos number */
                                _memory[1, 0] = i;
                                break;
                            }

                        /* 2 and 4 -> Same position as stage 1 */
                    } else if (temp[0] == 2 || temp[0] == 4) {
                        _memory[1, 0] = _memory[0, 0];
                        _memory[1, 1] = temp[_memory[1, 0]];
                        MemoryOutputTextBox.Text = "Click on " + _memory[1, 1];

                        /* 3 -> Fist position */
                    } else {
                        MemoryOutputTextBox.Text = "Click on " + temp[1];
                        _memory[1, 1] = temp[1];
                        _memory[1, 0] = 1;
                    }

                    Console.WriteLine("[Round 2]: " + temp[0] + temp[1] + temp[2] +
                                      temp[3] + temp[4] + "  Pos: " + _memory[1, 0] + ", Num: " +
                                      _memory[1, 1]);
                    break;
                case 3:
                    MemoryCurrentRoundTextBox.Text = "60% Done";

                    /* 1 - Same label as stage 2 */
                    if (temp[0] == 1) {
                        MemoryOutputTextBox.Text = "Click on " + _memory[1, 1];
                        _memory[2, 1] = _memory[1, 1];

                        /* Find pos of label and add to array */
                        for (var i = 1; i <= temp.Length; i++)
                            if (temp[i] == _memory[1, 1]) {
                                _memory[2, 0] = i;
                                break;
                            }

                        /* 1 - Same label as stage 1 */
                    } else if (temp[0] == 2) {
                        MemoryOutputTextBox.Text = "Click on " + _memory[0, 1];
                        _memory[2, 1] = _memory[0, 1];

                        /* Find pos of label and add to array */
                        for (var i = 1; i <= temp.Length; i++)
                            if (temp[i] == _memory[0, 1]) {
                                _memory[2, 0] = i;
                                break;
                            }

                        /* 1 - Third position */
                    } else if (temp[0] == 3) {
                        MemoryOutputTextBox.Text = "Click on " + temp[3];
                        _memory[2, 1] = temp[3];
                        _memory[2, 0] = 3;

                        /* 4 - Labeled "4" */
                    } else {
                        if (temp[0] == 4) {
                            MemoryOutputTextBox.Text = "Click on 4";
                            _memory[2, 1] = 4;

                            /* Find label "4" and add to array */
                            for (var i = 1; i <= temp.Length; i++)
                                if (temp[i] == 4) {
                                    /* Get pos number */
                                    _memory[2, 0] = i;
                                    break;
                                }
                        }
                    }

                    Console.WriteLine("[Round 3]: " + temp[0] + temp[1] + temp[2] +
                                      temp[3] + temp[4] + "  Pos: " + _memory[2, 0] + ", Num: " +
                                      _memory[2, 1]);
                    break;
                case 4:
                    MemoryCurrentRoundTextBox.Text = "80% Done";

                    /* 1 -> Same position as stage 1 */
                    if (temp[0] == 1) {
                        _memory[3, 0] = _memory[0, 0];
                        _memory[3, 1] = temp[_memory[3, 0]];
                        MemoryOutputTextBox.Text = "Click on " + _memory[3, 1];

                        /* 2 -> First position */
                    } else if (temp[0] == 2) {
                        MemoryOutputTextBox.Text = "Click on " + temp[1];
                        _memory[3, 1] = temp[1];
                        _memory[3, 0] = 1;

                        /* 3 and 4 -> Same position as stage 2 */
                    } else {
                        _memory[3, 0] = _memory[1, 0];
                        _memory[3, 1] = temp[_memory[3, 0]];
                        MemoryOutputTextBox.Text = "Click on " + _memory[3, 1];
                    }

                    Console.WriteLine("[Round 4]: " + temp[0] + temp[1] + temp[2] +
                                      temp[3] + temp[4] + "  Pos: " + _memory[3, 0] + ", Num: " +
                                      _memory[3, 1]);
                    break;
                case 5:
                    MemoryCurrentRoundTextBox.Text = "100% Done";

                    /* 1 - Same label as stage 1 */
                    if (temp[0] == 1) {
                        MemoryOutputTextBox.Text = "Click on " + _memory[0, 1];
                        _memory[4, 1] = _memory[0, 1];

                        /* Find pos of label and add to array */
                        for (var i = 1; i <= temp.Length; i++)
                            if (temp[i] == _memory[0, 1]) {
                                _memory[4, 0] = i;
                                break;
                            }

                        /* 1 - Same label as stage 2 */
                    } else if (temp[0] == 2) {
                        MemoryOutputTextBox.Text = "Click on " + _memory[1, 1];
                        _memory[4, 1] = _memory[1, 1];

                        /* Find pos of label and add to array */
                        for (var i = 1; i <= temp.Length; i++)
                            if (temp[i] == _memory[1, 1]) {
                                _memory[4, 0] = i;
                                break;
                            }

                        /* 1 - Same label as stage 4 */
                    } else if (temp[0] == 3) {
                        MemoryOutputTextBox.Text = "Click on " + _memory[3, 1];
                        _memory[4, 1] = _memory[3, 1];

                        /* Find pos of label and add to array */
                        for (var i = 1; i <= temp.Length; i++)
                            if (temp[i] == _memory[3, 1]) {
                                _memory[4, 0] = i;
                                break;
                            }

                        /* 1 - Same label as stage 3 */
                    } else {
                        MemoryOutputTextBox.Text = "Click on " + _memory[2, 1];
                        _memory[4, 1] = _memory[2, 1];

                        /* Find pos of label and add to array */
                        for (var i = 1; i <= temp.Length; i++)
                            if (temp[i] == _memory[2, 1]) {
                                _memory[4, 0] = i;
                                break;
                            }
                    }

                    Console.WriteLine("[Round 5]: " + temp[0] + temp[1] + temp[2] +
                                      temp[3] + temp[4] + "  Pos: " + _memory[4, 0] + ", Num: " +
                                      _memory[4, 1]);
                    break;
            }
        }

        private void Memory_ClearButton_OnClick(object sender, RoutedEventArgs e) {
            _memory = new[,] {{0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}};
            _memoryRound = 1;

            MemoryInputTextBox.Text = "";
            MemoryCurrentRoundTextBox.Text = "0% Done";
            MemoryOutputTextBox.Text = "";
            MemoryInput1Button.IsEnabled = true;
            MemoryInput2Button.IsEnabled = true;
            MemoryInput3Button.IsEnabled = true;
            MemoryInput4Button.IsEnabled = true;
            MemoryConfirmButton.IsEnabled = false;
        }

        private void MemoryClearInputButton_OnClick(object sender, RoutedEventArgs e) {
            MemoryInput1Button.IsEnabled = true;
            MemoryInput2Button.IsEnabled = true;
            MemoryInput3Button.IsEnabled = true;
            MemoryInput4Button.IsEnabled = true;
            MemoryConfirmButton.IsEnabled = false;
            MemoryInputTextBox.Text = "";
        }

        private void Memory_ConfirmButton_OnClick(object sender, RoutedEventArgs e) {
            MemoryLogic();
            _memoryRound++;

            MemoryInputTextBox.Text = "";
            MemoryConfirmButton.IsEnabled = false;

            if (_memoryRound > 5) {
                MemoryInput1Button.IsEnabled = false;
                MemoryInput2Button.IsEnabled = false;
                MemoryInput3Button.IsEnabled = false;
                MemoryInput4Button.IsEnabled = false;
            } else {
                MemoryInput1Button.IsEnabled = true;
                MemoryInput2Button.IsEnabled = true;
                MemoryInput3Button.IsEnabled = true;
                MemoryInput4Button.IsEnabled = true;
            }
        }

        private void MemoryInput1Button_OnClick(object sender, RoutedEventArgs e) {
            if (MemoryInputTextBox.Text != "") MemoryInput1Button.IsEnabled = false;

            if (MemoryInputTextBox.Text.Length == 4) MemoryConfirmButton.IsEnabled = true;

            MemoryInputTextBox.Text = MemoryInputTextBox.Text + "1";
        }

        private void MemoryInput2Button_OnClick(object sender, RoutedEventArgs e) {
            if (MemoryInputTextBox.Text != "") MemoryInput2Button.IsEnabled = false;

            if (MemoryInputTextBox.Text.Length == 4) MemoryConfirmButton.IsEnabled = true;

            MemoryInputTextBox.Text = MemoryInputTextBox.Text + "2";
        }

        private void MemoryInput3Button_OnClick(object sender, RoutedEventArgs e) {
            if (MemoryInputTextBox.Text != "") MemoryInput3Button.IsEnabled = false;

            if (MemoryInputTextBox.Text.Length == 4) MemoryConfirmButton.IsEnabled = true;

            MemoryInputTextBox.Text = MemoryInputTextBox.Text + "3";
        }

        private void MemoryInput4Button_OnClick(object sender, RoutedEventArgs e) {
            if (MemoryInputTextBox.Text != "") MemoryInput4Button.IsEnabled = false;

            if (MemoryInputTextBox.Text.Length == 4) MemoryConfirmButton.IsEnabled = true;

            MemoryInputTextBox.Text = MemoryInputTextBox.Text + "4";
        }

        #endregion

        #region Complicated_Wires

        private void ComplicatedWiresButton_OnClick(object sender, RoutedEventArgs e) {
            MainButtonsView.Visibility = Visibility.Hidden;
            ComplicatedWiresView.Visibility = Visibility.Visible;
        }

        private void ComplicatedWires_ClearButton_OnClick(object sender, RoutedEventArgs e) {
            ComplicatedWiresWhiteButton.IsEnabled = true;
            ComplicatedWiresBlueButton.IsEnabled = true;
            ComplicatedWiresRedButton.IsEnabled = true;
            ComplicatedWiresRedAndBlueButton.IsEnabled = true;
            ComplicatedWiresStarButton.IsEnabled = true;
            ComplicatedWiresLedButton.IsEnabled = true;

            ComplicatedWiresWireTextbox.Text = "";
            ComplicatedWiresWireTextbox.Background = Brushes.White;
            ComplicatedWiresOutputTextbox.Text = "";
            ComplicatedWiresLedTextbox.Text = "FALSE";
            ComplicatedWiresLedTextbox.Background = Brushes.LightGray;
            ComplicatedWiresStarTextbox.Text = "FALSE";
            ComplicatedWiresStarTextbox.Background = Brushes.LightGray;

            _complicatedWireType = 0;
            _complicatedWireLed = false;
            _complicatedWireStar = false;
        }

        private void ComplicatedWires_ConfirmButton_OnClick(object sender, RoutedEventArgs e) {
            ComplicatedWiresWhiteButton.IsEnabled = false;
            ComplicatedWiresBlueButton.IsEnabled = false;
            ComplicatedWiresRedButton.IsEnabled = false;
            ComplicatedWiresRedAndBlueButton.IsEnabled = false;
            ComplicatedWiresStarButton.IsEnabled = false;
            ComplicatedWiresLedButton.IsEnabled = false;
            ComplicatedWiresConfirmButton.IsEnabled = false;

            switch (_complicatedWireType) {
                /* White Wire */
                case 1:
                    /* Star and LED */
                    if (_complicatedWireStar && _complicatedWireLed)
                        ComplicatedWiresOutputTextbox.Text = BatterySlider.Value > 1 ? "CUT" : "DO NOT CUT";
                    else if (_complicatedWireLed)
                        ComplicatedWiresOutputTextbox.Text = "DO NOT CUT";
                    else
                        ComplicatedWiresOutputTextbox.Text = "CUT";

                    break;
                /* Blue Wire */
                case 2:
                    /* Star and LED && LED only */
                    if (_complicatedWireLed)
                        ComplicatedWiresOutputTextbox.Text = HasPp.IsChecked == true ? "CUT" : "DO NOT CUT";
                    else if (_complicatedWireStar)
                        ComplicatedWiresOutputTextbox.Text = "DO NOT CUT";
                    else
                        ComplicatedWiresOutputTextbox.Text = _isSerialEven ? "CUT" : "DO NOT CUT";

                    break;

                /* Red Wire */
                case 3:
                    /* Star and LED && LED only */
                    if (_complicatedWireLed)
                        ComplicatedWiresOutputTextbox.Text = BatterySlider.Value > 1 ? "CUT" : "DO NOT CUT";
                    else if (_complicatedWireStar)
                        ComplicatedWiresOutputTextbox.Text = "CUT";
                    else
                        ComplicatedWiresOutputTextbox.Text = _isSerialEven ? "CUT" : "DO NOT CUT";

                    break;

                /* Red and Blue Wire */
                case 4:
                    /* Star and LED */
                    if (_complicatedWireStar && _complicatedWireLed)
                        ComplicatedWiresOutputTextbox.Text = "DO NOT CUT";
                    else if (_complicatedWireStar)
                        ComplicatedWiresOutputTextbox.Text = HasPp.IsChecked == true ? "CUT" : "DO NOT CUT";
                    else
                        ComplicatedWiresOutputTextbox.Text = _isSerialEven ? "CUT" : "DO NOT CUT";

                    break;
            }
        }

        private void ComplicatedWiresWhiteButton_OnClick(object sender, RoutedEventArgs e) {
            _complicatedWireType = 1;
            ComplicatedWiresWireTextbox.Text = "White";
            ComplicatedWiresWireTextbox.Background = Brushes.White;
            ComplicatedWiresWireTextbox.Foreground = Brushes.Black;
            ComplicatedWiresConfirmButton.IsEnabled = true;
        }

        private void ComplicatedWiresBlueButton_OnClick(object sender, RoutedEventArgs e) {
            _complicatedWireType = 2;
            ComplicatedWiresWireTextbox.Text = "Blue or Blue/White";
            ComplicatedWiresWireTextbox.Background = Brushes.Blue;
            ComplicatedWiresWireTextbox.Foreground = Brushes.White;
            ComplicatedWiresConfirmButton.IsEnabled = true;
        }

        private void ComplicatedWiresRedButton_OnClick(object sender, RoutedEventArgs e) {
            _complicatedWireType = 3;
            ComplicatedWiresWireTextbox.Text = "Red or Red/White";
            ComplicatedWiresWireTextbox.Background = Brushes.Red;
            ComplicatedWiresWireTextbox.Foreground = Brushes.White;
            ComplicatedWiresConfirmButton.IsEnabled = true;
        }

        private void ComplicatedWiresRedAndBlueButton_OnClick(object sender, RoutedEventArgs e) {
            _complicatedWireType = 4;
            ComplicatedWiresWireTextbox.Text = "Blue/Red";
            ComplicatedWiresWireTextbox.Background = Brushes.Violet;
            ComplicatedWiresWireTextbox.Foreground = Brushes.White;
            ComplicatedWiresConfirmButton.IsEnabled = true;
        }

        private void ComplicatedWiresLedButton_OnClick(object sender, RoutedEventArgs e) {
            /* Swap current boolean value */
            _complicatedWireLed = !_complicatedWireLed;

            if (_complicatedWireLed) {
                ComplicatedWiresLedTextbox.Text = "TRUE";
                ComplicatedWiresLedTextbox.Background = Brushes.Yellow;
            } else {
                ComplicatedWiresLedTextbox.Text = "FALSE";
                ComplicatedWiresLedTextbox.Background = Brushes.LightGray;
            }
        }

        private void ComplicatedWiresStarButton_OnClick(object sender, RoutedEventArgs e) {
            /* Swap current boolean value */
            _complicatedWireStar = !_complicatedWireStar;
            if (_complicatedWireStar) {
                ComplicatedWiresStarTextbox.Text = "TRUE";
                ComplicatedWiresStarTextbox.Background = Brushes.Yellow;
            } else {
                ComplicatedWiresStarTextbox.Text = "FALSE";
                ComplicatedWiresStarTextbox.Background = Brushes.LightGray;
            }
        }

        #endregion

        #region Wire_Sequence

        private void WireSquButton_OnClick(object sender, RoutedEventArgs e) {
            WireSequenceView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        private void SeqWires_ClearButton_OnClick(object sender, RoutedEventArgs e) {
            _wireSeqTotals = new[] {0, 0, 0};
            WireSeqBlackOccurTextbox.Text = "0";
            WireSeqRedOccurTextbox.Text = "0";
            WireSeqBlueOccurTextbox.Text = "0";
            WireSeqOutputTextbox.Text = "";

            WireSeqBlackAButton.IsEnabled = true;
            WireSeqBlackBButton.IsEnabled = true;
            WireSeqBlackCButton.IsEnabled = true;
            WireSeqBlueAButton.IsEnabled = true;
            WireSeqBlueBButton.IsEnabled = true;
            WireSeqBlueCButton.IsEnabled = true;
            WireSeqRedAButton.IsEnabled = true;
            WireSeqRedBButton.IsEnabled = true;
            WireSeqRedCButton.IsEnabled = true;
        }

        private void SeqWiresLogic(int color, int letter) {
            switch (color) {
                case 1:
                    /* Black Wire */
                    _wireSeqTotals[0]++;

                    switch (_wireSeqTotals[0]) {
                        case 1:
                            WireSeqOutputTextbox.Text = "CUT";
                            break;
                        case 2:
                            if (letter == 1 || letter == 3)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 3:
                            WireSeqOutputTextbox.Text = letter == 2 ? "CUT" : "DO NOT CUT";
                            break;
                        case 4:
                            if (letter == 1 || letter == 3)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 5:
                            WireSeqOutputTextbox.Text = letter == 2 ? "CUT" : "DO NOT CUT";
                            break;
                        case 6:
                            if (letter == 2 || letter == 3)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 7:
                            if (letter == 1 || letter == 2)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 8:
                            WireSeqOutputTextbox.Text = letter == 3 ? "CUT" : "DO NOT CUT";
                            break;
                        case 9:
                            WireSeqOutputTextbox.Text = letter == 3 ? "CUT" : "DO NOT CUT";
                            WireSeqBlackAButton.IsEnabled = false;
                            WireSeqBlackBButton.IsEnabled = false;
                            WireSeqBlackCButton.IsEnabled = false;
                            break;
                    }

                    break;
                case 2:
                    /* Blue Wire */
                    _wireSeqTotals[1]++;

                    switch (_wireSeqTotals[1]) {
                        case 1:
                            WireSeqOutputTextbox.Text = letter == 2 ? "CUT" : "DO NOT CUT";
                            break;
                        case 2:
                            if (letter == 1 || letter == 3)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 3:
                            WireSeqOutputTextbox.Text = letter == 2 ? "CUT" : "DO NOT CUT";
                            break;
                        case 4:
                            WireSeqOutputTextbox.Text = letter == 1 ? "CUT" : "DO NOT CUT";
                            break;
                        case 5:
                            WireSeqOutputTextbox.Text = letter == 2 ? "CUT" : "DO NOT CUT";
                            break;
                        case 6:
                            if (letter == 2 || letter == 3)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 7:
                            WireSeqOutputTextbox.Text = letter == 3 ? "CUT" : "DO NOT CUT";
                            break;
                        case 8:
                            if (letter == 1 || letter == 3)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 9:
                            WireSeqOutputTextbox.Text = letter == 1 ? "CUT" : "DO NOT CUT";
                            WireSeqBlueAButton.IsEnabled = false;
                            WireSeqBlueBButton.IsEnabled = false;
                            WireSeqBlueCButton.IsEnabled = false;
                            break;
                    }

                    break;
                case 3:
                    /* Red Wire */
                    _wireSeqTotals[2]++;

                    switch (_wireSeqTotals[2]) {
                        case 1:
                            WireSeqOutputTextbox.Text = letter == 3 ? "CUT" : "DO NOT CUT";
                            break;
                        case 2:
                            WireSeqOutputTextbox.Text = letter == 2 ? "CUT" : "DO NOT CUT";
                            break;
                        case 3:
                            WireSeqOutputTextbox.Text = letter == 1 ? "CUT" : "DO NOT CUT";
                            break;
                        case 4:
                            if (letter == 1 || letter == 3)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 5:
                            WireSeqOutputTextbox.Text = letter == 2 ? "CUT" : "DO NOT CUT";
                            break;
                        case 6:
                            if (letter == 1 || letter == 3)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 7:
                            WireSeqOutputTextbox.Text = "CUT";
                            break;
                        case 8:
                            if (letter == 1 || letter == 2)
                                WireSeqOutputTextbox.Text = "CUT";
                            else
                                WireSeqOutputTextbox.Text = "DO NOT CUT";

                            break;
                        case 9:
                            WireSeqOutputTextbox.Text = letter == 2 ? "CUT" : "DO NOT CUT";
                            WireSeqRedAButton.IsEnabled = false;
                            WireSeqRedBButton.IsEnabled = false;
                            WireSeqRedCButton.IsEnabled = false;
                            break;
                    }

                    break;
            }

            WireSeqBlackOccurTextbox.Text = _wireSeqTotals[0].ToString();
            WireSeqBlueOccurTextbox.Text = _wireSeqTotals[1].ToString();
            WireSeqRedOccurTextbox.Text = _wireSeqTotals[2].ToString();
        }

        private void WireSeqBlackAButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(1, 1);
        }

        private void WireSeqBlackBButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(1, 2);
        }

        private void WireSeqBlackCButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(1, 3);
        }

        private void WireSeqBlueAButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(2, 1);
        }

        private void WireSeqBlueBButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(2, 2);
        }

        private void WireSeqBlueCButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(2, 3);
        }

        private void WireSeqRedAButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(3, 1);
        }

        private void WireSeqRedBButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(3, 2);
        }

        private void WireSeqRedCButton_OnClick(object sender, RoutedEventArgs e) {
            SeqWiresLogic(3, 3);
        }

        #endregion

        #region Whos_On_First

        private void WhoOnFirstButton_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        private void WhoOnFirstSwitchView_OnClick(object sender, RoutedEventArgs e) {
            _whoOnFirstView = !_whoOnFirstView;

            WhoOnFirstOutput1TextBox.Text = "";
            WhoOnFirstOutput2TextBox.Text = " \n ";

            if (_whoOnFirstView) {
                WhoOnFirstPage1View.Visibility = Visibility.Collapsed;
                WhoOnFirstPage2View.Visibility = Visibility.Visible;
                WhoOnFirstOutput1TextBox.Visibility = Visibility.Visible;
                WhoOnFirstOutput2TextBox.Visibility = Visibility.Visible;
            } else {
                WhoOnFirstPage1View.Visibility = Visibility.Visible;
                WhoOnFirstPage2View.Visibility = Visibility.Collapsed;
                WhoOnFirstOutput1TextBox.Visibility = Visibility.Hidden;
                WhoOnFirstOutput2TextBox.Visibility = Visibility.Hidden;
            }
        }

        private void WhoOnFirstButton01_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "BLANK";
            WhoOnFirstOutput2TextBox.Text =
                "WAIT, RIGHT, OKAY, MIDDLE, BLANK, PRESS, READY, NOTHING, NO, WHAT, LEFT, UHHH, YES, FIRST";
        }

        private void WhoOnFirstButton02_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "DONE";
            WhoOnFirstOutput2TextBox.Text =
                "SURE, UH HUH, NEXT, WHAT?, YOUR, UR, YOU'RE, HOLD, LIKE, YOU, U, YOU ARE, UH UH, DONE";
        }

        private void WhoOnFirstButton03_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "FIRST";
            WhoOnFirstOutput2TextBox.Text =
                "LEFT, OKAY, YES, MIDDLE, NO, RIGHT, NOTHING, UHHH, WAIT, READY, BLANK, WHAT, PRESS, FIRST";
        }

        private void WhoOnFirstButton04_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "HOLD";
            WhoOnFirstOutput2TextBox.Text =
                "YOU ARE, U, DONE, UH UH, YOU, UR, SURE, WHAT?, YOU'RE, NEXT, HOLD, UH HUH, YOUR, LIKE";
        }

        private void WhoOnFirstButton05_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "LEFT";
            WhoOnFirstOutput2TextBox.Text =
                "RIGHT, LEFT, FIRST, NO, MIDDLE, YES, BLANK, WHAT, UHHH, WAIT, PRESS, READY, OKAY, NOTHING";
        }

        private void WhoOnFirstButton06_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "LIKE";
            WhoOnFirstOutput2TextBox.Text =
                "YOU'RE, NEXT, U, UR, HOLD, DONE, UH UH, WHAT?, UH HUH, YOU, LIKE, SURE, YOU ARE, YOUR";
        }

        private void WhoOnFirstButton07_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "MIDDLE";
            WhoOnFirstOutput2TextBox.Text =
                "BLANK, READY, OKAY, WHAT, NOTHING, PRESS, NO, WAIT, LEFT, MIDDLE, RIGHT, FIRST, UHHH, YES";
        }

        private void WhoOnFirstButton08_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "NEXT";
            WhoOnFirstOutput2TextBox.Text =
                "WHAT?, UH HUH, UH UH, YOUR, HOLD, SURE, NEXT, LIKE, DONE, YOU ARE, UR, YOU'RE, U, YOU";
        }

        private void WhoOnFirstButton09_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "NO";
            WhoOnFirstOutput2TextBox.Text =
                "BLANK, UHHH, WAIT, FIRST, WHAT, READY, RIGHT, YES, NOTHING, LEFT, PRESS, OKAY, NO, MIDDLE";
        }

        private void WhoOnFirstButton10_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "NOTHING";
            WhoOnFirstOutput2TextBox.Text =
                "UHHH, RIGHT, OKAY, MIDDLE, YES, BLANK, NO, PRESS, LEFT, WHAT, WAIT, FIRST, NOTHING, READY";
        }

        private void WhoOnFirstButton11_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "OKAY";
            WhoOnFirstOutput2TextBox.Text =
                "MIDDLE, NO, FIRST, YES, UHHH, NOTHING, WAIT, OKAY, LEFT, READY, BLANK, PRESS, WHAT, RIGHT";
        }

        private void WhoOnFirstButton12_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "PRESS";
            WhoOnFirstOutput2TextBox.Text =
                "RIGHT, MIDDLE, YES, READY, PRESS, OKAY, NOTHING, UHHH, BLANK, LEFT, FIRST, WHAT, NO, WAIT";
        }

        private void WhoOnFirstButton13_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "READY";
            WhoOnFirstOutput2TextBox.Text =
                "YES, OKAY, WHAT, MIDDLE, LEFT, PRESS, RIGHT, BLANK, READY, NO, FIRST, UHHH, NOTHING, WAIT";
        }

        private void WhoOnFirstButton14_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "RIGHT";
            WhoOnFirstOutput2TextBox.Text =
                "YES, NOTHING, READY, PRESS, NO, WAIT, WHAT, RIGHT, MIDDLE, LEFT, UHHH, BLANK, OKAY, FIRST";
        }

        private void WhoOnFirstButton15_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "SURE";
            WhoOnFirstOutput2TextBox.Text =
                "YOU ARE, DONE, LIKE, YOU'RE, YOU, HOLD, UH HUH, UR, SURE, U, WHAT?, NEXT, YOUR, UH UH";
        }

        private void WhoOnFirstButton16_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "U";
            WhoOnFirstOutput2TextBox.Text =
                "UH HUH, SURE, NEXT, WHAT?, YOU'RE, UR, UH UH, DONE, U, YOU, LIKE, HOLD, YOU ARE, YOUR";
        }

        private void WhoOnFirstButton17_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "UH HUH";
            WhoOnFirstOutput2TextBox.Text =
                "UH HUH, YOUR, YOU ARE, YOU, DONE, HOLD, UH UH, NEXT, SURE, LIKE, YOU'RE, UR, U, WHAT?";
        }

        private void WhoOnFirstButton18_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "UH UH";
            WhoOnFirstOutput2TextBox.Text =
                "UR, U, YOU ARE, YOU'RE, NEXT, UH UH, DONE, YOU, UH HUH, LIKE, YOUR, SURE, HOLD, WHAT?";
        }

        private void WhoOnFirstButton19_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "UHHH";
            WhoOnFirstOutput2TextBox.Text =
                "READY, NOTHING, LEFT, WHAT, OKAY, YES, RIGHT, NO, PRESS, BLANK, UHHH, MIDDLE, WAIT, FIRST";
        }

        private void WhoOnFirstButton20_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "UR";
            WhoOnFirstOutput2TextBox.Text =
                "DONE, U, UR, UH HUH, WHAT?, SURE, YOUR, HOLD, YOU'RE, LIKE, NEXT, UH UH, YOU ARE, YOU";
        }

        private void WhoOnFirstButton21_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "WAIT";
            WhoOnFirstOutput2TextBox.Text =
                "UHHH, NO, BLANK, OKAY, YES, LEFT, FIRST, PRESS, WHAT, WAIT, NOTHING, READY, RIGHT, MIDDLE";
        }

        private void WhoOnFirstButton22_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "WHAT";
            WhoOnFirstOutput2TextBox.Text =
                "UHHH, WHAT, LEFT, NOTHING, READY, BLANK, MIDDLE, NO, OKAY, FIRST, WAIT, YES, PRESS, RIGHT";
        }

        private void WhoOnFirstButton23_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "WHAT?";
            WhoOnFirstOutput2TextBox.Text =
                "YOU, HOLD, YOU'RE, YOUR, U, DONE, UH UH, LIKE, YOU ARE, UH HUH, UR, NEXT, WHAT?, SURE";
        }

        private void WhoOnFirstButton24_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "YES";
            WhoOnFirstOutput2TextBox.Text =
                "OKAY, RIGHT, UHHH, MIDDLE, FIRST, WHAT, PRESS, READY, NOTHING, YES, LEFT, BLANK, NO, WAIT";
        }

        private void WhoOnFirstButton25_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "YOU";
            WhoOnFirstOutput2TextBox.Text =
                "SURE, YOU ARE, YOUR, YOU'RE, NEXT, UH HUH, UR, HOLD, WHAT?, YOU, UH UH, LIKE, DONE, U";
        }

        private void WhoOnFirstButton26_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "YOU ARE";
            WhoOnFirstOutput2TextBox.Text =
                "YOUR, NEXT, LIKE, UH HUH, WHAT?, DONE, UH UH, HOLD, YOU, U, YOU'RE, SURE, UR, YOU ARE";
        }

        private void WhoOnFirstButton27_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "YOUR";
            WhoOnFirstOutput2TextBox.Text =
                "UH UH, YOU ARE, UH HUH, YOUR, NEXT, UR, SURE, U, YOU'RE, YOU, WHAT?, HOLD, LIKE, DONE";
        }

        private void WhoOnFirstButton28_OnClick(object sender, RoutedEventArgs e) {
            WhoOnFirstOutput1TextBox.Text = "YOU'RE";
            WhoOnFirstOutput2TextBox.Text =
                "YOU, YOU'RE, UR, NEXT, UH UH, YOU ARE, U, YOUR, WHAT?, UH HUH, SURE, DONE, LIKE, HOLD";
        }

        #endregion

        #region Maze

        private void MazeButton_OnClick(object sender, RoutedEventArgs e) {
            MazeView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        private void Maze_ConfirmButton_OnClick(object sender, RoutedEventArgs e) {
            switch (MazeInputTextBox.Text) {
                case "12":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze1.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "1, 2";
                    break;
                case "52":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze2.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "5, 2";
                    break;
                case "44":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze3.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "4, 4";
                    break;
                case "11":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze4.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "1, 1";
                    break;
                case "53":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze5.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "5, 3";
                    break;
                case "51":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze6.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "5, 1";
                    break;
                case "21":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze7.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "2, 1";
                    break;
                case "41":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze8.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "4, 1";
                    break;
                case "32":
                    MazeImage.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/maze9.png",
                        UriKind.RelativeOrAbsolute));
                    MazeOutputTextBox.Text = "3, 2";
                    break;
            }

            MazeInputTextBox.Text = "";
        }

        private void MazeNumberValidation(object sender, TextCompositionEventArgs e) {
            var regex = new Regex("[^1-6]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MazeInputTextBox_OnTextChanged(object sender, TextChangedEventArgs e) {
            MazeConfirmButton.IsEnabled = MazeInputTextBox.Text.Length > 1;
        }

        #endregion

        #region MorseCode

        private void MorseCodeButton_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        private void MorseCodeLogic(int value) {
            switch (value) {
                case 1:
                    /* B words */
                    MorseCodeInput1Button.IsEnabled = false;
                    MorseCodeInput2Button.IsEnabled = false;
                    MorseCodeInput3Button.IsEnabled = false;
                    MorseCodeInput4Button.IsEnabled = false;
                    MorseCodeInput5Button.IsEnabled = false;
                    MorseCodeInput6Button.IsEnabled = false;
                    MorseCodeInput7Button.IsEnabled = false;
                    MorseCodeInput8Button.IsEnabled = true;
                    MorseCodeInput9Button.IsEnabled = true;
                    MorseCodeInput10Button.IsEnabled = true;
                    MorseCodeInput11Button.IsEnabled = true;
                    break;
                case 2:
                    /* "flick" */
                    MorseCodeOutputTextbox.Text = "555";
                    MorseCodeInput1Button.IsEnabled = false;
                    MorseCodeInput2Button.IsEnabled = false;
                    MorseCodeInput3Button.IsEnabled = false;
                    MorseCodeInput4Button.IsEnabled = false;
                    MorseCodeInput5Button.IsEnabled = false;
                    MorseCodeInput6Button.IsEnabled = false;
                    MorseCodeInput7Button.IsEnabled = false;
                    break;
                case 3:
                    /* "halls" */
                    MorseCodeOutputTextbox.Text = "515";
                    MorseCodeInput1Button.IsEnabled = false;
                    MorseCodeInput2Button.IsEnabled = false;
                    MorseCodeInput3Button.IsEnabled = false;
                    MorseCodeInput4Button.IsEnabled = false;
                    MorseCodeInput5Button.IsEnabled = false;
                    MorseCodeInput6Button.IsEnabled = false;
                    MorseCodeInput7Button.IsEnabled = false;
                    break;
                case 4:
                    /* "leaks" */
                    MorseCodeOutputTextbox.Text = "542";
                    MorseCodeInput1Button.IsEnabled = false;
                    MorseCodeInput2Button.IsEnabled = false;
                    MorseCodeInput3Button.IsEnabled = false;
                    MorseCodeInput4Button.IsEnabled = false;
                    MorseCodeInput5Button.IsEnabled = false;
                    MorseCodeInput6Button.IsEnabled = false;
                    MorseCodeInput7Button.IsEnabled = false;
                    break;
                case 5:
                    /* S words */
                    MorseCodeInput1Button.IsEnabled = false;
                    MorseCodeInput2Button.IsEnabled = false;
                    MorseCodeInput3Button.IsEnabled = false;
                    MorseCodeInput4Button.IsEnabled = false;
                    MorseCodeInput5Button.IsEnabled = false;
                    MorseCodeInput6Button.IsEnabled = false;
                    MorseCodeInput7Button.IsEnabled = false;
                    MorseCodeInput12Button.IsEnabled = true;
                    MorseCodeInput13Button.IsEnabled = true;
                    MorseCodeInput14Button.IsEnabled = true;
                    break;
                case 6:
                    /* "trick" */
                    MorseCodeOutputTextbox.Text = "532";
                    MorseCodeInput1Button.IsEnabled = false;
                    MorseCodeInput2Button.IsEnabled = false;
                    MorseCodeInput3Button.IsEnabled = false;
                    MorseCodeInput4Button.IsEnabled = false;
                    MorseCodeInput5Button.IsEnabled = false;
                    MorseCodeInput6Button.IsEnabled = false;
                    MorseCodeInput7Button.IsEnabled = false;
                    break;
                case 7:
                    /* "vector" */
                    MorseCodeOutputTextbox.Text = "595";
                    MorseCodeInput1Button.IsEnabled = false;
                    MorseCodeInput2Button.IsEnabled = false;
                    MorseCodeInput3Button.IsEnabled = false;
                    MorseCodeInput4Button.IsEnabled = false;
                    MorseCodeInput5Button.IsEnabled = false;
                    MorseCodeInput6Button.IsEnabled = false;
                    MorseCodeInput7Button.IsEnabled = false;
                    break;
                case 8:
                    /* "beats" */
                    MorseCodeOutputTextbox.Text = "600";
                    MorseCodeInput8Button.IsEnabled = false;
                    MorseCodeInput9Button.IsEnabled = false;
                    MorseCodeInput10Button.IsEnabled = false;
                    MorseCodeInput11Button.IsEnabled = false;
                    break;
                case 9:
                    /* "bistro" */
                    MorseCodeOutputTextbox.Text = "552";
                    MorseCodeInput8Button.IsEnabled = false;
                    MorseCodeInput9Button.IsEnabled = false;
                    MorseCodeInput10Button.IsEnabled = false;
                    MorseCodeInput11Button.IsEnabled = false;
                    break;
                case 10:
                    /* B-O words */
                    MorseCodeInput8Button.IsEnabled = false;
                    MorseCodeInput9Button.IsEnabled = false;
                    MorseCodeInput10Button.IsEnabled = false;
                    MorseCodeInput11Button.IsEnabled = false;
                    MorseCodeInput15Button.IsEnabled = true;
                    MorseCodeInput16Button.IsEnabled = true;
                    break;
                case 11:
                    /* B-R words */
                    MorseCodeInput8Button.IsEnabled = false;
                    MorseCodeInput9Button.IsEnabled = false;
                    MorseCodeInput10Button.IsEnabled = false;
                    MorseCodeInput11Button.IsEnabled = false;
                    MorseCodeInput17Button.IsEnabled = true;
                    MorseCodeInput18Button.IsEnabled = true;
                    break;
                case 12:
                    /* "shell" */
                    MorseCodeOutputTextbox.Text = "505";
                    MorseCodeInput12Button.IsEnabled = false;
                    MorseCodeInput13Button.IsEnabled = false;
                    MorseCodeInput14Button.IsEnabled = false;
                    break;
                case 13:
                    /* "slick" */
                    MorseCodeOutputTextbox.Text = "522";
                    MorseCodeInput12Button.IsEnabled = false;
                    MorseCodeInput13Button.IsEnabled = false;
                    MorseCodeInput14Button.IsEnabled = false;
                    break;
                case 14:
                    MorseCodeInput12Button.IsEnabled = false;
                    MorseCodeInput13Button.IsEnabled = false;
                    MorseCodeInput14Button.IsEnabled = false;
                    MorseCodeInput17Button.IsEnabled = true;
                    MorseCodeInput18Button.IsEnabled = true;
                    MorseCodeInput19Button.IsEnabled = true;
                    break;
                case 15:
                    /* bomb */
                    MorseCodeOutputTextbox.Text = "565";
                    MorseCodeInput15Button.IsEnabled = false;
                    MorseCodeInput16Button.IsEnabled = false;
                    MorseCodeInput17Button.IsEnabled = false;
                    MorseCodeInput18Button.IsEnabled = false;
                    break;
                case 16:
                    /* boxes */
                    MorseCodeOutputTextbox.Text = "535";
                    MorseCodeInput15Button.IsEnabled = false;
                    MorseCodeInput16Button.IsEnabled = false;
                    MorseCodeInput17Button.IsEnabled = false;
                    MorseCodeInput18Button.IsEnabled = false;
                    break;
                case 17:
                    if (_isMorseModeB) {
                        /* break */
                        MorseCodeOutputTextbox.Text = "572";
                        MorseCodeInput15Button.IsEnabled = false;
                        MorseCodeInput16Button.IsEnabled = false;
                        MorseCodeInput17Button.IsEnabled = false;
                        MorseCodeInput18Button.IsEnabled = false;
                    } else {
                        /* steak */
                        MorseCodeOutputTextbox.Text = "582";
                        MorseCodeInput16Button.IsEnabled = false;
                        MorseCodeInput17Button.IsEnabled = false;
                        MorseCodeInput18Button.IsEnabled = false;
                        MorseCodeInput19Button.IsEnabled = false;
                    }

                    break;
                case 18:
                    if (_isMorseModeB) {
                        /* brick */
                        MorseCodeOutputTextbox.Text = "575";
                        MorseCodeInput15Button.IsEnabled = false;
                        MorseCodeInput16Button.IsEnabled = false;
                        MorseCodeInput17Button.IsEnabled = false;
                        MorseCodeInput18Button.IsEnabled = false;
                    } else {
                        /* sting */
                        MorseCodeOutputTextbox.Text = "592";
                        MorseCodeInput16Button.IsEnabled = false;
                        MorseCodeInput17Button.IsEnabled = false;
                        MorseCodeInput18Button.IsEnabled = false;
                        MorseCodeInput19Button.IsEnabled = false;
                    }

                    break;
                case 19:
                    /* strobe */
                    MorseCodeOutputTextbox.Text = "545";
                    MorseCodeInput16Button.IsEnabled = false;
                    MorseCodeInput17Button.IsEnabled = false;
                    MorseCodeInput18Button.IsEnabled = false;
                    MorseCodeInput19Button.IsEnabled = false;
                    break;
            }
        }

        private void MorseCode_ClearButton_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeInput1Button.IsEnabled = true;
            MorseCodeInput2Button.IsEnabled = true;
            MorseCodeInput3Button.IsEnabled = true;
            MorseCodeInput4Button.IsEnabled = true;
            MorseCodeInput5Button.IsEnabled = true;
            MorseCodeInput6Button.IsEnabled = true;
            MorseCodeInput7Button.IsEnabled = true;
            MorseCodeInput8Button.IsEnabled = false;
            MorseCodeInput9Button.IsEnabled = false;
            MorseCodeInput10Button.IsEnabled = false;
            MorseCodeInput11Button.IsEnabled = false;
            MorseCodeInput12Button.IsEnabled = false;
            MorseCodeInput13Button.IsEnabled = false;
            MorseCodeInput14Button.IsEnabled = false;
            MorseCodeInput15Button.IsEnabled = false;
            MorseCodeInput16Button.IsEnabled = false;
            MorseCodeInput17Button.IsEnabled = false;
            MorseCodeInput18Button.IsEnabled = false;
            MorseCodeInput19Button.IsEnabled = false;
            MorseCodeOutputTextbox.Text = "";
        }

        private void MorseCodeInput1Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(1);
            _isMorseModeB = true;
        }

        private void MorseCodeInput2Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(2);
        }

        private void MorseCodeInput3Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(3);
        }

        private void MorseCodeInput4Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(4);
        }

        private void MorseCodeInput5Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(5);
            _isMorseModeB = false;
        }

        private void MorseCodeInput6Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(6);
        }

        private void MorseCodeInput7Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(7);
        }

        private void MorseCodeInput8Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(8);
        }

        private void MorseCodeInput9Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(9);
        }

        private void MorseCodeInput10Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(10);
        }

        private void MorseCodeInput11Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(11);
        }

        private void MorseCodeInput12Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(12);
        }

        private void MorseCodeInput13Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(13);
        }

        private void MorseCodeInput14Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(14);
        }

        private void MorseCodeInput15Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(15);
        }

        private void MorseCodeInput16Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(16);
        }

        private void MorseCodeInput17Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(17);
        }

        private void MorseCodeInput18Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(18);
        }

        private void MorseCodeInput19Button_OnClick(object sender, RoutedEventArgs e) {
            MorseCodeLogic(19);
        }

        #endregion

        #region Keypad

        private void KeypadButton_OnClick(object sender, RoutedEventArgs e) {
            KeypadView.Visibility = Visibility.Visible;
            MainButtonsView.Visibility = Visibility.Hidden;
        }

        private void KeypadLogic(int value) {
            switch (_keypadRound) {
                case 0:
                    _keypadValues[0] = value;
                    break;
                case 1:
                    _keypadValues[1] = value;
                    break;
                case 2:
                    _keypadValues[2] = value;
                    break;
                case 3:
                    _keypadValues[3] = value;
                    Keypad1Button.IsEnabled = false;
                    Keypad2Button.IsEnabled = false;
                    Keypad3Button.IsEnabled = false;
                    Keypad4Button.IsEnabled = false;
                    Keypad5Button.IsEnabled = false;
                    Keypad6Button.IsEnabled = false;
                    Keypad7Button.IsEnabled = false;
                    Keypad8Button.IsEnabled = false;
                    Keypad9Button.IsEnabled = false;
                    Keypad10Button.IsEnabled = false;
                    Keypad11Button.IsEnabled = false;
                    Keypad12Button.IsEnabled = false;
                    Keypad13Button.IsEnabled = false;
                    Keypad14Button.IsEnabled = false;
                    Keypad15Button.IsEnabled = false;
                    Keypad16Button.IsEnabled = false;
                    Keypad17Button.IsEnabled = false;
                    Keypad18Button.IsEnabled = false;
                    Keypad19Button.IsEnabled = false;
                    Keypad20Button.IsEnabled = false;
                    Keypad21Button.IsEnabled = false;
                    Keypad22Button.IsEnabled = false;
                    Keypad23Button.IsEnabled = false;
                    Keypad24Button.IsEnabled = false;
                    Keypad25Button.IsEnabled = false;
                    Keypad26Button.IsEnabled = false;
                    Keypad27Button.IsEnabled = false;

                    /* Get correct list from array */
                    for (var i = 0; i < _keypadFinal.GetLength(0); i++) {
                        var counter = 0;
                        for (var j = 0; j < _keypadFinal.GetLength(1); j++)
                        for (var k = 0; k < _keypadValues.GetLength(0); k++)
                            if (_keypadValues[k] == _keypadFinal[i, j]) {
                                counter++;
                                if (counter > 3) {
                                    var keypadsOrdered = new List<int>();

                                    /* Get correct order for keypads */
                                    for (var m = 0; m < _keypadFinal.GetLength(1); m++)
                                    for (var n = 0; n < _keypadValues.GetLength(0); n++)
                                        if (_keypadValues[n] == _keypadFinal[i, m])
                                            keypadsOrdered.Add(_keypadValues[n]);

                                    /* Convert numbers into real visual output */
                                    foreach (var number in keypadsOrdered)
                                        switch (number) {
                                            case 1:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ԇ  ";
                                                break;
                                            case 2:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ѯ  ";
                                                break;
                                            case 3:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ϭ  ";
                                                break;
                                            case 4:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "ψ  ";
                                                break;
                                            case 5:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ѧ  ";
                                                break;
                                            case 6:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "æ  ";
                                                break;
                                            case 7:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ҩ  ";
                                                break;
                                            case 8:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "¿  ";
                                                break;
                                            case 9:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ӭ  ";
                                                break;
                                            case 10:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ͼ  ";
                                                break;
                                            case 11:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ͽ  ";
                                                break;
                                            case 12:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ϙ  ";
                                                break;
                                            case 13:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "ϰ  ";
                                                break;
                                            case 14:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "ϗ  ";
                                                break;
                                            case 15:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ҋ  ";
                                                break;
                                            case 16:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "¶  ";
                                                break;
                                            case 17:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ѣ  ";
                                                break;
                                            case 18:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ѭ  ";
                                                break;
                                            case 19:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Җ  ";
                                                break;
                                            case 20:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "ƛ  ";
                                                break;
                                            case 21:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "★  ";
                                                break;
                                            case 22:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "☆  ";
                                                break;
                                            case 23:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "ټ  ";
                                                break;
                                            case 24:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ѽ  ";
                                                break;
                                            case 25:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "҂  ";
                                                break;
                                            case 26:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "©  ";
                                                break;
                                            case 27:
                                                KeypadOutputTextbox.Text =
                                                    KeypadOutputTextbox.Text + "Ω  ";
                                                break;
                                        }

                                    return;
                                }
                            }
                    }

                    KeypadOutputTextbox.Text = "Not Valid";
                    break;
            }

            _keypadRound++;
        }

        private void Keypad_ClearButton_OnClick(object sender, RoutedEventArgs e) {
            _keypadRound = 0;
            KeypadOutputTextbox.Text = "";
            Keypad1Button.IsEnabled = true;
            Keypad2Button.IsEnabled = true;
            Keypad3Button.IsEnabled = true;
            Keypad4Button.IsEnabled = true;
            Keypad5Button.IsEnabled = true;
            Keypad6Button.IsEnabled = true;
            Keypad7Button.IsEnabled = true;
            Keypad8Button.IsEnabled = true;
            Keypad9Button.IsEnabled = true;
            Keypad10Button.IsEnabled = true;
            Keypad11Button.IsEnabled = true;
            Keypad12Button.IsEnabled = true;
            Keypad13Button.IsEnabled = true;
            Keypad14Button.IsEnabled = true;
            Keypad15Button.IsEnabled = true;
            Keypad16Button.IsEnabled = true;
            Keypad17Button.IsEnabled = true;
            Keypad18Button.IsEnabled = true;
            Keypad19Button.IsEnabled = true;
            Keypad20Button.IsEnabled = true;
            Keypad21Button.IsEnabled = true;
            Keypad22Button.IsEnabled = true;
            Keypad23Button.IsEnabled = true;
            Keypad24Button.IsEnabled = true;
            Keypad25Button.IsEnabled = true;
            Keypad26Button.IsEnabled = true;
            Keypad27Button.IsEnabled = true;
        }

        private void Keypad1Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad1Button.IsEnabled = false;
            KeypadLogic(1);
        }

        private void Keypad2Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad2Button.IsEnabled = false;
            KeypadLogic(2);
        }

        private void Keypad3Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad3Button.IsEnabled = false;
            KeypadLogic(3);
        }

        private void Keypad4Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad4Button.IsEnabled = false;
            KeypadLogic(4);
        }

        private void Keypad5Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad5Button.IsEnabled = false;
            KeypadLogic(5);
        }

        private void Keypad6Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad6Button.IsEnabled = false;
            KeypadLogic(6);
        }

        private void Keypad7Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad7Button.IsEnabled = false;
            KeypadLogic(7);
        }

        private void Keypad8Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad8Button.IsEnabled = false;
            KeypadLogic(8);
        }

        private void Keypad9Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad9Button.IsEnabled = false;
            KeypadLogic(9);
        }

        private void Keypad10Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad10Button.IsEnabled = false;
            KeypadLogic(10);
        }

        private void Keypad11Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad11Button.IsEnabled = false;
            KeypadLogic(11);
        }

        private void Keypad12Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad12Button.IsEnabled = false;
            KeypadLogic(12);
        }

        private void Keypad13Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad13Button.IsEnabled = false;
            KeypadLogic(13);
        }

        private void Keypad14Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad14Button.IsEnabled = false;
            KeypadLogic(14);
        }

        private void Keypad15Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad15Button.IsEnabled = false;
            KeypadLogic(15);
        }

        private void Keypad16Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad16Button.IsEnabled = false;
            KeypadLogic(16);
        }

        private void Keypad17Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad17Button.IsEnabled = false;
            KeypadLogic(17);
        }

        private void Keypad18Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad18Button.IsEnabled = false;
            KeypadLogic(18);
        }

        private void Keypad19Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad19Button.IsEnabled = false;
            KeypadLogic(19);
        }

        private void Keypad20Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad20Button.IsEnabled = false;
            KeypadLogic(20);
        }

        private void Keypad21Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad21Button.IsEnabled = false;
            KeypadLogic(21);
        }

        private void Keypad22Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad22Button.IsEnabled = false;
            KeypadLogic(22);
        }

        private void Keypad23Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad23Button.IsEnabled = false;
            KeypadLogic(23);
        }

        private void Keypad24Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad24Button.IsEnabled = false;
            KeypadLogic(24);
        }

        private void Keypad25Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad25Button.IsEnabled = false;
            KeypadLogic(25);
        }

        private void Keypad26Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad26Button.IsEnabled = false;
            KeypadLogic(26);
        }

        private void Keypad27Button_OnClick(object sender, RoutedEventArgs e) {
            Keypad27Button.IsEnabled = false;
            KeypadLogic(27);
        }

        #endregion
    }
}