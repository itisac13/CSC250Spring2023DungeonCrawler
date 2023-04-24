using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightController : MonoBehaviour
{
    private Player player;
    private Monster monster;
    public Text stats;
    public Text attackCommentary;

    private bool yourTurn;
    private bool gameEnded;
    

    private string[] availableNames = { "Bob", "Howard", "Steve", "Donald", "Stewart" };

    

    // Start is called before the first frame update
    void Start()
    {
        this.yourTurn = true;
        this.gameEnded = false;
        this.player = MasterData.player;

        string monsterName = availableNames[Random.Range(0, availableNames.Length - 1)];
        this.monster = new Monster(monsterName);


        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("DungeonRoom");
        }
        if (this.player.getHitpoints() <= 0)
        {
            this.attackCommentary.text = "YOU LOSE!!!! LOL!!!!\n\npress space to exit";
            this.gameEnded = true;

            // restart the game
            MasterData.player = new Player("PLAYER");
            MasterData.dungeon = new Dungeon(100, MasterData.player);
            MasterData.room = MasterData.player.getCurrentRoom();
            MasterData.lastExit = string.Empty;
        }
        if (this.monster.getHitpoints() <= 0)
        {
            this.attackCommentary.text = "you win\n\nPress space to exit";
            this.gameEnded = true;
        }
        this.stats.text = "";
        string playerStats = this.player.getData();
        this.stats.text += playerStats + "\n\n";

        string monsterStats = this.monster.getData();
        this.stats.text += monsterStats + "\n";

        if (this.gameEnded)
        {
            
            return;
        }


        
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (this.yourTurn)
            {
                this.yourTurn = false;
                bool result = Fight.Attack(this.player, this.monster);
                
                
            }
            
        }
        if (!this.yourTurn)
        {
            this.yourTurn = true;
            bool result = Fight.Attack(this.monster, this.player);
            
        }

    }


}
