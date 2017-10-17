using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MakingACharacterMove.Background.ForegroundTile
{
    public class Sign : Tile
    {
        public Sign(Vector2 Position,int TileDimension) : base(Position, 0, TileDimension)
        {
            _TextureSheet = Load();
            _DrawRectangle = CalculateDrawRectangle();
        }

        public Sign(int X, int Y, int TileDimension) : base(new Vector2(X* TileDimension, Y* TileDimension), 0, TileDimension)
        {
            _TextureSheet = Load();
            _DrawRectangle = CalculateDrawRectangle();
        }

        public override Texture2D Load()
        {
            ContentManager cm = Moving.serviceContainer.GetService<ContentManager>();
            return cm.Load<Texture2D>("Tiles/Sign");
        }

        public override void Update()
        {
            var ply = Moving.entityManager.player;

            if (ply.GetHitBox.Intersects(GetHitBox))
                ply.Colided();
        }
    }
}
