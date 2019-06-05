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

            audio.Play("Theme");
            audio.Play("LavaRising");
            audio.Play("MainMenu");
            audio.Play("FireBurning");

            audio.Mute("LavaRising");
            audio.Mute("Theme");
            audio.Mute("FireBurning");


        });
    }
}

