using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Paletkowo.Sprites;
using System;
using System.Collections.Generic;

namespace Paletkowo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public float Speed = 4f;
        private Texture2D _texture;
        private Vector2 _position;

        public static int ScreenHeight;
        public static int ScreenWidth;
        public static Random Random;

        private List<Sprite> _sprites;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
            Random = new Random();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var ballTexture = Content.Load<Texture2D>("Ball");
            var batTexture = Content.Load<Texture2D>("Box");
            _texture = Content.Load<Texture2D>("Box");
            var wall_top_Texture = Content.Load<Texture2D>("wall_top");
            var wall_side = Content.Load<Texture2D>("left_right");
            _position = new Vector2(400, 400);

            _sprites = new List<Sprite>()
            {
                new Bat(batTexture)
                {
                    Position = new Vector2(400,(ScreenWidth/2)-(ballTexture.Width/2)),
                    Input = new Models.Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                    }
                },
                new Ball(ballTexture)
                {
                    Position = new Vector2((ScreenWidth/2)-(ballTexture.Width/2),(ScreenHeight/2)-(ballTexture.Height/2)),
                },
                new Wall_top(wall_top_Texture)
                {
                    Position=new Vector2(125,50),
                },
                new Wall_top(wall_side)
                {
                    Position=new Vector2(125,100),
                },
                
                new Wall_top(wall_side)
                {
                    Position=new Vector2(575,100),
                }

            };
        }
        // TODO: use this.Content to load your game content here


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.A))
            //{
            //    if (_position.X > 0)
            //        _position.X -= Speed;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D))
            //{
            //    if (_position.X + 100 < 750)
            //        _position.X += Speed;
            //}
            
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
