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
            InitializeComponent();
        }
        int[,] grayarr;

        // 전역변수 선언할것.

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            label1.Text = "원 영상";
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //그레이 영상
            int i, j, value;
            grayarr = new int[pictureBox1.Width, pictureBox1.Height];
            Color color, gray;
            Bitmap gbitmap = new Bitmap(pictureBox1.Image);

            for (i = 0; i < pictureBox1.Height; i++)
            {
                for (j = 0; j < pictureBox1.Width; j++)
                {
                    color = gbitmap.GetPixel(j, i);
                    value = (int)(color.R + color.G + color.B) / 3;
                    grayarr[j, i] = value;
                    gray = Color.FromArgb(value, value, value);
                    gbitmap.SetPixel(j, i, gray);
                }
                pictureBox2.Image = gbitmap;
                label2.Text = "그레이 영상";
            }
        }

        // 2 * 2 = 5개
        private void twobytwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, j, x, y, value, pattern;

            int[,,] twomask = { { { 0, 0}, { 0, 0}},
                                   { {0, 0 }, {0, 255 } },
                                   { {255, 0 }, {0, 255 } },
                                   { {255, 255}, {0, 255 } },
                                   { {255, 255}, {255, 255 } },
                                   { {255, 255}, {255, 255 } }
            };
            Color gray;
            value = (int)(255 / 5);

            Bitmap pb = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Bitmap pbitmap = new Bitmap(pb.Width * 2, pb.Height * 2);
            grayToolStripMenuItem_Click(sender, e);
            for (i = 0; i < pb.Height; i++)
            {
                for (j = 0; j < pb.Width; j++)
                {
                    pattern = (int)(grayarr[j, i] / value);
                    for (y = 0; y <= 1; y++)
                    {
                        for (x = 0; x <= 1; x++)
                        {
                            gray = Color.FromArgb(twomask[pattern, x, y], twomask[pattern, x, y], twomask[pattern, x, y]);
                            pbitmap.SetPixel(j * 2 + x, i * 2 + y, gray);
                        }
                    }
                }
            }
            pictureBox3.Image = pbitmap;
            label3.Text = "2 * 2 ";
        }

        // 3 * 3 = 10개
        private void threebythreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, j, x, y, value, pattern;

            // 255 밝은색
            // 0 어두운색

            int[,,] threemask = { { { 0, 0, 0}, { 0, 0, 0}, { 0, 0, 0} },
                                   { {0, 0, 0 }, {0, 255, 0 }, {0, 0, 0} },
                                   { {255, 0, 0 }, {0, 255, 0}, {0, 0, 255 } },
                                   { {255, 255, 0}, {0, 255, 0}, {0, 0, 255} },
                                   { {255, 255, 0}, {0, 255, 0 }, {0, 255, 255 } },
                                   { {255, 255, 0}, {0, 255, 255 }, {255, 0, 255 }},
                                   { {255, 255, 255 }, {0, 255, 0 }, {0, 255, 255} },
                                   { {255, 255, 255 }, {0, 255, 0 }, {255, 255, 255 } },
                                   { {255, 255, 255 }, {255, 255, 255 }, {255, 255, 255 } },
                                    { {255, 255, 255 }, {255, 255, 255 }, {255, 255, 255 } },
            };
            Color gray;
            value = (int)(255 / 10);

            Bitmap pb = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Bitmap pbitmap = new Bitmap(pb.Width * 3, pb.Height * 3);
            grayToolStripMenuItem_Click(sender, e);
            for (i = 0; i < pb.Height; i++)
            {
                for (j = 0; j < pb.Width; j++)
                {
                    pattern = (int)(grayarr[j, i] / value);
                    for (y = 0; y <= 1; y++)
                    {
                        for (x = 0; x <= 1; x++)
                        {
                            gray = Color.FromArgb(threemask[pattern, x, y], threemask[pattern, x, y], threemask[pattern, x, y]);
                            pbitmap.SetPixel(j * 3 + x, i * 3 + y, gray);
                        }
                    }
                }
            }
            pictureBox4.Image = pbitmap;
            label4.Text = "3 * 3";
        }

        // 4*4 패터닝 반대로 하기
        // 3/24까지 제출하기.
        private void fourbyfourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, j, x, y, value, pattern;

            // 255 밝은색
            // 0 어두운색

            int[,,] fourmask = { { { 0, 0, 0, 0}, { 0, 0, 0, 0}, { 0, 0, 0, 0}, { 0, 0, 0, 0} },
                                   { {0, 0, 0, 0 }, {0, 255, 0, 0 }, {0, 0, 0, 0}, {0, 0, 255, 0} },
                                   { {255, 0, 0, 0 }, {0, 255, 0, 0}, {0, 0, 255, 0}, {0, 0, 255, 0} },
                                   { {255, 255, 0, 0}, {0, 255, 0, 0}, {0, 0, 255, 0}, {255, 0, 255, 0} },
                                   { {255, 255, 0, 0}, {0, 255, 0, 0}, {0, 255, 255, 0}, {0, 255, 255, 0} },
                                   { {255, 255, 0, 0}, {0, 255, 255, 0 }, {255, 0, 255, 0 }, {255, 255, 255, 0}},
                                   { {0, 255, 255, 0 }, {0, 255, 0, 0 }, {0, 255, 255, 0}, {255, 255, 255, 0} },
                                   { {255, 255, 255, 0 }, {0, 255, 255, 0 }, {255, 255, 255, 255 }, {255, 255, 255, 0} },
                                   { {255, 255, 255, 0 }, {255, 255, 255, 255 }, {255, 255, 255, 0}, {0, 255, 255, 255} },
                                    { {255, 255, 255, 0 }, {255, 255, 255, 255 }, {255, 255, 255, 0 }, {255, 0, 255, 255} },

                                    { {255, 255, 255, 0 }, {255, 255, 255, 255 }, {255, 255, 255, 0 }, {0, 255, 255, 255} },
                                    { {255, 0, 255, 255 }, {255, 255, 255, 0 }, {255, 255, 255, 0 }, {0, 255, 0, 0} },
                                    { {0, 255, 255, 255 }, {255, 255, 255, 0 }, {255, 255, 255, 0 }, {255, 255, 0, 255} },
                                    { {255, 255, 0, 255 }, {255, 255, 255, 0 }, {255, 255, 255, 0 }, {255, 255, 0, 255} },
                                    { {255, 255, 255, 0 }, {255, 255, 255, 255 }, {255, 255, 255, 255 }, {255, 255, 255, 255} },
                                    { {255, 255, 255, 255 }, {255, 255, 255, 255 }, {255, 255, 255, 255 },  {255, 255, 255, 255} },
                                    { {255, 255, 255, 255 }, {255, 255, 255, 255 }, {255, 255, 255, 255 }, {255, 255, 255, 255} }, 
            }; // 17개
            Color gray;
            value = (int)(255 / 17);

            Bitmap pb = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Bitmap pbitmap = new Bitmap(pb.Width * 4, pb.Height * 4);
            grayToolStripMenuItem_Click(sender, e);
            for (i = 0; i < pb.Height; i++)
            {
                for (j = 0; j < pb.Width; j++)
                {
                    pattern = (int)(grayarr[j, i] / value);
                    for (y = 0; y <= 1; y++)
                    {
                        for (x = 0; x <= 1; x++)
                        {
                            // 원위치와 디더링행렬 적용만한다.
                            // 테더링과 디더링의 차이는
                            // 테더링: 출력장치가 더 클 때 사용됌., 사이즈 키우기.
                            // 디더링: 출력장치와 똑같을 때사용됌
                            gray = Color.FromArgb(fourmask[pattern, x, y], fourmask[pattern, x, y], fourmask[pattern, x, y]);
                            pbitmap.SetPixel(j * 4 + x, i * 4 + y, gray);
                        }
                    }
                }
            }
            pictureBox5.Image = pbitmap;
            label5.Text = "4 * 4";
        }

        
       

        private void 일반디더링ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, j;
            Color gray;

            Bitmap pb = new Bitmap(pictureBox1.Width, pictureBox1.Height); // 전역변수로 만들것.
            Bitmap dlbitmap = pb;

            // 4*4 디더링
            int[,] dl = { { 0, 128, 32, 160},
                            {192, 64, 224, 96 },
                            { 48, 176, 16, 144},
                            {240, 112, 208, 80 }
            };

            grayToolStripMenuItem_Click(sender, e);
            for (i = 0; i < pb.Height; i++)
            {
                for (j = 0; j < pb.Width; j++)
                {
                    if (grayarr[j, i] > dl[j % 4, i % 4])
                    {
                        gray = Color.FromArgb(255, 255, 255);
                        dlbitmap.SetPixel(j, i, gray);
                    }
                    else
                    {
                        gray = Color.FromArgb(0, 0, 0);
                        dlbitmap.SetPixel(j, i, gray);
                    }
                }
            }
            pictureBox6.Image = dlbitmap;
            label6.Text = "일반디더링";
        }

        // 45도 디더링
        private void 도디더링ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, j;
            Color gray;

            Bitmap pb = new Bitmap(pictureBox1.Width, pictureBox1.Height); // 전역변수로 만들것.
            Bitmap dlbitmap = pb;

            // 5*5 디더링
            int[,] dl = { { 167, 200, 230, 216, 181},
                            {94, 72, 193, 242, 232 },
                            { 36, 52, 222, 167, 200},
                            {181, 126, 210, 94, 72 },
                            {232, 153, 111, 36, 52 }
            };

            grayToolStripMenuItem_Click(sender, e);
            for (i = 0; i < pb.Height; i++)
            {
                for (j = 0; j < pb.Width; j++)
                {
                    if (grayarr[j, i] > dl[j % 5, i % 5])
                    {
                        gray = Color.FromArgb(255, 255, 255);
                        dlbitmap.SetPixel(j, i, gray);
                    }
                    else
                    {
                        gray = Color.FromArgb(0, 0, 0);
                        dlbitmap.SetPixel(j, i, gray);
                    }
                }
            }
            pictureBox7.Image = dlbitmap;
            label7.Text = "45도 디더링";
        }
    }
}
