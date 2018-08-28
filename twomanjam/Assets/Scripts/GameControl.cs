using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameControl : MonoBehaviour {

    private Player player;

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

        PlayerData data = new PlayerData();
        data.health = player.health;
        data.bladder = player.bladder;
        data.energy = player.energy;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData
{
    public Stats health;
    public Stats bladder;
    public Stats energy;
}
