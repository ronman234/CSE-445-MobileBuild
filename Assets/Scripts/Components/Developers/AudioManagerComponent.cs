using UnityEngine.Audio;
using UnityEngine;

public class AudioManagerComponent : MonoBehaviour
{
    public AudioMixerGroup group1;
    public AudioMixerGroup group2;
    public AudioMixerGroup group3;
    public SoundComponent[] sounds;

    public AudioManagerSystem instance;

    public void Play(string name)
    {
        SoundComponent s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        s.source.Play();
    }

    public void Mute(string named)
    {
        SoundComponent s = System.Array.Find(sounds, sound => sound.name == named);
        if (s == null)
        {
            Debug.LogWarning("Sound " + named + " not found.");
            return;
        }
        s.source.volume = 0.0f;
    }

    public void Stop(string name)
    {
        SoundComponent s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found.");
            return;
        }
        s.source.Stop();
    }

    public void UnMute(string name)
    {
        SoundComponent s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found.");
            return;
        }
        s.source.volume = 1.0f;
    }

    public bool IsPlaying(string name)
    {
        bool check;
        SoundComponent s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found.");
            return false;
        }
        check = s.source.isPlaying;
        return check;
    }

}
