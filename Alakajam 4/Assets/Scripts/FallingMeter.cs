using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingMeter : MonoBehaviour
{
    [SerializeField]
    private Text Text1 = null;

    [SerializeField]
    private Text CounterText = null;

    [SerializeField]
    private Text Text2 = null;

    private Camera Camera = null;

    private void Start()
    {
        Camera = Camera.main;
    }

    private void FixedUpdate()
    {
        string text = (-Camera.transform.position.y).ToString("0.00");
        Text1.text = text;
        Text2.text = text + "\n" + CounterText.text;
    }
}
