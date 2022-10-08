using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Commands.PlayerCommands;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;
using Zelda.Link.LinkStates;
using Zelda.Projectiles;
using Zelda.Achievements;

namespace Zelda.Link
{
    // The Player class is still more than 100 lines, but has been greatly reduced.
    class Player : IPlayer
    {
        public IPlayerState State { get; set; }
        public IPlayerCommander PlayerCommander { get; set; }
        public Color LinkColor { get; set; }
        public Rectangle LinkFrame { get; set; }
        public IMoveable Point { get; set; }
        public bool UsingItem { get; set; }
        public SpriteEffects Effects { get; set; }
        public IPlayerStats PlayerStats { get; set; }
        public IPlayerInventory PlayerInventory { get; set; }
        public IAchievements AchievementsStats { get; set; }

        private readonly Interfaces.IDrawable _sprite;
        private bool _hurt;
        private bool _berserk;
        private float _remainingDelay;
        private bool _moving;
        private int _damageFrame;
        private TimeSpan _damageSpan;

        public Player(Texture2D texture, Vector2 position, IProjectileController projectiles)
        {
            State = PlayerStateCreator.CreateNormalDirectionState(Direction.Down, this, projectiles);
            LinkColor = Color.White;
            Point = new PlayerPoint(position);
            PlayerStats = new PlayerStats(PlayerConstants.LinkHealth);
            AchievementsStats = new AchievementsStats();
            PlayerInventory = new PlayerInventory();
            _sprite = new PlayerSprite(this, texture);
            _hurt = false;
            _moving = true;
            _berserk = false;
            _remainingDelay = PlayerConstants.BerserkTime;
            _damageFrame = 0;
            _damageSpan = TimeSpan.FromMilliseconds(PlayerConstants.DamageTime);
        }

        public void Animate(bool animate)
        {
            _moving = animate;
        }

        public void ChangeDirection(Direction direction)
        {
            State.ChangeDirection(direction);
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(Point.ObjectPoint, 0, gameTime, PlayerConstants.LinkResize, sb);
            AchievementsStats.CheckAchievements(gameTime, sb);

        }

        public void Step()
        {
            State.Step();
            AchievementsStats.DistanceTraveled++;
        }

        public void GoBerserk()
        {
            _berserk = true;
        }
        public void TakeDamage()
        {
            _hurt = true;
            PlayerStats.KillStreak = 0;
            PlayerInventory.DeActivateKillStreak();
        }

        public void Update(GameTime gameTime)
        {
            if (_moving || UsingItem)
            {
                State.UpdateFrame(gameTime);
            }

            if (_berserk)
            {
                Berserk(gameTime);
            }
            if (_hurt)
            {
                HurtPlayer(gameTime);
            }

            if (PlayerStats.IsHealthy())
            {
                PlayerInventory.ActivateBeams();
                PlayerStats.Proj0 = Projectile.WoodenSwordBeam;
            } else
            {
                PlayerInventory.DeActivateBeams();
                PlayerStats.Proj0 = Projectile.WoodenSword;
            }

        }

        private void Berserk(GameTime gameTime)
        {
            LinkColor = PlayerConstants.ColorDamage[_damageFrame];

            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _remainingDelay -= timer;

            _damageSpan -= gameTime.ElapsedGameTime;
            if (_damageSpan < TimeSpan.Zero && PlayerStats.IsBerserk())
            {
                _damageSpan = TimeSpan.FromMilliseconds(PlayerConstants.DamageTime);
                if (++_damageFrame > PlayerConstants.DamageTime)
                {
                    _damageFrame = 1;
                    
                }
            }
            if (_remainingDelay <= 0)
            {
                _damageFrame = 0;
                PlayerStats.BerserkMode(); 
            }
           
        }

        private void HurtPlayer(GameTime gameTime)
        {
            LinkColor = PlayerConstants.ColorDamage[_damageFrame];
            
            _damageSpan -= gameTime.ElapsedGameTime;
            if (_damageSpan < TimeSpan.Zero)
            {
                _damageSpan = TimeSpan.FromMilliseconds(PlayerConstants.DamageTime);
                if (++_damageFrame > PlayerConstants.DamageTime)
                {
                    _damageFrame = 0;
                    _hurt = false;
                }
            }
            State.Recoil();
        }

        public void UseItem(Projectile projectile)
        {
            State.UseItem(projectile);
        }

        public void UseShield()
        {
            State.UseShield();
        }
    }
}
