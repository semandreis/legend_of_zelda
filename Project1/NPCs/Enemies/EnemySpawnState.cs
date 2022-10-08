using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Interfaces;
using Zelda.NPCs.Bosses;
using Zelda.NPCs;
using System;
using Zelda.Items;
using Zelda.GameState;

namespace Zelda.Enemies
{
    class EnemySpawnState : Interfaces.IDrawable
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

        public EnemySpawnState(Texture2D texture, int height, int width, int frame, IGameObject enemy)
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

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            
        }
    }
}
