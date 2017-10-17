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

        public static BackgroundManager backgroundManager;
        public static EntityManager entityManager;

        public Moving()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
            backgroundManager = new BackgroundManager();

            // New Random
            Random r = new Random();

            // Generates tiles with a random meta on the entire game screen
            for (byte x = 0; x < (GraphicsDevice.Viewport.Width / 32); x++)
                for (byte y = 0; y < (GraphicsDevice.Viewport.Height / 32); y++)
                    backgroundManager.AddBackgroundTile(x, y, r.Next(0, 4),32);

            backgroundManager.AddForegroundTile(new Vector2(6 * 32, 8 * 32), 16);

            // New Entity Manager
            entityManager = new EntityManager();
            entityManager.SpawnPlayer(new Vector2(10, 10), 2.5f);
            

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            entityManager.Update();
            backgroundManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Makes new SpriteBatch
            var sb = new SpriteBatch(GraphicsDevice);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Starts the Batch
            sb.Begin();

            backgroundManager.Draw(sb);
            entityManager.Draw(sb);

            // Ends Batch
            sb.End();

            // Disposes the batch
            sb.Dispose();

            base.Draw(gameTime);
        }
    }
}
