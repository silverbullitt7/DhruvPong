using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhruvPong
{
    class PaddleClass

    {
        int x;
        int y;
        int width;
        int height;

        public Rectangle Hitbox
        {
            get { return new Rectangle(x, y, width, height); }
        }
        public PaddleClass(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

        }

        public void moveUp()
        {
            y -= 45;
        }

        public void moveDown()
        {
            y += 45;
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(Brushes.White, x, y, width, height);
           
        }
    }
}
