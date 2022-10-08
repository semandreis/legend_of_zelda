using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Link;
using Zelda.Interfaces;
using Zelda.GameState;

namespace Zelda.Commands.ItemCommands
{
    class HeartCommand : ICommand
    {
        private readonly IPlayer _player;

        public HeartCommand(IPlayer player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.PlayerStats.ChangeHealth(5);
            GameManager gm = GameManager.GetInstance();
            gm.Player.AchievementsStats.HeartsCollected++;

        }
    }
}
