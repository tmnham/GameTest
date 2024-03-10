using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest.Sprites
{
    public class Sprite: ICloneable // nhân bản ra
    {
        protected Texture2D Anh; //_texture;
        protected float GocQuay; //_rotation;

        protected KeyboardState PhimHienTai; //_currentKey;
        protected KeyboardState PhimTruocDo;//_previousKey;

        public Vector2 ViTri; //Position;
        public Vector2 Goc;// Origin;
        public Vector2 Chieu;// Direction;

        public float RotationVelocity = 3f;//Vận tốc quay
        public float LinearVelocity = 4f;//Vận tốc tuyến tính


        public Sprite Parent;
        public float LifeSpan = 0f;

        public bool IsRemoved = false;


        public Sprite(Texture2D anh)
        {
            Anh = anh;
            // Gốc tọa độ của ảnh (X,Y)
            // điểm của ảnh ở vị trí X= rộng/2 
            //                       Y= cao/2

            Goc = new Vector2(Anh.Width / 2, Anh.Height / 2);
        }
        
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //              Anh, Vị Trí , vẻ trên toàn bộ hình ảnh
            spriteBatch.Draw(Anh, ViTri, null, Color.Red, GocQuay, Goc, 1, SpriteEffects.None, 0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
