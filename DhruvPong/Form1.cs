using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DhruvPong
{
    public partial class Form1 : Form
    {

        //int x;
        //int y;
        //int width;
        //int height;
        //int size;
        //int speedX = 35, speedY = 35;
        PaddleClass paddle;
        PaddleClass paddle2;
        BallClass ball;
        Graphics gfx;
        Bitmap bitmap;
        int player1score = 0;
        int player2score = 0;
        public Form1()
        {
            InitializeComponent();

            

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            gfx = Graphics.FromImage(bitmap);

           Color color = Color.FromArgb(255, 3, 3, 3);
          // Color color = Color.FromArgb(255, 30, 30, 30); 

            ball = new BallClass(100, 100, 100, 100, 10, 10, color);
            paddle = new PaddleClass(0, 150, 40, 180, color);
            paddle2 = new PaddleClass(1340, 150,39, 180, color);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                paddle.moveUp();
            }

            else if (e.KeyCode == Keys.S)
            {
                paddle.moveDown();
            }
            else if (e.KeyCode == Keys.Up)
            {
                paddle2.moveUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                paddle2.moveDown();
            }
            else if (e.KeyCode == Keys.Space)
            {
                ball.offscreen = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            score1.Text = $"{player1score}";
            score2.Text = $"{player2score}";

            ball.x += ball.speedX;
            ball.y += ball.speedY;
            gfx.Clear(Color.Black);

            gfx.FillRectangle(Brushes.White, ClientSize.Width / 2, 0, 5, 6000);

            paddle.Draw(gfx);

            paddle2.Draw(gfx);

            ball.Draw(gfx);


            if (ball.x <= 0 || ball.x >= ClientSize.Width)
            {
                if (ball.x <= 0)
                {

                    player2score++;

                }
                else
                {

                    player1score++;

                }
                ball.Reset(ClientSize.Width, ClientSize.Height);
            }
            else
            {
                ball.Move(ClientSize.Width, ClientSize.Height);
            }


           if (player1score > 6)
           {
               MessageBox.Show("Player 1 Won!");
               Close();
            }
            else if (player2score > 6)
            {
                MessageBox.Show("Player 2 Won!");
                Close();
            }


            ball.IntersectsPaddle(paddle, true);
            ball.IntersectsPaddle(paddle2, false);


            pictureBox1.Image = bitmap;
            
        }

    }
}
