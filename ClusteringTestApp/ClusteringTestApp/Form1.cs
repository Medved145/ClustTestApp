using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusteringTestApp
{
    public partial class Form1 : Form
    {
        private int count = 0;
        private string massive = String.Empty;
        private double[] dmassive;
        private double[][] ddmassive;
        ClustTest clusterist = new ClustTest();
        public Form1()
        {
            InitializeComponent();
            ConsoleTextBox.Text += "Введите количество точек";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doubleMass();
        }

        private void doubleMass()
        {
            if (massive == String.Empty && count != 0)
            {
                string[] splitmassive;

                ConsoleTextBox.Text += Environment.NewLine;
                ConsoleTextBox.Text += InputTextBox.Text;

                massive = InputTextBox.Text;
                massive = massive.Replace('.', ',');

                splitmassive = massive.Split(' ');
                if (splitmassive.Length < count)
                {
                    ConsoleTextBox.Text += Environment.NewLine;
                    ConsoleTextBox.Text += "Вы ввели недостаточно чисел, введите их сново";
                    massive = String.Empty;
                    InputTextBox.Text = String.Empty;
                }
                else
                {
                    string[] koord = new string[2];
                    InputTextBox.Text = String.Empty;
                    for (int i = 0; i < count; i++)
                    {
                        ddmassive[i] = new double[2];
                        koord = splitmassive[i].Split(';');
                        if (koord.Length != 2)
                        {
                            ConsoleTextBox.Text += Environment.NewLine;
                            ConsoleTextBox.Text += "Вы ввели недостаточно чисел, введите их сново";
                            massive = String.Empty;
                        }
                        else
                        {
                            ddmassive[i][0] = Convert.ToDouble(koord[0]);
                            ddmassive[i][1] = Convert.ToDouble(koord[1]);
                        }
                    }
                }
                ConsoleTextBox.Text += Environment.NewLine;
                ConsoleTextBox.Text += String.Join(Environment.NewLine, clusterist.Clustering(ddmassive));
            }
            if (count == 0)
            {
                count = Convert.ToInt32(InputTextBox.Text);
                ConsoleTextBox.Text += Environment.NewLine;
                ConsoleTextBox.Text += "Введите " + count.ToString() + " координат через пробел. Пример x;y";
                InputTextBox.Text = String.Empty;
                ddmassive = new double[count][];
            }
        }

        //private void odniceMass()
        //{
        //    if (massive == String.Empty && count != 0)
        //    {
        //        string[] splitmassive;

        //        ConsoleTextBox.Text += Environment.NewLine;
        //        ConsoleTextBox.Text += InputTextBox.Text;

        //        massive = InputTextBox.Text;
        //        massive = massive.Replace('.', ',');

        //        splitmassive = massive.Split(' ');
        //        if (splitmassive.Length < count)
        //        {
        //            ConsoleTextBox.Text += Environment.NewLine;
        //            ConsoleTextBox.Text += "Вы ввели недостаточно чисел, введите их сново";
        //            massive = String.Empty;
        //            InputTextBox.Text = String.Empty;
        //        }
        //        else
        //        {
        //            InputTextBox.Text = String.Empty;
        //            for (int i = 0; i < count; i++)
        //            {
        //                dmassive[i] = Convert.ToDouble(splitmassive[i]);
        //            }
        //        }
        //        ConsoleTextBox.Text += Environment.NewLine;
        //        ConsoleTextBox.Text += String.Join(Environment.NewLine, clusterist.Clustering(dmassive));
        //    }
        //    if (count == 0)
        //    {
        //        count = Convert.ToInt32(InputTextBox.Text);
        //        ConsoleTextBox.Text += Environment.NewLine;
        //        ConsoleTextBox.Text += "Введите " + count.ToString() + " чисел через пробел";
        //        InputTextBox.Text = String.Empty;
        //        dmassive = new double[count];
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            ConsoleTextBox.Text = String.Empty;
            count = 0;
            massive = String.Empty;
            ConsoleTextBox.Text += "Введите количество точек";
        }
    }
}
