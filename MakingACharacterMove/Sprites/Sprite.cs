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
        protected float _RotationAngleTo;
        protected float _Rotation;

        protected Texture2D _Texture;
        protected Vector2 _Origin;

        protected float _MoveSpeed;

        public Rectangle GetHitBox
        {
            get {
                return new Rectangle(
                        (int)_Position.X,
                        (int)_Position.Y,
                        _Texture.Width,
                        _Texture.Height);
                }
        }

        public Sprite(Vector2 Position)
        {
            _Position = Position;
        }

        public abstract Texture2D Load();
        public abstract void Update();

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(_Texture, _Position,null, Color.White, _Rotation,_Origin,1,SpriteEffects.None, 0f);
        }
    }
}
