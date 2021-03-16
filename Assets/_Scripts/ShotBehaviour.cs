using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehaviour : SteerableBehaviour
{

    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Player")) return;

        IDamageable damageble = other.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if(!(damageble is null)){
            damageble.TakeDamage();
        }
        Destroy (gameObject);
    }

    private void Update(){
        Thrust(1,0);
    }
}
