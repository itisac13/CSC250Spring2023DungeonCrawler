using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject northExit, southExit, eastExit, westExit;
    public bool northOn, southOn, eastOn, westOn;

    // Start is called before the first frame update
    void Start()
    {
        //hw answer should be in here!
        this.northExit.SetActive(this.northOn); 
        this.southExit.SetActive(this.southOn); 
        this.eastExit.SetActive(this.eastOn); 
        this.westExit.SetActive(this.westOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
