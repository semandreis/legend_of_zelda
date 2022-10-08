using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Projectiles;

namespace Zelda.Link.LinkStates
{
    class PickItemPlayerState : IPlayerState
    {
        private readonly IPlayer _player;
        private readonly Direction _direction;
        private readonly Vector2 _velocity;
        private readonly IProjectileController _projectiles;

        public PickItemPlayerState(IPlayer player, IProjectileController projectiles)
        {
            _player = player;
            _direction = Direction.Down;
            _velocity = new Vector2(0, PlayerConstants.LinkVelocity);
            _projectiles = projectiles;
            _player.LinkFrame = PlayerConstants.LinkItem1Rectangle;
            _player.UsingItem = false;
            _player.Effects = SpriteEffects.None;
        }

        public void ChangeDirection(Direction direction)
        {
            if (_direction != direction)
            {
                _player.State = PlayerStateCreator.CreateNormalDirectionState(direction, _player, _projectiles);
            }
        }

        public void PickItem(Item item)
        {
            _player.PlayerInventory.PickupItem(item);
        }

        public void Recoil()
        {
            _player.Point.Move(_velocity * PlayerConstants.LinkRecoilFactor, null);
        }

        public void Step()
        {

        }

        public void UpdateFrame(GameTime gameTime)
        {

        }

        public void UseItem(Projectile projectile)
        {

        }

        public void UseShield()
        {

        }
    }
}
