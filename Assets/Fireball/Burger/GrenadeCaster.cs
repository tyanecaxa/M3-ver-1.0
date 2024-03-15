using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourceTransform;

    public float force = 10;

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(GrenadePrefab);
            grenade.transform.position = GrenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourceTransform.forward * force);
        }
    }
}
