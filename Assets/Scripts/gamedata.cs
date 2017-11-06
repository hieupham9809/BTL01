using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gamedata : MonoBehaviour {
    string file_name = "savedGamea.gd";
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //Ghi file điểm
    public void write_socer(int best_score)
    {
        //ArrayList arraySocer = new ArrayList();
        //player_socers ps = new player_socers();
        //ps.best_socers = best_score;
        //arraySocer.Add(ps);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/" + file_name);
        //bf.Serialize(file, arraySocer);
        //file.Close();
    }

    //đọc file điểm
    public player_data read_data()
    {
        ArrayList ps = new ArrayList();
        if (File.Exists(Application.persistentDataPath + "/" + file_name))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + file_name, FileMode.Open);
            ps = (ArrayList)bf.Deserialize(file);
            file.Close();
            return (player_data)ps[0];
        }
        else
        {
            return new player_data();
        }
    }
}
