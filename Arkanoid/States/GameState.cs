using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkanoid.Models;
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

        PowerUp speeder;
        Texture2D powerup,powerup2;
        Ball ball;

        private List<Sprite> _sprites;
        private List<Sprite> _powerups;
        private double maxPoints;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Game1.globals.BallSpeed = Game1.globals.defaultBallSpeed;
            maxPoints = 0;
            ScreenWidth = Game1.globals.ScreenWidth;
            ScreenHeight = Game1.globals.ScreenHeight;
            spriteBatch = new SpriteBatch(graphicsDevice);
            Game1.globals.actualScore = new Score();
            game.IsMouseVisible = false;


            powerup = content.Load<Texture2D>("PowerUps/slider");
            powerup2 = content.Load<Texture2D>("PowerUps/slider2");
            var batTexture = content.Load<Texture2D>("Sprites/paddle");
            var batTextureShort = content.Load<Texture2D>("Sprites/batShort");
            var ballTexture = content.Load<Texture2D>("Sprites/ball_round");
            var blockTexture_gold = content.Load<Texture2D>("Sprites/blocks/block_gold");
            var blockTexture_red = content.Load<Texture2D>("Sprites/blocks/block_red");
            int ile_blokow = ScreenWidth / blockTexture_gold.Width;

            //obliczanie szerokości do generowania blokow na srodku ekranu
            int x = ile_blokow * blockTexture_gold.Width;
            int temp = (ScreenWidth - x) / 2;

            ball = new Ball(ballTexture)
            {
                Position = new Vector2((ScreenWidth / 2) - (batTexture.Width / 2), Game1.globals.ScreenHeight - 70),
            };

            _powerups = new List<Sprite>()
            {
                speeder,
        };

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
                ball,
            };
            //
           if(Game1.globals.check_dir==false)
            {
                Directory.SetCurrentDirectory(@"..\..\..\..");
                Game1.globals.check_dir = true;
            }
            string[] lines = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Maps\", "map1.txt"));

            for (int i = 0; i < lines.Length; i++)
           {
                string[] splited_line = lines[i].Split(';');
                int height = Convert.ToInt32(splited_line[0]);
                string single_line = splited_line[1];
                for(int j=0;j<single_line.Length;j++)
                {
                    char code = single_line[j];
                    switch(code)
                    {
                        case 'G':
                            _sprites.Add(new GoldBlock(blockTexture_gold, batTexture, batTextureShort, powerup,powerup2)
                            {
                                Position = new Vector2(temp + (j * blockTexture_gold.Width), height),
                            });
                            break;
                        case 'R':
                            _sprites.Add(new RedBlock(blockTexture_red, powerup,powerup2,batTextureShort,batTexture)
                            {
                                Position = new Vector2(temp + (j * blockTexture_red.Width), height),
                            });
                            break;
                        default:
                            Console.WriteLine("Map file: read error");
                            break;
                    }
                }
            }
            //

            foreach (Sprite xa in _sprites)
            {
                if (xa is GoldBlock)
                    maxPoints += 1;
                if (xa is RedBlock)
                    maxPoints += 3;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            if (Game1.globals.Paused)
                spriteBatch.DrawString(_content.Load<SpriteFont>("Fonts/Font"), "Paused | |", new Vector2(30, 30), Color.Black);

            if (Game1.globals.actualScore.score_player == 1)
            {
                if (speeder == null)
                {
                    speeder = new PowerUp(powerup, new Vector2(ball.Position.X, ball.Position.Y));
                    _sprites.Add(speeder);
                }
            }

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
             
                if (ball.restart)
                {
                    _game.ChangeState(new GameOver(_game, _graphicsDevice, _content));
                }

                if (Game1.globals.actualScore.score_player == maxPoints)
                {
                    _game.ChangeState(new GameOver(_game, _graphicsDevice, _content));
                }
            }



            if (Keyboard.GetState().IsKeyDown(Keys.P) && Game1.globals.isPlaying)
                Game1.globals.Paused = !Game1.globals.Paused;
        }
    }
}
