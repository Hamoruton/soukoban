using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Text startText;
    [SerializeField] Text quitText;
    [SerializeField] GameObject TransitionImage;

    enum SELECTTEXT
    {
        START,
        QUIT,
    }
    SELECTTEXT selectStatus = SELECTTEXT.START;

    private float time;

    void Update()
    {
        TitleUIUpdate();

        Move();
    }

    void TitleUIUpdate()
    {
        switch (selectStatus)
        {
            case SELECTTEXT.START:
                startText.color = GetAlphaColor(startText.color);
                break;

            case SELECTTEXT.QUIT:
                quitText.color = GetAlphaColor(quitText.color);
                break;
        }
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 3.0f;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

    void Move()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)) && selectStatus == SELECTTEXT.START) 
        {
            TransitionImage.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Return) && selectStatus == SELECTTEXT.QUIT)
        {
            UnityEngine.Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && selectStatus == SELECTTEXT.QUIT)
        {
            selectStatus = SELECTTEXT.START;
            quitText.color = Color.white;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && selectStatus == SELECTTEXT.START)
        {
            selectStatus = SELECTTEXT.QUIT;
            startText.color = Color.white;
        }
    }
}
