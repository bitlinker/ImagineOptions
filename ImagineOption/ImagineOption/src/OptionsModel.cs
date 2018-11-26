using System;

namespace ImagineOption
{
    class OptionsModel
    {
        // Outside options
        public String Adapter { get; set; }
        public int ChatFontSizeType { get; set; }
        public int Color { get; set; }
        public bool FullScreen { get; set; }               
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }

        // Launcher options
        public bool JapLocale { get; set; }

        // Updater options
        public String baseUrl1 { get; set; }
        public String information { get; set; }
        public bool disableBlacklists { get; set; }

        // Default options model
        public OptionsModel()
        {
            Adapter = "unknown";
            ChatFontSizeType = 1;
            Color = 32;
            FullScreen = false;
            ResolutionX = 800;
            ResolutionX = 600;
            JapLocale = false;
            baseUrl1 = "";
            information = "";
            disableBlacklists = false;
        }
    }
}
