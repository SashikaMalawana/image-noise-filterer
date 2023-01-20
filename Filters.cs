using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Assignment01Question03
{
    class Filters
    {
        IplImage src, grayImage, resultImage, colorImage, smoothImage;
        IplImage[] srcc = new IplImage[10];
        IplImage[] grayImagee = new IplImage[10];

        double[] pixelValueArray = new double[9];

        public void LoadOriginalImage(string fname)
        {

            src = Cv.LoadImage(fname, LoadMode.Color);
            Cv.SaveImage(fname, src);
        }

        public void LoadGrayScaleImage()
        {
            grayImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, grayImage, ColorConversion.RgbToGray);
            Cv.SaveImage("gray.jpg", grayImage);
        }

        public void LoadColorScaleImage()
        {
            colorImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            Cv.CvtColor(resultImage, colorImage, ColorConversion.GrayToRgb);
            Cv.SaveImage("color.jpg", colorImage);
        }

        public void ArithmaticMeanFilter()
        {
            LoadGrayScaleImage();

            resultImage = Cv.CreateImage(grayImage.Size, BitDepth.U8, 1);
            for (int y = 1; y < grayImage.Height - 1; y++)
            {
                for (int x = 1; x < grayImage.Width - 1; x++)
                {
                    double theSum = 0.0;
                    double newPixValue = 0.0;

                    theSum += Cv.GetReal2D(grayImage, y - 1, x - 1);
                    theSum += Cv.GetReal2D(grayImage, y - 1, x);
                    theSum += Cv.GetReal2D(grayImage, y - 1, x + 1);
                    theSum += Cv.GetReal2D(grayImage, y, x - 1);
                    theSum += Cv.GetReal2D(grayImage, y, x);
                    theSum += Cv.GetReal2D(grayImage, y, x + 1);
                    theSum += Cv.GetReal2D(grayImage, y + 1, x - 1);
                    theSum += Cv.GetReal2D(grayImage, y + 1, x);
                    theSum += Cv.GetReal2D(grayImage, y + 1, x + 1);

                    newPixValue = (double)theSum / 9.0;

                    Cv.SetReal2D(resultImage, y, x, newPixValue);
                }
            }
            Cv.SaveImage("arithmaticMeanFilter.jpg", resultImage);

            LoadColorScaleImage();
        }

        public void MedianMeanFilter()
        {
            LoadGrayScaleImage();

            resultImage = Cv.CreateImage(grayImage.Size, BitDepth.U8, 1);
            for (int y = 1; y < grayImage.Height - 1; y++)
            {
                for (int x = 1; x < grayImage.Width - 1; x++)
                {
                    double newPixValue = 0.0;

                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y - 1, x - 1), 0);
                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y - 1, x), 1);
                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y - 1, x + 1), 2);
                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y, x - 1), 3);
                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y, x), 4);
                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y, x + 1), 5);
                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y + 1, x - 1), 6);
                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y + 1, x), 7);
                    pixelValueArray.SetValue(Cv.GetReal2D(grayImage, y + 1, x + 1), 8);
                    Array.Sort(pixelValueArray);

                    newPixValue = (Double)pixelValueArray.GetValue(4);
                    Cv.SetReal2D(resultImage, y, x, newPixValue);

                }
            }
            Cv.SaveImage("medianMeanFilter.jpg", resultImage);

            LoadColorScaleImage();
        }

        public void SmoothFilter()
        {
            smoothImage = Cv.CreateImage(src.Size, BitDepth.U8, 3);
            Cv.Smooth(src, smoothImage, SmoothType.Median, 3, 3);
            Cv.SaveImage("smoothedImage.jpg", smoothImage);
        }

        public void MaximumFilter()
        {
            smoothImage = Cv.CreateImage(grayImage.Size, BitDepth.U8, 1);
            Cv.Dilate(grayImage, smoothImage, null, 1);
            Cv.SaveImage("maximumFilterImage.jpg", smoothImage);
        }

        public void MinimumFilter()
        {
            smoothImage = Cv.CreateImage(grayImage.Size, BitDepth.U8, 1);
            Cv.Erode(grayImage, smoothImage, null, 1);
            Cv.SaveImage("minimumFilterImage.jpg", smoothImage);
        }

        public void ApplyArithmeticOnce(string fname)
        {
            src = Cv.LoadImage(fname, LoadMode.Color);
            grayImage = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, grayImage, ColorConversion.RgbToGray);

            resultImage = Cv.CreateImage(grayImage.Size, BitDepth.U8, 1);
            for (int y = 1; y < grayImage.Height - 1; y++)
            {
                for (int x = 1; x < grayImage.Width - 1; x++)
                {
                    double theSum = 0.0;
                    double newPixValue = 0.0;

                    theSum += Cv.GetReal2D(grayImage, y - 1, x - 1);
                    theSum += Cv.GetReal2D(grayImage, y - 1, x);
                    theSum += Cv.GetReal2D(grayImage, y - 1, x + 1);
                    theSum += Cv.GetReal2D(grayImage, y, x - 1);
                    theSum += Cv.GetReal2D(grayImage, y, x);
                    theSum += Cv.GetReal2D(grayImage, y, x + 1);
                    theSum += Cv.GetReal2D(grayImage, y + 1, x - 1);
                    theSum += Cv.GetReal2D(grayImage, y + 1, x);
                    theSum += Cv.GetReal2D(grayImage, y + 1, x + 1);

                    newPixValue = (double)theSum / 9.0;

                    Cv.SetReal2D(resultImage, y, x, newPixValue);
                }
            }
            Cv.SaveImage("Converted " + fname, resultImage);
        }

        public void GenerateAverageImage(string[] fname)
        {
            for (int i=0; i<10; i++)
            {
                srcc[i] = Cv.LoadImage(fname[i], LoadMode.Color);
                grayImagee[i] = Cv.CreateImage(srcc[i].Size, BitDepth.U8, 1);
                Cv.CvtColor(srcc[i], grayImagee[i], ColorConversion.RgbToGray);
            }

            resultImage = Cv.CreateImage(grayImagee[1].Size, BitDepth.U8, 1);
            for (int y = 1; y < resultImage.Height; y++)
            {
                for (int x = 1; x < resultImage.Width; x++)
                {
                    double getPixelValue = 0;
                    getPixelValue = (Cv.GetReal2D(grayImagee[0], y, x) + Cv.GetReal2D(grayImagee[1], y, x) + Cv.GetReal2D(grayImagee[2], y, x) + Cv.GetReal2D(grayImagee[3], y, x) + Cv.GetReal2D(grayImagee[4], y, x) + Cv.GetReal2D(grayImagee[5], y, x) + Cv.GetReal2D(grayImagee[6], y, x) + Cv.GetReal2D(grayImagee[7], y, x) + Cv.GetReal2D(grayImagee[8], y, x) + Cv.GetReal2D(grayImagee[9], y, x)) /10;
                    Cv.SetReal2D(resultImage, y, x, getPixelValue);
                }
            }
            Cv.SaveImage("ConvertedAveragingAtOnce.jpg", resultImage);
        }
    }
}
