using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid.Sprites
{
    class PowerUp : Sprite
    {
        Texture2D _texture;

        private float powerUpSpeed;

        public PowerUp(Texture2D texture,Vector2 position) : base(texture)
        {
            powerUpSpeed = 1f;
            _texture = texture;
            this.Position = position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
          
            base.Draw(spriteBatch);
          
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

            if (this.IsTouchingTop(sprites[0]))
            {
                sprites.Remove(this);
                Game1.globals.BallSpeed = 7f;
            }


            this.Position.Y += powerUpSpeed;
            //base.Update(gameTime, sprites);
        }
    }
}
