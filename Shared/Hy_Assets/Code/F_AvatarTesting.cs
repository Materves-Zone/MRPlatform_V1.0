using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_AvatarTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AvatarAudioInit();
        NbAvatarPosInit();
        TestingAvatarPosInit();
        NbAvatarExpInit();
        TestingAvatarExpInit();
        GuideAudioInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public F_UserTrigger f_UserTrigger;
    public F_TTSTesting f_TTSTesting;
    public T_ArrowPointer t_ArrowPointer;
    public GameObject[] PosPosition;
    public GameObject[] PosExhibition;
    public GameObject[] NbAvatarPosObjs;
    public GameObject[] NbAvatarExpObjs;
    public AudioClip[] AvatarClips;
    public AudioClip[] GuideClips;
    public Animator[] NBanimators;
    public bool IsAvatarTesting = false;
    public GameObject Avatar;
    public Animator animator;
    public AudioSource audioSource;
    public AudioSource audioSource1;

    /// <summary>
    /// Avatar Nb Pos Guide Part
    /// </summary>
    public void NbAvatarPosInit()
    {
        IsAvatarTesting = false;
        NbAvatarPosObjs[0].SetActive(false);
        NBanimators[0].name = "NbPosAvatar";
        Avatar.SetActive(false);
    }
    public void NbAvatarPosStart()
    {
        IsAvatarTesting = true;
        NbAvatarPosObjs[0].SetActive(true);
        NbAvatarPosObjs[1].SetActive(true);
        NbAvatarPosObjs[2].SetActive(true);
        NBanimators[0].name = "NbPosAvatar";
        f_TTSTesting.AllTestingReset();
    }
    public void NbAvatarPosUpdate(int eventid)
    {
        switch (eventid)
        {
            case 0:
                NbAvatarPosObjs[1].SetActive(false);
                NbAvatarPosObjs[2].SetActive(false);
                NbAvatarPosObjs[3].SetActive(true);
                NbAvatarPosObjs[4].SetActive(true);
                NbAvatarAnimUpdate(0);
                break;
            case 1:
                NbAvatarPosObjs[5].SetActive(false);

                //NbAvatarPosObjs[6].SetActive(true);
                TestingAvatarPosStart();

                NbAvatarPosObjs[7].SetActive(false);
                NbAvatarPosObjs[8].SetActive(false);
                //NbAvatarAnimUpdate(1);
                break;
            case 2:
                NbAvatarAnimUpdate(1);
                NBanimators[0].name = "NbPosAvatar1";
                break;
            case 3:
                NbAvatarAnimUpdate(4);
                NBanimators[0].name = "NbPosAvatar2";
                NbAvatarPosObjs[8].SetActive(true);
                Debug.Log("~~~1");
                break;
        }
    }
    public void NbAvatarPosReset()
    {
        NbAvatarPosObjs[9].GetComponent<ReStart>().Show_Menu();
        NbAvatarPosObjs[9].GetComponent<ReStart>().Hide_Menu();
        NbAvatarPosInit();
        NbAvatarPosStart();
    }
    public void NbAvatarPosAllReseting()
    {
        NbAvatarPosObjs[9].GetComponent<ReStart>().Show_Menu();
        NbAvatarPosObjs[9].GetComponent<ReStart>().Hide_Menu();
        NbAvatarPosInit();
    }

    /// <summary>
    /// Avatar Testing Pos Part
    /// </summary>
    public void TestingAvatarPosInit()
    {
        IsAvatarTesting = false;
        for (int i = 0; i < PosPosition.Length; i++)
        {
            PosPosition[i].SetActive(false);
        }
        f_UserTrigger.TriggerInit();
        t_ArrowPointer.ArrowpointersInit();
    }
    public void TestingAvatarPosStart()
    {
        NbAvatarPosInit();
        IsAvatarTesting = true;
        for (int i = 0; i < PosPosition.Length; i++)
        {
            PosPosition[i].SetActive(true);
            PosPosition[i].GetComponent<MeshRenderer>().enabled = false;
        }
        // avatar show
        Avatar.SetActive(true);
        // avatar tts show
        AvatarAudioUpdate(0);
        // avatar animation
        AvatarAnimUpdate(0);
        // arrow show ...
        t_ArrowPointer.ArrowpointersStart();
    }
    public void TestingAvatarPosUpdate(int id)
    {
        // avatar
        AvatarAudioUpdate(id);
        // avatar animation
        AvatarAnimUpdate(id);
        // arrow show ...
    }
    public void TestingAvatarPosReset()
    {
        TestingAvatarPosInit();
        // arrow init ...
        TestingAvatarPosStart();
        t_ArrowPointer.ArrowpointersInit();
        t_ArrowPointer.ArrowpointersStart();
    }

    /// <summary>
    /// Avatar Nb Exp Guide Part
    /// </summary>
    public void NbAvatarExpInit()
    {
        IsAvatarTesting = false;
        NBanimators[1].name = "NbExpAvatar";
        NbAvatarExpObjs[0].SetActive(false);
    }
    public void NbAvatarExpStart(int id)
    {
        IsAvatarTesting = true;
        Avatar.SetActive(false);
        switch (id)
        {
            case 0:
                NbAvatarExpObjs[0].SetActive(true);
                NbAvatarExpObjs[1].SetActive(false);
                NbAvatarExpObjs[7].SetActive(true);
                break;

            case 1:
                NbAvatarExpObjs[0].SetActive(true);
                NbAvatarExpObjs[1].SetActive(true);
                NbAvatarExpObjs[2].SetActive(true);
                NbAvatarExpObjs[7].SetActive(false);
                break;
        }
        t_ArrowPointer.ArrowpointersInit();
        NBanimators[1].name = "NbExpAvatar";
    }
    public void NbAvatarExpUpdate(int eventid)
    {
        switch (eventid)
        {
            case 0:
                NbAvatarExpObjs[1].SetActive(false);
                NbAvatarExpObjs[2].SetActive(false);
                NbAvatarExpObjs[3].SetActive(true);
                NbAvatarExpObjs[4].SetActive(true);
                NbAvatarAnimUpdate(2);
                break;

            case 1:
                NbAvatarExpObjs[5].SetActive(false);

                //NbAvatarExpObjs[6].SetActive(true);
                TestingAvatarExpStart();

                NbAvatarExpObjs[8].SetActive(false);
                NbAvatarExpObjs[9].SetActive(false);
                //NbAvatarAnimUpdate(3);
                //Debug.Log("2");
                break;

            case 2:
                NbAvatarAnimUpdate(3);
                NBanimators[1].name = "NbExpAvatar1";
                //Debug.Log("111");
                break;

            case 3:
                NbAvatarAnimUpdate(5);
                NBanimators[1].name = "NbExpAvatar2";
                NbAvatarExpObjs[9].SetActive(true);
                Debug.Log("222");
                break;

            case 4:
                NbAvatarExpObjs[11].SetActive(true);
                break;
        }
    }
    public void NbAvatarExpReset()
    {
        NbAvatarExpObjs[10].GetComponent<ReStart>().Show_Menu();
        NbAvatarExpObjs[10].GetComponent<ReStart>().Hide_Menu();
        NbAvatarExpInit();
        NbAvatarExpStart(1);
    }
    public void NbAvatarExpAllReseting()
    {
        NbAvatarExpObjs[10].GetComponent<ReStart>().Show_Menu();
        NbAvatarExpObjs[10].GetComponent<ReStart>().Hide_Menu();
        NbAvatarExpInit();
    }

    /// <summary>
    /// Avatar Texting Exp Part
    /// </summary>
    public void TestingAvatarExpInit()
    {
        IsAvatarTesting = false;
        for (int i = 0; i < PosExhibition.Length; i++)
        {
            PosExhibition[i].SetActive(false);
        }
    }
    public void TestingAvatarExpStart()
    {
        //NbAvatarExpInit();
        IsAvatarTesting = true;
        Avatar.SetActive(true);
        for (int i = 0; i < PosExhibition.Length; i++)
        {
            PosExhibition[i].SetActive(true);
        }
        // TTS ...
        //AvatarAudioUpdate(4);
        // avatar animation
        AvatarAnimUpdate(4);
        t_ArrowPointer.ArrowpointersStart();
    }
    public void TestingAvatarExpUpdate(int eventid)
    {
        switch (eventid)
        {
            case 0:
                AvatarAnimUpdate(5);
                t_ArrowPointer.ArrowpointersUpdate(2);
                break;

            case 1:
                AvatarAnimUpdate(6);
                t_ArrowPointer.ArrowpointersUpdate(1);
                break;
        }
    }
    public void TestingAvatarExpReset()
    {
        TestingAvatarExpInit();
        TestingAvatarExpStart();
    }

    /// <summary>
    /// Avatar Clips Manager
    /// </summary>
    public void AvatarAudioInit()
    {
        audioSource.playOnAwake = false;
    }
    public void AvatarAudioUpdate(int id)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(AvatarClips[id]);
    }

    /// <summary>
    /// Avatar Animation Manager
    /// </summary>
    public void AvatarAnimInit()
    {
        //
    }
    public void AvatarAnimUpdate(int id)
    {
        switch (id)
        {
            case 0:
                animator.Play("Step1");
                break;

            case 1:
                animator.Play("Step2");
                break;

            case 2:
                animator.Play("Step3");
                break;

            case 3:
                animator.Play("Step4");
                break;

            case 4:
                animator.Play("Step5");
                break;

            case 5:
                animator.Play("Step6");
                break;

            case 6:
                animator.Play("Step7");
                break;

            case 7:
                animator.Play("Step8");
                break;
        }
    }

    /// <summary>
    /// Nb Avatar Animation Manager
    /// </summary>
    public void NbAvatarAnimInit()
    {

    }
    public void NbAvatarAnimUpdate(int id)
    {
        switch (id)
        {
            case 0:
                NBanimators[0].Play("NbAvatarFindPosInit");
                break;

            case 1:
                NBanimators[0].Play("NbAvatarFindPos");
                NBanimators[0].name = "NbPosAvatar1";
                break;

            case 2:
                NBanimators[1].Play("NbAvatarFindPosInit");
                break;

            case 3:
                NBanimators[1].Play("NbAvatarFindPos");
                NBanimators[1].name = "NbExpAvatar1";
                break;

            case 4:
                NBanimators[0].Play("NbAvatarFindPos1");
                break;

            case 5:
                NBanimators[1].Play("NbAvatarFindPos2");
                break;

            case 6:
                //1
                NBanimators[1].gameObject.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// Resting Control
    /// </summary>
    public void AllTestingReset()
    {
        NbAvatarPosAllReseting();
        TestingAvatarPosInit();
        NbAvatarExpAllReseting();
        TestingAvatarExpInit();
        t_ArrowPointer.ArrowpointersInit();
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
}
