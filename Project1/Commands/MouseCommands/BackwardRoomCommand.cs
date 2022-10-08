using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Commands.MouseCommands
{
    class BackwardRoomCommand : ICommand
    {
        private readonly GameManager _gm;

        public BackwardRoomCommand(GameManager gm)
        {
            _gm = gm;
        }

        public void Execute()
        {
            _gm.CurrentRoom.ActiveObjects.Remove(_gm.PlayerObject);
            _gm.CurrentState = TransitioningState.GetInstance();
            _gm.NextRoomID = _gm.CurrentRoomID - 1;
            if (_gm.NextRoomID < 1)
            {
                _gm.NextRoomID += _gm.MaxRoomID;
            }
            _gm.CurrentState.InitializeState();
        }
    }
}
