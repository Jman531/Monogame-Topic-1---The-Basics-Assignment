using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Monogame_Topic_1___The_Basics_Assignment
{
    public class Game1 : Game
    {
        public Vector2 birdLocation;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D backgroundTexture, birdTexture, deerTexture, mooseTexture, bearTexture;

        Random generator = new Random();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            birdLocation = new Vector2(generator.Next(0, 701), generator.Next(0, 401));

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            this.Window.Title = "Wild Animals";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            int randomBackround = generator.Next(0, 3);

            if (randomBackround == 0)
                backgroundTexture = Content.Load<Texture2D>("Field Background");
            else if (randomBackround == 1)
                backgroundTexture = Content.Load<Texture2D>("forest background 1");
            else if (randomBackround == 2)
                backgroundTexture = Content.Load<Texture2D>("forest background 2");
            birdTexture = Content.Load<Texture2D>("bird");
            deerTexture = Content.Load<Texture2D>("deer");
            mooseTexture = Content.Load<Texture2D>("moose");
            bearTexture = Content.Load<Texture2D>("bear");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(deerTexture, new Vector2(150, 350), Color.White);
            _spriteBatch.Draw(mooseTexture, new Vector2(450, 370), Color.White);
            _spriteBatch.Draw(bearTexture, new Vector2(0, 350), Color.White);
            _spriteBatch.Draw(birdTexture, birdLocation, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
