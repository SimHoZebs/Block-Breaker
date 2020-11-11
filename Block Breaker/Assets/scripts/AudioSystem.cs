using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static void PlayRandomSFX(AudioClip[] audioClips, GameObject audioSource){
        var chosenAudio = audioClips[Random.Range(0, audioClips.Length)];
        var audioSourceLocation = audioSource.transform.localPosition;
        AudioSource.PlayClipAtPoint(chosenAudio, audioSourceLocation);
    }
}
