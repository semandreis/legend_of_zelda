using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Items
{
    class FairyItem : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }

        private readonly Interfaces.IDrawable _sprite;
        private readonly IMoveable _point;

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y,
                (int)(_sprite.SourceRectangle.Width * ItemConstants.ItemResize),
                (int)(_sprite.SourceRectangle.Height * ItemConstants.ItemResize));
        }

        public FairyItem(Texture2D texture, Vector2 position)
        {
            Exists = true;
            _sprite = new FairySprite(texture);
            _point = new ItemPoint(position);
            SetRectangle();
            ObjectProperty = ObjectType.Item;
            SoundProperty = SoundType.Item;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(_point.ObjectPoint, 0, gameTime, ItemConstants.ItemResize, sb);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void UndoMovement()
        {

        }

        public void ChangeStats(int change)
        {

        }

        public void Initial()
        {

        }
    }
}
