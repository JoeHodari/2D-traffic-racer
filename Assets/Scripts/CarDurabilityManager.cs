using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDurabilityManager : MonoBehaviour 
{
    public GameObject playerCarPrefab;
    public GameObject playerCarSpawnPlace;
    public TextMesh durabilityText;
    public int NrOfLifes;

    private GameObject _playerCar;

    private void Start()
    {
        _playerCar = (GameObject)Instantiate(playerCarPrefab, playerCarSpawnPlace.transform.position, Quaternion.identity); //Quaternion.identity - default prefab rotation.
    }

    private void Update()
    {
        if (_playerCar.GetComponent<CarControll>().durability <= 0)
        {
            Destroy(_playerCar);
            NrOfLifes--;

            if (NrOfLifes > 0)
                StartCoroutine("SpawnCar"); //Coroutines start independent on new thread, should be IEnumerator.
        }
        else if (_playerCar.GetComponent<CarControll>().durability > _playerCar.GetComponent<CarControll>().maxDurability)
            _playerCar.GetComponent<CarControll>().durability = _playerCar.GetComponent<CarControll>().maxDurability;
        //if current durability is higher than maxDurability,
        //set durability = 100 again.

        durabilityText.text = "Durability: " + _playerCar.GetComponent<CarControll>().durability + " / " + _playerCar.GetComponent<CarControll>().maxDurability;
    }

    IEnumerator SpawnCar() 
    {
        _playerCar = (GameObject)Instantiate(playerCarPrefab, playerCarSpawnPlace.transform.position, Quaternion.identity);
        _playerCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        _playerCar.GetComponent<BoxCollider2D>().isTrigger = true;
        _playerCar.tag = "Untouchable"; //it could be different tag, for example "empty" cause I didnt create it on inspector.

        yield return new WaitForSeconds(4); //Coroutine exist only for 3 seconds, so car is dead proof for a while. (unity documentation ;)))
        _playerCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        _playerCar.GetComponent<BoxCollider2D>().isTrigger = false;
        _playerCar.tag = "Player";
    }
}
