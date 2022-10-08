using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Items
{
    class NullItem : IGameObject
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
        }

        public NullItem(Texture2D texture, Vector2 position)
        {
            Exists = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
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
