using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_ArrowPointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ArrowpointersInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] _Arrowpointers;

    public void ArrowpointersInit()
    {
        for (int i = 0; i < _Arrowpointers.Length; i++)
        {
            _Arrowpointers[i].SetActive(false);
        }
    }
    public void ArrowpointersStart()
    {
        _Arrowpointers[0].SetActive(true);
    }
    public void ArrowpointersUpdate(int id)
    {
        for (int i = 0; i < _Arrowpointers.Length; i++)
        {
            _Arrowpointers[i].SetActive(false);
            if(i == id)
            {
                _Arrowpointers[i].SetActive(true);
            }
        }
    }
}
