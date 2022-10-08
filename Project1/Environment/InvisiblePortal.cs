using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Environment
{
    class InvisiblePortal : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }
        public int NextRoomID { get; set; }
        public int DoorType { get; set; }
        public Vector2 NextPosition { get; set; }
        public IMoveable _point;
        public Vector2 _pos;

        public InvisiblePortal(Vector2 position)
        {
            Exists = true;
            _point = new NonMovingTilePoint(position);
            ObjectRectangle = new Rectangle((int)position.X, (int)position.Y, EnvironmentConstants.TileWidth, EnvironmentConstants.TileHeight);
            ObjectProperty = ObjectType.Portal;
            _pos = position;
            SubProperty = SubType.None;
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
