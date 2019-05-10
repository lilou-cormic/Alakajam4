using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer Instance;

    private AudioSource audioSource;

    public static bool IsMusicPlaying { get { return Instance != null && Instance.audioSource != null && Instance.audioSource.enabled; } }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void SwitchMusicState()
    {
        Instance.audioSource.enabled = !Instance.audioSource.enabled;
    }
}
