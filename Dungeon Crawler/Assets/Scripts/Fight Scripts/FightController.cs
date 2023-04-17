using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightController : MonoBehaviour
{
    public int hitpoints;
    public int armorClass;
    public int attackStrength;
    public Text stats;

    // Start is called before the first frame update
    void Start()
    {
        this.hitpoints = Random.Range(10, 20);
        this.armorClass = Random.Range(10, 17);
        this.attackStrength = Random.Range(1, 6);

        string statsString = "\n\nStats for " + gameObject.name + ":\nHitpoints: " + this.hitpoints.ToString() + "\nArmor Class: " + this.armorClass.ToString() + "\nDamage: " + this.attackStrength.ToString();
        stats.text += statsString;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("DungeonRoom");
        }

    }


}
