using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private Transform Player;

    private Vector3 lastPlayerPos;

    // Start is called before the first frame update
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = new Vector3(0, Player.position.y, 0);

        transform.Translate((pos - lastPlayerPos) * 0.75f);

        lastPlayerPos = pos;

        if (transform.position.y > Player.position.y + 5)
        {
            transform.position = new Vector3(transform.position.x, Player.position.y - 10, transform.position.z);
        }
    }
}
