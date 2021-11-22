using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(instantiateBullet());
    }

    IEnumerator instantiateBullet()
    {
        yield return new WaitForSeconds(1);
        ObjectPooler.Instance.SpawnForGameObject("particle", transform.position, Quaternion.identity);
        ObjectPooler.Instance.SpawnForGameObject("Bullet", transform.position, Quaternion.identity);
        StartCoroutine(instantiateBullet());
    }
}
