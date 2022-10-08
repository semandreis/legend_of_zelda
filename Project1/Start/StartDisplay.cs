using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameState;
using Zelda.Link;
using Zelda.Records;

namespace Zelda.Start
{
    public class StartDisplay
    {
        private static Vector2 _messagePosition = new Vector2(120, 50);
        private static Vector2 _messageScale = new Vector2(.7f, .7f);
        private static Color _messageColor = Color.AntiqueWhite;

        private static Vector2 _startPosition = new Vector2(280, 650);
        private static Vector2 _startScale = new Vector2(.9f, .9f);
        private static Color _startColor = Color.CornflowerBlue;

        private static Vector2 _hardModePosition = new Vector2(100, 150);
        private static Vector2 _normalModePosition = new Vector2(100, 200);

        private static Vector2 _withNoRecordPosition = new Vector2(100, 400);
        private static Vector2 _withRecordPosition = new Vector2(100, 450);
        private static Vector2 _recordPosition = new Vector2(100, 500);


        private static Vector2 _file1Position = new Vector2(700, 150);
        private static Vector2 _file2Position = new Vector2(700, 200);
        private static Vector2 _file3Position = new Vector2(700, 250);
        private static Vector2 _file4Position = new Vector2(700, 300);

        private static readonly float _rotation = 0f;
        private static Vector2 _origin = Vector2.Zero;
        private static Vector2 _scale = new Vector2(.5f, .5f);
        private static SpriteEffects _effects = SpriteEffects.None;
        private static readonly float _depth = .8f;

        private static Color _selectedColor = Color.Red;
        private static Color _otherColor = Color.Yellow;

        private readonly GameManager _gm;
        private static Vector2 _linkPosition = new Vector2(700, 450);
        private static readonly Rectangle[] _linkFrame = PlayerConstants.PlayerSpinFrames;
        private static int _frame = 0;
        private static int _count = 0;
        private static Vector2 _linkScale = new Vector2(8f, 8f);
        private static SpriteEffects _linkEffects = SpriteEffects.None;

        public StartDisplay()
        {
            _gm = GameManager.GetInstance();
        }

        private void DrawMessage(SpriteBatch sb)
        {
            sb.DrawString(Globals.Font, "Press Key to Change Game Settings", _messagePosition, _messageColor, _rotation, _origin, _messageScale, _effects, _depth);
        }

        private void DrawMode(SpriteBatch sb)
        {
            if (Globals.HardMode)
            {
                sb.DrawString(Globals.Font, "H : Hard Mode", _hardModePosition, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "N : Normal Mode", _normalModePosition, _otherColor, _rotation, _origin, _scale, _effects, _depth);
            }
            else
            {
                sb.DrawString(Globals.Font, "H : Hard Mode", _hardModePosition, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "N : Normal Mode", _normalModePosition, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
            }
        }

        private void DrawRunOptions(SpriteBatch sb)
        {
            if (Globals.IsRecording && Globals.IsUserControl)
            {
                sb.DrawString(Globals.Font, "Z : Play, No record", _withNoRecordPosition, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "X : Play, Record", _withRecordPosition, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "C : Play Saved File", _recordPosition, _otherColor, _rotation, _origin, _scale, _effects, _depth);
            }
            else if (!Globals.IsRecording && !Globals.IsUserControl)
            {
                sb.DrawString(Globals.Font, "Z : Play, No record", _withNoRecordPosition, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "X : Play, Record", _withRecordPosition, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "C : Play Saved File", _recordPosition, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
            }
            else
            {
                sb.DrawString(Globals.Font, "Z : Play, No record", _withNoRecordPosition, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "X : Play, Record", _withRecordPosition, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "C : Play Saved File", _recordPosition, _otherColor, _rotation, _origin, _scale, _effects, _depth);
            }            
        }

        private void DrawFileOptions(SpriteBatch sb)
        {
            if (Globals.RecordFilename == RecordConstants.Filename1)
            {
                sb.DrawString(Globals.Font, "1 : Record1", _file1Position, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "2 : Record2", _file2Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "3 : Record3", _file3Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "4 : Record4", _file4Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
            }
            else if (Globals.RecordFilename == RecordConstants.Filename2)
            {
                sb.DrawString(Globals.Font, "1 : Record1", _file1Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "2 : Record2", _file2Position, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "3 : Record3", _file3Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "4 : Record4", _file4Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
            }
            else if(Globals.RecordFilename == RecordConstants.Filename3)
            {
                sb.DrawString(Globals.Font, "1 : Record1", _file1Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "2 : Record2", _file2Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "3 : Record3", _file3Position, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "4 : Record4", _file4Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
            }
            else
            {
                sb.DrawString(Globals.Font, "1 : Record1", _file1Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "2 : Record2", _file2Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "3 : Record3", _file3Position, _otherColor, _rotation, _origin, _scale, _effects, _depth);
                sb.DrawString(Globals.Font, "4 : Record4", _file4Position, _selectedColor, _rotation, _origin, _scale, _effects, _depth);
            }
        }

        private void DrawStart(SpriteBatch sb)
        {
            sb.DrawString(Globals.Font, "V : Start Game", _startPosition, _startColor, _rotation, _origin, _startScale, _effects, _depth);
        }

        private void UpdateFrame()
        {
            _count += 1;

            if (_count == 60)
            {
                _frame += 1;
                _linkEffects = SpriteEffects.None;
                _count = 0;
            }
            else if (_count == 45)
            {
                _frame += 1;
            }
            else if (_count == 30)
            {
                _frame += 1;
                _linkEffects = SpriteEffects.FlipHorizontally;
            }
            else if (_count == 15)
            {
                _frame += 1;
            }

            _frame %= _linkFrame.Length;
        }

        private void LinkSpin(SpriteBatch sb)
        {
            sb.Draw(_gm.LinkTexture, _linkPosition, _linkFrame[_frame], _messageColor, 0f, Vector2.Zero, _linkScale, _linkEffects, PlayerConstants.LinkDepth);
            UpdateFrame();
        }

        public void Draw(SpriteBatch sb)
        {
            DrawMessage(sb);
            DrawMode(sb);
            DrawRunOptions(sb);
            DrawFileOptions(sb);
            DrawStart(sb);
            LinkSpin(sb);
        }

    }
}
