using System.Collections.Generic;
using Zelda.Commands.PlayerCommands;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;
using Zelda.Link;
using Zelda.Records;

namespace Zelda.Commands.StateCommander
{
    class ResetCommand : ICommand
    {
        private readonly GameManager _gm;

        public ResetCommand(GameManager gm)
        {
            _gm = gm;
        }

        private void Record()
        {
            GameManager gm = GameManager.GetInstance();
            gm.Recorder.RecordCommand(RecordConstants.QuitCommandString);
            Globals.IsRecording = false;
        }

        public void Execute()
        {
            foreach (KeyValuePair<int, IRoom> entry in _gm.RoomDict)
            {
                entry.Value.ResetRoom();
            }
            _gm.NextRoomID = _gm.StartingRoomID;
            _gm.PlayerObject.Exists = false;
            _gm.ActiveObjects.Remove(_gm.PlayerObject);

            _gm.Player = new Player(_gm.LinkTexture, _gm.StartPosition, _gm.ProjectileController);
            _gm.PlayerObject = new PlayerObject(_gm.Player);
            _gm.InputCommands.UpdatePlayerCommand();

            _gm.ActiveObjects.Add(_gm.PlayerObject);

            _gm.CurrentState = TransitioningState.GetInstance();
            _gm.CurrentState.InitializeState();

            if (Globals.IsRecording)
            {
                Record();
            }
        }
    }
}
