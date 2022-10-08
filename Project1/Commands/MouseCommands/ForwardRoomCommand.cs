using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Commands.MouseCommands
{
    class ForwardRoomCommand : ICommand
    {
        private readonly GameManager _gm;

        public ForwardRoomCommand(GameManager gm)
        {
            _gm = gm;
        }

        public void Execute()
        {
            _gm.CurrentRoom.ActiveObjects.Remove(_gm.PlayerObject);
            _gm.CurrentState = TransitioningState.GetInstance();
            _gm.NextRoomID = _gm.CurrentRoomID % _gm.MaxRoomID;
            _gm.NextRoomID += 1;
            _gm.CurrentState.InitializeState();
        }
    }
}
