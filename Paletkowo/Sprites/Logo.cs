using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paletkowo.Sprites
{
    class Logo : Sprite
    {
        private Vector2? _startPosition = null;
        public Logo(Texture2D texture) : base(texture)
        {
        }
    }
}
