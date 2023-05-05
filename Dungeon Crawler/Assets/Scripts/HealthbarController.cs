using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    public Text healthBar;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = MasterData.player;
        this.healthBar.color = Color.red;

        // increase player hitpoints when they enter a new room
        int extraHitoints = 5;
        this.player.heal(extraHitoints);
        

    }

    // Update is called once per frame
    void Update()
    {
        int currentHealth = this.player.getHitpoints();
        int healthPercent = Mathf.CeilToInt((float)currentHealth / (float)this.player.getMaxHitpoints() * 100f);
        int healthSquares = Mathf.CeilToInt((float)healthPercent / 10f);

        this.healthBar.text = "Hitpoints: ";

        // Loop through the health bar squares and activate/deactivate them based on the current health
        for (int i = 0; i < healthSquares; i++)
        {
            this.healthBar.text += "[]";
        }
    }
}
