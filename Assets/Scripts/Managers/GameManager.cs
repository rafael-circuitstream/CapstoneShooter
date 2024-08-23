using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneAsset[] scenesList;

    public GameObject playerPrefab;
    public GameObject player;
    public static GameManager Singleton
    {
        get; private set;
    }



    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < scenesList.Length)
        {
            SceneManager.LoadScene(scenesList[sceneIndex].name);
        }


    }

    public void AssignPlayerToController(PlayerData playerData)
    {
        player = Instantiate(playerPrefab);
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.AssignPlayerData(playerData);
    }


    
}
