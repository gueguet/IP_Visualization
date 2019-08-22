using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



// class to represent coordinates of a IP
public class PacketAnim
{
    public float packetDuration;
    public string srcIP, dstIP, packetTime;

    public PacketAnim(string srcIP, string dstIP, string packetTime, float packetDuration)
    {
        this.srcIP = srcIP;
        this.dstIP = dstIP;
        this.packetTime = packetTime;
        this.packetDuration = packetDuration;
    }

    public string getPacketInfo()
    {
        return ("Packet : " + srcIP + " / " + dstIP + " / " + packetTime + " / " + packetDuration);
    }
}


public class AnimationController : MonoBehaviour
{

    
    public GameObject packetPrefab;
    private List<PacketAnim> packetList = new List<PacketAnim>();

    public Text packetInfoText, packetTimeText;
    private GameObject soundManager;

    private IEnumerator coroutine;



    void Start()
    {
        ReadFlowData();
        soundManager = GameObject.Find("SoundManager");


    }


    void Update()
    {


        if (Input.GetKeyDown("b"))
        {
            Debug.Log("b pressed");

            coroutine = StartAnimationPacket(1.0f);
            StartCoroutine(coroutine);

        }



    }



    // -------------------------------------- READ FLOW DATA CSV
    void ReadFlowData()
    {
        // we have to store our csv in the resources folder to be accessible after the building if the app
        TextAsset fileData = Resources.Load<TextAsset>("FlowData/TestFlowCsv");

        // retrieve each line of the csv as a new string
        string[] flowData = fileData.text.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
        );

        // iterate through the IP data
        for (var i = 0; i < flowData.Length - 1; i++)
        {
            string[] flowArray = flowData[i].Split(',');

            // extract the value of the IP src --> store as spherique coordinates first
            var srcIP = flowArray[0];
            var dstIP = flowArray[1];
            var flowTime = flowArray[7];
            var flowDuration = float.Parse(flowArray[6]);

            var packet = new PacketAnim(srcIP, dstIP, flowTime, flowDuration);
            packetList.Add(packet);

            Debug.Log(i.ToString());
            
        }

        Debug.Log("We have " + packetList.Count + " packets to show");



    }


    public IEnumerator StartAnimationPacket(float waitTime)
    {

        

        foreach (PacketAnim currentPacket in packetList)
        {

            Debug.Log("yo package sent");

            var dstNode = GameObject.Find(currentPacket.dstIP);
            var srcNode = GameObject.Find(currentPacket.srcIP);

            Vector3 pos = srcNode.transform.position;

            var packet = Instantiate(packetPrefab, pos, Quaternion.identity);
            iTween.MoveTo(packet, dstNode.transform.position, 2.0f);

            soundManager.GetComponent<SoundController>().PlayPacketAnim();

            packetTimeText.text = currentPacket.packetTime; 
            packetInfoText.text += currentPacket.getPacketInfo() + "\n";

            yield return new WaitForSeconds(waitTime);
        }





        

    }



}
