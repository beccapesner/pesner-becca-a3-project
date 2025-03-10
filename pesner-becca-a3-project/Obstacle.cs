using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace pesner_becca_a3_project
{
    public class Obstacle
    {
        public Vector2 Position;
        public float Width = 0;

        public Obstacle()
        {
            Position = new Vector2(0, 350);
            Width = 0;
        }
        public Obstacle(Vector2 position)
        {
            Position = position;
            Width = 0;
        }
        public Obstacle(Vector2 position, float width)
        {
            Position = position;
            Width = width;
        }
    }
}

// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA