using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandle : MonoBehaviour
{



    public void LaunchAnim()
    {

        var animationManager = GameObject.Find("AnimationManager");
        var animationController = animationManager.GetComponent<AnimationController>();
        StartCoroutine(animationController.StartAnimationPacket(1.0f));

    }

}
