using Zelda.Interfaces;
using Zelda.Link;

namespace Zelda.Commands.CollisionCommands
{
    class PlayerBerserkCommand : ICommand
    {
        private readonly IPlayer _player;
        public PlayerBerserkCommand(IPlayer player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.GoBerserk();
        }
    }
}


