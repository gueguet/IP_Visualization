using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{

    [SerializeField]
    private string[] keywords;
    private KeywordRecognizer voiceRecognizer;
    private GameObject animationController;  

    void Start()
    {

        keywords = new string[1];
        keywords[0] = "Launch";
        voiceRecognizer = new KeywordRecognizer(keywords);
        voiceRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        voiceRecognizer.Start();

        animationController = GameObject.Find("AimationController");

    }


    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {

        //StringBuilder builder = new StringBuilder();
        //builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        //builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        //builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        //Debug.Log(builder.ToString());

        Debug.Log(args.text);


        if (args.text == keywords[0])
        {
            animationController.GetComponent<AnimationController>().StartAnimationPacket(1.5f);
            Debug.Log("ok ca match");
        }

        


    }


    void Update()
    {
        
    }
}
