using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int divided;
        int diviser;
        int timeLeft;
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            label3.Text=addend1.ToString();
            label5.Text=addend2.ToString();
            numericUpDown1.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1,minuend);
            label10.Text=minuend.ToString();
            label8.Text=subtrahend.ToString();
            numericUpDown2.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            label14.Text=multiplicand.ToString();
            label12.Text=multiplier.ToString();
            numericUpDown3.Value = 0;

            diviser = randomizer.Next(2, 11);
            int temporaryQuotion=randomizer.Next(2, 11);
            divided = diviser * temporaryQuotion;
            label18.Text=divided.ToString();
            label16.Text=diviser.ToString();
            numericUpDown4.Value = 0;

            timeLeft = 360;
            label2.Text = "360 seconds";
            timer1.Start();
        }
        private void StartButton_Click(object sender,EventArgs e)
        {
            StartTheQuiz();
            button1.Enabled = false;
        }
        private bool CheckTheAnswer()
        {
            if ((addend1+addend2==numericUpDown1.Value) && (minuend-subtrahend==numericUpDown2.Value)
                && (multiplicand*multiplier==numericUpDown3.Value) && (divided/diviser==numericUpDown4.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers rigth!", "Congratutions!", MessageBoxButtons.OK);
                button1.Enabled=true;
            }
            else if (timeLeft > 5)
            {
                timeLeft = timeLeft - 1;
                label2.Text = timeLeft.ToString() + " seconds";
            }
            else if(0<timeLeft && timeLeft < 5)
            {
                label2.BackColor = Color.Red;
                timeLeft = timeLeft - 1;
                label2.Text = timeLeft.ToString() + " seconds";
            }
            else
            {
                timer1.Stop();
                label2.Text = "Time's up!";
                MessageBox.Show("You didn't finished in time.","Sorry!");
                numericUpDown1.Value = addend1 + addend2;
                numericUpDown2.Value = minuend - subtrahend;
                numericUpDown3.Value = multiplicand * multiplier;
                numericUpDown4.Value = divided / diviser;
                button1.Enabled = true;
            }
        }
        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = new NumericUpDown();
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == addend1 + addend2)
            {
                timer1.Stop();
                MessageBox.Show("That's right. Gp ahead.","The value is changed!",MessageBoxButtons.OK);
                timer1.Start();
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == minuend - subtrahend)
            {
                timer1.Stop();
                MessageBox.Show("That's right. Go ahead.", "The value is changed!", MessageBoxButtons.OK);
                timer1.Start();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown3.Value==multiplicand * multiplier)
            {
                timer1.Stop();
                MessageBox.Show("That's right. Go ahead.","The value is changed!",MessageBoxButtons.OK);
                timer1.Start();
            }
        }
    }
}
