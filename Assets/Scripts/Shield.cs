using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour 
{
    public float shieldDuration;

    private void Update()
    {
        shieldDuration -= Time.deltaTime;

        if (shieldDuration <= 0)
        {
            this.gameObject.transform.parent.tag = "Player";
            Destroy(this.gameObject);
        }
    }
}
