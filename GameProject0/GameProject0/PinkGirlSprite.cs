using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameProject0
{
    public class PinkGirlSprite
    {
        private Texture2D texture;
        private double animationTimer;
        private int animationFrame = 1;

        /// <summary>
        /// Loads pinkhairgirl sprite sheet
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pinkhairgirl");
        }
        
        /// <summary>
        /// Draws animation frames for pinkgirl
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="graphics"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(animationTimer > 0.2)
            {
                animationFrame++;
                if(animationFrame > 8)
                {
                    animationFrame = 0;
                }
                animationTimer -= 0.2;
            }

            var source = new Rectangle(animationFrame * 128, 0, 128, 128);
            spriteBatch.Draw(texture, new Vector2(graphics.Viewport.Width/2 - 64, graphics.Viewport.Height - graphics.Viewport.Height/6 - 64), source, Color.White);
        }
    }
}
