using System.Collections.Generic;
using Zelda.General;

namespace Zelda.Link
{
    class PlayerInventory : IPlayerInventory
    {
        private Dictionary<Item, int> _countableItems { get; set; }
        private Dictionary<Item, bool> _hasableItems { get; set; }
        private Dictionary<Projectile, bool> _projectileItems { get; set; }

        private void AddProjectiles()
        {
            _projectileItems.Add(Projectile.WoodenSword, true);
            _projectileItems.Add(Projectile.WoodenSwordBeam, false);
            _projectileItems.Add(Projectile.WhiteSword, false);
            _projectileItems.Add(Projectile.MagicalSword, false);
            _projectileItems.Add(Projectile.MagicalRod, false);
            _projectileItems.Add(Projectile.Candle, false);
            _projectileItems.Add(Projectile.Boomerang, false);
            _projectileItems.Add(Projectile.MagicalBoomerang, false);
        }

        private void AddHasables()
        {
            _hasableItems.Add(Item.Clock, false);
            _hasableItems.Add(Item.Compass, false);
            _hasableItems.Add(Item.Map, false);
            _hasableItems.Add(Item.Bow, false);
        }

        private void AddCountables()
        {
            _countableItems.Add(Item.Arrow, 0);
            _countableItems.Add(Item.SilverArrow, 0);
            _countableItems.Add(Item.Bomb, 0);
            _countableItems.Add(Item.Key, 0);
            _countableItems.Add(Item.Rupee, 0);
        }

        private void InitializeItems()
        {
            AddProjectiles();
            AddHasables();
            AddCountables();
        }

        public PlayerInventory()
        {
            _countableItems = new Dictionary<Item, int>();
            _hasableItems = new Dictionary<Item, bool>();
            _projectileItems = new Dictionary<Projectile, bool>();
            InitializeItems();
        }

        public void PickupItem(Item item)
        {
            bool exists = _countableItems.TryGetValue(item, out int countValue);

            if (exists)
            {
                _countableItems[item] = countValue + 1;
            }
        }

        public void PickUpHasable(Item item)
        {
            bool exists = _hasableItems.TryGetValue(item, out bool value);

            if (exists)
            {
                _hasableItems[item] = true;
            }
        }

        public void PickUpProjectile(Projectile p)
        {
            bool exists = _projectileItems.TryGetValue(p, out bool value);

            if (exists)
            {
                _projectileItems[p] = true;
            }
        }

        public void ActivateKillStreak()
        {
            if (_projectileItems[Projectile.Boomerang])
            {
                _projectileItems[Projectile.MagicalBoomerang] = true;
            }
            if (_projectileItems[Projectile.WoodenSword])
            {
                _projectileItems[Projectile.MagicalSword] = true;
            }
            _projectileItems[Projectile.Candle] = true;

            System.Console.WriteLine("KILL STREAK ACTIVATED");
        }

        public void ActivateBeams()
        {
            if (!_projectileItems[Projectile.WoodenSwordBeam])
            {
                _projectileItems[Projectile.WoodenSwordBeam] = true;
            }
        }

        public void DeActivateBeams()
        {
            if (_projectileItems[Projectile.WoodenSwordBeam])
            {
                _projectileItems[Projectile.WoodenSwordBeam] = false;
            }
        }

        public void DeActivateKillStreak()
        {
            _projectileItems[Projectile.MagicalBoomerang] = false;
            _projectileItems[Projectile.MagicalSword] = false;
            _projectileItems[Projectile.Candle] = false;

            // if Proj 1 or 0 is magical, take it back

            System.Console.WriteLine("KILL STREAK DEACTIVATED");
        }

        public bool HasItem(Item item)
        {
            bool exists = _hasableItems.TryGetValue(item, out bool value);

            if (exists)
            {
                return value;
            }

            else
            {
                return exists;
            }
        }

        public List<Item> GetCountables()
        {
            List<Item> list = new List<Item>();

            foreach (var i in _countableItems)
            {
                list.Add(i.Key);
            }

            return list;
        }

        public List<Item> GetHasables()
        {
            List<Item> list = new List<Item>();

            foreach (var i in _hasableItems)
            {
                list.Add(i.Key);
            }

            return list;
        }

        public List<Projectile> GetProjectiles()
        {
            List<Projectile> list = new List<Projectile>();
            bool exists;
            bool value;

            foreach (var i in _projectileItems)
            {
                exists = _projectileItems.TryGetValue(i.Key, out value);
                if (value)
                {
                    list.Add(i.Key);
                }
            }

            if (_countableItems[Item.Arrow] > 0 && _hasableItems[Item.Bow])
            {
                list.Add(Projectile.Arrow);
            }

            if (_countableItems[Item.SilverArrow] > 0 && _hasableItems[Item.Bow])
            {
                list.Add(Projectile.SilverArrow);
            }

            if (_countableItems[Item.Bomb] > 0)
            {
                list.Add(Projectile.Bomb);
            }

            return list;
        }

        public void UseItem(Item item)
        {
            bool exists = _countableItems.TryGetValue(item, out int value);

            if (exists)
            {
                _countableItems[item] = value - 1;
            }
        }

        public int ItemCount(Item item)
        {
            bool exists = _countableItems.TryGetValue(item, out int value);


            if (exists)
            {
                return value;
            }

            else
            {
                return 0;
            }
        }

        public void ChangeHasable(Item item, bool hasItem)
        {
            bool exists = _hasableItems.TryGetValue(item, out _);

            if (exists)
            {
                _hasableItems[item] = hasItem;
            }
        }
    }
}
