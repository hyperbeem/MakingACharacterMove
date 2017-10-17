using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace MakingACharacterMove.Background
{
    public abstract class Tile
    {
        protected Vector2 _Position;
        protected Texture2D _TextureSheet;
        protected Rectangle _DrawRectangle;
        protected int _Meta;

        private int _TileDim;

        public Rectangle GetHitBox
        {
            get
            {
                return new Rectangle(
                        (int)_Position.X,
                        (int)_Position.Y,
                        _DrawRectangle.Width,
                        _DrawRectangle.Height);
            }
        }

        public Tile(Vector2 Position, int Meta, int TileDimension)
        {
            _Position = Position;
            _TileDim = TileDimension;
            _Meta = Meta;
        }

        protected Rectangle CalculateDrawRectangle()
        {
            int tY = _Meta / (_TextureSheet.Width / _TileDim);
            int tX = _Meta % (_TextureSheet.Width / _TileDim);

            return new Rectangle(tX * _TileDim, tY * _TileDim, _TileDim, _TileDim);
        }

        public abstract Texture2D Load();
        public abstract void Update();

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(_TextureSheet, _Position, _DrawRectangle, Color.White);
        }
    }
}
