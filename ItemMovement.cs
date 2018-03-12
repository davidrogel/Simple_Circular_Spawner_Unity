using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMovement : MonoBehaviour
{
    [HideInInspector]
    public float speed = 0;
    private Vector3 dir;

    private bool used;

    private Transform myTransform;

    private Color myColor;

    private SpawnManager manager;

	void Start ()
    {
        used = false;

        myTransform = transform;

        dir = (Vector3.zero - myTransform.position);

        Vector3 rand = new Vector3(Random.Range(0, 2), Random.Range(0, -2), 0f);

        dir += rand;

        dir.Normalize();

        myColor = GetComponent<SpriteRenderer>().color;

        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnManager>();
	}
	
	void Update ()
    {
        myTransform.Translate(dir * speed * Time.deltaTime);
	}

    void OnMouseDown()
    {
        if (myColor == Color.black && used == false)
        {
            used = true;
            manager.AddScore();
        }
    }
}
