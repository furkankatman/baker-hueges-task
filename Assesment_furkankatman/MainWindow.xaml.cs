using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Assesment_furkankatman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private JewelSuiteHelper JewelSuiteHelper;
        private bool datasetLoading;
        private List<int> depthValues = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt_ResultCubicMeter.Text = "";
            txt_ResultCubicFeet.Text = "";
            txt_ResultBarrels.Text = "";
            datasetLoading = true;
            lbl_Loading.Content = "Dataset is loading...".ToUpper();
            
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? response = openFileDialog.ShowDialog();
                if (response == true)
                {
                    string pathToFile = openFileDialog.FileName;
                    using (var reader = new StreamReader(pathToFile))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(' ');

                            values.ToList().ForEach(x=> {
                                depthValues.Add(int.Parse(x));
                            });
                        }
                    }
                    if(depthValues!=null && depthValues.Count > 0)
                    {
                        lbl_Loading.Content = "Dataset is ready.";
                        datasetLoading = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var baseHorizon = int.Parse(txt_baseHorizon.Text);
                var fluidContact = int.Parse(txt_FluidContact.Text);
                var cellSizeWidth = 60.96;
                var cellSizeHeight = 60.96;

                if (txt_CellSizeHeight.Text != "Cell Size Height")
                {
                    cellSizeHeight = double.Parse(txt_CellSizeHeight.Text);
                }
                if (txt_CellSizeWidth.Text != "Cell Size Width")
                {
                    cellSizeWidth = double.Parse(txt_CellSizeWidth.Text);
                }
                JewelSuiteHelper = new JewelSuiteHelper(depthValues, baseHorizon, fluidContact, cellSizeWidth, cellSizeHeight);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (datasetLoading)
            {
                MessageBox.Show("JewelSuite is still loading data wait for it.");
                return;
            }
            if (JewelSuiteHelper == null)
            {
                MessageBox.Show("First fill the inputs and load the dataset");
                return;
            }
            var volumeCalculatedMeter = JewelSuiteHelper.CalculateVolume(UnitEnum.CubicMeter);
            var volumeCalculatedFeet = JewelSuiteHelper.CalculateVolume(UnitEnum.Cubicfeet);
            var volumeCalculatedBarrels = JewelSuiteHelper.CalculateVolume(UnitEnum.Barrels);
            txt_ResultCubicMeter.Text = volumeCalculatedMeter + " cubic meters";
            txt_ResultCubicFeet.Text = volumeCalculatedFeet + " cubic feet";
            txt_ResultBarrels.Text = volumeCalculatedBarrels + " barrels";
        }
    }
}
