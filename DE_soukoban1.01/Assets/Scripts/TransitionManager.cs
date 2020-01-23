using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SCENE
{
    GAME01,
    GAME02,
    GAME03,
    GAME04,
    GAME05,
    GAME06,
    GAME07,
    GAME08,
    GAME09,
    GAME10,
    GAME11,
    GAME12,
    SELECT
};

public class TransitionManager : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    [SerializeField] Sprite goldCrown;
    [SerializeField] Sprite silverCrown;

    [SerializeField] GameObject[] crownImage;

    public static SCENE scene = SCENE.GAME02;

    private void Start()
    {
        Score();

        CrownImage();
    }

    private void Update()
    {
        Move();

        //Score();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextStage();
        }
    }

   public void NextStage()
    {
        switch (scene)
        {
            case SCENE.GAME01:
                SceneManager.LoadScene("GAME01");
                scene = SCENE.GAME02;
                break;

            case SCENE.GAME02:
                SceneManager.LoadScene("GAME02");
                scene = SCENE.GAME03;
                break;

            case SCENE.GAME03:
                SceneManager.LoadScene("GAME03");
                scene = SCENE.GAME04;
                break;

            case SCENE.GAME04:
                SceneManager.LoadScene("GAME04");
                scene = SCENE.GAME05;
                break;

            case SCENE.GAME05:
                SceneManager.LoadScene("GAME05");
                scene = SCENE.GAME06;
                break;

            case SCENE.GAME06:
                SceneManager.LoadScene("GAME06");
                scene = SCENE.GAME07;
                break;

            case SCENE.GAME07:
                SceneManager.LoadScene("GAME07");
                scene = SCENE.GAME08;
                break;

            case SCENE.GAME08:
                SceneManager.LoadScene("GAME08");
                scene = SCENE.GAME09;
                break;

            case SCENE.GAME09:
                SceneManager.LoadScene("GAME09");
                scene = SCENE.GAME10;
                break;

            case SCENE.GAME10:
                SceneManager.LoadScene("GAME10");
                scene = SCENE.GAME11;
                break;

            case SCENE.GAME11:
                SceneManager.LoadScene("GAME11");
                scene = SCENE.GAME12;
                break;

            case SCENE.GAME12:
                SceneManager.LoadScene("GAME12");
                scene = SCENE.SELECT;
                break;

            case SCENE.SELECT:
                SceneManager.LoadScene("Select");
                break;
        }
    }

    public void ReturnStage()
    {
        switch (scene-1)
        {
            case SCENE.GAME01:
                SceneManager.LoadScene("GAME01");
                scene = SCENE.GAME02;
                break;

            case SCENE.GAME02:
                SceneManager.LoadScene("GAME02");
                scene = SCENE.GAME03;
                break;

            case SCENE.GAME03:
                SceneManager.LoadScene("GAME03");
                scene = SCENE.GAME04;
                break;

            case SCENE.GAME04:
                SceneManager.LoadScene("GAME04");
                scene = SCENE.GAME05;
                break;

            case SCENE.GAME05:
                SceneManager.LoadScene("GAME05");
                scene = SCENE.GAME06;
                break;

            case SCENE.GAME06:
                SceneManager.LoadScene("GAME06");
                scene = SCENE.GAME07;
                break;

            case SCENE.GAME07:
                SceneManager.LoadScene("GAME07");
                scene = SCENE.GAME08;
                break;

            case SCENE.GAME08:
                SceneManager.LoadScene("GAME08");
                scene = SCENE.GAME09;
                break;

            case SCENE.GAME09:
                SceneManager.LoadScene("GAME09");
                scene = SCENE.GAME10;
                break;

            case SCENE.GAME10:
                SceneManager.LoadScene("GAME10");
                scene = SCENE.GAME11;
                break;

            case SCENE.GAME11:
                SceneManager.LoadScene("GAME11");
                scene = SCENE.GAME12;
                break;

            case SCENE.GAME12:
                SceneManager.LoadScene("GAME12");
                scene = SCENE.SELECT;
                break;

            case SCENE.SELECT:
                SceneManager.LoadScene("Select");
                break;
        }
    }

    public void SceneSelect()
    {
        SceneManager.LoadScene("Select");
    }

    private void CrownImage()
    {
        for (int i = 0; i < 12; i++)
        {
            if ((int)TransitionManager.scene - 1 == i)
            {
                if (GameUIManager.limitCount[i] > GameUIManager.moveCount)
                {
                    crownImage[0].GetComponent<Image>().sprite = goldCrown;
                    crownImage[1].GetComponent<Image>().sprite = goldCrown;
                }
                else
                {
                    crownImage[0].GetComponent<Image>().sprite = silverCrown;
                    crownImage[1].GetComponent<Image>().sprite = silverCrown;
                }
            }
        }
    }

    private void Score()
    {
        for (int i = 0; i < GameUIManager.limitCount.Length; i++)
        {
            if ((int)TransitionManager.scene - 1 == i)
            {
                ScoreText.text = GameUIManager.moveCount.ToString("0") + ("/") + GameUIManager.limitCount[i].ToString("0");
            }
        }
    }
}
