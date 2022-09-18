using System;
using System.Collections.Generic;
using System.Text;

namespace Assesment_furkankatman
{
    public class VolumeCalculator:IVolumeCalculator
    {
        public List<double> DepthValues  { get; set; }
        public int BaseHorizon { get; set; }
        public int FluidContact { get; set; }
        public int CellSizeWidth { get; set; }
        public int CellSizeHeight { get; set; }
        public VolumeCalculator(List<double> depthValues,int baseHorizon,int fluidContact,int cellSizeWidth,int cellSizeHeight)
        {
            this.BaseHorizon = baseHorizon;
            this.CellSizeHeight = cellSizeHeight;
            this.CellSizeWidth = cellSizeWidth;
            this.DepthValues = depthValues;
            this.FluidContact = fluidContact;
        }

        public int Calculate(List<double> depthValues,int baseHorizon,int fluidContact, int cellSize_Width, int cellSize_Height, UnitEnum unit)
        {
            var Volume = 0;
            foreach (var depth in depthValues)
            {
                var baseHorizonActual = depth + baseHorizon;
                if (fluidContact> depth && fluidContact < baseHorizonActual)
                {
                    Volume = (int)(Volume + (cellSize_Height * cellSize_Width * (Math.Abs(depth - fluidContact))));
                }

                    

            }
            return Volume;
            
        }
    }

    public interface IVolumeCalculator
    {
        public int Calculate(List<double> depthValues, int baseHorizon, int fluidContact, int cellSize_Width, int cellSize_Height,UnitEnum unit);

    }
    public enum UnitEnum
    {
        CubicMeter,
        Cubicfeet,
        Barrels

    }
}
