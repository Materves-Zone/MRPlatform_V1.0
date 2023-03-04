using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject[] HideMenu;
    public GameObject[] ShowMenu;

    // Update is called once per frame
    void Update()
    {

    }


    public void Hide_Menu()
    {
        for (int i = 0; i < HideMenu.Length; i++)
        {
            //ArrayButton[i].transform.position = new Vector3(2 * i, 0, 0);
            HideMenu[i].SetActive(false);
        }

        
    }

    public void Show_Menu()
    {
        for (int i = 0; i < ShowMenu.Length; i++)
        {
            //ArrayButton[i].transform.position = new Vector3(2 * i, 0, 0);
            ShowMenu[i].SetActive(true);
        }

        //GameObject.Find("PlayControl_Orcal/ButtonSwitch").GetComponent<C_ButtonSwitch>().ArrayReset();
    }
}
