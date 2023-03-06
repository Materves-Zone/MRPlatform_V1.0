using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_StartPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartPosInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Start 
    /// </summary>
    public bool IsInit;
    public GameObject[] StartPosArray;
    public Color[] colors;

    public void StartPosInit()
    {
        if(IsInit)
        {
            for (int i = 0; i < StartPosArray.Length; i++)
            {
                StartPosArray[i].SetActive(false);
            }
        }
    }
    public void StartPosUpdate (string str ,int id)
    {
        switch (str)
        {
            case "hide":
                for (int i = 0; i < StartPosArray.Length; i++)
                {
                    StartPosArray[i].GetComponent<T_StartPoint>().StartPosChangeColor(1);
                    StartPosArray[i].SetActive(false);
                }
                break;

            case "show":
                    StartPosArray[id].SetActive(true);
                break;
        }
    }
    public void StartPosChangeColor(int id)
    {
        switch (id)
        {
            case 1:
                this.GetComponent<Renderer>().material.color = colors[0];
                break;
            case 2:
                this.GetComponent<Renderer>().material.color = colors[1];
                break;
        }
    }
}
