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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void textChange(object sender, EventArgs e)
        {
            var a = e as MyEventArg;
            //textBox2.Text = a.Text;
            textBox2.AppendText(a.Text+"\r\n");
        }


        public void receiveImage(object sender, EventArgs_myData  e)
        {
            var a = e as EventArgs_myData;
            Image img = a.img;

            Rectangle  rect = this.pictureBox1.DisplayRectangle ;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Image = img;
            textBox2.AppendText("接收了图片。\r\n");// "";
        }





    }
}
