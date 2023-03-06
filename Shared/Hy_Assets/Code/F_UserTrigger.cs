using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_UserTrigger : MonoBehaviour
{
    public int CheckID = 0;
    public int ExpID = 0;
    public F_FlashTesting f_FlashTesting;
    public F_TTSTesting f_TTSTesting;
    public F_AvatarTesting f_AvatarTesting;
    public F_StaffSettings f_StaffSettings;

    public void TriggerInit()
    {
        CheckID = 0;
        ExpID = 0;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!f_StaffSettings.IsStaffMode)
        {
            if (f_FlashTesting.IsFlashTesting)
            {
                // nb flash pos and nb exp part
                switch (other.name)
                {
                    case "FlashPosInsideCircle":
                        f_FlashTesting.NbFlashPosUpdate(0);
                        break;

                    case "FlashNbPos":
                        f_FlashTesting.NbFlashPosUpdate(1);
                        break;

                    case "FlashExpInsideCircle":
                        f_FlashTesting.NbFlashExpUpdate(0);
                        break;

                    case "Object":
                        f_FlashTesting.NbFlashExpUpdate(1);
                        break;
                }
                // testing flash pos part
                if (other.tag == "Pos" && CheckID == other.transform.GetComponent<T_FlashControl>().PillarID)
                {
                    CheckID++;
                    if (CheckID < f_FlashTesting.PosPosition.Length)
                    {
                        f_FlashTesting.TestingFlashPosUpdate(CheckID);
                    }
                    else if (CheckID == f_FlashTesting.PosPosition.Length)
                    {
                        Debug.Log("start to nb exp part");
                        f_FlashTesting.TestingFlashPosUpdate(CheckID);
                        f_FlashTesting.NbFlashExpStart(0);
                        // guide tts
                        f_FlashTesting.GuideAudioUpdate(0);
                        CheckID = 999;
                    }
                }
                // testing flash exp part
                if (other.tag == "Exp")
                {
                    switch (other.name)
                    {
                        case "PartA":
                            if (ExpID == 0)
                            {
                                f_FlashTesting.TestingFlashExpUpdate(0);
                                ExpID++;
                            }
                            break;

                        case "PartB":

                            if (ExpID == 1)
                            {
                                //f_FlashTesting.TestingFlashExpUpdate(1);
                                Debug.Log("show pannel");
                                //f_FlashTesting.FinishPannelShowHide(1);
                                f_FlashTesting.GuideAudioUpdate(1);
                                f_FlashTesting.TestingFlashExpUpdate(2);
                                ExpID = 999;
                            }
                            break;
                    }
                }
            }
            else if (f_TTSTesting.IsTTSTesting)
            {
                // nb tts pos and nb exp part 
                switch (other.name)
                {
                    case "StandAreaTTSPos":
                        f_TTSTesting.NbTTSPosUpdate(0);
                        break;

                    case "Apple_Pic":
                        f_TTSTesting.NbTTSPosUpdate(1);
                        break;

                    case "StandAreaTTSExp":
                        f_TTSTesting.NbTTSExpUpdate(0);
                        break;

                    case "Tree_Pic":
                        f_TTSTesting.NbTTSExpUpdate(1);
                        break;
                }
                // testing tts pos part
                if (other.tag == "Pos" && CheckID == other.transform.GetComponent<F_PosID>().PosID)
                {
                    CheckID++;
                    if (CheckID < f_TTSTesting.PosPosition.Length)
                    {
                        f_TTSTesting.TestingTTSPosUpdate(CheckID);
                    }
                    else if (CheckID == f_TTSTesting.PosPosition.Length)
                    {
                        Debug.Log("start to nb tts exp guide part");
                        f_TTSTesting.NbTTSExpStart(0);
                        // guide tts
                        f_TTSTesting.GuideAudioUpdate(0);
                        CheckID = 999;
                    }
                }
                // testing tts exp part
                if (other.tag == "Exp")
                {
                    switch (other.name)
                    {
                        case "PartA":
                            if(ExpID == 0)
                            {
                                f_TTSTesting.TestingTTSExpUpdate(0);
                                ExpID++;
                            }
                            break;

                        case "PartB":
                            if(ExpID == 1)
                            {
                                //f_TTSTesting.TestingTTSExpUpdate(1);
                                f_TTSTesting.GuideAudioUpdate(1);
                                f_TTSTesting.NbTTSExpUpdate(2);
                                ExpID = 999;
                            }
                            break;
                    }
                }
            }
            else if (f_AvatarTesting.IsAvatarTesting)
            {
                // nb avatar pos and nb exp part
                switch (other.name)
                {
                    case "StandAreaAvatarPos":
                        f_AvatarTesting.NbAvatarPosUpdate(0);
                        break;

                    case "NbPosAvatar":
                        //f_AvatarTesting.NbAvatarAnimUpdate(1);
                        //other.name = "NbPosAvatar1";
                        f_AvatarTesting.NbAvatarPosUpdate(2);
                        break;

                    case "NbPosAvatar1":
                        //f_AvatarTesting.NbAvatarAnimUpdate(4);
                        //other.name = "NbPosAvatar99";
                        f_AvatarTesting.NbAvatarPosUpdate(3);
                        break;

                    case "NbPosAvatarPillar":
                        f_AvatarTesting.NbAvatarPosUpdate(1);
                        break;

                    case "StandAreaAvatarExp":
                        f_AvatarTesting.NbAvatarExpUpdate(0);
                        break;

                    case "NbExpAvatar":
                        f_AvatarTesting.NbAvatarExpUpdate(2);
                        break;

                    case "NbExpAvatar1":
                        f_AvatarTesting.NbAvatarExpUpdate(3);
                        break;

                    case "NbExpAvatarPillar":
                        f_AvatarTesting.NbAvatarExpUpdate(1);
                        f_AvatarTesting.NbAvatarAnimUpdate(6);
                        break;
                }
                // testing avatar pos part
                if (other.tag == "Pos" && CheckID == other.transform.GetComponent<F_PosID>().PosID)
                {
                    CheckID++;
                    if (CheckID < f_AvatarTesting.PosPosition.Length)
                    {
                        f_AvatarTesting.TestingAvatarPosUpdate(CheckID);
                    }
                    else if (CheckID == f_AvatarTesting.PosPosition.Length)
                    {
                        Debug.Log("start to nb avatar exp guide part");

                        f_AvatarTesting.NbAvatarExpStart(0);
                        f_AvatarTesting.GuideAudioUpdate(0);

                        CheckID = 999;
                    }
                }
                // testing avatar exp part
                if (other.tag == "Exp")
                {
                    switch (other.name)
                    {
                        case "PartA":
                            if(ExpID == 0)
                            {
                                f_AvatarTesting.TestingAvatarExpUpdate(0);
                                ExpID++;
                            }
                            break;

                        case "PartB":
                            if(ExpID == 1)
                            {
                                //f_AvatarTesting.TestingAvatarExpUpdate(1);
                                Debug.Log("Testing finished!");
                                f_AvatarTesting.NbAvatarExpUpdate(4);
                                f_AvatarTesting.GuideAudioUpdate(1);
                                ExpID = 999;
                            }
                            break;
                    }
                }
            }
        }

        // other ...
        if (other.tag == "SPos")
        {
            Debug.Log("Enter");
            other.GetComponent<T_StartPoint>().StartPosChangeColor(2);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // other ...
        if (other.tag == "SPos")
        {
            Debug.Log("Enter");
            other.GetComponent<T_StartPoint>().StartPosChangeColor(2);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        // other ...
        if (other.tag == "SPos")
        {
            Debug.Log("Exit");
            other.GetComponent<T_StartPoint>().StartPosChangeColor(1);
        }
    }
}
