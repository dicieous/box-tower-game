using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public BoxScript currentbox;

    public BoxSpawner box_spawner;

    public BoxFollow CameraScript;
    private int MoveCount;

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
   
    void Start()
    {
        box_spawner.SpawnBox();
    }

    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentbox.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NewBox", 1f);
    }

    void NewBox()
    {
        box_spawner.SpawnBox();
    }

    public void MoveCamera()
    {
        MoveCount++;
        if(MoveCount == 3)
        {
            MoveCount = 0;
            CameraScript.targetpos.y += 2f;
        }
        

    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
