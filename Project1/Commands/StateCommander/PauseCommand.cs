using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Commands.StateCommander
{
    class PauseCommand : ICommand
    {
        private readonly GameManager _gm;

        public PauseCommand(GameManager gm)
        {
            _gm = gm;
        }

        public void Execute()
        {
            if (!Globals.GameIsPaused)
            {
                _gm.StateCommander.ChangeState(GameStateType.Paused);
                Globals.SoundManager.PauseMusic();
                Globals.GameIsPaused = true;
            } else
            {
                _gm.StateCommander.ChangeState(GameStateType.Running);
                Globals.SoundManager.PlayMusic();
                Globals.GameIsPaused = false;
            }

        }
    }
}
