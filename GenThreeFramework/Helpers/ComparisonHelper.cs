using GenThreeFramework.Config;
using NUnit.Framework;
using System;
using System.Drawing;
using System.IO;

namespace GenThreeFramework.Helpers
{
    public class ComparisonHelper
    {

        public static void OperateComparison(string baseFile, string toComapreFile, decimal errorThreshold, string name)
        {
            try
            {
                decimal totalError = 0;
                Bitmap basePicture = new Bitmap(baseFile);
                Bitmap newSnapshot = new Bitmap(toComapreFile);
                Bitmap differences = new Bitmap(basePicture.Width, basePicture.Height);


                for (int x = 0; x < newSnapshot.Width; x++)
                {
                    for (int y = 0; y < newSnapshot.Height; y++)
                    {
                        var comparison = CompareColours(basePicture.GetPixel(x, y), newSnapshot.GetPixel(x, y)) / 198608M;

                        if (comparison > 0)
                        {
                            differences.SetPixel(x, y, Color.Red);
                        }
                        else if (comparison < 0)
                        {
                            differences.SetPixel(x, y, Color.Yellow);
                        }
                        else
                        {
                            differences.SetPixel(x, y, Color.Black);
                        }

                        totalError += comparison;
                    }
                    differences.Save(Configuration.DifferencesSnapshotsFolder + name + "diff.bmp");
                }
                decimal averageError = totalError / (basePicture.Width * basePicture.Height);
                Console.WriteLine("Value for file " + baseFile + " is: " + averageError);
                Assert.IsTrue(averageError < errorThreshold);
            }
            catch (Exception ex)
            {
                //TO DO
            }
        }

        private static int CompareColours(Color x, Color y)
        {
            return (int)(Math.Pow((int)x.R - y.R, 2) + Math.Pow((int)x.B - y.B, 2) + Math.Pow((int)x.G - y.G, 2));
        }

    }
}
