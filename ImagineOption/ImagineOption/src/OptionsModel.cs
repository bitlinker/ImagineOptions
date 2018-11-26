using System;

namespace ImagineOption
{
    class OptionsModel
    {
        public String Adapter { get; set; }
        public int ChatFontSizeType { get; set; }
        public int Color { get; set; }
        public bool FullScreen { get; set; }               
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public bool JapLocale { get; set; }

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
        }
    }
}
