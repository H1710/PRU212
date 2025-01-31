using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthMan;
    public Slider healthBar;
    public Text hpText;

    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    
    void Update()
    {
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        hpText.text = "HP: " + healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
