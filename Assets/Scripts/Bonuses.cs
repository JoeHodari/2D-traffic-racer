using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonuses : MonoBehaviour 
{
    [Header("Type of bonus")]
    public bool isDurability;
    public bool isShield;
    public bool isSpeed;

    [Header("Bonuses settings")]
    public float bonusSpeed = 5f;

    [Header("Durability settings")]
    public float repairPoints;

    [Header("Shield settings")]
    public GameObject shield;
    private GameObject _playerCar;
    private Vector3 _playerCarPosition;

    [Header("Speed settings")]
    public float speedBoost;
    public float duration;
    private bool _isActive = false;

    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * bonusSpeed * Time.deltaTime); //go down with road.
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player" || obj.gameObject.tag == "Shield")
        {
            if (isDurability == true)
            {
                obj.gameObject.GetComponent<CarControll>().durability += repairPoints;
                Destroy(this.gameObject);
            }
            else if (isShield == true)
            {
                _playerCar = GameObject.FindWithTag("Player");
                obj.gameObject.tag = "Shield";
                _playerCarPosition = _playerCar.transform.position;
                _playerCarPosition.z = -0.1f;
                GameObject shieldObj = (GameObject)Instantiate(shield, _playerCarPosition, Quaternion.identity);
                shieldObj.transform.parent = _playerCar.transform;
                Destroy(this.gameObject);
            }
            else if (isSpeed == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                _isActive = true;
                StartCoroutine("SpeedBoostActivated");
            }
            else if (obj.gameObject.tag == "EndOfRoad" && _isActive == false)
                Destroy(this.gameObject);
        }
    }

    IEnumerator SpeedBoostActivated()
    {
        while(duration > 0)
        {
            duration -= Time.deltaTime / speedBoost;
            Time.timeScale = speedBoost;
            yield return null;
        }

        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }
}
