using System;
using System.IO;

namespace ImagineOption
{
    class OptionsSerializer
    {
        private const string OPTIONS_OUTSIDE_FILENAME = "OutsideOption.txt";
        private const string OPTIONS_NEW_FILENAME = "LauncherOption.txt";
        private const string OPTIONS_UPDATER_FILENAME = "ImagineUpdate.dat";

        private const string OPTION_ADAPTER = "-Adapter";
        private const string OPTION_FONTSIZE = "-ChatFontSizeType";
        private const string OPTION_COLOR = "-Color";
        private const string OPTION_FULLSCREEN = "-FullScreen";
        private const string OPTION_RESOLUTIONX = "-ResolutionX";
        private const string OPTION_RESOLUTIONY = "-ResolutionY";

        private const string OPTION_LOCALE_DEFAULT = "locale=Default";
        private const string OPTION_LOCALE_JAP = "locale=Japanese";

        // Updater options
        private const string OPTION_CATEGORY_SETTING = "[Setting]";
        private const string OPTION_BASE_URL1 = "BaseURL1";
        private const string OPTION_INFORMATION = "Information";
        private const string OPTION_CATEGORY_CUSTOM = "[Custom]";
        private const string OPTION_DISABLE_BLACKLISTS = "DisableBlacklists";

        public OptionsModel LoadOptions()
        {
            OptionsModel optionsModel = new OptionsModel();

            if (File.Exists(OPTIONS_OUTSIDE_FILENAME))
            {
                using (StreamReader file = new StreamReader(OPTIONS_OUTSIDE_FILENAME))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.Length == 0) continue;
                        var split = splitOptionLine(line);
                        if (split == null) throw new IOException("Can't split string: " + line);

                        switch (split[0])
                        {
                            case OPTION_ADAPTER:
                                optionsModel.Adapter = split[1].Replace("\"", "");
                                break;
                            case OPTION_FONTSIZE:
                                optionsModel.ChatFontSizeType = Int32.Parse(split[1]);
                                break;
                            case OPTION_COLOR:
                                optionsModel.Color = Int32.Parse(split[1]);
                                break;
                            case OPTION_FULLSCREEN:
                                optionsModel.FullScreen = split[1].Equals("true", StringComparison.InvariantCultureIgnoreCase);
                                break;
                            case OPTION_RESOLUTIONX:
                                optionsModel.ResolutionX = Int32.Parse(split[1]);
                                break;
                            case OPTION_RESOLUTIONY:
                                optionsModel.ResolutionY = Int32.Parse(split[1]);
                                break;
                                // No strict parsing
                                /*default:
                                    throw new IOException("Unknown option: " + line);*/
                        }
                    }
                }
            }

            if (File.Exists(OPTIONS_NEW_FILENAME))
            {
                using (StreamReader file = new StreamReader(OPTIONS_NEW_FILENAME))
                {
                    string line = file.ReadLine();
                    if (line != null)
                    {
                        line = line.Trim();
                        optionsModel.JapLocale = line.Equals(OPTION_LOCALE_JAP, StringComparison.InvariantCultureIgnoreCase);
                    }
                }
            }

            if (File.Exists(OPTIONS_UPDATER_FILENAME))
            {
                using (StreamReader file = new StreamReader(OPTIONS_UPDATER_FILENAME))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.Length == 0) continue;
                        // TODO: handle categories if needed
                        if (line.StartsWith("[")) continue;

                        var split = splitUpdaterOptionLine(line);
                        if (split == null) throw new IOException("Can't split string: " + line);

                        switch (split[0])
                        {
                            case OPTION_BASE_URL1:
                                optionsModel.baseUrl1 = split[1];
                                break;
                            case OPTION_INFORMATION:
                                optionsModel.information = split[1];
                                break;
                            case OPTION_DISABLE_BLACKLISTS:
                                optionsModel.disableBlacklists = split[1].Equals("true", StringComparison.InvariantCultureIgnoreCase);
                                break;
                        }
                    }
                }
            }
            return optionsModel;
        }

        public void SaveOptions(OptionsModel model)
        {
            using (StreamWriter file = new StreamWriter(OPTIONS_OUTSIDE_FILENAME))
            {
                file.WriteLine(OPTION_ADAPTER + " \"" + model.Adapter + "\"");
                file.WriteLine(OPTION_FONTSIZE + " " + model.ChatFontSizeType);
                file.WriteLine(OPTION_COLOR + " " + model.Color);
                file.WriteLine(OPTION_FULLSCREEN + " " + (model.FullScreen ? "true" : "false"));
                file.WriteLine(OPTION_RESOLUTIONX + " " + model.ResolutionX);
                file.WriteLine(OPTION_RESOLUTIONY + " " + model.ResolutionY);
            }

            using (StreamWriter file = new StreamWriter(OPTIONS_NEW_FILENAME))
            {
                file.WriteLine(model.JapLocale ? OPTION_LOCALE_JAP : OPTION_LOCALE_DEFAULT);
            }

            using (StreamWriter file = new StreamWriter(OPTIONS_UPDATER_FILENAME))
            {
                file.WriteLine(OPTION_CATEGORY_SETTING);
                file.WriteLine(OPTION_BASE_URL1 + " = " + model.baseUrl1);
                file.WriteLine(OPTION_INFORMATION + " = " + model.information);
                file.WriteLine();
                file.WriteLine(OPTION_CATEGORY_CUSTOM);
                file.WriteLine(OPTION_DISABLE_BLACKLISTS + " = " + model.disableBlacklists);
            }
        }

        private string[] splitOptionLine(string line)
        {
            var spaceIndex = line.IndexOf(' ');
            if (spaceIndex == -1) return null;

            string[] result = new string[2];
            result[0] = line.Substring(0, spaceIndex);
            result[1] = line.Substring(spaceIndex + 1);
            return result;
        }

        private string[] splitUpdaterOptionLine(string line)
        {
            var spaceIndex = line.IndexOf('=');
            if (spaceIndex == -1) return null;

            string[] result = new string[2];
            result[0] = line.Substring(0, spaceIndex).Trim();
            result[1] = line.Substring(spaceIndex + 1).Trim();
            return result;
        }
    }
}
