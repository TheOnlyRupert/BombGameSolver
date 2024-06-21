using System;
using System.Collections.Generic;
using BombGameSolver.Source.ViewModel.Base;

namespace BombGameSolver.Source.ViewModel;

public class MazeModuleVM : BaseViewModel {
    private static readonly int[,,] MazeList = {
        {
            /* Maze 1,1 */ { 1, 0, 1, 2, 1, 0, 1, 0, 1, 0, 1 }, { 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0 },
            { 1, 2, 1, 2, 1, 0, 1, 0, 1, 0, 1 }, { 0, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0 }, { 1, 2, 1, 0, 1, 2, 1, 0, 1, 2, 1 },
            { 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0 }, { 1, 2, 1, 0, 1, 0, 1, 0, 1, 0, 1 }, { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
            { 1, 0, 1, 0, 1, 0, 1, 0, 1, 2, 1 }, { 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 0 }, { 1, 0, 1, 0, 1, 2, 1, 0, 1, 2, 1 }
        }, {
            /* Maze 1,2 */ { 1, 0, 1, 0, 1, 2, 1, 0, 1, 0, 1 }, { 0, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2 },
            { 1, 2, 1, 0, 1, 2, 1, 0, 1, 0, 1 }, { 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0 }, { 1, 2, 1, 0, 1, 2, 1, 0, 1, 0, 1 },
            { 0, 2, 2, 2, 0, 2, 0, 2, 2, 2, 0 }, { 1, 2, 1, 0, 1, 0, 1, 2, 1, 0, 1 }, { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
            { 1, 0, 1, 0, 1, 2, 1, 0, 1, 2, 1 }, { 0, 2, 2, 2, 0, 2, 0, 2, 2, 2, 0 }, { 1, 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 }
        }, {
            /* Maze 2,1 */ { 1, 0, 1, 0, 1, 0, 1, 2, 1, 0, 1 }, { 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 0 },
            { 1, 2, 1, 0, 1, 2, 1, 0, 1, 2, 1 }, { 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0 }, { 1, 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 },
            { 2, 2, 2, 2, 0, 2, 2, 2, 0, 2, 2 }, { 1, 0, 1, 2, 1, 0, 1, 0, 1, 2, 1 }, { 0, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0 },
            { 1, 2, 1, 2, 1, 0, 1, 0, 1, 2, 1 }, { 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 0 }, { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }
        }, {
            /* Maze 2,4 */ { 1, 0, 1, 0, 1, 2, 1, 0, 1, 0, 1 }, { 2, 2, 0, 2, 2, 2, 0, 2, 0, 2, 2 },
            { 1, 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 }, { 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0 }, { 1, 2, 1, 0, 1, 2, 1, 0, 1, 0, 1 },
            { 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 0 }, { 1, 0, 1, 2, 1, 0, 1, 2, 1, 2, 1 }, { 0, 2, 2, 2, 0, 2, 2, 2, 0, 2, 0 },
            { 1, 2, 1, 2, 1, 2, 1, 0, 1, 2, 1 }, { 0, 2, 0, 2, 0, 2, 0, 2, 2, 2, 0 }, { 1, 2, 1, 0, 1, 2, 1, 0, 1, 0, 1 }
        }, {
            /* Maze 3,2 */ { 1, 2, 1, 0, 1, 0, 1, 0, 1, 0, 1 }, { 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0 },
            { 1, 2, 1, 2, 1, 0, 1, 2, 1, 2, 1 }, { 0, 2, 0, 2, 0, 2, 2, 2, 0, 2, 0 }, { 1, 0, 1, 0, 1, 2, 1, 0, 1, 2, 1 },
            { 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0 }, { 1, 2, 1, 2, 1, 0, 1, 2, 1, 0, 1 }, { 0, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0 },
            { 1, 2, 1, 2, 1, 2, 1, 0, 1, 2, 1 }, { 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 2 }, { 1, 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 }
        }, {
            /* Maze 4,1 */ { 1, 2, 1, 0, 1, 0, 1, 2, 1, 0, 1 }, { 0, 2, 0, 2, 2, 2, 0, 2, 0, 2, 0 },
            { 1, 0, 1, 0, 1, 2, 1, 0, 1, 2, 1 }, { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 }, { 1, 2, 1, 0, 1, 0, 1, 0, 1, 2, 1 },
            { 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0 }, { 1, 2, 1, 0, 1, 2, 1, 0, 1, 0, 1 }, { 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2 },
            { 1, 2, 1, 2, 1, 0, 1, 0, 1, 0, 1 }, { 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2 }, { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }
        }, {
            /* Maze 4,4 */ { 1, 0, 1, 0, 1, 2, 1, 2, 1, 0, 1 }, { 0, 2, 2, 2, 0, 2, 0, 2, 0, 2, 0 },
            { 1, 2, 1, 2, 1, 2, 1, 0, 1, 2, 1 }, { 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0 }, { 1, 0, 1, 2, 1, 2, 1, 0, 1, 2, 1 },
            { 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0 }, { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 }, { 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0 },
            { 1, 2, 1, 0, 1, 2, 1, 2, 1, 2, 1 }, { 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 0 }, { 1, 0, 1, 0, 1, 0, 1, 2, 1, 0, 1 }
        }, {
            /* Maze 5,1 */ { 1, 2, 1, 0, 1, 2, 1, 0, 1, 0, 1 }, { 0, 2, 0, 2, 0, 2, 2, 2, 0, 2, 0 },
            { 1, 2, 1, 2, 1, 2, 1, 0, 1, 2, 1 }, { 0, 2, 0, 2, 0, 2, 0, 2, 2, 2, 0 }, { 1, 0, 1, 2, 1, 2, 1, 2, 1, 0, 1 },
            { 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 2 }, { 1, 0, 1, 2, 1, 0, 1, 2, 1, 2, 1 }, { 2, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0 },
            { 1, 0, 1, 2, 1, 2, 1, 2, 1, 0, 1 }, { 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0 }, { 1, 0, 1, 0, 1, 0, 1, 2, 1, 0, 1 }
        }, {
            /* Maze 5,3 */ { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }, { 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 0 },
            { 1, 0, 1, 0, 1, 0, 1, 0, 1, 2, 1 }, { 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2 }, { 1, 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 },
            { 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0 }, { 1, 2, 1, 0, 1, 0, 1, 2, 1, 2, 1 }, { 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0 },
            { 1, 2, 1, 0, 1, 0, 1, 0, 1, 2, 1 }, { 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0 }, { 1, 2, 1, 0, 1, 0, 1, 0, 1, 0, 1 }
        }
    };

    private readonly int[,] correctPath = new int[11, 11];
    private readonly int[] mazeData = new int[4];
    private readonly bool[,] wasHere = new bool[11, 11];
    private int _currentMazeInUse;
    private string _inputMazeData, _mazeImage, _outputTextBox;
    private List<string> outputList = new();

    public MazeModuleVM() {
        MazeImage = "../../Resources/maze/blank.png";

        CrossViewMessenger simpleMessenger = CrossViewMessenger.Instance;
        simpleMessenger.MessageValueChanged += OnSimpleMessengerValueChanged;
        simpleMessenger.PushMessage("KeyBindings_MazeModule", null);
    }

    public string MazeImage {
        get => _mazeImage;
        set {
            _mazeImage = value;
            RaisePropertyChangedEvent("MazeImage");
        }
    }

    public string InputMazeData {
        get => _inputMazeData;
        set {
            _inputMazeData = VerifyNodeText(value);
            RaisePropertyChangedEvent("InputMazeData");
        }
    }

    public string OutputTextBox {
        get => _outputTextBox;
        set {
            _outputTextBox = value;
            RaisePropertyChangedEvent("OutputTextBox");
        }
    }

    private void OnSimpleMessengerValueChanged(object sender, MessageValueChangedEventArgs e) {
        if (ReferenceValues.CurrentModule == "../Modules/MazeModule.xaml") {
            if (e.PropertyName == "KEY_F12") {
                ResetButtonLogic();
            }
        }
    }

    private string VerifyNodeText(string value) {
        /* Maze Main Node */
        switch (value.Length) {
        case 1:
            MazeImage = "../../Resources/maze/blank.png";
            OutputTextBox = "";
            try {
                if (int.Parse(value) > 0 && int.Parse(value) < 6) {
                    return value;
                }

                throw new FormatException();
            } catch (Exception) {
                return "";
            }

        case 2:
            OutputTextBox = "";
            try {
                switch (int.Parse(value)) {
                case 11:
                    MazeImage = "../../Resources/maze/maze11.png";
                    _currentMazeInUse = 0;
                    break;
                case 12:
                    MazeImage = "../../Resources/maze/maze12.png";
                    _currentMazeInUse = 1;
                    break;
                case 21:
                    MazeImage = "../../Resources/maze/maze21.png";
                    _currentMazeInUse = 2;
                    break;
                case 24:
                    MazeImage = "../../Resources/maze/maze24.png";
                    _currentMazeInUse = 3;
                    break;
                case 32:
                    MazeImage = "../../Resources/maze/maze32.png";
                    _currentMazeInUse = 4;
                    break;
                case 41:
                    MazeImage = "../../Resources/maze/maze41.png";
                    _currentMazeInUse = 5;
                    break;
                case 44:
                    MazeImage = "../../Resources/maze/maze44.png";
                    _currentMazeInUse = 6;
                    break;
                case 51:
                    MazeImage = "../../Resources/maze/maze51.png";
                    _currentMazeInUse = 7;
                    break;
                case 53:
                    MazeImage = "../../Resources/maze/maze53.png";
                    _currentMazeInUse = 8;
                    break;
                default:
                    MazeImage = "../../Resources/maze/blank.png";
                    throw new FormatException();
                }
            } catch (Exception) {
                return value.Remove(1);
            }

            return value;

        /* Player Location */
        case 3:
            OutputTextBox = "";
            try {
                if (int.Parse(value[2].ToString()) > 0 && int.Parse(value[2].ToString()) < 7) {
                    return value;
                }

                throw new FormatException();
            } catch (Exception) {
                return value.Remove(2);
            }

        case 4:
            OutputTextBox = "";
            outputList = new List<string>();
            try {
                if (int.Parse(value[3].ToString()) > 0 && int.Parse(value[3].ToString()) < 7) {
                    return value;
                }

                throw new FormatException();
            } catch (Exception) {
                return value.Remove(3);
            }

        case 5:
            OutputTextBox = "";
            try {
                if (int.Parse(value[4].ToString()) > 0 && int.Parse(value[4].ToString()) < 7) {
                    return value;
                }

                throw new FormatException();
            } catch (Exception) {
                return value.Remove(4);
            }

        case 6:
            OutputTextBox = "";
            try {
                if (int.Parse(value[5].ToString()) > 0 && int.Parse(value[5].ToString()) < 7) {
                    MazeLogic(new[] {
                        int.Parse(value[2].ToString()), int.Parse(value[3].ToString()),
                        int.Parse(value[4].ToString()), int.Parse(value[5].ToString())
                    });
                    return value;
                }

                throw new FormatException();
            } catch (Exception) {
                return value.Remove(5);
            }

        default:
            OutputTextBox = "";
            return "";
        }
    }

    private void MazeLogic(IReadOnlyList<int> mazeDataUnformatted) {
        /* Clear output list for new data */
        outputList = new List<string>();

        /* Format input data to new format
         * input 1 -> output 0
         * input 2 -> output 2
         * input 3 -> output 4
         * input 4 -> output 6
         * input 5 -> output 8
         * input 6 -> output 10 */
        for (int i = 0; i < mazeDataUnformatted.Count; i++) {
            mazeData[i] = (mazeDataUnformatted[i] - 1) * 2;
        }

        for (int row = 0; row < MazeList.GetLength(1); row++) // Sets boolean Arrays to default values
        for (int col = 0; col < MazeList.GetLength(2); col++) {
            wasHere[row, col] = false;
            correctPath[row, col] = 0;
        }

        /* Start solving the maze */
        RecursiveSolve(mazeData[1], mazeData[0]);

        /* Display debug output */
        for (int row = 0; row < correctPath.GetLength(0); row++) {
            // Sets boolean Arrays to default values
            for (int col = 0; col < correctPath.GetLength(1); col++) {
                Console.Write(correctPath[row, col] + @",");
            }

            Console.Write("\n");
        }

        /* Loop through maze to find output directions */
        int rightLeft = mazeData[1], upDown = mazeData[0], lastDirectionMoved = 0, infLoopProtect = 0;
        do {
            /* Check if finished */
            if (rightLeft == mazeData[3] && upDown == mazeData[2]) {
                break;
            }

            /* Check Up */
            if (upDown > 0 && correctPath[rightLeft, upDown - 1] == 1 && lastDirectionMoved != 2) {
                outputList.Add("Left");
                upDown--;
                lastDirectionMoved = 1;

                /* Check Down */
            } else if (upDown < 10 && correctPath[rightLeft, upDown + 1] == 1 && lastDirectionMoved != 1) {
                outputList.Add("Right");
                upDown++;
                lastDirectionMoved = 2;

                /* Check Right */
            } else if (rightLeft > 0 && correctPath[rightLeft - 1, upDown] == 1 && lastDirectionMoved != 3) {
                outputList.Add("Up");
                rightLeft--;
                lastDirectionMoved = 4;

                /* Check Left */
            } else if (rightLeft < 10 && correctPath[rightLeft + 1, upDown] == 1 && lastDirectionMoved != 4) {
                outputList.Add("Down");
                rightLeft++;
                lastDirectionMoved = 3;
            }

            /* VERY poor implementation of an infLoop protector... You can do better than This Robert! */
            if (infLoopProtect > 1000) {
                outputList = new List<string> { "InfLoop Protector Error  " };
                break;
            }

            infLoopProtect++;
        } while (true);

        /* Clean up list (remove dupe list data) */
        int pos = 0;
        for (int i = 0; i < outputList.Count; i += 2, pos++) {
            outputList[pos] = outputList[i];
        }

        outputList.RemoveRange(pos, outputList.Count - pos);

        /* Output Directions into TextBox */
        foreach (string list in outputList) {
            OutputTextBox = OutputTextBox + list + ", ";
        }

        /* Remove last comma from OutputTextBox */
        if (OutputTextBox.Length > 2) {
            OutputTextBox = OutputTextBox.Remove(OutputTextBox.Length - 2);
        }
    }

    private bool RecursiveSolve(int x, int y) {
        if (x == mazeData[3] && y == mazeData[2]) {
            correctPath[x, y] = 1;
            return true; // Reached the end of the maze
        }

        if (MazeList[_currentMazeInUse, x, y] == 2 || wasHere[x, y]) {
            return false;
        }

        // If it is a wall or already here
        wasHere[x, y] = true;

        // Checks if not on left edge
        if (x != 0) {
            if (RecursiveSolve(x - 1, y)) {
                // Recalls method one to the left
                correctPath[x, y] = 1;
                return true;
            }
        }

        // Checks if not on right edge
        if (x != 11 - 1) {
            if (RecursiveSolve(x + 1, y)) {
                // Recalls method one to the right
                correctPath[x, y] = 1;
                return true;
            }
        }

        // Checks if not on top edge
        if (y != 0) {
            if (RecursiveSolve(x, y - 1)) {
                // Recalls method one up
                correctPath[x, y] = 1;
                return true;
            }
        }

        // Checks if not on bottom edge
        if (y != 11 - 1) {
            if (RecursiveSolve(x, y + 1)) {
                // Recalls method one down
                correctPath[x, y] = 1;
                return true;
            }
        }

        return false;
    }

    private void ResetButtonLogic() {
        MazeImage = "../../Resources/maze/blank.png";
        InputMazeData = OutputTextBox = "";
    }
}