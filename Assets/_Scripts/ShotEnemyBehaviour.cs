using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour
{
    private Vector3 direction;
    private void OnTriggerEnter2D(Collider2D other){

        if (other.CompareTag("Inimigos")) return;

        IDamageable damageble = other.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if(!(damageble is null)){
            damageble.TakeDamage();
        }
        Destroy (gameObject);
    }

    void Start(){
       
    } 

    private void Update(){
        Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
        Thrust(direction.x,direction.y);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
