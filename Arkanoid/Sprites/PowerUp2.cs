using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid.Sprites
{
    class PowerUp2 : Sprite
    {
        Texture2D _texture,_shortBat,_longBat;

        private float powerUpSpeed;

        public PowerUp2(Texture2D texture,Vector2 position, Texture2D shortBat, Texture2D longBat) : base(texture)
        {
            powerUpSpeed = 1f;
            _texture = texture;
            _shortBat = shortBat;
            _longBat = longBat;
            this.Position = position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
          
            base.Draw(spriteBatch);
          
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

            if (this.IsTouchingTop(sprites[0])||this.IsTouchingLeft(sprites[0])||this.IsTouchingRight(sprites[0]))
            {
                sprites.Remove(this);
                
                if (sprites[0]._texture == _shortBat)
                {
                    sprites[0]._texture = _longBat;
                }
                else
                {
                    sprites[0]._texture = _shortBat;

                };
            }else if(this.Position.Y > Game1.globals.ScreenHeight)
            {
                sprites.Remove(this);
            }


            this.Position.Y += powerUpSpeed;
            //base.Update(gameTime, sprites);
        }
    }
}
