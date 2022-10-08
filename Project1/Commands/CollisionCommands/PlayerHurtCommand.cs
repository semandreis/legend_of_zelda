using System;
using Zelda.GameState;
using Zelda.Interfaces;
using Zelda.Link;

namespace Zelda.Commands.CollisionCommands
{
    class PlayerHurtCommand : ICommand
    {
        private readonly IPlayer _player;
        public PlayerHurtCommand(IPlayer player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.TakeDamage();
            GameManager gm = GameManager.GetInstance();
            gm.Player.AchievementsStats.DamageTaken++;
            Globals.SoundManager.PlaySound("link_hurt");
        }
    }
}
