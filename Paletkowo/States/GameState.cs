using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Paletkowo.Sprites;

namespace Paletkowo.States
{
    class GameState : State
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public float Speed = 4f;
        private Texture2D _texture;
        private Vector2 _position;

        public static int ScreenHeight;
        public static int ScreenWidth;
        public static Random Random;

        Ball ball;

        private List<Sprite> _sprites;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {        
            ScreenWidth = game.graphics.PreferredBackBufferWidth;
            ScreenHeight = game.graphics.PreferredBackBufferHeight;
            spriteBatch = new SpriteBatch(graphicsDevice);

            var ballTexture = content.Load<Texture2D>("Ball");
            var batTexture = content.Load<Texture2D>("bat_long");
            var batbotTexture = content.Load<Texture2D>("bat_bot");
            _texture = content.Load<Texture2D>("Box");
            var wall_top_Texture = content.Load<Texture2D>("wall_top");
            var wall_side = content.Load<Texture2D>("left_right");
            _position = new Vector2(400, 400);



            ball = new Ball(ballTexture)
            {
                Position = new Vector2((ScreenWidth / 2) - (ballTexture.Width / 2), (ScreenHeight / 2) - (ballTexture.Height / 2)),
            };

            _sprites = new List<Sprite>()
            {
                new Bat(batTexture)
                {
                    Position = new Vector2((ScreenWidth/2)-(batTexture.Width/2),380),
                    Input = new Models.Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                    }
                },
                ball,
                new Wall_top(wall_top_Texture)
                {
                    Position=new Vector2(150,50),
                },
                new Wall_top(wall_side)
                {
                    Position=new Vector2(150,100),
                },

                new Wall_top(wall_side)
                {
                    Position=new Vector2(600,100),
                }, 
                new Bat_bot(batbotTexture)
                {
                    Position= new Vector2((ScreenWidth/2)-(batTexture.Width/2),380),
                }
              
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            if(Game1.paused)
            spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "Paused | |", new Vector2(30, 30), Color.Black);


            spriteBatch.End();

        }

        public override void PostUpdate(GameTime gameTime)
        {
      
        }

        public override void Update(GameTime gameTime)
        {
            if (!Game1.paused)
            {
                foreach (var sprite in _sprites)
                {
                    sprite.Update(gameTime, _sprites);
                }
                if (ball.restart)
                {
                    _game.ChangeState(new GameOver(_game, _graphicsDevice, _content));
                }
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Pause))
                Game1.paused = !Game1.paused;
        }
    }
}
