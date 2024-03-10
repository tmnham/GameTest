using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameTest.Sprites
{
    public class Tau : Sprite
    {
        public Dan Dan;
        //Goi tau
        public Tau(Texture2D texture) : base(texture)
        {

        }
        //Sound
        private Sound _sound;

        public Tau(Texture2D texture, Sound sound) : base(texture)
        {
            _sound = sound;
        }
        //
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            PhimTruocDo = PhimHienTai;
            PhimHienTai = Keyboard.GetState();
            //phim A
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                GocQuay -= MathHelper.ToRadians(RotationVelocity);
            //phim D
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                GocQuay += MathHelper.ToRadians(RotationVelocity);

            Chieu = new Vector2((float)Math.Cos(GocQuay), (float)Math.Sin(GocQuay));
            //phim W
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                ViTri += Chieu * LinearVelocity;
            //phim Space ban dan
            if (PhimHienTai.IsKeyDown(Keys.Space) &&
                PhimTruocDo.IsKeyUp(Keys.Space))
            {
                _sound.Play();
                ThemDan(sprites);
            }


        }
        //them dan
        private void ThemDan(List<Sprite> sprites)
        {
            var dan = Dan.Clone() as Dan;
            dan.Chieu = this.Chieu;
            dan.ViTri = this.ViTri;
            dan.LinearVelocity = this.LinearVelocity * 2;
            dan.LifeSpan = 2f;
            dan.Parent = this;

            sprites.Add(dan);
        }
    }
}
