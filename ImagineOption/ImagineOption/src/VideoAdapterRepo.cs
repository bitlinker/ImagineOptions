using System;
using System.Collections.Generic;
using SharpDX.DXGI;

namespace ImagineOption
{
    class AdapterOutputInfo
    {
        private Adapter AdapterSrc;
        private Output AdapterOutput;
        public SortedSet<AdapterResolution> Resolutions { get; }

        public AdapterOutputInfo(Adapter adapter, Output output, SortedSet<AdapterResolution> resolution)
        {
            AdapterSrc = adapter;
            AdapterOutput = output;
            Resolutions = resolution;
        }

        public string GetAdapterOutputName()
        {
            return AdapterSrc.Description.Description;
            // Imagine can't select specific adapter output, but handles it's resolutions fine
            //return AdapterOutput.Description.DeviceName;
        }
    }

    class AdapterResolution : IComparable
    {
        public int Width { get; }
        public int Height { get; }
        public int Bpp { get; }

        public AdapterResolution(int width, int height, int bpp)
        {
            Width = width;
            Height = height;
            Bpp = bpp;
        }

        public override bool Equals(object obj)
        {
            AdapterResolution item = obj as AdapterResolution;
            return item.Width == this.Width && 
                item.Height == this.Height &&
                item.Bpp == this.Bpp;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Width.GetHashCode();
            hash = (hash * 7) + Height.GetHashCode();
            hash = (hash * 7) + Bpp.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return Width + " x " + Height + " x " + Bpp + " bpp";
        }

        public int CompareTo(object obj)
        {
            AdapterResolution item = obj as AdapterResolution;

            if (item.Width > Width) return -1;
            else if (item.Width < Width) return 1;
            else
            {
                if (item.Height > Height) return -1;
                else if (item.Height < Height) return 1;
                else
                {
                    return Bpp - item.Bpp;
                }
            }
        }
    }

    class VideoAdapterRepo
    {
        private Factory factory = new Factory1();

        public List<AdapterOutputInfo> EnumerateAdapterOutputs()
        {
            List<AdapterOutputInfo> result = new List<AdapterOutputInfo>();
            foreach (var adapter in factory.Adapters)
            {
                foreach (var output in adapter.Outputs)
                {
                    var modes = EnumerateDispalyModes(output);
                    if (modes.Count > 0)
                    {
                        result.Add(new AdapterOutputInfo(adapter, output, modes));
                    }
                }
            }
            return result;
        }

        private SortedSet<AdapterResolution> EnumerateDispalyModes(Output output)
        {
            SortedSet<AdapterResolution> resolutions = new SortedSet<AdapterResolution>();            
            foreach (Format format in Enum.GetValues(typeof(Format)))
            {
                var list = output.GetDisplayModeList(format, 0);
                foreach (var mode in list)
                {
                    int bpp = mode.Format.SizeOfInBits();
                    if (mode.Scaling == DisplayModeScaling.Unspecified && (bpp == 32 || bpp == 16)) // Allow only 16 & 32 bpp resolutions
                    {
                        resolutions.Add(new AdapterResolution(mode.Width, mode.Height, bpp));
                    }
                }
            }
            return resolutions;
        }
    }
}
