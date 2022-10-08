using System;
using System.Collections.Generic;
using System.Text;
using Zelda.GameState;
using Zelda.Interfaces;

namespace Zelda.Commands.ItemCommands
{
    class ClockCommand : ICommand
    {

        private static GameManager _gm;
        public ClockCommand()
        {
            _gm = GameManager.GetInstance();
        }

        public void Execute()
        {
            _gm.StateCommander.ChangeState(General.GameStateType.ClockPause);
            Console.WriteLine("executed");

        }
    }
}
