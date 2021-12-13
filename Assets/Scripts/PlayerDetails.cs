using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerDetails
{
    public string username;
    public string shape;
    public Vector2 pos;
    public string dateTimeCreated;
    public string uID;
    //public string score;

    public PlayerDetails(string username, string shape, Vector2 pos)
    {
        this.username = username;
        this.shape = shape;
        this.pos = pos;
        DateTime time = DateTime.Now;
        dateTimeCreated = time.ToString();

        Guid guid = Guid.NewGuid();
        string id = guid.ToString();
        uID = id;
       
        //this.score = score;
    }

    public PlayerDetails(PlayerDetails player)
    {
        username = player.username;
        shape = player.shape;
        pos = player.pos;
        dateTimeCreated = player.dateTimeCreated;
        uID = player.uID;
        //score = player.score;
    }

}
