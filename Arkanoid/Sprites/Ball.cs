using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Sprites
{
    class Ball : DrawableGameComponent
    {
        int size;

        public int DirX { get; set; }
        public int DirY { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        SpriteBatch spriteBatch;
        Texture2D pixel;
        GraphicsDevice graphics;

        public Ball(Game game, GraphicsDevice graphics, SpriteBatch spriteBatch, int size) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.size = size;

            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            ResetBallPosition();
        }

        public void ResetBallPosition()
        {
            PosX = graphics.Viewport.Width / 2 - size / 2;
            PosY = graphics.Viewport.Height - graphics.Viewport.Height / 3;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(PosX, PosY, size, size), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
