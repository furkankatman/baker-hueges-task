using System;
using System.Collections.Generic;
using System.Text;

namespace Assesment_furkankatman
{
    public class VolumeCalculatorBasic:IVolumeCalculator
    {
        public List<int> DepthValues{ get; set; }
        public int BaseHorizon { get; set; }
        public int FluidContact { get; set; }
        public double CellSizeWidth { get; set; }
        public double CellSizeHeight { get; set; }
        public UnitEnum Unit { get; set; }

        public VolumeCalculatorBasic(List<int> depthValues, int baseHorizon, int fluidContact, double cellSizeWidth, double cellSizeHeight)
        {
            DepthValues = depthValues;
            BaseHorizon = baseHorizon;
            FluidContact = fluidContact;
            CellSizeWidth = cellSizeWidth;
            CellSizeHeight = cellSizeHeight;
        }

        public ulong Calculate(UnitEnum unit)
        {
            var Volume = 0ul;
            
            switch (unit)
            {
                case UnitEnum.CubicMeter:
                    {
                        foreach (var depth in DepthValues)
                        {
                            var baseHorizonActual = (depth*0.3048) + BaseHorizon;
                            double depthMeter = (depth * 0.3048);
                            if (FluidContact > depthMeter && FluidContact < baseHorizonActual)
                            {
                                Volume = (ulong)(Volume + (CellSizeHeight * CellSizeWidth * (Math.Abs(depthMeter - FluidContact))));
                            }
                        }
                        return Volume;
                    }
                case UnitEnum.Cubicfeet:
                    {
                        foreach (var depth in DepthValues)
                        {
                            double depthMeter = (depth * 0.3048);
                            var baseHorizonActual = (depth * 0.3048) + BaseHorizon;
                            if (FluidContact > depthMeter && FluidContact < baseHorizonActual)
                            {
                                Volume = (ulong)(Volume + (CellSizeHeight * CellSizeWidth * (Math.Abs(depthMeter - FluidContact))));
                            }
                        }
                        return (ulong)(Volume/0.3048/ 0.3048/ 0.3048);
                    }
                case UnitEnum.Barrels:
                    {
                        foreach (var depth in DepthValues)
                        {
                            var baseHorizonActual = (depth * 0.3048) + BaseHorizon;
                            double depthMeter = (depth * 0.3048);
                            if (FluidContact > depthMeter && FluidContact < baseHorizonActual)
                            {
                                Volume = (ulong)(Volume + (CellSizeHeight * CellSizeWidth * (Math.Abs(depthMeter - FluidContact))));
                            }
                        }
                        return (ulong)(Volume/0.1592);
                    }
                default:
                    { return 0; }
            }

            
        }
    }

    public interface IVolumeCalculator
    {
        public ulong Calculate(UnitEnum unit);

    }
    public enum UnitEnum
    {
        CubicMeter,
        Cubicfeet,
        Barrels

    }
}
