using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Projectiles;

namespace Zelda.Link.LinkStates
{
    class ShieldItemForwardPlayerState : IPlayerState
    {
        private readonly IPlayer _player;
        private readonly Direction _direction;
        private readonly Vector2 _velocity;
        private TimeSpan _timeSpan;
        private readonly IProjectileController _projectiles;

        public ShieldItemForwardPlayerState(IPlayer player, IProjectileController projectiles)
        {
            _player = player;
            _direction = Direction.Down;
            _velocity = new Vector2(0, PlayerConstants.LinkVelocity);
            _player.LinkFrame = PlayerConstants.LinkUseItemForwardRectangle;
            _timeSpan = TimeSpan.FromMilliseconds(PlayerConstants.ItemTime);
            _projectiles = projectiles;
            _player.UsingItem = true;
            _player.Effects = SpriteEffects.None;
        }

        public void ChangeDirection(Direction direction)
        {

        }

        public void PickItem(Item item)
        {
            _player.State = PlayerStateCreator.CreatePickItemPlayerState(_player, _projectiles);
        }

        public void Step()
        {

        }

        public void UpdateFrame(GameTime gameTime)
        {
            _timeSpan -= gameTime.ElapsedGameTime;
            UsingItem();
        }

        private void UsingItem()
        {
            if (_timeSpan < TimeSpan.Zero)
            {
                _player.State = PlayerStateCreator.CreateShieldDirectionState(_direction, _player, _projectiles);
            }
        }

        public void UseItem(Projectile projectile)
        {
            _projectiles.AddProjectile(projectile, _direction, _player.Point.ObjectPoint);
            _player.State = PlayerStateCreator.CreateShieldItemDirectionState(_direction, _player, _projectiles);
        }

        public void UseShield()
        {
            _player.State = PlayerStateCreator.CreateItemDirectionState(_direction, _player, _projectiles);
        }

        public void Recoil()
        {
            _player.Point.Move(_velocity * PlayerConstants.LinkRecoilFactor, null);
        }
    }
}
