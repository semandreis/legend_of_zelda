using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Commands.StateCommander
{
    class RunCommand : ICommand
    {
        private readonly GameManager _gm;

        public RunCommand(GameManager gm)
        {
            _gm = gm;
        }

        public void Execute()
        {
            _gm.StateCommander.ChangeState(GameStateType.Running);
            Globals.SoundManager.PlayMusic();
        }
    }
}
