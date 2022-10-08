using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Environment
{
    class InvisibleTile : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }
        private readonly IMoveable _point;

        public InvisibleTile(Vector2 position)
        {
            Exists = true;
            _point = new NonMovingTilePoint(position);
            ObjectRectangle = new Rectangle((int)position.X, (int)position.Y, EnvironmentConstants.TileWidth, EnvironmentConstants.TileHeight);
            ObjectProperty = ObjectType.Unmoveable;
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
