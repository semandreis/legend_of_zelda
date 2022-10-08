using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Environment
{
    class ClosedDoorObject : IGameObject
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
        public Vector2 _pos { get; set; }
        public bool IsLocked { get; set; }
        private readonly Interfaces.IDrawable _sprite;
        public ClosedDoorObject(Texture2D texture, IGameObject portal)
        {

            Exists = true;
            _pos = ((InvisiblePortal)portal)._pos;
            _point = new NonMovingTilePoint(_pos);
            ObjectRectangle = new Rectangle((int)_pos.X, (int)_pos.Y, EnvironmentConstants.TileWidth, EnvironmentConstants.TileHeight);
            ObjectProperty = ObjectType.Portal;

            ObjectRectangle = portal.ObjectRectangle;
            NextRoomID = ((InvisiblePortal)portal).NextRoomID;
            NextPosition = ((InvisiblePortal)portal).NextPosition;
            _point = ((InvisiblePortal)portal)._point;
            DoorType = ((InvisiblePortal)portal).DoorType;
            IsLocked = true;

            switch (DoorType)
            {
                case 5:
                    _sprite = new ClosedDoorEastSprite(texture);
                    SubProperty = SubType.ClosedDoorEnemy;
                    break;
                case 6:
                    SubProperty = SubType.ClosedDoorBlock;
                    _sprite = new ClosedDoorWestSprite(texture);
                    break;
                default:
                    break;
            }

        }
        public void Update(GameTime gameTime)
        {

        }
        public void UndoMovement()
        {

        }
        public void Initial()
        {

        }
        public void ChangeStats(int change)
        {

        }
        public void UnLockDoor()
        {
            IsLocked = false;
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            if (IsLocked)
            {
                _sprite.Draw(Vector2.Zero, 0, gameTime, EnvironmentConstants.DoorResize, sb);
            }
        }
    }
}
