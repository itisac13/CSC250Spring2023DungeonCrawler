using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightController : MonoBehaviour
{
    private Player player;
    private Monster monster;
    public GameObject playerobj;
    public GameObject monsterobj;
    public Text stats;
    public Text attackCommentary;

    public AudioSource victoryMusic;
    public AudioSource defeatMusic;

    private bool yourTurn;
    private bool gameEnded;

    private bool playingMusic;


    private Vector3 playerOriginalPosition;
    private Vector3 monsterOriginalPosition;

    
    
    

    private string[] availableNames = { "Bob", "Howard", "Steve", "Donald", "Stewart" };

    

    // Start is called before the first frame update
    void Start()
    {
        this.playerOriginalPosition = this.playerobj.transform.position;
        this.monsterOriginalPosition = this.monsterobj.transform.position;

        this.playingMusic= false;
        this.yourTurn = true;
        this.gameEnded = false;
        this.player = MasterData.player;

        string monsterName = availableNames[Random.Range(0, availableNames.Length - 1)];
        this.monster = new Monster(monsterName);


        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (this.yourTurn)
        {
            this.monsterobj.transform.position = this.monsterOriginalPosition;
            // this.playerobj.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        }
        else
        {
            this.playerobj.transform.position = this.playerOriginalPosition;
            // this.monsterobj.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
        }
        if (this.player.getHitpoints() <= 0)
        {
            Renderer renderer = this.playerobj.GetComponent<Renderer>();
            
            renderer.enabled = false;
            this.attackCommentary.text = "YOU LOSE!!!! LOL!!!!\n\npress space to restart the game";
            // this.gameEnded = true;
            // Destroy(this.playerobj);

            // restart the game
            this.gameEnded = true;


            MasterData.player = new Player("PLAYER");
            MasterData.dungeon = new Dungeon(100, MasterData.player);
            MasterData.room = MasterData.player.getCurrentRoom();
            MasterData.lastExit = string.Empty;

            if (!this.playingMusic)
            {
                this.playingMusic = true;
                this.defeatMusic.Play();
            }
        }
        if (this.monster.getHitpoints() <= 0)
        {
            

            Renderer renderer = this.monsterobj.GetComponent<Renderer>();
            renderer.enabled = false;
            this.attackCommentary.text = "you win\n\nPress space to continue";
            this.gameEnded = true;
            // Destroy(this.monsterobj);
            if (!this.playingMusic)
            {
                this.playingMusic = true;
                this.victoryMusic.Play();
            }
            
        }
        this.stats.text = "";
        string playerStats = this.player.getData();
        this.stats.text += playerStats + "\n\n";

        string monsterStats = this.monster.getData();
        this.stats.text += monsterStats + "\n";

        


        
        
        if (!this.gameEnded) {
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
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("DungeonRoom");
            }
        }
        

    }


}
