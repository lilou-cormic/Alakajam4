using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Text CounterText = null;

    [SerializeField]
    private Text Text2 = null;

    [SerializeField]
    private AudioClip EnemyClip = null;

    [SerializeField]
    private AudioClip ParachuteClip = null;

    private Rigidbody2D rb;

    private AudioSource audioSource;

    private int parachuteCount = 0;
        
    private bool isPlaying = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (isPlaying)
            return;

        if (Input.anyKeyDown)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Parachute")
        {
            audioSource.PlayOneShot(ParachuteClip);

            rb.velocity = rb.velocity.normalized;
            parachuteCount++;
            CounterText.text = parachuteCount.ToString();
        }

        if (tag == "Enemy")
        {
            audioSource.PlayOneShot(EnemyClip);

            isPlaying = false;
            LevelSpawner.Instance.StopSpawning();

            rb.velocity = Vector3.zero;
            rb.isKinematic = true;

            Text2.enabled = true;
        }

        Destroy(collision.gameObject);
    }
}
