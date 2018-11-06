using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Paletkowo.Sprites;

namespace Paletkowo.States
{
    public class SplashState : State
    {
        SpriteFont font;
        Texture2D image;
        SpriteBatch spriteBatch;
        Sprite imagesprite;
        static bool elapsed = false;
        public SplashState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            font = _content.Load<SpriteFont>("Fonts/Font");
            image = _content.Load<Texture2D>("SplashScreen/Logo");

            spriteBatch = new SpriteBatch(graphicsDevice);
            imagesprite = new Logo(image)
            {
                Position = new Vector2(250, 50),
            };
            Timer aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            imagesprite.Draw(spriteBatch);
            spriteBatch.DrawString(font, "SquashGame", new Vector2(360, 60 + _content.Load<Texture2D>("SplashScreen/Logo").Height), Color.Black);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            elapsed = true;
        }

        public override void Update(GameTime gameTime)
        {

            if (elapsed)
            {
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            }
        }
    }
}
