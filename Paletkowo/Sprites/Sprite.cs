using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Paletkowo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paletkowo.Sprites
{
    class Sprite
    {
        protected Texture2D _texture;

        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed;
        public Input Input;
       

    }
}
