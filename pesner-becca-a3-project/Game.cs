// Include the namespaces (code libraries) you need below.
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Numerics;
using pesner_becca_a3_project;

// the namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // place your variables here:
        Texture2D capybaraTexture = Graphics.LoadTexture("../../../../assets/Graphics/capybara.png");
        Texture2D orangeTexture = Graphics.LoadTexture("../../../../assets/Graphics/orange.png");
        Texture2D backgroundTexture = Graphics.LoadTexture("../../../../assets/Graphics/background.png");
        Texture2D cloudTexture = Graphics.LoadTexture("../../../../assets/Graphics/cloud.png");

        Vector2 capybaraPosition = new Vector2(0, 250);
        float capybaraHeight = 150;
        float capybaraWidth = 200;
        float jumpGrace = 5;
        Vector2 groundStart = new Vector2(0, 450);
        Vector2 groundSize = new Vector2(800, 150);
        bool isJumping = false;
        const float jumpTimeDefault = 0.5f;
        float jumpTime = 0;
        const float jumpPower = 4.5f;
        const float gravity = 4.0f;
        const float obstacleSpeed = 3.0f;  // speed of obstacles
        float score = 0f;  // score based on time
        float hitDistance = 50;
        Vector2 hitOffset = new Vector2(50, 50);

        Obstacle[] obstacles = { new Obstacle(new Vector2(750, 350)), new Obstacle(new Vector2(950, 350)) };
        Clouds[] clouds = { new Clouds(new Vector2(750, 50)), new Clouds(new Vector2(950, 50)) };

        // game state management
        bool isGameOver = false;
        public void Setup()
        {
            Window.SetTitle("cappy blappy");
            Window.SetSize(800, 600);
            jumpTime = jumpTimeDefault;
            isGameOver = false;

            ResetGame();
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
            // clear background and draw other elements
            Graphics.Draw(backgroundTexture, 0, 0);
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

            // update obstacles
            foreach (var obstacle in obstacles)
            {
                // scale down orange
                Graphics.Scale = 0.7f; 
                obstacle.position -= Vector2.UnitX * obstacleSpeed;
                Graphics.Draw(orangeTexture, obstacle.position);
                // reset scale
                Graphics.Scale = 1f;

                // reset obstacle position if it goes off screen
                if (obstacle.position.X < -100)
                {
                    obstacle.position.X = 850;
                }

                // reset obstacle position if it goes off screen
                if (obstacle.position.X < -100)
                {
                    obstacle.position.X = 850;
                }

                //// New collision detection using bounding boxes
                //if (IsCollision(capybaraPosition, capybaraHeight, obstacle.position))
                //{
                //    isGameOver = true;
                //}
            }

            // update and draw clouds
            foreach (var cloud in clouds)
            {
                cloud.position -= Vector2.UnitX * 2.4f; // move the cloud leftwards at a speed of 2.4 units per frame

                // draw the cloud at its new position
                Graphics.Draw(cloudTexture, cloud.position);

                // if the cloud moves off screen (to the left), reset it to the right side of the screen
                if (cloud.position.X < -cloudTexture.Width)
                {
                    cloud.position.X = 800; // reset to the right edge of the screen
                }
            }

            // display score 
            Text.Color = Color.Black;
            Text.Size = 20;
            score += Time.DeltaTime;
            Text.Draw($"score: {score}", 10, 10);


            // collision detection 
            foreach (Obstacle obstacle in obstacles)
            {
                if (Vector2.Distance(obstacle.position, capybaraPosition + hitOffset) < hitDistance)
                {
                    GameOver();
                }
            }

        }

        // logic when the game is over
        public void GameOver()
        {
            isGameOver = true;
            // game over text
            Text.Color = Color.White;
            Text.Size = 20;
            Text.Draw("game over!", 300, 50);

            // reset the game after enter or space bar is pressed
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Enter) || Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                ResetGame();
            }
        }

        // resets the game state
        public void ResetGame()
        {
            score = 0;
            capybaraPosition = new Vector2(0, 250);
            isJumping = false;
            isGameOver = false;
            jumpTime = jumpTimeDefault;
            obstacles = new Obstacle[] { new Obstacle(new Vector2(750, 350)), new Obstacle(new Vector2(950, 350)) }; // reset obstacles
        }
        public void DrawGround()
        {
            //Draw.FillColor = new Color(70, 60, 10);
            //Draw.Rectangle(groundStart, groundSize);
        }
    }

} 