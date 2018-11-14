using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arkanoid.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid.Sprites
{
   
    class GoldBlock : Sprite
    {
        int sprite_life;
        int points_for_break;
        Texture2D _texture,_batShort,_batLong,_powerup;
        public GoldBlock(Texture2D texture, Texture2D batLong, Texture2D batShort, Texture2D powerup) : base(texture)
        {
            this.sprite_life = 1;
            this.points_for_break = 1;
            _texture = texture;
            _batLong = batLong;
            _batShort = batShort;
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
            base.Update(gameTime, sprites);
            if (this.sprite_life <= 0)
            {
                Game1.globals.actualScore.score_player += points_for_break;
                sprites.Remove(this);
                Random rnd = new Random();
                //TODO: zrobić randoma rzadziej!
                int number = rnd.Next(1, 5);
                if (number == 2)
                {
                    PowerUp2 power = new PowerUp2(_powerup, this.Position, _batShort, _batLong);
                    sprites.Add(power);
                }

            }
        }
  
        }
 
}
// return 