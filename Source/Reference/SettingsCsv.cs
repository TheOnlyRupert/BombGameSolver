using System;
using System.IO;
using System.Windows;

namespace BombGameSolver.Source.Reference {
    public class SettingsCsv {
        private readonly string _fileDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/TheOnlyRupert/BombGameSolver/";

        public SettingsCsv() {
            try {
                Directory.CreateDirectory(_fileDirectory);

                if (!File.Exists(_fileDirectory + "settings.csv")) {
                    Console.WriteLine(@"settings.csv does not exist. Restoring default settings");
                    var file = new StreamWriter(_fileDirectory + "settings.csv", true);
                    file.WriteLine("!KEY,VALUE\nSimonSaysViewType,0");
                    file.Close();
                }
            } catch (Exception) {
                MessageBox.Show("Error! Unable to create settings.csv file in documents directory.\n" +
                                "Using default settings with saving disabled.", "Error");
            }
        }

        private void GetSettings_OneTime() {
            try {
                var streamReader = new StreamReader(_fileDirectory + "settings.csv");

                while (!streamReader.EndOfStream) {
                    var str = streamReader.ReadLine();

                    if (str != null && str[0] != '!') {
                        string[] strArray = str.Split(',');
                        switch (strArray[0]) {
                        case "SimonSaysViewType":
                            ReferenceValues.SimonSaysViewType = int.Parse(strArray[1]);
                            break;
                        }
                    }
                }
            } catch (Exception) {
                Console.WriteLine(@"Error! settings.csv file read error.");
            }
        }

        public void SetSettingFromString(string key) { }
    }
}