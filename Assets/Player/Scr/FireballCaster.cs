using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public float damage = 10;
    public Fireball fireballPrefab;
    public Transform fireballSourgeTransform;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(fireballPrefab, fireballSourgeTransform.position, fireballSourgeTransform.rotation);
            fireball.damage = damage;
        }
    }
}
