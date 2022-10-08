using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Zelda.Sound
{
    // refrenced material https://youtu.be/JykpElYLIk8?list=PLZ6ofHM1rvK8lQSoKX1USZstM-ZXikFHp
    class SoundItem
    {
        public string _name;
        public SoundEffect sound;
        public SoundEffectInstance instance;

        public SoundItem(string name, string path, ContentManager content)
        {
            _name = name;
            sound = content.Load<SoundEffect>(path);
            CreateInstance();
        }

        public virtual void CreateInstance()
        {
            instance = sound.CreateInstance();
        }
    }
}