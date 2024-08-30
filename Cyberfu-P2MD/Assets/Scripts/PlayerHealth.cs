using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxPlayerHealth = 10;
    public int currentPlayerHealth;
    public int enemyDamage = 2;
   
    public PlayerExplosionParticles particles;

    private Animator playerAnimator;

    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        playerAnimator = GetComponent<Animator>();
        particles = GetComponent<PlayerExplosionParticles>();
    }

    public void HurtPlayer(){
        currentPlayerHealth -= enemyDamage;
        playerAnimator.SetTrigger("Hit");

        if (currentPlayerHealth <= 0){
            particles.Explode();
            Invoke("ReloadScreen", 5);
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("HitCollider")){
            HurtPlayer();
        }
    }

    private void ReloadScreen(){
        SceneManager.LoadScene("Cyberfu");
    }
    
}
