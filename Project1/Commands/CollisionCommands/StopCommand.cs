using Zelda.Interfaces;
using Zelda.Link;

namespace Zelda.Commands.CollisionCommands
{
    class StopCommand : ICommand
    {
        private readonly IPlayer _player;
        public StopCommand(IPlayer player)
        {
            _player = player;
        }

        public void Execute()
        {
            _player.Point.Move(new Microsoft.Xna.Framework.Vector2(0,0), null);
        }
    }
}
