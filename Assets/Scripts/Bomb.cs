using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour 
{
    public int bombDmg;
    public float bombSpeed;

    private void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * bombSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<CarControll>().durability -= bombDmg;
            Destroy(this.gameObject);
        }
        else if (obj.gameObject.tag == "Shield")
        {
            Destroy(this.gameObject);
        }
        else if (obj.gameObject.tag == "EndOfRoad")
        {
            Destroy(this.gameObject);
        }
    }
}
