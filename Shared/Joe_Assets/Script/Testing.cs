using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        reStartInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ReStart reStart;

    public void reStartInit()
    {
        Debug.Log("~~~~~");
        reStart.Hide_Menu();
        reStart.Show_Menu();
    }
    

}
