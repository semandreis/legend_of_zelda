using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Interfaces;
using Zelda.Items;
using Zelda.GameState;

namespace Zelda.NPCs.Bosses
{
    class BossDeathState : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly IGameObject _enemy;
        private int _frame;
        private readonly int _initialFrame;
        private readonly int _maxFrame;
        public readonly int _height;
        public readonly int _width;
        private int _timeSinceLastFrame = 600;
        private readonly Texture2D _texture;
        private int _cycles;
        private static GameManager _gameManager = GameManager.GetInstance();

        public BossDeathState(Texture2D texture, int height, int width, int frame, IGameObject enemy)
        {
            _enemy = enemy;
            _initialFrame = frame;
            _frame = _initialFrame;
            _maxFrame = _initialFrame + 16 * 3;
            _texture = texture;
            _width = width;
            _height = height;
            _cycles = 0;
        }

        private void SetNextFrame(int frameTime)
        {
            _timeSinceLastFrame -= frameTime;
            _frame += 16;

        }

        private void SetInitialFrame()
        {
            _frame = _initialFrame;

        }

        private void UpdateFrame(int frameTime, GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (_timeSinceLastFrame > frameTime)
            {
                SetNextFrame(frameTime);
            }

            if (_frame > _maxFrame)
            {
                SetInitialFrame();
                _cycles++;
            }
        }

        private void Kill()
        {
            _enemy.Exists = false;
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            UpdateFrame(100, gameTime);
            SourceRectangle = new Rectangle(_frame, 0, _width, _height);
            sb.Draw(_texture, position, SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, NPCConstants.EnemyLayer);
            
            if (_cycles > 1)
            {
                Kill();
                _gameManager.Player.AchievementsStats.RoomsCleared++;
                IGameObject drop = ItemCreator.CreateItem(General.Item.HeartContainer, position);
                _gameManager.ActiveObjects.Add(drop);
            }
        }
    }
}
