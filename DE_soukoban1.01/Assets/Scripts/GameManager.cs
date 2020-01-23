using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum DIRECTION
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class GameManager : MonoBehaviour
{
    [SerializeField] StageManager stageManager;
    PlayerManager playerManager;
    [SerializeField]
    public GameObject TransitionImage;

    //SE
    [SerializeField] AudioClip SEMove;
    AudioSource audioSource;

    public bool gameStart = false;
    private bool isClear = false;

    void Start()
    {
        stageManager.LoadTileData();
        stageManager.CreateStage();

        playerManager = stageManager.playerManager;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isClear)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Debug.Log("up");
            MoveTo(DIRECTION.UP);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Debug.Log("down");
            MoveTo(DIRECTION.DOWN);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("left");
            MoveTo(DIRECTION.LEFT);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log("right");
            MoveTo(DIRECTION.RIGHT);
        }else if (Input.GetKeyDown(KeyCode.RightShift))
        {
            ReStart();
        }
        CheckAllClear();
    }

    public void MoveButtonRight()
    {
        MoveTo(DIRECTION.RIGHT);
    }

    public void MoveButtonLeft()
    {
        MoveTo(DIRECTION.LEFT);
    }

    public void MoveButtonUp()
    {
        MoveTo(DIRECTION.UP);
    }

    public void MoveButtonDown()
    {
        MoveTo(DIRECTION.DOWN);
    }

    public void ReStartButton()
    {
        if (!gameStart)
            return;

        ReStart();
    }

    public void SelectButton()
    {
        if (!gameStart)
            return;

        SelectScene();
    }

    void MoveTo(DIRECTION direction)
    {
        if (!gameStart)
            return;

        audioSource.PlayOneShot(SEMove);

        Vector2Int currentPlayerPositionOnTile = stageManager.moveObjPositionOnTile[playerManager.gameObject];
        Vector2Int nextPlayerPositionOnTile = GetNextPositionOnTile(currentPlayerPositionOnTile, direction);

        if (stageManager.IsWall(nextPlayerPositionOnTile))
        {
            return;
        }
        if (stageManager.IsBlock(nextPlayerPositionOnTile))
        {
            Vector2Int nextBlockPositionOnTile = GetNextPositionOnTile(nextPlayerPositionOnTile, direction);

            if (stageManager.IsWall(nextBlockPositionOnTile) || stageManager.IsBlock(nextBlockPositionOnTile))
            {
                return;
            }

            stageManager.UpdateBlockPosition(nextPlayerPositionOnTile, nextBlockPositionOnTile);
        }

        stageManager.UpdateTileListForPlayer(currentPlayerPositionOnTile, nextPlayerPositionOnTile);
        playerManager.Move(stageManager.GetScreenPositionFromTileList(nextPlayerPositionOnTile), direction);
        stageManager.moveObjPositionOnTile[playerManager.gameObject] = nextPlayerPositionOnTile;

        GameUIManager.moveCount++;
    }

    Vector2Int GetNextPositionOnTile(Vector2Int currentPosition,DIRECTION direction)
    {
        switch (direction)
        {
            case DIRECTION.UP:
                return currentPosition - Vector2Int.up;
            case DIRECTION.DOWN:
                return currentPosition + Vector2Int.up;
            case DIRECTION.LEFT:
                return currentPosition - Vector2Int.right;
            case DIRECTION.RIGHT:
                return currentPosition + Vector2Int.right;
        }
        return currentPosition;
    }

    void CheckAllClear()
    {
        if (isClear)
        {
            return;
        }
        if (stageManager.IsAllClear())
        {
            isClear = true;
            SetUICrown();
            Invoke("TransitionScene", 1.0f);
        }
    }

    void ReStart()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    void TransitionScene()
    {
        SceneManager.LoadScene("Transition");
    }

    void SelectScene()
    {
        TransitionImage.SetActive(true);
    }

    void SetUICrown()
    {
        switch (TransitionManager.scene-1)
        {
            case SCENE.GAME01:
                if (GameUIManager.limitCount[0] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN1", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[0] < GameUIManager.moveCount) 
                {
                    PlayerPrefs.SetInt("CROWN1", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME02:
                if (GameUIManager.limitCount[1] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN2", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[1] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN2", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME03:
                if (GameUIManager.limitCount[2] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN3", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[2] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN3", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME04:
                if (GameUIManager.limitCount[3] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN4", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[3] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN4", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME05:
                if (GameUIManager.limitCount[4] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN5", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[4] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN5", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME06:
                if (GameUIManager.limitCount[5] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN6", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[5] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN6", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME07:
                if (GameUIManager.limitCount[6] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN7", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[6] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN7", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME08:
                if (GameUIManager.limitCount[7] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN8", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[7] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN8", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME09:
                if (GameUIManager.limitCount[8] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN9", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[8] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN9", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME10:
                if (GameUIManager.limitCount[9] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN10", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[9] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN10", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME11:
                if (GameUIManager.limitCount[10] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN11", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[10] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN11", 2);
                    PlayerPrefs.Save();
                }
                break;

            case SCENE.GAME12:
                if (GameUIManager.limitCount[11] >= GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN12", 1);
                    PlayerPrefs.Save();
                }
                else if (GameUIManager.limitCount[11] < GameUIManager.moveCount)
                {
                    PlayerPrefs.SetInt("CROWN12", 2);
                    PlayerPrefs.Save();
                }
                break;
        }
    }
}
