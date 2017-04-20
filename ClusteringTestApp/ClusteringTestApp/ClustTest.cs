using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringTestApp
{
    class ClustTest
    {
        //public string Clustering(double[] data)
        //{
        //    double[] F;
        //    int number = 0;
        //    F = FindFirstpillar(data);

        //    return "0";
        //}

        public string Clustering(double[][] data)
        {
            int kmin = 2;
            int kmax = 5;
            double r1;
            double r2;
            double[] F;
            double F0;
            double[,] C = new double[kmax - 1, data.Length];
            int[] numbers = new int[kmax];
            for (int i = 0; i < kmax; i++)
            {
                numbers[i] = -1;
            }
            double[,] S = new double[kmax, 2];
            F = FindFirstPillar(data);
            F0 = F[0];
            S[0, 0] = data[0][0];
            S[0, 1] = data[0][1];
            numbers[0] = 0;
            for (int i = 1; i < F.Length; i++)
            {
                if (F0 < F[i])
                {
                    S[0, 0] = data[i][0];
                    S[0, 1] = data[i][1];
                    numbers[0] = i;
                    F0 = F[i];
                }
            }
            for (int i = 0; i < F.Length; i++)
            {
                C[0, i] = 0;
                if (i != numbers[0])
                {
                    for (int j = 0; j < F.Length; j++)
                    {
                        r1 = Math.Sqrt(Math.Pow((data[i][0] - data[j][0]), 2) + Math.Pow((data[i][1] - data[j][1]), 2));
                        r2 = Math.Sqrt(Math.Pow((data[i][0] - data[j][0]), 2) + Math.Pow((data[i][1] - data[numbers[0]][1]), 2));
                        C[0, i] += Competition(r1, r2);
                    }
                }
            }
            if (0 != numbers[0])
            {
                F0 = C[0, 0];
                S[1, 0] = data[0][0];
                S[1, 1] = data[0][1];
                numbers[1] = 0;
            }
            else
            {
                F0 = C[0, 1];
                S[1, 0] = data[1][0];
                S[1, 1] = data[1][1];
                numbers[1] = 1;
            }
            for (int i = 1; i < F.Length; i++)
            {
                if (i != numbers[0])
                {
                    if (F0 < C[0, i])
                    {
                        S[1, 0] = data[i][0];
                        S[1, 1] = data[i][1];
                        numbers[1] = i;
                        F0 = C[0, i];
                    }
                }
            }

            return "s1 " + numbers[0].ToString() + " " + S[0, 0] + "," + S[0, 1] + Environment.NewLine + "s2 " + numbers[1].ToString() + " " + S[1, 0] + "," + S[1, 1];
        }
        
        //double[] FindFirstpillar(double[] data)
        //{
        //    double r = 1;//r* по формуле - растояние до виртуального пространства
        //    double r1 = 0;//r1 по формуле - растояние до столпа
        //    double[] F = new double[data.Length];
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        for (int j = 0; j < data.Length; j++)
        //        {
        //            if (i != j)
        //            {
        //                r1 = Math.Sqrt(Math.Pow((data[i] - data[j]), 2) + Math.Pow(r, 2));
        //                F[i] += 1 - (r1 / (r1 + r));
        //            }
        //            else
        //            {
        //                F[i] += 1;
        //            }
        //        }
        //        F[i] /= data.Length;
        //    }

        //    return F;
        //}

        double[] FindFirstPillar(double[][] data)
        {
            double r = 1;//r* по формуле - растояние до виртуального пространства
            double r1 = 0;//r1 по формуле - растояние до столпа
            double[] F = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (i != j)
                    {
                        r1 = Math.Sqrt(Math.Pow((data[i][0] - data[j][0]), 2) + Math.Pow((data[i][1] - data[j][1]), 2) + Math.Pow(r, 2));
                        F[i] += Competition(r1, r);
                    }
                    else
                    {
                        F[i] += 1;
                    }
                }
                F[i] /= data.Length;
            }

            return F;
        }

        //double[] FindMPillar(double[][] data)
        //{
        //    double[] result = new double[data.Length];

        //    return result;
        //}

        double Competition(double r1, double r2)
        {
            double result = 1 - (r1 / (r1 + r2));
            return result;
        }
    }
}
