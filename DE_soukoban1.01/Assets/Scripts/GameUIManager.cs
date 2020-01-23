using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] Text moveCountText;
    [SerializeField] Text limitCountText;

    public static int moveCount = 0;
    public static int[] limitCount = new int[12] { 50, 45, 60, 70, 20, 130, 75, 50, 130, 35, 70, 115 };

    void Start()
    {
        moveCount = 0;
        moveCountText.text = moveCount.ToString("0");
        for (int i = 0; i < limitCount.Length; i++)
        {
            if ((int)TransitionManager.scene - 1 == i)
                limitCountText.text = limitCount[i].ToString("0");
        }
    }

    void Update()
    {
        moveCountText.text = moveCount.ToString("0");
    }
}
