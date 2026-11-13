using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        bool isPlayer1Turn = true;
        bool gameOver = false;
        short moveCount = 0;

        void ResetPicBox (PictureBox pBox)
        {
            pBox.Image = Resources.question_mark_96;
            pBox.Tag = "";
            pBox.BackColor = Color.White;
        }

        void RestartGame ()
        {

            ResetPicBox(picBox1);
            ResetPicBox(picBox2);
            ResetPicBox(picBox3);
            ResetPicBox(picBox4);
            ResetPicBox(picBox5);
            ResetPicBox(picBox6);
            ResetPicBox(picBox7);
            ResetPicBox(picBox8);
            ResetPicBox(picBox9);


            lblTurn.Text = "Player 1";
            lblWinner.Text = "In Progress";
            isPlayer1Turn = true;
            gameOver = false;
            moveCount = 0;
        }

        void StartGame (PictureBox picBox)
        {
            

            if(picBox.Tag.ToString() != "")
            {
                MessageBox.Show("Wrong Choice!", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            picBox.Image = isPlayer1Turn ? Resources.X : Resources.O;
            picBox.Tag = isPlayer1Turn ? "X" : "O";
            moveCount++;

            CheckWinner();

            if (gameOver)
                return;

            if (moveCount == 9)
            {
                gameOver = true;
                lblWinner.Text = "Draw";
                MessageBox.Show("Draw!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isPlayer1Turn = !isPlayer1Turn;
            lblTurn.Text = isPlayer1Turn ? "Player 1" : "Player 2";
        }

        bool CheckValues (PictureBox pBox1, PictureBox pBox2, PictureBox pBox3)
        {

            if((pBox1.Tag.ToString() != "") &&( pBox1.Tag.ToString() == pBox2.Tag.ToString() ) &&  ( pBox2.Tag.ToString() == pBox3.Tag.ToString()))
            {
                gameOver = true;
                pBox1.BackColor = Color.LightPink;
                pBox2.BackColor = Color.LightPink;
                pBox3.BackColor = Color.LightPink;


                if (pBox1.Tag.ToString() == "X")
                {
                    lblWinner.Text = "Player 1";
                    MessageBox.Show("Player 1 Win ", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }

                else if (pBox1.Tag.ToString() == "O")
                {
                    lblWinner.Text = "Player 2";
                    MessageBox.Show("Player 2 Win ", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }


            return false;

        }

        void CheckWinner()
        {


            // Check Rows

            if (CheckValues(picBox1, picBox2, picBox3))
                return;

            if (CheckValues(picBox4, picBox5, picBox6))
                return;

            if (CheckValues(picBox7, picBox8, picBox9))
                return;

            // Check Cols
            if (CheckValues(picBox1, picBox4, picBox7))
                return;

            if (CheckValues(picBox2, picBox5, picBox8))
                return;

            if (CheckValues(picBox3, picBox6, picBox9))
                return;


            // Check Diagonals 
            if (CheckValues(picBox1, picBox5, picBox9))
                return;

            if (CheckValues(picBox3, picBox5, picBox7))
                return;

        }

        void Box_Click(object sender, EventArgs e)
        {
            StartGame((PictureBox)sender);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Brown, 5))
            {
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                e.Graphics.DrawLine(pen, 400, 100, 400, 400);
                e.Graphics.DrawLine(pen, 500, 100, 500, 400);
                e.Graphics.DrawLine(pen, 300, 200, 600, 200);
                e.Graphics.DrawLine(pen, 300, 300, 600, 300);
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
