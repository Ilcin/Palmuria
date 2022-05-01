using UnityEngine;

// This Reaction is used to play sounds through a given AudioSource.
public class AudioReaction : DelayedReaction
{
    public AudioSource audioSource;     // The AudioSource to play the clip.
    public AudioClip audioClip;         // The AudioClip to be played.


    protected override void ImmediateReaction()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}