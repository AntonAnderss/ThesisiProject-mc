using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private void OnMovement()
    {
        //Checks if the audio is already playing, then it leaves the method
        if (audioSource.isPlaying && audioSource.clip == SoundBank.Instance.stepAudio)
            return;

        //If not it assigns the audioclip, sets it on loop and starts playing it
        audioSource.clip = SoundBank.Instance.stepAudio;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void OnMovementStop()
    {
        audioSource.Stop();
        audioSource.loop=false;
    }
}
                                                                                                                                                      