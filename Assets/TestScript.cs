using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour {

    public LoopScrollRect loopScrollRect;
    public Text vOffsetLabel;

	// Use this for initialization
	void Start () {
		
	}

    public bool needToScrollDown = true;
    int counter = 0;
    int skipScrollUpdates = 0;
    public bool logToConsole = false;

	// Update is called once per frame
	void Update () {
        if (needToScrollDown) {
            if (skipScrollUpdates == 0) {
                if (loopScrollRect.verticalNormalizedPosition < 1) {
                    //Debug.Log("-----------");
                    //Debug.Log("loopScrollRect: " + loopScrollRect.verticalNormalizedPosition.ToString());
                    loopScrollRect.verticalNormalizedPosition = 1 - (1 - loopScrollRect.verticalNormalizedPosition) * 0.75f;
                    //Debug.Log("loopScrollRect: " + loopScrollRect.verticalNormalizedPosition.ToString());
                }
            } else {
                skipScrollUpdates--;
            }
        }

        vOffsetLabel.text = loopScrollRect.verticalNormalizedPosition.ToString();
        if (logToConsole) {
            Debug.Log(counter.ToString() + " - " + loopScrollRect.verticalNormalizedPosition.ToString());
        }
        counter = counter + 1;
	}

    public void ButtonClick() {
        loopScrollRect.totalCount = loopScrollRect.totalCount + 1;
        loopScrollRect.NewItemAtEnd();
        if (logToConsole) {
            Debug.LogError(counter.ToString() + " - CLICK");
        }
        skipScrollUpdates = 1;
        //loopScrollRect.up
        //needToScrollDown = true;
    }
}
