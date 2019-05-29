using Unity.Entities;
using UnityEngine;

public class AudioManagerSystem : ComponentSystem
{
    protected override void OnUpdate() 
    {
        Entities.ForEach((AudioManagerComponent audio, GameObject gobject, AudioSource clips) =>
        {
            if (audio.instance == null)
            {
                audio.instance = this;
            }
            else
            {
                Object.Destroy(gobject.gameObject);
                Debug.Log("Destroyed previous manager");
                return;
            }
            Object.DontDestroyOnLoad(gobject.gameObject);

            foreach (SoundComponent s in audio.sounds)
            {
                s.source = clips;
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.outputAudioMixerGroup = s.mixer;
            }

            Play("Theme");
            Play("LavaRising");
            Play("MainMenu");
            Play("FireBurning");

            Mute("LavaRising");
            Mute("Theme");
            Mute("FireBurning");

            void Play(string name)
            {
                SoundComponent s = System.Array.Find(audio.sounds, sound => sound.name == name);
                if (s == null)
                {
                    Debug.LogWarning("Sound: " + name + " not found.");
                    return;
                }
                s.source.Play();
            }

            void Mute(string name)
            {
                SoundComponent s = System.Array.Find(audio.sounds, sound => sound.name == name);
                if (s == null)
                {
                    Debug.LogWarning("Sound " + name + " not found.");
                    return;
                }
                s.source.volume = 0.0f;
            }

        });
    }
}

