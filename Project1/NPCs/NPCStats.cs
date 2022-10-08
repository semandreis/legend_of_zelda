using Zelda.Interfaces;

namespace Zelda.NPCs
{
    class NPCStats : IStats
    {
        private int _health;

        public NPCStats (int health)
        {
            _health = health;
        }

        public bool ChangeStats(int change)
        {
            _health += change;

            return _health >= 1;
        }
    }
}
