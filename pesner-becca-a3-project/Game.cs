// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Texture2D capybara = Graphics.LoadTexture("./capybara.png");
        public void Setup()
        {
        
            Window.SetSize (800, 600);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);
            DrawGround();
            Graphics.Draw(capybara, 0, 300);
        }

        public void DrawGround()
        {
            Draw.FillColor = new Color(70, 60, 10);
            Draw.Rectangle(0, 450, 800, 150);
        }
    }

}
