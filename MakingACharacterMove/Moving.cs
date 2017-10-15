using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MakingACharacterMove.Managers;

namespace MakingACharacterMove
{
    public class Moving : Game
    {
        public static GameServiceContainer serviceContainer = new GameServiceContainer();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        BackgroundManager bm;
        EntityManager em;

        public Moving()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Adds services to global container, easy access
            serviceContainer.AddService(GraphicsDevice);
            serviceContainer.AddService(Content);

            // New BackgroundManager
            bm = new BackgroundManager();

            // New Random
            Random r = new Random();

            // Generates tiles with a random meta on the entire game screen
            for (byte x = 0; x < (GraphicsDevice.Viewport.Width / 32); x++)
                for (byte y = 0; y < (GraphicsDevice.Viewport.Height / 32); y++)
                    bm.AddTile(x, y, r.Next(0, 4));

            // New Entity Manager
            em = new EntityManager();
            em.SpawnPlayer(new Vector2(10, 10), 2.5f);
            

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            bm.Update();
            em.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Makes new SpriteBatch
            var sb = new SpriteBatch(GraphicsDevice);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Starts the Batch
            sb.Begin();

            bm.Draw(sb);
            em.Draw(sb);

            // Ends Batch
            sb.End();

            // Disposes the batch
            sb.Dispose();

            base.Draw(gameTime);
        }
    }
}
