using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Valve.VR;
using UnityEngine.SceneManagement;

public class VRInputTest : BaseInputModule
{

    // UI
    public Text inputTextTest;

    // target source is the controller we want to use --> here the right hand
    public SteamVR_Input_Sources m_TargetSource;

    // this is the input of the controller --> here the trigger
    public SteamVR_Action_Boolean m_ClickAction;

    private PointerEventData m_Data = null;
    
    protected override void Awake()
    {
        base.Awake();

        m_Data = new PointerEventData(eventSystem);
    }

    // call like Update
    public override void Process()
    {




        // press
        if (m_ClickAction.GetStateDown(m_TargetSource))
        {
            inputTextTest.text = "trigger down";
            //actionText.text = "trigger down";

        }

        //release 
        if (m_ClickAction.GetStateUp(m_TargetSource))
        {
            inputTextTest.text = "trigger up";
            //actionText.text = "trigger up";

        }



    }

    public PointerEventData GetData()
    {
        return m_Data;
    }

    private void ProcessPress(PointerEventData data)
    {

    }


    private void ProcessRelease(PointerEventData data)
    {

    }





}
