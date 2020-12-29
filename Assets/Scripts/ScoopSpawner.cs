using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ScoopSpawner : MonoBehaviour
{
    public Scoop[] scoopPrefabs;

    public float width;
    public float delay;

    Coroutine coroutine;

    public void Begin()
    {
        coroutine = StartCoroutine(StartSpawn());
    }

    public void Stop()
    {
        if (coroutine != null) StopCoroutine(coroutine);
    }

    IEnumerator StartSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Scoop scoop = Instantiate(scoopPrefabs[Random.Range(0, scoopPrefabs.Length)]);
            scoop.transform.position = GetRandomPosition();
            scoop.speed = GameController.instance.currentSpeed;
            scoop.isFalling = true;
        }
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-width, width), transform.position.y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width * 2, 0.5f));
    }
}
