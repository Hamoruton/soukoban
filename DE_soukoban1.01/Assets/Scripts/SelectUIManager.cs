using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUIManager : MonoBehaviour
{
    [SerializeField] Sprite nomalCrown;
    [SerializeField] Sprite goldCrown;
    [SerializeField] Sprite silverCrown;

    [SerializeField] GameObject[] uiCrown;

    public static int[] a = new int[12];

    private void Start()
    {
        //InitUICrown();
        GetUICrown();

        for (int i = 0; i < a.Length; i++)
        {
            switch (a[i]) {
                case 0:
                    uiCrown[i].GetComponent<Image>().sprite = nomalCrown;
                    break;

                case 1:
                    uiCrown[i].GetComponent<Image>().sprite = goldCrown;
                    break;

                case 2:
                    uiCrown[i].GetComponent<Image>().sprite = silverCrown;
                    break;
        }
        }
           
        
    }

    private void Update()
    {
        
    }

    private void GetUICrown()
    {
        a[0] = PlayerPrefs.GetInt("CROWN1");
        a[1] = PlayerPrefs.GetInt("CROWN2");
        a[2] = PlayerPrefs.GetInt("CROWN3");
        a[3] = PlayerPrefs.GetInt("CROWN4");
        a[4] = PlayerPrefs.GetInt("CROWN5");
        a[5] = PlayerPrefs.GetInt("CROWN6");
        a[6] = PlayerPrefs.GetInt("CROWN7");
        a[7] = PlayerPrefs.GetInt("CROWN8");
        a[8] = PlayerPrefs.GetInt("CROWN9");
        a[9] = PlayerPrefs.GetInt("CROWN10");
        a[10] = PlayerPrefs.GetInt("CROWN11");
        a[11] = PlayerPrefs.GetInt("CROWN12");
    }

    private void InitUICrown()
    {
        PlayerPrefs.SetInt("CROWN1", 0);
        PlayerPrefs.SetInt("CROWN2", 0);
        PlayerPrefs.SetInt("CROWN3", 0);
        PlayerPrefs.SetInt("CROWN4", 0);
        PlayerPrefs.SetInt("CROWN5", 0);
        PlayerPrefs.SetInt("CROWN6", 0);
        PlayerPrefs.SetInt("CROWN7", 0);
        PlayerPrefs.SetInt("CROWN8", 0);
        PlayerPrefs.SetInt("CROWN9", 0);
        PlayerPrefs.SetInt("CROWN10", 0);
        PlayerPrefs.SetInt("CROWN11", 0);
        PlayerPrefs.SetInt("CROWN12", 0);
        PlayerPrefs.Save();
    }
}
