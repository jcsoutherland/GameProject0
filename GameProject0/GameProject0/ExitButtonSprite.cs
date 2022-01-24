using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace GameProject0
{
    public class ExitButtonSprite
    {
        private Texture2D texture;
        private Vector2 position;

        private MouseState currentMouseState;

        /// <summary>
        /// sets button color
        /// </summary>
        public Color Color { get; set; } = Color.White;
        /// <summary>
        /// true if button clicked, false otherwise.
        /// </summary>
        public bool ExitGame { get; private set; } = false; 

        /// <summary>
        /// Constructs a new exit button in the correct position
        /// </summary>
        /// <param name="graphics"></param>
        public ExitButtonSprite(GraphicsDevice graphics)
        {
            position = new Vector2(graphics.Viewport.Width / 2 - 64, graphics.Viewport.Height / 2 - 16);
        }

        /// <summary>
        /// Loads sprite for exit button
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ExitButton");
        }

        /// <summary>
        /// Checks if mouse is over the button and if mouse is clicked on the button
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            Color = Color.White;
            currentMouseState = Mouse.GetState();

            if (currentMouseState.Position.X < (int)position.X+128 && currentMouseState.Position.X > (int)position.X && currentMouseState.Position.Y > (int)position.Y && currentMouseState.Position.Y < (int)position.Y + 128)
            {
                Color = Color.DarkGray;
                if(currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    ExitGame = true;
                }
            }
        }

        /// <summary>
        /// draws the button on the screen
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color);
        }
    }
}
