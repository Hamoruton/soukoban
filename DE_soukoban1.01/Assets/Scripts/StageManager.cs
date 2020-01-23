using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public Dictionary<GameObject, Vector2Int> moveObjPositionOnTile = new Dictionary<GameObject, Vector2Int>();

    private enum TILE_TYPE
    {
        WALL,
        GROUND,
        TARGET,
        BLOCK,
        PLAYER,
        BACKGROUND,
        BLOCK_ON_TARGET,
        PLAYER_ON_TARGET,
    }
    private TILE_TYPE[,] tileList;
    private float tileSize;
    private int blockCount = 0;

    [SerializeField] TextAsset stageFile;
    [SerializeField] GameObject[] prefabs;

    Vector2 centerPosition;

    public void LoadTileData()
    {
        string[] lines = stageFile.text.Split
            (
                new[] { '\n', '\r' },
                System.StringSplitOptions.RemoveEmptyEntries
             );
        int columns = lines[0].Split(new[] { ',' }).Length;
        int rows = lines.Length;
        tileList = new TILE_TYPE[columns, rows];

        for(int y = 0; y < rows; y++)
        {
            string[] values = lines[y].Split(new[] { ',' });
            for (int x = 0; x < columns; x++)
            {
                tileList[x, y] = (TILE_TYPE)int.Parse(values[x]);
                //Debug.Log(tileList[x, y]);
            }
        }
    }

    public void CreateStage()
    {
        tileSize = prefabs[0].GetComponent<SpriteRenderer>().bounds.size.x;
        centerPosition.x = (tileList.GetLength(0) / 2) * tileSize;
        centerPosition.y = (tileList.GetLength(1) / 2) * tileSize;

        for (int y = 0; y < tileList.GetLength(1); y++)
        {
            for(int x = 0; x < tileList.GetLength(0); x++)
            {
                Vector2Int position = new Vector2Int(x, y);

                GameObject ground = Instantiate(prefabs[(int)TILE_TYPE.GROUND]);
                ground.transform.position = GetScreenPositionFromTileList(position);

                TILE_TYPE tileType = tileList[x, y];
                GameObject obj = Instantiate(prefabs[(int)tileType]);
                obj.transform.position = GetScreenPositionFromTileList(position);
                if (tileType == TILE_TYPE.PLAYER)
                {
                    playerManager = obj.GetComponent<PlayerManager>();
                    moveObjPositionOnTile.Add(obj, position);
                }
                if (tileType == TILE_TYPE.BLOCK)
                {
                    moveObjPositionOnTile.Add(obj, position);
                    blockCount++;
                    //Debug.Log("block : " + blockCount);
                }
            }
        }
    }

    public Vector2 GetScreenPositionFromTileList(Vector2Int position)
    {
        return new Vector2(position.x * tileSize - centerPosition.x, -(position.y * tileSize - centerPosition.y));
    }

    public bool IsWall(Vector2Int position)
    {
        if (tileList[position.x, position.y] == TILE_TYPE.WALL)
        {
            return true;
        }
        return false;
    }

    public bool IsBlock(Vector2Int position)
    {
        if (tileList[position.x, position.y] == TILE_TYPE.BLOCK)
        {
            return true;
        }
        if (tileList[position.x, position.y] == TILE_TYPE.BLOCK_ON_TARGET)
        {
            return true;
        }
        return false;
    }

    //pairにはKey(obj)とvalue(position)が入っている
    GameObject GetBlockObjAt(Vector2Int position)
    {
        foreach(var pair in moveObjPositionOnTile)
        {
            if (pair.Value == position)
            {
                return pair.Key;
            }
        }
        return null;
    }

    public void UpdateBlockPosition(Vector2Int currentBlockPosition,Vector2Int nextBlockPosition)
    {
        GameObject block = GetBlockObjAt(currentBlockPosition);
        block.transform.position = GetScreenPositionFromTileList(nextBlockPosition);
        moveObjPositionOnTile[block] = nextBlockPosition;

        if (tileList[nextBlockPosition.x, nextBlockPosition.y] == TILE_TYPE.TARGET)
        {
            tileList[nextBlockPosition.x, nextBlockPosition.y] = TILE_TYPE.BLOCK_ON_TARGET;
        }
        else
        {
            tileList[nextBlockPosition.x, nextBlockPosition.y] = TILE_TYPE.BLOCK;
        }
    }

    public void UpdateTileListForPlayer(Vector2Int currentPosition,Vector2Int nextPosition)
    {
        if (tileList[nextPosition.x, nextPosition.y] == TILE_TYPE.TARGET ||
            tileList[nextPosition.x, nextPosition.y] == TILE_TYPE.BLOCK_ON_TARGET) 
        {
            tileList[nextPosition.x, nextPosition.y] = TILE_TYPE.PLAYER_ON_TARGET;
        }
        else
        {
            tileList[nextPosition.x, nextPosition.y] = TILE_TYPE.PLAYER;
        }

        if (tileList[currentPosition.x, currentPosition.y] == TILE_TYPE.PLAYER_ON_TARGET) 
        {
            tileList[currentPosition.x, currentPosition.y] = TILE_TYPE.TARGET;
        }
        else
        {
            tileList[currentPosition.x, currentPosition.y] = TILE_TYPE.GROUND;
        }
    }

    public bool IsAllClear()
    {
        int clearCount = 0;

        for(int y = 0; y < tileList.GetLength(1); y++)
        {
            for(int x = 0; x < tileList.GetLength(0); x++)
            {
                if (tileList[x, y] == TILE_TYPE.BLOCK_ON_TARGET)
                {
                    clearCount++;
                    //Debug.Log("clear : " + clearCount);
                }
            }
        }

        if (blockCount == clearCount)
        {
            return true;
        }
        return false;
    }
}
