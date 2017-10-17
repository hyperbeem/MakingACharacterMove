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
        private Vector2 _LastPos;

        public Player(Vector2 Position, float MoveSpeed) : base(Position)
        {
            _MoveSpeed = 2f;
            _Texture = Load();
            _Origin = new Vector2(_Texture.Bounds.Center.X, _Texture.Bounds.Center.Y);
            _MoveSpeed = MoveSpeed;
        }

        public override Texture2D Load()
        {
            ContentManager cm = Moving.serviceContainer.GetService<ContentManager>();
            return cm.Load<Texture2D>("Character");
        }

        public override void Update()
        {
            _LastPos = _Position;

            var ms = Mouse.GetState();
            var ks = Keyboard.GetState();

            UpdateRotation(ms);

            Vector2 dir = new Vector2((float)Math.Cos(_Rotation), (float)Math.Sin(_Rotation));
            dir.Normalize();

            if (ks.IsKeyDown(Keys.W) || ks.IsKeyDown(Keys.Up))
            {
                _Position -= dir * _MoveSpeed;
            }

            if (ks.IsKeyDown(Keys.S))
            {
                _Position -= dir * (_MoveSpeed * -1);
            }

            if (ks.IsKeyDown(Keys.A))
            {
                dir = new Vector2((float)Math.Cos(_Rotation - (Math.PI * 2) / 4), (float)Math.Sin(_Rotation - (Math.PI * 2) / 4));

                _Position -= dir * _MoveSpeed;
            }

            if (ks.IsKeyDown(Keys.D))
            {
                dir = new Vector2((float)Math.Cos(_Rotation + (Math.PI * 2) / 4), (float)Math.Sin(_Rotation + (Math.PI * 2) / 4));

                _Position -= dir * _MoveSpeed;
            }
        }

        public void Colided()
        {
            _Position = _LastPos;
        }

        private void UpdateRotation(MouseState ms)
        {
            Vector2 mPos = new Vector2(ms.X, ms.Y);
            Vector2 dPos = _Position - mPos;

            _RotationAngleTo = (float)Math.Atan2(dPos.Y, dPos.X);
            _Rotation = MathHelper.WrapAngle(_Rotation);

            _Rotation = _RotationAngleTo;
        }
    }
}
