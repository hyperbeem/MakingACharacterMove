using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using MakingACharacterMove.Sprites;
using MakingACharacterMove.Sprites.Entities;

namespace MakingACharacterMove.Managers
{
    public class EntityManager
    {
        private readonly List<Sprite> _EntityList;

        public EntityManager()
        {
            _EntityList = new List<Sprite>();
        }

        public void SpawnPlayer(Vector2 Position, float Speed)
        {
            var p = new Player(Position, Speed);
            _EntityList.Add(p);
        }

        public void Update()
        {
            foreach (Sprite s in _EntityList)
                s.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Sprite s in _EntityList)
                s.Draw(sb);
        }

    }
}
