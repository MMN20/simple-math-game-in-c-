using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathGame
{
    public partial class frmGameForm : Form
    {
        public frmGameForm()
        {
            InitializeComponent();
        }
        Random rand = new Random();

        GameStatus gameStatus;
        int GetRandomNumber(Level level)
        {
          
            switch (level)
            {
                case Level.Easy:
                    return rand.Next(1,10);
                    
                case Level.Med:
                    return rand.Next(10, 50);
                   
                case Level.Hard:
                    return rand.Next(50, 300);
                   
                case Level.Mix:
                    return GetRandomNumber((Level)rand.Next(0, 3));
                  
            }
            return 0;
        }

        // gets random answer depends on the current level
        int getRandomAnswer()
        {
            int number = GetRandomNumber(Form1.level);
            while (number == Result)
            {
                number = GetRandomNumber(Form1.level);
            }
            return number;
        }

        struct GameStatus
        {
          public  short rightAnswers;
            public short wrongAnswers;
        }

        int number1 = 0;
        int number2 = 0;
        int Result = 0;
        char Operation;
        int currRound = 0;
        int GetResult(Operations oper)
        {
            
            switch (oper)
            {
                case Operations.Add:
                    Operation = '+';
                    return number1 + number2;

                case Operations.Sub:
                    Operation = '-';
                    return number1 - number2;

                case Operations.Mul:
                    Operation = '*';
                    return number1* number2;

                case Operations.Div:
                    Operation = '/';
                    return number1 / number2;

                case Operations.Mix:
                   return GetResult((Operations)rand.Next(0, 4));
            }
            return 0;
        }

        void fillNumber1AndNumber2AndResult()
        {
            number1 = getRandomAnswer();
            number2 = getRandomAnswer();
            Result = GetResult(Form1.oper);
        }

        void AssignTheLabelWithTheirValues()
        {
            lblNum1.Text = number1.ToString();
            lblNum2.Text = number2.ToString();
            lblOper.Text = Operation.ToString();
        }

        short numberOfRounds =(short)Form1.NumberOfQuestions;     

        void WhereToPutTheResult(int num)
        {
            if (num == 1)
                btn1.Text = Result.ToString();
            else
                btn1.Text = getRandomAnswer().ToString();

            if(num == 2)
                btn2.Text = Result.ToString();
            else
                btn2.Text = getRandomAnswer().ToString();

            if(num == 3)
                btn3.Text = Result.ToString();
            else
                btn3.Text = getRandomAnswer().ToString();

            if(num == 4)
                btn4.Text = Result.ToString();
            else
                btn4.Text= getRandomAnswer().ToString();


        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmGameForm_Load(object sender, EventArgs e)
        {
            fillNumber1AndNumber2AndResult();

            AssignTheLabelWithTheirValues();        

            int whereToPutTheRightAnswer = rand.Next(1, 5);

            WhereToPutTheResult(whereToPutTheRightAnswer);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            currRound = 0;
            frmGameForm_Load(sender, e);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           if (currRound < Form1.NumberOfQuestions)
            {
                if (btn.Text == Result.ToString())
                {
                    MessageBox.Show("Right Answer");
                    gameStatus.rightAnswers++;
                }

                else
                {
                    MessageBox.Show("Wrong Answer!");
                    gameStatus.wrongAnswers++;
                }
                currRound++;

                frmGameForm_Load(sender, e);
            }
        


            if (currRound == Form1.NumberOfQuestions)
            {
                string numberOfRounds = Form1.NumberOfQuestions.ToString();
                string numberOfRightAnswers = gameStatus.rightAnswers.ToString();
                string numberOfWrongAnswers = gameStatus.wrongAnswers.ToString();

                string message = "Game Over" + Environment.NewLine;
                message += "Number of Rounds: " + numberOfRounds + Environment.NewLine;
                message += "Number of Right Answers: "+  numberOfRightAnswers + Environment.NewLine;
                message += "Number of Wrong Answers: "+  numberOfWrongAnswers;
                MessageBox.Show(message);
            }
                  
        }


    }
}
