// Include the namespaces (code libraries) you need below.
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Numerics;
using pesner_becca_a3_project;
using Raylib_cs;

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
        Texture2D orangeTexture = Graphics.LoadTexture("./orange.png");
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
        float obstacleSpeed = 3.0f;  // speed of obstacles
        float score = 0f;  // score based on time

        Obstacle[] obstacles = [new Obstacle(), new Obstacle(new Vector2(0, 1100))];

        //Game state management
        bool isGameOver = false;
        public void Setup()
        {
            Window.SetTitle("cappy blappy");
            Window.SetSize(800, 600);
            jumpTime = jumpTimeDefault;
            isGameOver = false;
        }

        public void Update()
        {
            if (isGameOver)
            {
                GameOver();
            }
            else
            {
                PlayGame();
            }
        }

        // when the game is running 
        public void PlayGame()

        {
            Window.ClearBackground(Color.White);
            DrawGround();
            Graphics.Draw(capybaraTexture, capybaraPosition);

            // player jump logic 
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

            // draw obstacles
            foreach (var obstacle in obstacles)
            {
                Graphics.Draw(orangeTexture, obstacle.Position);
            }

            // check for game-over condition (e.g., collision with obstacle/orange)
            foreach (var obstacle in obstacles)
            {
                if (capybaraPosition.X + capybaraHeight > obstacle.Position.X && capybaraPosition.X < obstacle.Position.X + obstacle.Width)
                {
                    isGameOver = true;
                }
            }
        }

        // logic when the game is over
        public void GameOver()
        {
            Window.ClearBackground(Color.Red); // change the background to red when game is over and put "game over" text
            Text.Color = Color.White;
            Text.Size = 7;
            Text.Draw("game over!", 300, 250);
            // reset the game after some time or on key press enter
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter))
            {
                ResetGame();
            }
        }

        // resets the game state
        public void ResetGame()
        {
            capybaraPosition = new Vector2(0, 250);
            isJumping = false;
            isGameOver = false;
            jumpTime = jumpTimeDefault;
            obstacles = new Obstacle[] { new Obstacle(), new Obstacle(new Vector2(0, 1100)) }; // reset obstacles
        }

        public void DrawGround()
        {
            Draw.FillColor = new Color(70, 60, 10);
            Draw.Rectangle(groundStart, groundSize);
        }
    }

}

// committing a push because my laptop just shut off twice 