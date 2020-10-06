using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative_2D_Game
{
    class Attacks
    {
        //possibility of adding more attacks in behaviours?

        public int x, y, size;
        public Attacks (int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;

        }

        public void Shoot(int speed, string direction)
        {
            if (direction == "right")
            {
                x += speed;
            }
            if (direction == "left")
            {
                x -= speed;
            }
            if (direction == "up")
            {
                y -= speed;
            }
            if (direction == "down")
            {
                y += speed;
            }
        }
    }
}
