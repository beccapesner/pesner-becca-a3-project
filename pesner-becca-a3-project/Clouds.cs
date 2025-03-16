using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace pesner_becca_a3_project
{
    internal class Clouds
    {
        public Vector2 position;
        public float width = 0;

        public Clouds(Vector2 position)
        {
            this.position = position;
            this.width = 0;
        }
        public Clouds(Vector2 position, float width)
        {
            this.position = position;
            this.width = width;
        }
    }
}
