using System;
using System.Collections.Generic;
using System.Text;

namespace Assesment_furkankatman
{
    public static class VolumeCalculatorFactory
    {
        public static VolumeCalculatorBasic GetBasicVolumeCalculator(List<int> depthValues,int baseHorizon, int fluidContact, double cellSizeWidth, double cellSizeHeight)
        {
            VolumeCalculatorBasic VolumeCalculator = new VolumeCalculatorBasic(depthValues,baseHorizon,fluidContact,cellSizeWidth,cellSizeHeight);
            return VolumeCalculator;
        }
    }
}
