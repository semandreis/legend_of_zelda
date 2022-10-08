using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Zelda.General;
using Zelda.Interfaces;
using Zelda.Link;
using Zelda.NPCs;

namespace Zelda.Environment
{
    class MovingTileObject : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }

        private readonly Interfaces.IDrawable _sprite;
        public IMoveable Point;
        private IMoveable _previousPoint;
        private readonly Vector2 _initialPoint;
        public bool Moving { get; set; }

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)Point.ObjectPoint.X, (int)Point.ObjectPoint.Y,
                (EnvironmentConstants.TileWidth),
                (EnvironmentConstants.TileHeight));
        }

        public MovingTileObject(Texture2D texture, Vector2 position)
        {
            Exists = true;
            _sprite = new BarrierTileSprite(texture);
            Point = new MovingTilePoint(position);
            _previousPoint = Point;
            _initialPoint = position;
            ObjectProperty = ObjectType.Moveable;
            SetRectangle();
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(Point.ObjectPoint, 0, gameTime, EnvironmentConstants.TileResize, sb);
            _previousPoint = Point;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void UndoMovement()
        {
            Point = _previousPoint;
        }

        public void ChangeStats(int change)
        {

        }
        public void Pushed(Direction direction)
        {
            if (direction == Direction.Down)
            {
                Console.WriteLine("down");
                Point.Move(new Vector2(0, 4), null);
                SetRectangle();
            }
            else if (direction == Direction.Up)
            {
                Console.WriteLine("up");
                Point.Move(new Vector2(0, -4), null);
                SetRectangle();
            }
            else if (direction == Direction.Left)
            {
                Console.WriteLine("left");
                Point.Move(new Vector2(4, 0), null);
                SetRectangle();
            }
            else if (direction == Direction.Right)
            {
                Console.WriteLine("Right");
                Point.Move(new Vector2(-4, 0), null);
                SetRectangle();
            }
        }

        public void Initial()
        {
            Point.ObjectPoint = _initialPoint;
            SetRectangle();
        }
    }
}
