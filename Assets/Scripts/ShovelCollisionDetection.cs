using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelCollisionDetection : MonoBehaviour
{
    public WeaponController wc;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dirt" && wc.IsAttacking == true)
        {
            Destroy(collision.gameObject);
            //Destroy(gameObject);
            Debug.Log("Detected Collision");
        }
    }
}
