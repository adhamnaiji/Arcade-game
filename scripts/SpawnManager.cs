using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private float spawnrange = 9.0f;
    public int enemycount;
    public int wavenumber=1;

    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnenemywaves(wavenumber);
        Instantiate(powerupPrefab, generatespawnmanager(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemycount = FindObjectsOfType<Enemy>().Length;
        if (enemycount == 0)
        {
            wavenumber++;
            spawnenemywaves(wavenumber);
            Instantiate(powerupPrefab, generatespawnmanager(), powerupPrefab.transform.rotation);

        }

    }
    void spawnenemywaves(int enemynumber)
    {
        for (int i = 0; i < enemynumber; i = i + 1)
        {
            Instantiate(enemy, generatespawnmanager(), enemy.transform.rotation);
        }
    }

    private Vector3 generatespawnmanager()
    {
        float spawnx = Random.Range(-spawnrange, spawnrange);
        float spawnz = Random.Range(-spawnrange, spawnrange);
        Vector3 randompos = new Vector3(spawnx, 0, spawnz);
        return randompos;
    }
}
