﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace MakingACharacterMove.Background.Tiles
{
    public class Floor : Tile
    {
        public Floor(Vector2 Position, int Meta, int TileDimension) : base(Position, Meta, TileDimension)
        {
            _TextureSheet = Load();
            _DrawRectangle = CalculateDrawRectangle();
        }

        public Floor(int X, int Y, int Meta, int TileDimension) : base(new Vector2(X, Y), Meta, TileDimension)
        {
            _TextureSheet = Load();
            _DrawRectangle = CalculateDrawRectangle();
        }

        public override Texture2D Load()
        {
            ContentManager cm = Moving.serviceContainer.GetService<ContentManager>();
            return cm.Load<Texture2D>("Tiles/Floor");
        }

        public override void Update()
        {

        }
    }
}
