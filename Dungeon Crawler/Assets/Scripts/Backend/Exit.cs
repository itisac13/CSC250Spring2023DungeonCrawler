public class Exit
{
    private string direction;
    private Room destinationRoom;

    public Exit(string direction, Room destinationRoom)
    {
        this.direction = direction;
        this.destinationRoom = destinationRoom;
    }


    public void addPlayer(Player p)
    {
        this.destinationRoom.addPlayer(p);
        p.setCurrentRoom(this.destinationRoom);
    }

    public string getDirection()
    {
        return this.direction;
    }
}