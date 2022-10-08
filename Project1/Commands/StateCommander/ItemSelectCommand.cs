using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Commands.StateCommander
{
    class ItemSelectCommand : ICommand
    {
        private readonly GameManager _gm;

        public ItemSelectCommand(GameManager gm)
        {
            _gm = gm;
        }

        public void Execute()
        {
            if (!_gm.CurrentState.Equals(ItemSelectionState.GetInstance()))
            {
                _gm.StateCommander.ChangeState(GameStateType.Selection);
                Globals.SoundManager.PlayMusic();
            }
            else
            {
                _gm.StateCommander.ChangeState(GameStateType.Running);
                Globals.SoundManager.PlayMusic();
            }
        }
    }
}
