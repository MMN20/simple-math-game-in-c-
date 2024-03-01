using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathGame
{

    public enum Operations { Add,Sub,Mul,Div,Mix}

    public enum Level { Easy,Med,Hard,Mix}



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Operations oper = Operations.Add;

        public static Level level = Level.Easy;

        public static int NumberOfQuestions = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            lblNOfRounds.Text = "1";
            lblDifficulty.Text = level.ToString();
            lblOperation.Text = oper.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberOfQuestions = Convert.ToInt32(lblNOfRounds.Tag) + 1;
            lblNOfRounds.Tag = NumberOfQuestions;
            lblNOfRounds.Text = NumberOfQuestions.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(NumberOfQuestions > 1) 
            {
                NumberOfQuestions = Convert.ToInt32(lblNOfRounds.Tag) - 1;
                lblNOfRounds.Tag = NumberOfQuestions;
                lblNOfRounds.Text = NumberOfQuestions.ToString();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if((int)level < 3)
            {
                level = (Level) (int)level + 1;
                lblDifficulty.Tag = (short)level;
                lblDifficulty.Text = level.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((int)level > 0)
            {
                level = (Level)(int)level - 1;
                lblDifficulty.Tag = (short)level;
                lblDifficulty.Text = level.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if((int)oper < 4)
            {
                oper = (Operations) (int)oper + 1;
                lblOperation.Tag = (short)oper;
                lblOperation.Text = oper.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((int)oper > 0)
            {
                oper = (Operations)(int)oper - 1;
                lblOperation.Tag = (short)oper;
                lblOperation.Text = oper.ToString();
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            frmGameForm frm = new frmGameForm();
            frm.Show();
            this.Visible = false;
        }
    }
}
