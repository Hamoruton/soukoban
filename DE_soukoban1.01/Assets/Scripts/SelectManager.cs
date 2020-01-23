using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{

    private void Start()
    {
    }

    public void Game01Scene()
    {
        SceneManager.LoadScene("Game01");
        TransitionManager.scene = SCENE.GAME02;
    }

    public void Game02Scene()
    {
        SceneManager.LoadScene("Game02");
        TransitionManager.scene = SCENE.GAME03;
    }

    public void Game03Scene()
    {
        SceneManager.LoadScene("Game03");
        TransitionManager.scene = SCENE.GAME04;
    }

    public void Game04Scene()
    {
        SceneManager.LoadScene("Game04");
        TransitionManager.scene = SCENE.GAME05;
    }

    public void Game05Scene()
    {
        SceneManager.LoadScene("Game05");
        TransitionManager.scene = SCENE.GAME06;
    }

    public void Game06Scene()
    {
        SceneManager.LoadScene("Game06");
        TransitionManager.scene = SCENE.GAME07;
    }

    public void Game07Scene()
    {
        SceneManager.LoadScene("Game07");
        TransitionManager.scene = SCENE.GAME08;
    }

    public void Game08Scene()
    {
        SceneManager.LoadScene("Game08");
        TransitionManager.scene = SCENE.GAME09;
    }

    public void Game09Scene()
    {
        SceneManager.LoadScene("Game09");
        TransitionManager.scene = SCENE.GAME10;
    }

    public void Game10Scene()
    {
        SceneManager.LoadScene("Game10");
        TransitionManager.scene = SCENE.GAME11;
    }

    public void Game11Scene()
    {
        SceneManager.LoadScene("Game11");
        TransitionManager.scene = SCENE.GAME12;
    }

    public void Game12Scene()
    {
        SceneManager.LoadScene("Game12");
        TransitionManager.scene = SCENE.SELECT;
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("Title");
    }
}
