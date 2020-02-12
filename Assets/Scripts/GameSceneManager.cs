using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    #region Singleton
    public static GameSceneManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("many gamemanagers");
            return;
        }

        instance = this;
    }
    #endregion

    String playerTeam = "Orange", enemyTeam = "Blue";
    Blob[] blobs;
    List<Blob> playerBlobs, enemyBlobs;
    Blob currentBlob;
    void Start()
    {
        playerBlobs = new List<Blob>();
        enemyBlobs = new List<Blob>();
        blobs = GameObject.FindObjectsOfType<Blob>();
        foreach (Blob blob in blobs)
        {
            if(blob.tag.ToString() == playerTeam){
                playerBlobs.Add(blob);
            }else{
                enemyBlobs.Add(blob);
            }
        }
        int rand = UnityEngine.Random.Range(0, playerBlobs.Count);
        currentBlob = playerBlobs[rand];
        currentBlob.setPlayerControl();
        CameraController.instance.setTransform(currentBlob.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeBlob();
        }

    }

    void ChangeBlob()
    {
        currentBlob.ResetPlayerControl();
        int rand = UnityEngine.Random.Range(0, playerBlobs.Count);
        currentBlob = playerBlobs[rand];
        currentBlob.setPlayerControl();
        CameraController.instance.setTransform(currentBlob.transform);
    }

    public Blob getCurrentBlob()
    {
        return currentBlob;
    }
}
