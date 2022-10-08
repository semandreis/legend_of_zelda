using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Rooms;

namespace Zelda.GameState
{
    class ItemSelectionState : IGameState
    {

        private static ItemSelectionState _instance;
        private static ItemSelectionScreen _screen;
        private GameManager _gameManager;
        private static SpriteFont _font;

        private ItemSelectionState() { }

        public static ItemSelectionState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ItemSelectionState();
            }
            return _instance;
        }

        public void InitializeState()
        {
            _gameManager = GameManager.GetInstance();
            _screen = ItemSelectionScreen.GetInstance();
            _screen.InitializeScreen();
            _gameManager.HUD.MapDestination = new Rectangle(50, 50, 800, 800);
            _font = _gameManager.Content.Load<SpriteFont>("Ubuntu32");
            Globals.IsMouseDebugging = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _screen.Draw(gameTime, sb);
            _gameManager.HUD.Draw(Vector2.Zero, sb, _font);
        }

        public void Update(GameTime gameTime)
        {
            _gameManager.HUD.Update(gameTime);
            _screen.Update(gameTime);
        }
    }
}
