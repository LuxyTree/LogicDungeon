using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelCollisionDetection : MonoBehaviour
{
    public WeaponController wc;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dirt" && wc.IsAttacking == true)
        {
            Debug.Log(other.name);
            Destroy(other.gameObject);
        }
    }
}
