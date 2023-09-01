using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public BossHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        var maxHealth = this.GetComponent<Enemy>().Maxhealth;
        var health = this.GetComponent<Enemy>().health;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        var health = this.GetComponent<Enemy>().health;
        healthBar.SetHealth(health);
    }

}
