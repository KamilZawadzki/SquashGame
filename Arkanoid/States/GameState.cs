﻿using System;
using System.Collections.Generic;
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
        Texture2D powerup;
        Ball ball;

        private List<Sprite> _sprites;
        private List<Sprite> _powerups;
        private double maxPoints;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            maxPoints = 0;
            ScreenWidth = Game1.globals.ScreenWidth;
            ScreenHeight = Game1.globals.ScreenHeight;
            spriteBatch = new SpriteBatch(graphicsDevice);
            Game1.globals.actualScore = new Score();
            game.IsMouseVisible = false;


            powerup = content.Load<Texture2D>("PowerUps/powerup");
            var batTexture = content.Load<Texture2D>("Sprites/paddle");
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

            for (int i = 0; i < ile_blokow * 3; i++)
            {
                if (i <= ile_blokow - 1)
                {

                    _sprites.Add(new GoldBlock(blockTexture_gold)
                    {
                        Position = new Vector2(temp + (i * blockTexture_gold.Width), 100),
                    });
                    _sprites.Add(new RedBlock(blockTexture_red, powerup)
                    {
                        Position = new Vector2(temp + (i * blockTexture_red.Width), 84),
                    });
                    _sprites.Add(new GoldBlock(blockTexture_gold)
                    {
                        Position = new Vector2(temp + (i * blockTexture_gold.Width), 68),
                    });
                    _sprites.Add(new GoldBlock(blockTexture_gold)
                    {
                        Position = new Vector2(temp + (i * blockTexture_gold.Width), 52),
                    });
                    _sprites.Add(new GoldBlock(blockTexture_gold)
                    {
                        Position = new Vector2(temp + (i * blockTexture_gold.Width), 36),
                    });
                    _sprites.Add(new RedBlock(blockTexture_red, powerup)
                    {
                        Position = new Vector2(temp + (i * blockTexture_red.Width), 116),
                    });
                    _sprites.Add(new GoldBlock(blockTexture_gold)
                    {
                        Position = new Vector2(temp + (i * blockTexture_gold.Width), 132),
                    });
                    _sprites.Add(new GoldBlock(blockTexture_gold)
                    {
                        Position = new Vector2(temp + (i * blockTexture_gold.Width), 148),
                    });
                }
            }
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
