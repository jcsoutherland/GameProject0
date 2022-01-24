using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject0
{
    public class TitleScreenGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private PinkGirlSprite girl;
        private SpriteFont bangers;
        private ExitButtonSprite exitbtn;
        private Texture2D rock;
        private Texture2D mushroom;

        /// <summary>
        /// constructs new title screen game
        /// </summary>
        public TitleScreenGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// inits game assests
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            girl = new PinkGirlSprite();
            exitbtn = new ExitButtonSprite(GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// loads game content
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            girl.LoadContent(Content);
            exitbtn.LoadContent(Content);
            rock = Content.Load<Texture2D>("rockguy");
            mushroom = Content.Load<Texture2D>("mushroom");
            bangers = Content.Load<SpriteFont>("bangers");

        }

        /// <summary>
        /// updates game on game time
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            exitbtn.Update(gameTime);
            if (exitbtn.ExitGame)
            {
                Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// draws game content on screen
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(rock, new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2 - 48), Color.White);
            _spriteBatch.Draw(mushroom, new Vector2(GraphicsDevice.Viewport.Width / 2 - 64, GraphicsDevice.Viewport.Height / 2 - 48), Color.White);
            exitbtn.Draw(gameTime, _spriteBatch);
            girl.Draw(gameTime, _spriteBatch, GraphicsDevice);
            _spriteBatch.DrawString(bangers, "Game Project 0", new Vector2(GraphicsDevice.Viewport.Width/2 - 184, 80), Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
