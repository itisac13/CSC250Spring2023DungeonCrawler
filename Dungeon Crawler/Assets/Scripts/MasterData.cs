using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterData
{
    // public static GameObject? lastExit = null;
    public static int count = 0;
    public static string lastExit = string.Empty;

    
    public static Player player = new Player("Bob");
    public static Dungeon dungeon = new Dungeon(100, player);
    public static Room room = player.getCurrentRoom();
    // MasterData.dungeon.populateCSDepartment();

}
