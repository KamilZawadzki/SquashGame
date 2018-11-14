using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Sprites
{
    class RedBlock : Sprite
    {
        Texture2D _texture,_powerup;
        int sprite_life = 2;
        const int points_for_break = 3;
     


        public RedBlock(Texture2D texture,Texture2D powerup) : base(texture)
        {
            _texture = texture;
            _powerup = powerup;
         
        }

        
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (this.IsLeft(sprites[1]))
            {
                this.sprite_life--;        
                sprites[1].Velocity.X = -sprites[1].Velocity.X;

            }

            if (this.IsRight(sprites[1]))
            {
                this.sprite_life--;
                sprites[1].Velocity.X = -sprites[1].Velocity.X;

            }

            if (this.IsTop(sprites[1]))
            {
                this.sprite_life--;
                sprites[1].Velocity.Y = -sprites[1].Velocity.Y;
            }
            if (this.IsBottom(sprites[1]))
            {
                this.sprite_life--;
                sprites[1].Velocity.Y = -sprites[1].Velocity.Y;
            }         
            if (this.sprite_life < 0)
            {
                  Game1.globals.actualScore.score_player += points_for_break;
                    sprites.Remove(this);                
                    PowerUp speeder = new PowerUp(_powerup, new Vector2(this.Position.X, this.Position.Y));
                    sprites.Add(speeder);                
            }
                base.Update(gameTime, sprites);
        }
    }
}
