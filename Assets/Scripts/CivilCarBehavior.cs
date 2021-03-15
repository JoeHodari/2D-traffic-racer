using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilCarBehavior : MonoBehaviour 
{
    public float civilCarSpeed;
    public int direction = -1;
    public float crashDamage = 25f;

    private Vector3 _civilCarPosition;

    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, direction, 0) * civilCarSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D obj) //only for Box Collider 2D with IS TRIGGER.
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<CarControll>().durability -= crashDamage;

            Debug.Log("Civil car colision");

            Destroy(this.gameObject);
        }

        else if (obj.gameObject.tag == "EndOfRoad")
            Destroy(this.gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<CarControll>().durability -= crashDamage / 5;
        }
    }
}
