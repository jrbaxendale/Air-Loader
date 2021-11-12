using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using UnityEngine.Networking;


public class StartServer : MonoBehaviour
{
    public GameObject NetworkManager;

   


    public void StarttheServer()
    {

        NetworkManager.GetComponent<NetworkingManager>().StartHost();


        Debug.Log("Started a host");
            

    }






}

