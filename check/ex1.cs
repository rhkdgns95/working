using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // ***** 1.
            InitializeComponent();
        }
        // ***** 2.
        // 전역변수 선언할것.
        int[, ] grayArr;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ***** 3.
            if(openFileDialog.ShowDialog() == DialogReseult.OK) {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
            label1.Text = "원 영상";
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //그레이 영상
            // ***** 4.
            int i, j, value;
            Color color, gray;
            grayArr = new Int[pictureBox1.Width, pictureBox1.Height];

            Bitmap gBitmap = new Bitmap(pictureBox1.Image);
            for(i = 0; i < pictureBox1.Height; i++) {
                for(j = 0; j < pcitureBox1.WIdth; j++) {
                    color = gBitmap.GetPixel(j, i);
                    value = (int) (color.R + color.G + color.B) / 3;
                    gray = Color.FromArgb(value, value, value);
                    grayArr[j, i] = value;
                    gBitmap.SetPixel(j, i, gray);
                }
            }
            pictureBox2.Image = gBitmap;
            label2.Text = "Gray 영상";
            
        }

        // 2 * 2 = 5개
        private void twobytwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ***** 5.
        }

        // 3 * 3 = 10개
        private void threebythreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ***** 6.
        }

        // 4*4 패터닝 반대로 하기
        // 3/24까지 제출하기.
        private void fourbyfourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ***** 7.
        }

        
       

        private void 일반디더링ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ***** 8.
            int i, j;
            Color gray;
            Bitmap pb = new Bitmap(pcitureBox1.Width, pictureBox1.Height);
            Bitmap dlBitmap = pb;

            int[, ] dl = {
                {1, 2, 3, 4, 5},
                {2, 3, 4, 5, 7}
            };
            
            for(i = 0; i < pictureBox1.Height; i++) {
                for(j = 0; j < pictureBox1.Width; j++) {
                    if(grayArr[j, i] > dl[j % 5, j % 5]) {
                        gray = Color.FromArgb(255, 255, 255);
                        dlBitmap.SetPixel(j, i, gray); 
                    } else {
                        gray = Color.FromArgb(0, 0, 0);
                        dlBitmap.SetPixel(j, i, gray);
                    }
                }
            }
            pictureBox3.Image = dlBitmap;
            label3.Text = "디더링~";

        }

        // 45도 디더링
        private void 도디더링ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ***** 9.
        }
    }
}
