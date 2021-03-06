﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class NetworkController : MonoBehaviour {

	public int connectionPort = 25001;
    private const string GameNameString = "nybblestudiosnextgame";
    public string GameRoomInstanceName = "buddha";
	public Text networkText;

	
	public Object ShipPrefab;
	public Object TankPrefab;
	
	private bool loadplayer = false;
    private bool clientConnect = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(clientConnect)
        {
            try
            {
                List<HostData> hostdata = new List<HostData>(MasterServer.PollHostList());
                if(hostdata.Count > 0)
                {
                    Network.Connect(hostdata[0]);//MASTER
                    clientConnect = false;
                    loadplayer = true;
                    //Network.Instantiate(TankPrefab, transform.position, transform.rotation, 0);
                }
            }
            catch (UnityException e) { }
        }

		if (Network.peerType == NetworkPeerType.Disconnected)
		{
			/* NetworkPeerType is an enumeration with the following values: Disconnected, 
			Connecting, Client, Server. This first statement checks our Network class variable 
			peerType (which is of type NetworkPeerType) to see if we have the Disconnected value. 
			Since we haven’t initialized or connected to any server, Unity automatically assigned 
			peerType to Disconnected. Then we just have a label that states we are disconnected. */
			networkText.text = "Status: Disconnected";
		}
		else if (Network.peerType == NetworkPeerType.Client)
		{
			networkText.text = "Status: Connected as Client";
            if (loadplayer)
			{
				Debug.Log("Spawning Player...");
				Network.Instantiate(TankPrefab, transform.position, transform.rotation, 0);
                loadplayer = false;
                this.gameObject.SetActive(false);
			}
		}
		else if (Network.peerType == NetworkPeerType.Server)
		{
			networkText.text = "Status: Connected as Server";
		}
	}
	
	public void onButtonClickClient()
	{
		/* This creates the button to connect to a server as a client. There are several overloaded 
		options for the Connect function, but we are just sending it an IP address in the form of a 
		string and the port number as an int. You can also use a domain name in place of the IP address. 
		We haven’t started a server yet, so if we clicked the button now, it would try to connect at the 
		IP address (which would just be whatever computer you are on) at port 25001. Nothing is active 
		yet so it wouldn’t connect to anything so nothing would happen. */
        //Network.Connect(connectionIP, connectionPort);//NON-MASTER
        MasterServer.RequestHostList(GameNameString);//MASTER
        clientConnect = true;
	}
	
	public void onButtonClickDisconectFromServer()
	{
		if (Network.peerType == NetworkPeerType.Client)
		{
			networkText.text = "disconected";
			//Network.Disconnect(200);
            MasterServer.UnregisterHost();
		}
	}
	
	public void onButtonClickServer()
	{
		/* The InitializeServer function in the Network class starts a server on your computer using 
		the connectionPort as the second parameter. The first parameter is the maximum number of 
		connections, or players, you allow to your server. The final parameter is for NAT (Network Address Translation). 
		We’ll ignore it for now, just set it to false. */
		Network.InitializeServer(32, connectionPort, false);
        MasterServer.RegisterHost(GameNameString, GameRoomInstanceName, "Host");//MASTER
		Network.Instantiate(ShipPrefab, transform.position, transform.rotation, 0);
        this.gameObject.SetActive(false);
	}
	
	[RPC]
	private void SpawnPlayer()
	{
		Network.Instantiate(TankPrefab, transform.position, transform.rotation, 0);
		Debug.Log("Ship Instantiated");	
	}
	
}
