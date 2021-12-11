

public class PlayerDetails
{
    public string username;
    public string shape;
    public string pos;
    public string dateTimeCreated;
    public string uID;

    public PlayerDetails()
    {
        username = "";
        shape = "";
        pos = "";
        dateTimeCreated = "";
        uID = "";
    }

    public PlayerDetails(string username, string shape, string pos, string dateTimeCreated, string uID)
    {
        this.username = username;
        this.shape = shape;
        this.pos = pos;
        this.dateTimeCreated = dateTimeCreated;
        this.uID = uID;
    }

    public PlayerDetails(PlayerDetails player)
    {
        username = player.username;
        shape = player.shape;
        pos = player.pos;
        dateTimeCreated = player.dateTimeCreated;
        uID = player.uID;
    }

}
