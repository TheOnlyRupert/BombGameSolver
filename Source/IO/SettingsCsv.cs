using System;
using System.IO;
using System.Windows;

namespace BombGameSolver.Source.IO;

public class SettingsCsv {
    private static readonly string _fileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                                    "/TheOnlyRupert/BombGameSolver/";

    public SettingsCsv() {
        try {
            Directory.CreateDirectory(_fileDirectory);

            if (!File.Exists(_fileDirectory + "settings.csv")) {
                Console.WriteLine(@"settings.csv does not exist. Restoring default settings");
                StreamWriter file = new(_fileDirectory + "settings.csv", true);
                file.WriteLine("!KEY,VALUE\nSimonSaysViewType,0\nSequWiresSounds,1\nDebugMode,0");
                file.Close();
            }
        } catch (Exception) {
            MessageBox.Show("Error! Unable to create settings.csv file in documents directory.\n" +
                            "Using default settings with saving disabled.", "Error");
        }
    }

    public void GetSettings_OneTime() {
        /* Set default values first */
        ReferenceValues.SimonSaysViewType = 0;
        ReferenceValues.SequWiresSounds = true;
        ReferenceValues.DebugMode = 0;

        try {
            StreamReader streamReader = new(_fileDirectory + "settings.csv");

            while (!streamReader.EndOfStream) {
                string str = streamReader.ReadLine();

                if (str != null && str[0] != '!') {
                    string[] strArray = str.Split(',');
                    switch (strArray[0]) {
                    case "SimonSaysViewType":
                        ReferenceValues.SimonSaysViewType = int.Parse(strArray[1]);
                        break;
                    case "SequWiresSounds":
                        ReferenceValues.SequWiresSounds = strArray[1] == "1";
                        break;
                    case "DebugMode":
                        ReferenceValues.DebugMode = int.Parse(strArray[1]);
                        break;
                    }
                }
            }

            Console.WriteLine(@"SimonSaysViewType: " + ReferenceValues.SimonSaysViewType);
            Console.WriteLine(@"SequWiresSounds: " + ReferenceValues.SequWiresSounds);
            Console.WriteLine(@"DebugMode: " + ReferenceValues.DebugMode);
        } catch (Exception) {
            Console.WriteLine(@"Error! settings.csv file read error.");
        }
    }

    public static void SetSequWiresSounds(bool value) { }
}