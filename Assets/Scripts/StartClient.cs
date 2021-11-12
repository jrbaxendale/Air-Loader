using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class StartClient : MonoBehaviour
{
    public GameObject NetworkManager;
    public GameObject Prefab;
    public Vector3 vec;


    public void StarttheClient()
    {
        vec = new Vector3(0, 0, 0);

        NetworkManager.GetComponent<NetworkingManager>().StartClient();
        //NetworkingManager.Singleton.StartServer();
        
        Debug.Log("Started a Client");
        GameObject go = Instantiate(Prefab, vec, Quaternion.identity);
        go.GetComponent<NetworkedObject>().Spawn();
        Debug.Log("Spawned a player");


    }

public void OnConnectedToServer()
  
    {
        GameObject go = Instantiate(Prefab, vec, Quaternion.identity);
        go.GetComponent<NetworkedObject>().Spawn();
        Debug.Log("Spawned a player");


        Debug.Log("CONNECTED CONNECTED CONNECTED CONNECTED CONNECTED CONNECTED CONNECTED........");



    }





}
