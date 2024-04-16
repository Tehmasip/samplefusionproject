using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.SceneManagement;

public class Spawner : SimulationBehaviour, INetworkRunnerCallbacks
{
    public NetworkPlayer playerPrefab;
    public Transform SpawnPoint;

    // Mapping between Token ID and Re-created Players
    Dictionary<int, NetworkPlayer> mapTokenIDWithNetworkPlayer;

    //List of bots
    List<NetworkPlayer> botList = new List<NetworkPlayer>();

    bool isBotsSpawned = false;

    //Other compoents
   // CharacterInputHandler characterInputHandler;
   // SessionListUIHandler sessionListUIHandler;

    void Awake()
    {
        //Create a new Dictionary
        mapTokenIDWithNetworkPlayer = new Dictionary<int, NetworkPlayer>();

        //sessionListUIHandler = FindObjectOfType<SessionListUIHandler>(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnBots()
    {
        if (isBotsSpawned)
            return;

        int numberOfBotsToSpawn = 10;

        Debug.Log($"Number of bots to spawn {numberOfBotsToSpawn}. Bot spawned count {botList.Count}. Player count {Runner.SessionInfo.PlayerCount}");

        for (int i = 0; i < numberOfBotsToSpawn; i++)
        {
            NetworkPlayer spawnedAIPlayer = Runner.Spawn(playerPrefab, SpawnPoint.transform.position, Quaternion.identity, null, InitializeBotBeforeSpawn);

            botList.Add(spawnedAIPlayer);
        }

        isBotsSpawned = true;
    }

    void InitializeBotBeforeSpawn(NetworkRunner runner, NetworkObject networkObject)
    {
    }


    

    public void SetConnectionTokenMapping(int token, NetworkPlayer networkPlayer)
    {
        mapTokenIDWithNetworkPlayer.Add(token, networkPlayer);
    }

    IEnumerator CallSpawnedCO()
    {
        yield return new WaitForSeconds(0.5f);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
       // if(runner.IsServer)
        {
            runner.Spawn(playerPrefab, SpawnPoint.transform.position, Quaternion.identity, player);
        }
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
     
    }

    public void OnConnectedToServer(NetworkRunner runner) { Debug.Log("OnConnectedToServer"); }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) { Debug.Log("OnShutdown"); }
    public void OnDisconnectedFromServer(NetworkRunner runner) { Debug.Log("OnDisconnectedFromServer"); }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { Debug.Log("OnConnectRequest"); }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { Debug.Log("OnConnectFailed"); }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) 
    {
     
    }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) 
    {
       // if (SceneManager.GetActiveScene().name != "Ready" && runner.IsServer)
       //     SpawnBots();

    }
    public void OnSceneLoadStart(NetworkRunner runner) { }


    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        throw new NotImplementedException();
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {
        throw new NotImplementedException();
    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {
        throw new NotImplementedException();
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        throw new NotImplementedException();
    }
}
