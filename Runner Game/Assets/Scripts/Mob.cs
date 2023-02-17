using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            TakeDamage(10);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            if (currentHealth < maxHealth) AddHealth(10);
        }
    }

    void TakeDamage(int damage){
        if (currentHealth - damage < 0){
            currentHealth = 0;
            return;
        }
        else{
            currentHealth -= damage;
        }
        healthBar.SetHealth(currentHealth);
    }

    void AddHealth(int health){
        if (currentHealth + health > maxHealth){
            currentHealth = maxHealth;
        }
        else{
            currentHealth += health;
        }
        healthBar.SetHealth(currentHealth);
    }
}
