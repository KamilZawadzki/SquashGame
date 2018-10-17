using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paletkowo.Sprites
{
    class Wall_left : Sprite
    {

        private Vector2? _startPosition = null;
        private float? _startSpeed;
        private bool _isPlaying;
        public Wall_left(Texture2D texture)
          : base(texture)
        {

        }
    }
}
