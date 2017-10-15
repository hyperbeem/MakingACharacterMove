using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MakingACharacterMove.Sprites.Entities
{
    public class Player : Sprite
    {
        public Player(Vector2 Position, float MoveSpeed) : base(Position)
        {
            _Texture = Load();
            _MoveSpeed = MoveSpeed;
        }

        public override Texture2D Load()
        {
            ContentManager cm = Moving.serviceContainer.GetService<ContentManager>();
            return cm.Load<Texture2D>("Character");
        }

        public override void Update()
        {
            var ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.W) || ks.IsKeyDown(Keys.Up))
                _Position.Y -= _MoveSpeed;
            if (ks.IsKeyDown(Keys.S) || ks.IsKeyDown(Keys.Down))
                _Position.Y += _MoveSpeed;
            if (ks.IsKeyDown(Keys.A) || ks.IsKeyDown(Keys.Left))
                _Position.X -= _MoveSpeed;
            if (ks.IsKeyDown(Keys.D) || ks.IsKeyDown(Keys.Right))
                _Position.X += _MoveSpeed;
        }
    }
}
