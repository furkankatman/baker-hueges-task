using System;
using System.Collections.Generic;
using System.Text;

namespace Assesment_furkankatman
{
    public class JewelSuiteHelper
    {
        public int VersionNumber { get; set; }
        public DateTime ReleaseDate { get; set; }

        public IVolumeCalculator VolumeCalculator { get; set; }
        public JewelSuiteHelper(List<int> depthValues, int baseHorizon, int fluidContact, double cellSizeWidth, double cellSizeHeight)
        {
            VolumeCalculator = VolumeCalculatorFactory.GetBasicVolumeCalculator(depthValues, baseHorizon, fluidContact, cellSizeWidth, cellSizeHeight);
        }

        public ulong CalculateVolume(UnitEnum unit)
        {
            return VolumeCalculator.Calculate(unit);
        }

        public void SetVolumeCalculator(IVolumeCalculator volumeCalculator)
        {
            VolumeCalculator = volumeCalculator;
        }



    }
}
