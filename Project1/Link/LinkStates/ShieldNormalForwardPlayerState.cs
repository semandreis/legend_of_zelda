using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Projectiles;

namespace Zelda.Link.LinkStates
{
    class ShieldNormalForwardPlayerState : IPlayerState
    {
        private readonly IPlayer _player;
        private readonly Direction _direction;
        private readonly Vector2 _velocity;
        private TimeSpan _timeSpan;
        private int _frame = 0;
        private readonly Rectangle[] _playerFrame;
        private readonly int _maxFrame;
        private readonly IProjectileController _projectiles;

        public ShieldNormalForwardPlayerState(IPlayer player, IProjectileController projectiles)
        {
            _player = player;
            _direction = Direction.Down;
            _velocity = new Vector2(0, PlayerConstants.LinkVelocity);
            _playerFrame = PlayerConstants.PlayerShieldFramesFront;
            _player.LinkFrame = _playerFrame[_frame];
            _maxFrame = _playerFrame.Length - 1;
            _projectiles = projectiles;
            _player.UsingItem = false;
            _player.Effects = SpriteEffects.None;
        }

        public void ChangeDirection(Direction direction)
        {
            if (_direction != direction)
            {
                _player.State = PlayerStateCreator.CreateShieldDirectionState(direction, _player, _projectiles);
            }
        }

        public void PickItem(Item item)
        {
            _player.State = PlayerStateCreator.CreatePickItemPlayerState(_player, _projectiles);
        }

        public void Step()
        {
            _player.Point.Move(_velocity, null);
        }

        public void UpdateFrame(GameTime gameTime)
        {
            _timeSpan -= gameTime.ElapsedGameTime;
            if (_timeSpan < TimeSpan.Zero)
            {
                MovingAnimation();
            }
        }

        private void MovingAnimation()
        {
            _frame++;
            _timeSpan = TimeSpan.FromMilliseconds(PlayerConstants.AnimationTime);
            if (_frame > _maxFrame)
            {
                _frame = 0;
            }
            _player.LinkFrame = _playerFrame[_frame];
        }

        public void UseItem(Projectile projectile)
        {
            _projectiles.AddProjectile(projectile, _direction, _player.Point.ObjectPoint);
            _player.State = PlayerStateCreator.CreateShieldItemDirectionState(_direction, _player, _projectiles);
        }

        public void UseShield()
        {
            _player.State = PlayerStateCreator.CreateNormalDirectionState(_direction, _player, _projectiles);
        }

        public void Recoil()
        {
            _player.Point.Move(_velocity * PlayerConstants.LinkRecoilFactor, null);
        }
    }
}
