using UnityEngine;
public class SoundMananger
{
    AudioSource source;
    AudioClip[] clips;

    public SoundMananger(Player p)
    {
        clips = p.ClipsAudio;
        source = p.GetComponent<AudioSource>();
    }

    public void SoundPlay(int clip)
    {
        source.Stop();
        source.clip = clips[clip];
        source.Play();
    }
}
