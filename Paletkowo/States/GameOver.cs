using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Paletkowo.Controls;

namespace Paletkowo.States
{
    class GameOver : State
    {
        private List<Component> _components;

        public GameOver(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
            
            var playAgain = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(120, 150),
                Text = "Play Again",
            };

            playAgain.Click += playAgainButton_Click;
            var goToMenuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(120, 250),
                Text = "Menu",
            };
            goToMenuButton.Click += goToMenuButton_Click;
            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(120, 350),
                Text = "Quit",
            };
            quitGameButton.Click += QuitGameButton_Click;
            _components = new List<Component>()
            {
                playAgain,
                goToMenuButton,
                quitGameButton,
            };
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void goToMenuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Game1.punkty.score_bot = 0;

            spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "Score:\nGracz: "+ Game1.punkty.score_player+"\nBot: "+ Game1.punkty.score_bot, new Vector2(120, 80), Color.Black);
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }
    }
}
