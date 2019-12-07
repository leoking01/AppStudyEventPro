using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudyEventPro
{





    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public event EventHandler Main2SlaveMsgEvent;


        public event EventHandler<EventArgs_myData> sendImageToTargetWnd;

        Form2 form2 = null;

        // 打开一个窗口
        private void button1_Click(object sender, EventArgs e)
        {
            if (null != form2)
                return;
            form2 = new Form2();
            Main2SlaveMsgEvent += form2.textChange;
            sendImageToTargetWnd += form2.receiveImage;//()
            form2.Show();
            //form2.ShowDialog();
        }

        static int id = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            id++;
            MyEventArg eee = new MyEventArg()
            {
                //Text = DateTime.Now.Second.ToString()
                Text = id.ToString()  //"999"
            };

            Main2SlaveMsgEvent.Invoke(this, eee);
        }





        //发送图像到目标窗口
        private void button3_Click(object sender, EventArgs e)
        {
            if (m_img != null)
            {
                EventArgs_myData em = new EventArgs_myData();//{  m_img  };
                em.img = m_img;
                sendImageToTargetWnd.Invoke(this, em);
            }
            else
            {
                MessageBox.Show("m_img is null.");
            }
        }


        //---------------------------------------------------------------------
        private string pathname = string.Empty;     		//定义路径名变量
        //Image.Image m_img = new Image();

        Image m_img;

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ".";
            file.Filter = "所有文件(*.*)|*.*";
            file.ShowDialog();
            if (file.FileName != string.Empty)
            {
                try
                {
                    pathname = file.FileName;   //获得文件的绝对路径
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    m_img = Image.FromFile(pathname);
                    this.pictureBox1.Load(pathname);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            if (save.FileName != string.Empty)
            {
                pictureBox1.Image.Save(save.FileName);
            }
        }




        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "Jpg Files(*.jpg)|*.jpg|Bmp Files(*.bmp)|*.bmp";
            // ofdlg.Filter = "Bmp Files(*.bmp)|*.bmp|Gif Files（*.gif)| *.gif|Jpg Files(*.jpg)|*.jpg";
            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(ofdlg.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = image;
            }
        }


        private void button100_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "Jpg Files(*.jpg)|*.jpg|Bmp Files(*.bmp)|*.bmp";
            // ofdlg.Filter = "Bmp Files(*.bmp)|*.bmp|Gif Files（*.gif)| *.gif|Jpg Files(*.jpg)|*.jpg";
            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(ofdlg.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = image;
            }
        }
    }

    public class EventArgs_myData : EventArgs
    {
        public Image img;
    }
}
