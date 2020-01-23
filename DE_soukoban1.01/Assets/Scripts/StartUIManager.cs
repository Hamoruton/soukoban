using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] StarEffectManager starEffect;
    GameManager gameManager;
    Vector2 pos;

    private float Time = 0;
    public bool gameStart = false;
    private bool move = false;
    private bool starEffectFlag = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pos = new Vector2(-1600, 0);
    }

    void Update()
    {
        pos.x += 20;
        transform.localPosition = pos;

        if ((transform.localPosition.x > 0) && (!move)) 
        {
            if (!starEffectFlag)
            {
                Instantiate(starEffect, new Vector2(0, 0), Quaternion.identity);
                starEffectFlag = true;
            }

            transform.localPosition = new Vector2(0, 0);
            Time++;
            if (Time > 120)
            {
                move = true;
                pos = new Vector2(0, 0);
            }
        }

        if (transform.localPosition.x > 1600) 
        {
            gameManager.gameStart = true;
            Destroy(gameObject);
        }
    }
}
