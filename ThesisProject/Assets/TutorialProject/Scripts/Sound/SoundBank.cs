using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public AudioClip stepAudio;

    public static SoundBank Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
