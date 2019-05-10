using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnMusicOnOff : MonoBehaviour
{
    [SerializeField]
    private Text Text = null;

    public void Start()
    {
        SetText();
    }

    public void SwitchMusicState()
    {
        MusicPlayer.SwitchMusicState();

        SetText();
    }
    
    private void SetText()
    {
        if (MusicPlayer.IsMusicPlaying)
            Text.text = "Music On";
        else
            Text.text = "Music Off";
    }
}
