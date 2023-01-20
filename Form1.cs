using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment01Question03
{
    public partial class Form1 : Form
    {
        Filters filterObject = new Filters();
        OpenFileDialog ofd = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filterObject.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox1.ImageLocation = picPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filterObject.LoadGrayScaleImage();
            pictureBox2.ImageLocation = "gray.jpg";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filterObject.SmoothFilter();
            pictureBox3.ImageLocation = "smoothedImage.jpg";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filterObject.MedianMeanFilter();
            pictureBox4.ImageLocation = "medianMeanFilter.jpg";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filterObject.ApplyArithmeticOnce("3a (1).png");
            filterObject.ApplyArithmeticOnce("3a (2).png");
            filterObject.ApplyArithmeticOnce("3a (3).png");
            filterObject.ApplyArithmeticOnce("3a (4).png");
            filterObject.ApplyArithmeticOnce("3a (5).png");
            filterObject.ApplyArithmeticOnce("3a (6).png");
            filterObject.ApplyArithmeticOnce("3a (7).png");
            filterObject.ApplyArithmeticOnce("3a (8).png");
            filterObject.ApplyArithmeticOnce("3a (9).png");
            filterObject.ApplyArithmeticOnce("3a (10).png");

            pictureBox5.ImageLocation = "Converted 3a (1).png";
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.ImageLocation = "Converted 3a (2).png";
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.ImageLocation = "Converted 3a (3).png";
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.ImageLocation = "Converted 3a (4).png";
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.ImageLocation = "Converted 3a (5).png";
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.ImageLocation = "Converted 3a (6).png";
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.ImageLocation = "Converted 3a (7).png";
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.ImageLocation = "Converted 3a (8).png";
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox13.ImageLocation = "Converted 3a (9).png";
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.ImageLocation = "Converted 3a (10).png";
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] photos = { "3a (1).png", "3a (2).png", "3a (3).png", "3a (4).png", "3a (5).png", "3a (6).png", "3a (7).png", "3a (8).png", "3a (9).png", "3a (10).png" };
            filterObject.GenerateAverageImage(photos);
            pictureBox15.ImageLocation = "ConvertedAveragingAtOnce.jpg";
            pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
