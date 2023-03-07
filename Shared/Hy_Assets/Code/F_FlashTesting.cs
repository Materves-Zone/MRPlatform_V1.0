using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_FlashTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GuideAudioInit();
        NbFlashPosInit();
        TestingFlashPosInit();
        NbFlashExpInit();
        TestingFlashExpInit();
        FinishPannelInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public F_UserTrigger f_UserTrigger;
    public T_StartPoint t_StartPoint;
    public T_ArrowPointer t_ArrowPointer;
    public GameObject[] PosPosition;
    public GameObject[] PosExhibition;
    public GameObject[] NbFlashPosObjs;
    public GameObject[] NbFlashExpObjs;
    public AudioClip[] Clips;
    public AudioSource audioSource;
    public GameObject FinishPannel;
    public bool IsFlashTesting = false;
    public bool IsOnlyShow = false;

    /// <summary>
    /// Flash Nb Pos Guide Part
    /// </summary>
    public void NbFlashPosInit()
    {
        IsFlashTesting = false;
        NbFlashPosObjs[0].SetActive(false);
    }
    public void NbFlashPosStart()
    {
        IsFlashTesting = true;
        NbFlashPosObjs[0].SetActive(true);
        NbFlashPosObjs[1].SetActive(true);
        NbFlashPosObjs[2].SetActive(true);

        t_StartPoint.StartPosUpdate("hide", 999);
        t_StartPoint.StartPosUpdate("show", 0);
    }
    public void NbFlashPosUpdate(int eventid)
    {
        switch (eventid)
        {
            case 0:
                NbFlashPosObjs[1].SetActive(false);
                NbFlashPosObjs[2].SetActive(false);
                NbFlashPosObjs[3].SetActive(true);
                NbFlashPosObjs[4].SetActive(true);
                break;
            case 1:
                NbFlashPosObjs[5].SetActive(false);

                // 02 show
                //NbFlashPosObjs[6].SetActive(true);
                TestingFlashPosStart();

                NbFlashPosObjs[7].SetActive(false);
                NbFlashPosObjs[8].SetActive(false);
                break;
        }
    }
    public void NbFlashPosReset()
    {
        NbFlashPosObjs[9].GetComponent<ReStart>().Show_Menu();
        NbFlashPosObjs[9].GetComponent<ReStart>().Hide_Menu();
        NbFlashPosInit();
        NbFlashPosStart();
    }
    public void NbFlashPosAllReseting()
    {
        NbFlashPosObjs[9].GetComponent<ReStart>().Show_Menu();
        NbFlashPosObjs[9].GetComponent<ReStart>().Hide_Menu();
        NbFlashPosInit();
    }

    /// <summary>
    /// Flash Pos Testing Part
    /// </summary>
    public void TestingFlashPosInit()
    {
        IsFlashTesting = false;
        IsOnlyShow = false;

        for (int i = 0; i < PosPosition.Length; i++)
        {
            PosPosition[i].SetActive(false);
            PosPosition[i].GetComponent<T_FlashControl>().IsFlash = false;
        }
        f_UserTrigger.TriggerInit();
        t_ArrowPointer.ArrowpointersInit();

    }
    public void TestingFlashPosStart()
    {
        NbFlashPosInit();
        IsFlashTesting = true;
        if(!IsOnlyShow)
        {
            for (int i = 0; i < PosPosition.Length; i++)
            {
                PosPosition[i].SetActive(true);
            }
            PosPosition[0].SetActive(true);
            PosPosition[0].GetComponent<T_FlashControl>().IsFlash = true;
        }
        else
        {
            for (int i = 0; i < PosPosition.Length; i++)
            {
                PosPosition[i].SetActive(false);
            }
            PosPosition[0].SetActive(true);
            PosPosition[0].GetComponent<T_FlashControl>().IsFlash = true;
        }
        t_ArrowPointer.ArrowpointersStart();
    }
    public void TestingFlashPosUpdate(int id)
    {
        if(!IsOnlyShow)
        {
            if (id > 0 && id < PosPosition.Length)
            {
                PosPosition[id - 1].GetComponent<T_FlashControl>().IsFlash = false;
                PosPosition[id].GetComponent<T_FlashControl>().IsFlash = true;
            }
            else if (id == PosPosition.Length)
            {
                Debug.Log("last pos position");
                PosPosition[id - 1].GetComponent<T_FlashControl>().IsFlash = false;
            }
        }
        else
        {
            for (int i = 0; i < PosPosition.Length; i++)
            {
                PosPosition[i].GetComponent<T_FlashControl>().IsFlash = false;
                PosPosition[i].SetActive(false);

                if(i == id)
                {
                    PosPosition[i].SetActive(true);
                    PosPosition[i].GetComponent<T_FlashControl>().IsFlash = true;
                }
            }

            if (id == PosPosition.Length)
            {
                Debug.Log("last pos position");
                PosPosition[id - 1].SetActive(true);
                PosPosition[id - 1].GetComponent<T_FlashControl>().IsFlash = false;
            }

        }
        t_ArrowPointer.ArrowpointersUpdate(id);
    }
    public void TestingFlashPosReset()
    {
        f_UserTrigger.TriggerInit();
        TestingFlashPosInit();
        TestingFlashPosStart();
        t_ArrowPointer.ArrowpointersInit();
        t_ArrowPointer.ArrowpointersStart();
    }

    /// <summary>
    /// Flash Exp Guide Part
    /// </summary>
    public void NbFlashExpInit()
    {
        IsFlashTesting = false;
        NbFlashExpObjs[0].SetActive(false);
    }
    public void NbFlashExpStart(int id)
    {
        IsFlashTesting = true;
        switch (id)
        {
            case 0:
                NbFlashExpObjs[0].SetActive(true);
                NbFlashExpObjs[1].SetActive(false);
                NbFlashExpObjs[7].SetActive(true);

                t_StartPoint.StartPosUpdate("hide", 999);
                t_StartPoint.StartPosUpdate("show", 1);
                break;
            case 1:
                NbFlashExpObjs[0].SetActive(true);
                NbFlashExpObjs[1].SetActive(true);
                NbFlashExpObjs[2].SetActive(true);
                NbFlashExpObjs[7].SetActive(false);

                t_StartPoint.StartPosUpdate("hide", 999);
                t_StartPoint.StartPosUpdate("show", 1);
                break;
        }
        t_ArrowPointer.ArrowpointersInit();
    }
    public void NbFlashExpUpdate(int eventid)
    {
        switch (eventid)
        {
            case 0:
                NbFlashExpObjs[1].SetActive(false);
                NbFlashExpObjs[2].SetActive(false);
                NbFlashExpObjs[3].SetActive(true);
                NbFlashExpObjs[4].SetActive(true);
                break;

            case 1:
                NbFlashExpObjs[5].SetActive(false);

                //NbFlashExpObjs[6].SetActive(true);             
                TestingFlashExpStart();
                NbFlashExpObjs[3].GetComponent<T_FlashControl>().IsFlash = false;

                NbFlashExpObjs[8].SetActive(false);
                NbFlashExpObjs[9].SetActive(false);
                break;
        }
    }
    public void NbFlashExpReset()
    {
        NbFlashExpObjs[10].GetComponent<ReStart>().Show_Menu();
        NbFlashExpObjs[10].GetComponent<ReStart>().Hide_Menu();
        NbFlashExpInit();
        NbFlashExpStart(1);
    }
    public void NbFlashExpAllReseting()
    {
        NbFlashExpObjs[10].GetComponent<ReStart>().Show_Menu();
        NbFlashExpObjs[10].GetComponent<ReStart>().Hide_Menu();
        NbFlashExpInit();
    }

    /// <summary>
    /// Flash Exp Testing Part
    /// </summary>
    public void TestingFlashExpInit()
    {
        IsFlashTesting = false;
        for (int i = 0; i < PosExhibition.Length; i++)
        {
            PosExhibition[i].SetActive(false);
            PosExhibition[i].GetComponent<T_FlashControl>().IsFlash = false;
        }
    }
    public void TestingFlashExpStart()
    {
        //NbFlashExpInit();
        IsFlashTesting = true;
        for (int i = 0; i < PosExhibition.Length; i++)
        {
            PosExhibition[i].SetActive(true);
        }
        PosExhibition[0].GetComponent<T_FlashControl>().IsFlash = true;
        t_ArrowPointer.ArrowpointersUpdate(4);
    }
    public void TestingFlashExpUpdate(int envntid)
    {
        switch (envntid)
        {
            case 0:
                PosExhibition[0].GetComponent<T_FlashControl>().IsFlash = false;
                PosExhibition[1].GetComponent<T_FlashControl>().IsFlash = true;
                t_ArrowPointer.ArrowpointersUpdate(5);
                break;
            case 1:
                PosExhibition[0].GetComponent<T_FlashControl>().IsFlash = true;
                PosExhibition[1].GetComponent<T_FlashControl>().IsFlash = false;
                t_ArrowPointer.ArrowpointersUpdate(4);
                break;
            case 2:
                NbFlashExpObjs[11].SetActive(true);
                break;
        }
    }
    public void TestingFlashExpReset()
    {
        TestingFlashExpInit();
        TestingFlashExpStart();
    }

    /// <summary>
    /// Resting Control
    /// </summary>
    public void AllTestingReset()
    {
        NbFlashPosAllReseting();
        TestingFlashPosInit();
        NbFlashExpAllReseting();
        TestingFlashExpInit();
        FinishPannelInit();
        t_ArrowPointer.ArrowpointersInit();
    }

    /// <summary>
    /// TTS Clips Manager
    /// </summary>
    public void GuideAudioInit()
    {
        audioSource.playOnAwake = false;
    }
    public void GuideAudioUpdate(int id)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(Clips[id]);
    }
    public void GuideAudioStop()
    {
        audioSource.Stop();
    }

    /// <summary>
    /// Finsh Pannel Control
    /// </summary>
    public void FinishPannelInit()
    {
        FinishPannel.SetActive(false);
    }
    public void FinishPannelShowHide(int id)
    {
        switch (id)
        {
            case 0:
                FinishPannel.SetActive(false);
                break;
            case 1:
                FinishPannel.SetActive(true);
                break;
        }
    }
}
