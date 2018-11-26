using System.Collections.Generic;
using System.IO;

namespace ImagineOption
{
    class Business
    {
        private OptionsSerializer serializer = new OptionsSerializer();
        private VideoAdapterRepo repo = new VideoAdapterRepo();

        private OptionsModel optionsModel = new OptionsModel();
        private List<AdapterOutputInfo> adapterOutputs;

        private int selectedAdapterOutputIndex;
        private int selectedResolutionIndex;

        public Business()
        {
            // Load options
            optionsModel = serializer.LoadOptions();

            // Load adapters info
            adapterOutputs = repo.EnumerateAdapterOutputs();

            // Validate options with adapter
            selectedAdapterOutputIndex = findSelectedAdapterOutputIndex();
            selectedResolutionIndex = findSelectedResolutionIndex();
        }


        private int findSelectedAdapterOutputIndex()
        {
            int i = 0;
            foreach(var output in adapterOutputs)
            {
                if (output.GetAdapterOutputName().Equals(optionsModel.Adapter)) return i;
                ++i;
            }
            return 0;            
        }

        private int findSelectedResolutionIndex()
        {
            var modelResolution = new AdapterResolution(optionsModel.ResolutionX, optionsModel.ResolutionY, optionsModel.Color);
            if (selectedAdapterOutputIndex >= adapterOutputs.Count) return 0;
            var output = adapterOutputs[selectedAdapterOutputIndex];
            int i = 0;
            foreach (var resolution in output.Resolutions)
            {
                if (resolution.Equals(modelResolution)) return i;
                ++i;
            }
            return 0;
        }

        public void SelectAdapterOutput(int index)
        {
            if (selectedAdapterOutputIndex >= 0 && selectedAdapterOutputIndex < adapterOutputs.Count)
            {
                selectedAdapterOutputIndex = index;
                var output = adapterOutputs[selectedAdapterOutputIndex];
                optionsModel.Adapter = output.GetAdapterOutputName();                
                selectedResolutionIndex = findSelectedResolutionIndex();
            }
        }

        public void SelectResolution(int index)
        {
            var output = adapterOutputs[selectedAdapterOutputIndex];
            if (selectedResolutionIndex >= 0 && selectedResolutionIndex < output.Resolutions.Count)
            {
                selectedResolutionIndex = index;
                var resolution = new List<AdapterResolution>(output.Resolutions)[selectedResolutionIndex];
                optionsModel.ResolutionX = resolution.Width;
                optionsModel.ResolutionY = resolution.Height;
                optionsModel.Color = resolution.Bpp;                
            }
        }

        public void Save()
        {
            serializer.SaveOptions(optionsModel);
        }

        public OptionsModel GetOptionsModel()
        {
            return optionsModel;
        }

        public List<string> GetAdapterOutputNames()
        {
            List<string> result = new List<string>();
            foreach (var output in adapterOutputs)
            {
                result.Add(output.GetAdapterOutputName());
            }
            return result;
        }

        public List<string> GetResolutionNames()
        {
            List<string> result = new List<string>();
            if (selectedAdapterOutputIndex < adapterOutputs.Count)
            {
                var output = adapterOutputs[selectedAdapterOutputIndex];
                foreach (var res in output.Resolutions)
                {
                    result.Add(res.ToString()); // TODO: localize!
                }
            }                
            return result;
        }

        public int GetSelectedAdapterOutputIndex()
        {
            return selectedAdapterOutputIndex;
        }

        public int GetSeletedResolutionIndex()
        {
            return selectedResolutionIndex;
        }
    }
}
