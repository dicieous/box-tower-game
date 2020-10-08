using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private float min_X = -2.2f, max_X = 2.2f;
    private bool Gameover;
    private bool ignoreCollision;
    private bool ignoretrigger;
    private Rigidbody2D MyBody;
    private float Move_Speed = 2f;
    private bool CanMove;

    void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        MyBody.gravityScale = 0f;
    }

    void Start()
    {
        CanMove = true;
        if(Random.Range(0,2) > 0)
        {
            Move_Speed *= -1f;
        }

        GameplayController.instance.currentbox = this;
    }

    void Update()
    {
        MoveBox();  
    }

    void MoveBox()
    {
        if(CanMove)
        {
            Vector3 temp = transform.position;
            temp.x += Move_Speed * Time.deltaTime;
            if(temp.x > max_X)
            {
                Move_Speed *= -1f;
            }
            else if(temp.x < min_X)
            {
              Move_Speed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropBox()
    {
        CanMove = false;
        MyBody.gravityScale = Random.Range(2, 4);
    }

    void Landed()
    {
        if (Gameover)
            return;

        ignoreCollision = true;
        ignoretrigger = true;

        GameplayController.instance.SpawnNewBox();
        GameplayController.instance.MoveCamera();
        
    }

    void RestartGame()
    {
        GameplayController.instance.RestartGame();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision)
            return;

        if(target.gameObject.tag == "Platform")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
            SoundMaager.instance.LandSound();
        }

        if (target.gameObject.tag == "Box")
        {
            Invoke("Landed", 1f);
            ignoreCollision = true;
            SoundMaager.instance.LandSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoretrigger)
            return;

        if(target.gameObject.tag == "Gameover")
        {
            CancelInvoke("Landed");
            Gameover = true;
            ignoretrigger = true;
            Invoke("RestartGame", 2f);
            SoundMaager.instance.GameoverSound();
        }
    }
}
