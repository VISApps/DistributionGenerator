using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DistributionGenerator
{
    public partial class Form1 : Form
    {
        private Generator evenDistribution;

        public Form1()
        {
            InitializeComponent();
            evenDistribution = new Generator();
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(numericUpDown1.Value);
            int b = Convert.ToInt32(numericUpDown2.Value);
            int n = Convert.ToInt32(numericUpDown3.Value);
            double c = 0;
            double d = 0;
            int intervals = Convert.ToInt32(numericUpDown4.Value);

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            Distribution distribution = Distribution.Even;
            RandomType type = RandomType.Standart;
            if (radioButton2.Checked)
            {
                distribution = Distribution.Triangular;
                c = Convert.ToDouble(numericUpDown5.Value);
            }

            if (radioButton3.Checked)
            {
                distribution = Distribution.Exponential;
                c = Convert.ToDouble(numericUpDown10.Value);
            }
            if (radioButton4.Checked)
            {
                distribution = Distribution.Trapezoidal;
                c = Convert.ToInt32(numericUpDown6.Value);
                d = Convert.ToInt32(numericUpDown7.Value);
            }
            if (radioButton5.Checked)
            {
                distribution = Distribution.Normal;
                c = Convert.ToInt32(numericUpDown8.Value);
                d = Convert.ToInt32(numericUpDown9.Value);
            }
            if (radioButton7.Checked)
            {
                type = RandomType.Conq;
            }
            if (radioButton8.Checked)
            {
                type = RandomType.Lemer;
            }
            double[,] result = evenDistribution.CreateHistogram(a,b,n,intervals, distribution, c, d, type);
           
            for (int i = 0; i < intervals; i++) {
                chart1.Series["Random"].Points.AddXY(result[i, 0], result[i, 1]);
            }

           
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
