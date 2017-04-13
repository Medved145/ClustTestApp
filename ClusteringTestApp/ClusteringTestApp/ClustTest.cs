using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringTestApp
{
    class ClustTest
    {
        public string[] ClusteringTestApp(double[] data)
        {
            double r = -1;//r* по формуле
            double ra = 0;//r1 по формуле
            double[] F = new double[data.Length];
            string[] result;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (i != j)
                    {
                        ra = Math.Sqrt(Math.Pow((data[i] - data[j]), 2) + Math.Pow(r, 2));
                        F[i] += 1-(ra/(ra-r));
                    }
                    else
                    {
                        F[i] += 1;
                    }
                }
                F[i] /= data.Length;
            }
            result = new string[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = data[i].ToString() + ", " + F[i].ToString();
            }
            return result;
        }

        public string[] ClusteringTestApp(double[][] data)
        {
            double r = -1;//r* по формуле
            double ra = 0;//r1 по формуле
            double[] F = new double[data.Length];
            string[] result;
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (i != j)
                    {
                        ra = Math.Sqrt(Math.Pow((data[i][0] - data[j][0]), 2) + Math.Pow((data[i][1] - data[j][1]), 2) + Math.Pow(r, 2));
                        F[i] += 1 - (ra / (ra - r));
                    }
                    else
                    {
                        F[i] += 1;
                    }
                }
                F[i] /= data.Length;
            }
            result = new string[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = data[i][0].ToString() + ";" + data[i][1] + ", " + F[i].ToString();
            }
            return result;
        }
    }
}
