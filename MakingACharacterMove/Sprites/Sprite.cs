using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MakingACharacterMove.Sprites
{
    public abstract class Sprite
    {
        // Position of Entity
        protected Vector2 _Position;

        protected Texture2D _Texture;

        protected float _MoveSpeed;

        public Sprite(Vector2 Position)
        {
            _Position = Position;
        }

        public abstract Texture2D Load();
        public abstract void Update();

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(_Texture, _Position, Color.White);
        }

    }
}
