using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvPong
{
    class BallClass
    {

        public int x;
        public int y;
        public int width;
        public int height;
        public int speedX;
        public int speedY;
        public bool offscreen;
        int startingSpeed;
        Color color;
        public Rectangle Hitbox
        {
            get { return new Rectangle(x,y, width, height); }
        }


        public BallClass(int x, int y, int width, int height, int speedX, int speedY, Color color)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.speedX = speedX;
            this.speedY = speedY;
            startingSpeed = speedX;
            this.color = color;
            offscreen = false;
            
        }

        public void Move(int ClientWidth, int ClientHeight)
        {
            x += speedX;
            y += speedY;
            if (x + width >= ClientWidth) // Right Side OK
            {
                offscreen = true;
            }

            if (x <= 0) // Left Side OK
            {
                offscreen = true;
                //speedX = Math.Abs(speedX);
            }

            if (y <= 0) // Top OK
            {
                speedY = Math.Abs(speedY);
            }

            if (y + height >= ClientHeight) //Bottom 
            {
                speedY = -Math.Abs(speedY);
            }
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(new SolidBrush(color), Hitbox);
            ///if ballheight + postionx >= 0, then multiply x by -1
        }

        public void IntersectsPaddle(PaddleClass paddle, bool leftPaddle)
        {
            if(Hitbox.IntersectsWith(paddle.Hitbox))
            {
                if(leftPaddle)
                {
                    speedX = Math.Abs(speedX);
                }
                else
                {
                    speedX = -Math.Abs(speedX);
                }

            }
        }

        public void Reset(int ClientWidth, int ClientHeight)
        {
            x = (ClientWidth - width) / 2;
            y = (ClientHeight - height) / 2;
        }
    }

}
