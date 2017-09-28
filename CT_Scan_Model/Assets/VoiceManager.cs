using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;


public class VoiceManager : MonoBehaviour {
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	// Use this for initialization
	void Start () {
        keywords.Add("Stay", () =>
        {
            this.BroadcastMessage("StopCalibration");
            Debug.Log("Stay Recognized");
        });
        keywords.Add("Calibrate", () =>
        {
            this.BroadcastMessage("StartCalibration");
            Debug.Log("Calibrate Recognized");
        });
        keywords.Add("Further", () =>
        {
            this.BroadcastMessage("Further");
            Debug.Log("Further Recognized");
        });
        keywords.Add("Closer", () =>
        {
            this.BroadcastMessage("Nearer");
            Debug.Log("Closer Recognized");
        });
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs arg)
    {
        System.Action keywordAction;
        if(keywords.TryGetValue(arg.text, out keywordAction))
        {
            keywordAction.Invoke();
        }

    }
}
