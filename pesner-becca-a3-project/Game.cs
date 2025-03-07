// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using pesner_becca_a3_project;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Texture2D capybaraTexture = Graphics.LoadTexture("./capybara.png");
        Vector2 capybaraPosition = new Vector2(0, 250);
        float capybaraHeight = 150;
        float jumpGrace = 5;
        Vector2 groundStart = new Vector2(0, 450);
        Vector2 groundSize = new Vector2(800, 150);
        bool isJumping = false;
        float jumpTimeDefault = 0.8f;
        float jumpTime = 0;
        float jumpPower = 1.5f;
        float gravity = 1.7f;
        Obstacle[] obstacles = [new Obstacle(), new Obstacle(1100)];
        

        public void Setup()
        {
            Window.SetTitle("cappy blappy");
            Window.SetSize(800, 600);
            jumpTime = jumpTimeDefault;
        }

        public void Update()
        {
            Window.ClearBackground(Color.White);
            DrawGround();
            Graphics.Draw(capybaraTexture, capybaraPosition);
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) && (groundStart.Y < capybaraPosition.Y + capybaraHeight + jumpGrace))
            {
                isJumping = true;
            }
            if (isJumping)
            {
                capybaraPosition += -Vector2.UnitY * jumpPower;
                jumpTime -= Time.DeltaTime;
                if (jumpTime < 0)
                {
                    jumpTime = jumpTimeDefault;
                    isJumping = false;
                }
            }
            else
            {
                if (groundStart.Y > capybaraPosition.Y + capybaraHeight)
                {
                    capybaraPosition += Vector2.UnitY * gravity;
                }
            }
        }

        public void DrawGround()
        {
            Draw.FillColor = new Color(70, 60, 10);
            Draw.Rectangle(groundStart, groundSize);
        }
    }

}
