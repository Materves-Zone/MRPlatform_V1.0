using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_StartPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color[] colors;

    public void ChangeColor (int id)
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
