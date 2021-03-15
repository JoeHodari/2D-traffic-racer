using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilCarSpawner : MonoBehaviour 
{
    public float carSpawnDelay = 2f;
    public GameObject civilCar;

    private float _spawnDelay;
    private float[] _placesOnRoad;

    private void Start()
    {
        _placesOnRoad = new float[4] { -2.11f, -0.76f, 0.76f, 2.11f };
        _spawnDelay = carSpawnDelay;
    }

    private void Update()
    {
        _spawnDelay -= Time.deltaTime;

        if (_spawnDelay <= 0)
        {
            spawnCar();

            _spawnDelay = carSpawnDelay;
        }
    }

    void spawnCar()
    {
        int place = Random.Range(0, 4);

        if (place == 0 || place == 1)
        {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(_placesOnRoad[place], 6, 0), Quaternion.Euler(new Vector3(0, 0, 180)));

            car.GetComponent<CivilCarBehavior>().direction = 1; //GetComponent can get also other scripts.
            car.GetComponent<CivilCarBehavior>().civilCarSpeed = 12;
        }

        if (place == 2 || place == 3)
            Instantiate(civilCar, new Vector3(_placesOnRoad[place], 6, 0), Quaternion.identity);
    }
}
