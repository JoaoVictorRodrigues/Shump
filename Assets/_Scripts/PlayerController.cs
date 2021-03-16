using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  
    Animator animator;
    GameManager gm;

    private int lifes;
    public AudioClip shootSFX;

    public GameObject bullet;
    public Transform arma;

    public float shotDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    private void Start(){
        animator = GetComponent<Animator>();
        lifes = 2;
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        if(Time.time - _lastShootTimestamp < shotDelay) return;
        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma.position, Quaternion.identity);
       // throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        lifes--;
        if(lifes<=0){
            Die();
            gm.changeState(GameManager.GameState.END);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);

        if(yInput != 0 || xInput != 0){
            animator.SetFloat("Velocidade",1.0f);
        }else{
            animator.SetFloat("Velocidade",0.0f);
        }

        if (Input.GetAxisRaw("Jump")!= 0){
            Shoot();
        }
    }    

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Inimigos")){
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Pedra")){
            Destroy(other.gameObject);
        }
    }
    
}
