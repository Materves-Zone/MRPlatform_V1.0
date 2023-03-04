using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_TTSTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TTSAudioInit();
        NbTTSPosInit();
        TestingTTSPosInit();
        NbTTSExpInit();
        TestingTTSExpInit();
        GuideAudioInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public F_UserTrigger f_UserTrigger;
    public F_FlashTesting f_FlashTesting;
    public T_ArrowPointer t_ArrowPointer;
    public GameObject[] PosPosition;
    public GameObject[] PosExhibition;
    public GameObject[] NbTTSPosObjs;
    public GameObject[] NbTTSExpObjs;
    public AudioClip[] TTSClips;
    public AudioClip[] GuideClips;
    public bool IsTTSTesting = false;
    public AudioSource audioSource;
    public AudioSource audioSource1;

    /// <summary>
    /// TTS Nb Pos Guide Part
    /// </summary>
    public void NbTTSPosInit()
    {
        IsTTSTesting = false;
        NbTTSPosObjs[0].SetActive(false);
    }
    public void NbTTSPosStart()
    {
        IsTTSTesting = true;
        NbTTSPosObjs[0].SetActive(true);
        NbTTSPosObjs[1].SetActive(true);
        NbTTSPosObjs[2].SetActive(true);

        // follow the flash testing part
        f_FlashTesting.AllTestingReset();
    }
    public void NbTTSPosUpdate(int eventid)
    {
        switch (eventid)
        {
            case 0:
                NbTTSPosObjs[1].SetActive(false);
                NbTTSPosObjs[2].SetActive(false);
                NbTTSPosObjs[3].SetActive(true);
                NbTTSPosObjs[4].SetActive(true);
                break;
            case 1:
                NbTTSPosObjs[5].SetActive(false);

                //NbTTSPosObjs[6].SetActive(true);
                TestingTTSPosStart();

                NbTTSPosObjs[7].SetActive(false);
                NbTTSPosObjs[8].SetActive(false);
                break;
        }
    }
    public void NbTTSPosReset()
    {
        NbTTSPosObjs[9].GetComponent<ReStart>().Show_Menu();
        NbTTSPosObjs[9].GetComponent<ReStart>().Hide_Menu();
        NbTTSPosInit();
        NbTTSPosStart();
    }
    public void NbTTSPosAllReseting()
    {
        NbTTSPosObjs[9].GetComponent<ReStart>().Show_Menu();
        NbTTSPosObjs[9].GetComponent<ReStart>().Hide_Menu();
        NbTTSPosInit();
    }

    /// <summary>
    /// TTS Pos Testing Part
    /// </summary>   
    public void TestingTTSPosInit()
    {
        IsTTSTesting = false;
        for (int i = 0; i < PosPosition.Length; i++)
        {
            PosPosition[i].SetActive(false);
        }
        f_UserTrigger.TriggerInit();
        t_ArrowPointer.ArrowpointersInit();

    }
    public void TestingTTSPosStart()
    {
        NbTTSPosInit();
        IsTTSTesting = true;
        for (int i = 0; i < PosPosition.Length; i++)
        {
            PosPosition[i].SetActive(true);
            PosPosition[i].GetComponent<MeshRenderer>().enabled = false;
        }
        // play tts
        TTSAudioUpdate(0);
        t_ArrowPointer.ArrowpointersStart();
    }
    public void TestingTTSPosUpdate(int id)
    {
        TTSAudioUpdate(id);
        t_ArrowPointer.ArrowpointersUpdate(id);
    }
    public void TestingTTSReset()
    {
        TestingTTSPosInit();
        TestingTTSPosStart();
        t_ArrowPointer.ArrowpointersInit();
        t_ArrowPointer.ArrowpointersStart();
    }

    /// <summary>
    /// TTS Exp Guide Part 
    /// </summary>
    public void NbTTSExpInit()
    {
        IsTTSTesting = false;
        NbTTSExpObjs[0].SetActive(false);
    }
    public void NbTTSExpStart(int id)
    {
        IsTTSTesting = true;
        switch (id)
        {
            case 0:
                NbTTSExpObjs[0].SetActive(true);
                NbTTSExpObjs[1].SetActive(false);
                NbTTSExpObjs[7].SetActive(true);
                break;

            case 1:
                NbTTSExpObjs[0].SetActive(true);
                NbTTSExpObjs[1].SetActive(true);
                NbTTSExpObjs[2].SetActive(true);
                NbTTSExpObjs[7].SetActive(false);
                break;
        }
        t_ArrowPointer.ArrowpointersInit();
    }
    public void NbTTSExpUpdate(int eventid)
    {
        switch (eventid)
        {
            case 0:
                NbTTSExpObjs[1].SetActive(false);
                NbTTSExpObjs[2].SetActive(false);
                NbTTSExpObjs[3].SetActive(true);
                NbTTSExpObjs[4].SetActive(true);
                break;

            case 1:
                NbTTSExpObjs[5].SetActive(false);

                //NbTTSExpObjs[6].SetActive(true);
                TestingTTSExpStart();

                NbTTSExpObjs[8].SetActive(false);
                NbTTSExpObjs[9].SetActive(false);
                break;

            case 2:
                NbTTSExpObjs[11].SetActive(true);
                break;
        }
    }
    public void NbTTSExpReset()
    {
        Debug.Log("~");
        NbTTSExpObjs[10].GetComponent<ReStart>().Show_Menu();
        NbTTSExpObjs[10].GetComponent<ReStart>().Hide_Menu();
        NbTTSExpInit();
        NbTTSExpStart(1);
    }
    public void NbTTSExpAllReseting()
    {
        NbTTSExpObjs[10].GetComponent<ReStart>().Show_Menu();
        NbTTSExpObjs[10].GetComponent<ReStart>().Hide_Menu();
        NbTTSExpInit();
    }

    /// <summary>
    /// TTS Exp Testing Part
    /// </summary>
    public void TestingTTSExpInit()
    {
        IsTTSTesting = false;
        for (int i = 0; i < PosExhibition.Length; i++)
        {
            PosExhibition[i].SetActive(false);       
        }
    }
    public void TestingTTSExpStart()
    {
        //NbTTSExpInit();
        IsTTSTesting = true;
        for (int i = 0; i < PosExhibition.Length; i++)
        {
            PosExhibition[i].SetActive(true);
        }
        // TTS ...
        TTSAudioUpdate(4);
        t_ArrowPointer.ArrowpointersUpdate(4);
    }
    public void TestingTTSExpUpdate(int eventid)
    {
        switch (eventid)
        {
            case 0:
                // TTS ...
                TTSAudioUpdate(5);
                t_ArrowPointer.ArrowpointersUpdate(5);
                break;

            case 1:
                // TTS ...
                TTSAudioUpdate(4);
                t_ArrowPointer.ArrowpointersUpdate(4);
                break;

            case 2:
                NbTTSExpObjs[11].SetActive(true);
                break;
        }
    }
    public void TestingTTSExpReset()
    {
        TestingTTSExpInit();
        TestingTTSExpStart();
    }

    /// <summary>
    /// TTS Clips Manager
    /// </summary>
    public void TTSAudioInit()
    {
        audioSource.playOnAwake = false;
    }
    public void TTSAudioUpdate(int id)
    {
        if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(TTSClips[id]);
    }

    /// <summary>
    /// Guide TTS Manager
    /// </summary>
    public void GuideAudioInit()
    {
        audioSource1.playOnAwake = false;
    }
    public void GuideAudioUpdate(int id)
    {
        if (audioSource1.isPlaying)
        {
            audioSource1.Stop();
        }
        audioSource1.PlayOneShot(GuideClips[id]);
    }

    /// <summary>
    /// Resting Control
    /// </summary>
    public void AllTestingReset()
    {
        NbTTSPosAllReseting();
        TestingTTSPosInit();
        NbTTSExpAllReseting();
        TestingTTSExpInit();
        t_ArrowPointer.ArrowpointersInit();
    }

}
