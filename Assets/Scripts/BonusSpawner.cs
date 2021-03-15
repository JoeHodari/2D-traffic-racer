using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour 
{
    public GameObject[] bonuses;
    public int minDelay;
    public int maxDelay;

    private float _delay;

    private void Start()
    {
        _delay = Random.Range(minDelay, maxDelay);
    }

    private void Update()
    {
        _delay -= Time.deltaTime;

        if (_delay <= 0)
        {
            _delay = Random.Range(minDelay, maxDelay);
            spawnBonus();
        }
    }

    void spawnBonus()
    {
        Instantiate(bonuses[(int)Random.Range(0, 3)], new Vector3(Random.Range(-2.4f, 2.4f), 6f, 0), Quaternion.identity);
    }
}
