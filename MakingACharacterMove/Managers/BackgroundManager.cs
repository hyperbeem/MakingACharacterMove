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

namespace MakingACharacterMove.Managers
{
    public class BackgroundManager
    {
        private readonly List<Tile> _TileList;

        public BackgroundManager()
        {
            _TileList = new List<Tile>();
        }

        public void AddTile(int X, int Y, int Meta)
        {
            var t = new Floor(new Vector2(X,Y), Meta);
            _TileList.Add(t);
        }

        public void AddTile(Vector2 Position, int Meta)
        {
            var t = new Floor(Position, Meta);
            _TileList.Add(t);
        }

        public void Update()
        {
            foreach (Tile t in _TileList)
                t.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Tile t in _TileList)
                t.Draw(sb);
        }
    }
}
