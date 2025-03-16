using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pesner_becca_a3_project
{
    internal class Score
    {
            private int currentScore;

            public void Update()
            {
                currentScore++;
            }

            public void Draw()
            {
                // Display the score on the screen
                //Renderer.DrawText($"Score: {currentScore}", 10, 10);
            }
 
    }
}
