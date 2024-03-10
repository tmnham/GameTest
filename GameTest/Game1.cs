using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameTest.Sprites;

namespace GameTest
{
    public class Game1 : Game
    {
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //
        private List<Sprite> _sprites;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //
            // Tải âm thanh từ tệp music.mp3
            Sound sound = new Sound(Content, "music");

            // TODO: use this.Content to load your game content here
            //
            var tauTexture = Content.Load<Texture2D>("Tau");
            _sprites = new List<Sprite>()
            {
                new Tau(tauTexture, sound)
                {
                    ViTri = new Vector2(100, 100),
                    Dan = new Dan(Content.Load<Texture2D>("Dan")),
                },
            };
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //
            foreach (var sprite in _sprites.ToArray())
                sprite.Update(gameTime, _sprites);
            PostUpdate();
            base.Update(gameTime);
        }
        //
        private void PostUpdate()
        {
            for (int i = 0; i < _sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
        }
        //
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //
            _spriteBatch.Begin();
            foreach (var sprite in _sprites)
                sprite.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
