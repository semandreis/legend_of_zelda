using Zelda.General;

namespace Zelda.Link
{
    class PlayerStats : IPlayerStats
    {
        private int _health;
        private int _maxHealth;
        private bool _berserk;
        public int KillStreak { get; set; }

        public Projectile Proj0 { get; set; }
        public Projectile Proj1 { get; set; }

        public PlayerStats (int health)
        {
            _health = health;
            _maxHealth = health;
            _berserk = false;
            KillStreak = 0;
            Proj0 = Projectile.WoodenSword;
            Proj1 = Projectile.WoodenSword;
        }

        public void IncreaseHealth(int change)
        {
            _health += change;
            _maxHealth += change;
        }

        public bool IsHealthy()
        {
            return _health == _maxHealth;
        }
        public bool IsAlive()
        {
            return _health > 0;
        }
        public bool IsBerserk()
        {
            return _berserk;
        }

        public bool OneHP()
        {
            return _health == 1;
        }

        public void BerserkMode()
        {
            _berserk = !_berserk;
        }

        public void ChangeHealth(int change)
        {
            _health = _health + change;
            if(_health > _maxHealth)
            {
                _health = _maxHealth;

            }
            System.Console.WriteLine("Health: " + _health);

        }

        public void SetProj0(Projectile p)
        {
            Proj0 = p;
        }

        public void SetProj1(Projectile p)
        {
            Proj1 = p;
        }

        public int FullHeartCount()
        {
            return _health / PlayerConstants.LinkHeartSize;
        }

        public bool HasHalfHeart()
        {
            return _health % PlayerConstants.LinkHeartSize > 0;
        }
        
        
    }
}
