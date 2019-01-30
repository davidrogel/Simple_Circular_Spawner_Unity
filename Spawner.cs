
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float radius = 12;
    public float timeBetweenSpawns = 1;

    public float minSpeed = 0.3f;
    public float maxSpeed = 0.75f;

    public GameObject prefab;
    public Sprite[] sprites;

    public Color[] colors;
    
    public bool run;

    private List<Vector3> startPositions;

    void Start ()
    {
        CreateStartPositions();
        StartCoroutine(Spawn());
    }

    void CreateStartPositions()
    {
        startPositions = new List<Vector3>();
        float TWO_PI = Mathf.PI * 2;
        for (float i = 0; i < TWO_PI; i += 0.1f)
        {
            Vector3 randomPosition = new Vector3();
            randomPosition.x = Mathf.Cos(i);
            randomPosition.y = Mathf.Sin(i);
            randomPosition *= radius;

            startPositions.Add(randomPosition);            
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);

        GameObject go = Instantiate(prefab, startPositions[Random.Range(0, startPositions.Count)], Quaternion.identity);

        go.GetComponent<SpriteRenderer>().color = (Random.Range(0, 100) <= 35)
            ?
                Color.black
            :
                colors[Random.Range(0, colors.Length - 1)];

        ItemMovement goItem = go.GetComponent<ItemMovement>();
        goItem.speed = Random.Range(minSpeed, maxSpeed);

        if(run)
            StartCoroutine(Spawn());
    }
}
