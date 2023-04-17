using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit;
    public float movementSpeed;

    public Dungeon dungeon = MasterData.dungeon;
    public Player player = MasterData.player;
    public Room currentRoom;

    private bool moving = false;
    private bool start;

    private bool northOn = false;
    private bool southOn = false;
    private bool eastOn = false;
    private bool westOn = false;

    private bool fightScene;

    Vector3 center = new Vector3(0.0f, 0.5f, 0.0f);

    private void DetermineExits()
    {
        this.northExit.SetActive(false);
        this.southExit.SetActive(false);
        this.eastExit.SetActive(false);
        this.westExit.SetActive(false);


        string directions = this.currentRoom.getExitsString().ToLower();
        if (directions.Contains("north"))
        { this.northOn = true; this.northExit.SetActive(true); }    
            
        if (directions.Contains("south"))
        { this.southOn = true; this.southExit.SetActive(true); }
            
        if (directions.Contains("east"))
        { this.eastOn = true; this.eastExit.SetActive(true); }    
            
        if (directions.Contains("west"))
        { this.westOn = true; this.westExit.SetActive(true); }
            

        /*
        Exit[] exits = this.currentRoom.getExits();
        print(exits[0].getDirection());
        foreach (Exit exit in exits)
        {
            string direction = exit.getDirection().ToLower();
            if (direction.Equals("north"))
                this.northExit.SetActive(true);
            if (direction.Equals("south"))
                this.southExit.SetActive(true);
            if (direction.Equals("east"))
                this.eastExit.SetActive(true);
            if (direction.Equals("west"))
                this.westExit.SetActive(true);
        }
        */


    }

    // Start is called before the first frame update
    void Start()
    {
        this.fightScene = false;
        int diceRoll = Random.Range(0, 100);
        if (diceRoll < 33)
        {
            print("Fight scene");
            this.fightScene = true;
        }
        // print(Random.Range(1, 4));
        this.movementSpeed = 80.0f;
        this.rb = this.GetComponent<Rigidbody>();
        this.currentRoom = MasterData.player.getCurrentRoom();
        this.DetermineExits();

        // print(this.player.getCurrentRoom().getName());
        // print(this.currentRoom.getExitsString());
        this.start = true; // set it in start mode
        // this.rb = this.GetComponent<Rigidbody>();

        // move it to the opposite exit of the last exist, then begin rolling it
        if (MasterData.lastExit == "North")
        {
            this.rb.transform.position = new Vector3(this.southExit.transform.position.x, 0.5f, this.southExit.transform.position.z + 1.0f);
            this.rb.AddForce(this.northExit.transform.position * movementSpeed);
        }
        else if (MasterData.lastExit == "South")
        {
            this.rb.transform.position = new Vector3(this.northExit.transform.position.x, 0.5f, this.northExit.transform.position.z - 1.0f);
            this.rb.AddForce(this.southExit.transform.position * movementSpeed);
        }
        else if (MasterData.lastExit == "East")
        {
            this.rb.transform.position = new Vector3(this.westExit.transform.position.x + 1, 0.5f, this.westExit.transform.position.z);
            this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
        }
        else if (MasterData.lastExit == "West")
        {
            this.rb.transform.position = new Vector3(this.eastExit.transform.position.x - 1, 0.5f, this.eastExit.transform.position.z);
            this.rb.AddForce(this.westExit.transform.position * movementSpeed);
        }

    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.start)
        {
            if (Vector3.Distance(this.rb.transform.position, center) <= 0.1f)
            {
                // stop the object when it reaches the center
                this.rb.velocity = Vector3.zero;
                this.rb.angularVelocity = Vector3.zero;
                this.start = false;
            }

        }
        else if (!this.moving)
        {
            
            

            if (Input.GetKeyDown(KeyCode.UpArrow) && this.northOn)
            {
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                this.moving = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && this.southOn)
            {
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                this.moving = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && this.eastOn)
            {
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                this.moving = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && this.westOn)
            {
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                this.moving = true;
            }
        }
        

    }
    void OnTriggerEnter(Collider other)
    {
        if (this.fightScene)
        {
            if (other.transform.parent.name == "Exit")
            {
                SceneManager.LoadScene("FightScene");
                MasterData.lastExit = other.gameObject.name.ToString();
                this.currentRoom.takeExit(this.player, MasterData.lastExit);
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        // This is called when the collider enters another collider marked as a trigger
        if (other.transform.parent.name == "Exit")
        {
            
            MasterData.lastExit = other.gameObject.name.ToString();
            this.currentRoom.takeExit(this.player, MasterData.lastExit);
            // print("New room:" + this.player.getCurrentRoom().getName());
            // print(MasterData.room.test);
            SceneManager.LoadScene("DungeonRoom");
        }
    }
    
}