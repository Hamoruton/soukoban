using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionShader : MonoBehaviour
{
    [SerializeField]
    private Material transition;
    public bool selectScene;
   
    private void Start()
    {
        StartCoroutine(BiginTransition());
    }

    IEnumerator BiginTransition()
    {
        yield return Animate(transition, 1);
        if (!selectScene)
            SceneManager.LoadScene("Select");

        gameObject.SetActive(false);
    }
    
    IEnumerator Animate(Material material,float time)
    {
        GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 1);
    }
}
