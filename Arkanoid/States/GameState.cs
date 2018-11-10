using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkanoid.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Arkanoid.States
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

        //Ball ball;

        private List<Sprite> _sprites;
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {     
            ScreenWidth = Game1.globals.ScreenWidth;
            ScreenHeight = Game1.globals.ScreenHeight;
            spriteBatch = new SpriteBatch(graphicsDevice);

           //var ballTexture = content.Load<Texture2D>("Ball");
            var batTexture = content.Load<Texture2D>("Sprites/paddle");
            var ballTexture = content.Load<Texture2D>("Sprites/ball_round");
            var blockTexture_gold = content.Load<Texture2D> ("Sprites/blocks/block_gold");
            var blockTexture_red = content.Load<Texture2D>("Sprites/blocks/block_red");
            int ile_blokow = ScreenWidth / blockTexture_gold.Width;


            //ball = new Ball(ballTexture)
            //{
            //    Position = new Vector2((ScreenWidth / 2) - (ballTexture.Width / 2), (ScreenHeight / 2) - (ballTexture.Height / 2)),
            //};
           
            _sprites = new List<Sprite>()
            {
                new Paddle(batTexture)
                {
                    Position = new Vector2((ScreenWidth/2)-(batTexture.Width/2),Game1.globals.ScreenHeight-50),
                    Input = new Models.Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                    }
                },
                 new Ball(ballTexture)
            {
                Position = new Vector2((ScreenWidth / 2) - (batTexture.Width / 2), Game1.globals.ScreenHeight - 70),
            },
            };
            
            for (int i = 0; i < ile_blokow*3; i++)
            {
                if (i <= ile_blokow - 1)
                {
                    _sprites.Add(new GoldBlock(blockTexture_gold)
                    {
                        Position = new Vector2(1 + (i * blockTexture_gold.Width), 100),
                    });
                    _sprites.Add(new RedBlock(blockTexture_red)
                    {
                        Position = new Vector2(1 + (i * blockTexture_red.Width), 84),
                    });
                    _sprites.Add(new GoldBlock(blockTexture_gold)
                    {
                        Position = new Vector2(1 + (i * blockTexture_gold.Width), 68),
                    });
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            if(Game1.globals.Paused)
            spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "Paused | |", new Vector2(30, 30), Color.Black);


            spriteBatch.End();

        }

        public override void PostUpdate(GameTime gameTime)
        {
      
        }

        public override void Update(GameTime gameTime)
        {
            if (!Game1.globals.Paused)
            {
                for (int i = 0; i < _sprites.Count; i++)
                {
                    var sprite = _sprites[i];
                    sprite.Update(gameTime, _sprites);
                }
               // if (ball.restart)
                //{
                   // _game.ChangeState(new GameOver(_game, _graphicsDevice, _content));
               // }
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Pause))
                Game1.globals.Paused = !Game1.globals.Paused;
        }
    }
}
