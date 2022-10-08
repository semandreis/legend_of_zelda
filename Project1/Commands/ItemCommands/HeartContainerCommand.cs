using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Link;
using Zelda.Interfaces;

namespace Zelda.Commands.ItemCommands
{
    class HeartContainerCommand : ICommand
    {
        private readonly IPlayer _player;

        public HeartContainerCommand(IPlayer player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.PlayerStats.IncreaseHealth(10);

        }
    }
}
