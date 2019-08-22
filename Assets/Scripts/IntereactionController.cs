using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntereactionController : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    public Text IPInfoText;

    // static to be referenced in the other scripts
    // public static string selectedObject;
    private GameObject selectedObject;
    private Material highlightMat, originDstMat;
    private string lastSelectedObjectName = "";

    void Start()
    {
        originDstMat = (Material)Resources.Load("DestinationIPMat");
        highlightMat = (Material)Resources.Load("HighlightMat");
    }


    void Update()
    {
        createRaycast();
    }


    // ---------------- Raycast ----------------- //
    private void createRaycast()
    {

        // get the left button of the mouse
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);



            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.name != lastSelectedObjectName)
                {
                    Debug.Log("new object touch");
                    selectedObject = hit.transform.gameObject;

                    Debug.Log("Selected name : " + selectedObject.name);

                    IPInfoText.text = "IP address : " + selectedObject.name;
                    selectedObject.GetComponent<Renderer>().material = highlightMat;

                    if (lastSelectedObjectName != "")
                    {
                        GameObject.Find(lastSelectedObjectName).GetComponent<Renderer>().material = originDstMat;

                    }

                    Debug.Log("last object selected name : " + lastSelectedObjectName);
                    lastSelectedObjectName = selectedObject.name;


                }

                else
                {

                }


            }
        }
    }


}
