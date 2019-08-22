using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



// class to represent coordinates of a IP
public class IPCoord
{
    public float x, y, z;
    public string nodeType;

    public IPCoord(float x, float y, float z, string nodeType)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.nodeType = nodeType;
    }

    public string getCoord()
    {
        return ("Coord : " + x + "." + y + "." + z);
    }
}


// Script to read csv info about the IP adresses and place it into our scene 
public class PlaceIPController : MonoBehaviour
{

    // prefab for the node to instantiate
    public GameObject nodeSrcPrefab;
    public GameObject nodeDstPrefab;

    // base cube and its origin
    public GameObject baseCubePrefab;
    public GameObject baseCubeOrigin;


    // store the maximum of each coordinate 
    //private List<float> x_coord_list = new List<float>();
    private float x_max = 0;
    private float y_max = 0;
    private float z_max = 0;

    // store each IP in a array
    private List<IPCoord> IPArray = new List<IPCoord>();



    // -------------------------------------- START
    void Start()
    {
        // extract values of all IP adresses
        ReadSourceCsv();
        ReadDestinationCsv();


        PlaceIP();
    }



    // -------------------------------------- UPDATE
    void Update()
    {

        // if we want to retrieve all the stored IP coordinates
        if (Input.GetKeyDown("r"))
        {
            foreach(IPCoord ipcoord in IPArray) {
                Debug.Log(ipcoord.getCoord());
            }
        }

        // if we want to retireve all the maximum coordinates stored
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("max x : " + x_max);
            Debug.Log("max y : " + y_max);
            Debug.Log("max z : " + z_max);
        }


    }



    // -------------------------------------- READ SOURCE IP CSV
    void ReadSourceCsv()
    {
        // we have to store our csv in the resources folder to be accessible after the building if the app
        TextAsset fileData = Resources.Load<TextAsset>("IP/disctinct_src_nodes");

        // retrieve each line of the csv as a new string
        string[] linesData = fileData.text.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
        );

        // iterate through the IP data
        for (var i = 0; i < linesData.Length - 1; i++)
        {
            string[] rowArray = linesData[i].Split(',');
            var src_ip = rowArray[0];

            // extract the value of the IP src --> store as spherique coordinates first
            var x_ip = float.Parse(rowArray[1]);
            var y_ip = float.Parse(rowArray[2]);
            var z_ip = float.Parse(rowArray[3]);

            // new instance of IPCoord and save it into the main List of IP
            var currentIP = new IPCoord(x_ip, y_ip, z_ip, "sourceNode");
            IPArray.Add(currentIP);

            // we upate the maximum of each coordinates
            if (x_ip > x_max)
            {
                x_max = x_ip;
            }
            if (y_ip > y_max)
            {

                y_max = y_ip;
            }
            if (z_ip > z_max)
            {
                z_max = z_ip;
            }
        }
    }



    // -------------------------------------- READ SOURCE IP CSV
    void ReadDestinationCsv()
    {
        // we have to store our csv in the resources folder to be accessible after the building if the app
        TextAsset fileData = Resources.Load<TextAsset>("IP/disctinct_dst_nodes");

        // retrieve each line of the csv as a new string
        string[] linesData = fileData.text.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
        );

        // iterate through the IP data
        for (var i = 0; i < linesData.Length - 1; i++)
        {
            string[] rowArray = linesData[i].Split(',');
            var src_ip = rowArray[0];

            // extract the value of the IP src --> store as spherique coordinates first
            var x_ip = float.Parse(rowArray[1]);
            var y_ip = float.Parse(rowArray[2]);
            var z_ip = float.Parse(rowArray[3]);

            // new instance of IPCoord and save it into the main List of IP
            var currentIP = new IPCoord(x_ip, y_ip, z_ip, "destinationNode");
            IPArray.Add(currentIP);

            // we upate the maximum of each coordinates
            if (x_ip > x_max)
            {
                x_max = x_ip;
            }
            if (y_ip > y_max)
            {

                y_max = y_ip;
            }
            if (z_ip > z_max)
            {
                z_max = z_ip;
            }
        }
    }



    // -------------------------------------- PLACE OUR NODES
    void PlaceIP()
    {
        foreach (IPCoord ipcoord in IPArray)
        {
            var instantiateIp = new GameObject();

            // the prefab is different depending on the type of the node we want to place
            if (ipcoord.nodeType == "sourceNode")
            {
                instantiateIp = Instantiate(nodeSrcPrefab, Vector3.zero, Quaternion.identity);
            }
            else
            {
                instantiateIp = Instantiate(nodeDstPrefab, Vector3.zero, Quaternion.identity);
            }

            // placement based on the origin of our base cube
            instantiateIp.transform.SetParent(baseCubeOrigin.transform);
            instantiateIp.name = ("10." + ipcoord.x + "." + ipcoord.y + "." + ipcoord.z);

            // scale the placement regarding on the maximum possible value for each coordinate ==> use the maximum of space available
            instantiateIp.transform.localPosition = new Vector3((ipcoord.x / x_max), (ipcoord.y / y_max), (ipcoord.z / z_max));
        }


    }


}
