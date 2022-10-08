using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Zelda.GameState;
using Zelda.Interfaces;

namespace Zelda.Commands.MouseCommands
{
    public class MouseCommander
    {
        private readonly GameManager _gm;
        private int _timeSinceLastClick = 0;
        private const int _clickTime = 200;
        private ICommand _backward;
        private ICommand _forward;

        public MouseCommander(GameManager gm)
        {
            _gm = gm;
            _backward = new BackwardRoomCommand(_gm);
            _forward = new ForwardRoomCommand(_gm);
        }

        private void HandleClick()
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                _backward.Execute();
            }
            else if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                _forward.Execute();
            }
        }

        public void Update(GameTime gt)
        {
            _timeSinceLastClick += gt.ElapsedGameTime.Milliseconds;

            if (_timeSinceLastClick > _clickTime)
            {
                _timeSinceLastClick = 0;
                HandleClick();
            }

        }
    }
}
