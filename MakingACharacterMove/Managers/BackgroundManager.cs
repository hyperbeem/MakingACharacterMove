using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using MakingACharacterMove.Background;
using MakingACharacterMove.Background.Tiles;
using MakingACharacterMove.Background.ForegroundTile;

namespace MakingACharacterMove.Managers
{
    public class BackgroundManager
    {
        private readonly List<Tile> _BackgroundList;
        private readonly List<Tile> _ForegroundList;

        public BackgroundManager()
        {
            _BackgroundList = new List<Tile>();
            _ForegroundList = new List<Tile>();
        }

        public void AddBackgroundTile(int X, int Y, int Meta,int TileDimension)
        {
            var t = new Floor(new Vector2(X * TileDimension, Y * TileDimension), Meta, TileDimension);
            _BackgroundList.Add(t);
        }

        public void AddBackgroundTile(Vector2 Position, int Meta,int TileDimension)
        {
            var t = new Floor(Position, Meta, TileDimension);
            _BackgroundList.Add(t);
        }

        public void AddForegroundTile(int X, int Y, int TileDimension)
        {
            var t = new Sign(new Vector2(X, Y), TileDimension);
            _ForegroundList.Add(t);
        }

        public void AddForegroundTile(Vector2 Position, int TileDimension)
        {
            var t = new Sign(Position, TileDimension);
            _ForegroundList.Add(t);
        }

        public void Update()
        {
            foreach (Tile t in _BackgroundList)
                t.Update();
            foreach (Tile t in _ForegroundList)
                t.Update();

        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Tile t in _BackgroundList)
                t.Draw(sb);
            foreach (Tile t in _ForegroundList)
                t.Draw(sb);

        }
    }
}
