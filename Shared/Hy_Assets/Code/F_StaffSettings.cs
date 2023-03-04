using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class F_StaffSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AllResetingInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public F_FlashTesting f_FlashTesting;
    public F_TTSTesting f_TTSTesting;
    public F_AvatarTesting f_AvatarTesting;
    public GameObject TragObj;
    public GameObject UIObjs;
    public ObjectManipulator objectManipulator;
    public GameObject[] ShowHideObjs;
    public bool IsStaffMode = false;
    private int ClickIDEvent;
    private int ClickIDUI;

    /// <summary>
    /// settings
    /// </summary>
    public void AllResetingInit()
    {
        UIObjs.SetActive(false);
        IsStaffMode = true;
    }
    public void AllReseting()
    {
        //Debug.Log("All Reset!");
        f_FlashTesting.AllTestingReset();
        f_TTSTesting.AllTestingReset();
        f_AvatarTesting.AllTestingReset();
    }

    /// <summary>
    /// function
    /// </summary>
    public void Drag(int id)
    {
        switch (id)
        {
            case 0:
                TragObj.GetComponent<Collider>().enabled = false;
                TragObj.GetComponent<MeshRenderer>().enabled = false;
                objectManipulator.enabled = false;
                break;

            case 1:
                TragObj.GetComponent<Collider>().enabled = true;
                TragObj.GetComponent<MeshRenderer>().enabled = true;
                objectManipulator.enabled = true;
                break;
        }
    }
    public void ShowHideSettings ()
    {
        ClickIDEvent++;

        switch (ClickIDEvent)
        {
            case 2:
                IsStaffMode = true;
                AllReseting();
                Drag(1);
                // Show
                for (int i = 0; i < ShowHideObjs.Length; i++)
                {
                    ShowHideObjs[i].SetActive(true);
                    ClickIDEvent = 0;
                }
                // Drag enable ...
                break;

            case 1:
                // Hide
                for (int i = 0; i < ShowHideObjs.Length; i++)
                {
                    ShowHideObjs[i].SetActive(false);
                }
                Drag(0);
                AllReseting();
                IsStaffMode = false;
                break;
        }
    }

    /// <summary>
    /// UI
    /// </summary>
    public void ShowHideUI()
    {
        //ClickIDEvent++;

        //switch (ClickIDUI)
        //{
        //    case 1:
        //        UIObjs.SetActive(true);
        //        break;

        //    case 2:
        //        UIObjs.SetActive(false);
        //        break;
        //}

        UIObjs.SetActive(true);
    }
}
