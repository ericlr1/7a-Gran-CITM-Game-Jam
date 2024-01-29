using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
   static PlayerManager _instance;
   public static PlayerManager Instance
    {
        get
        {
            if(_instance == null) _instance = new PlayerManager();
            return _instance;
        }
    }

    public Player Player;

    PlayerManager() { }


}
