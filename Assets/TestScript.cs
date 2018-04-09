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

    public static TestScript Instance;

    public bool DisableAutoScroll = false;
    private bool needToScrollDown = true;
    int counter = 0;
    int skipScrollUpdates = 0;
    public bool logToConsole = false;

	private void Awake() {
        Instance = this;
	}

	// Update is called once per frame
	void Update () {
        if (DisableAutoScroll) {
            needToScrollDown = false;
        }

        if (needToScrollDown) {
            if (skipScrollUpdates == 0) {
                if (1 - loopScrollRect.verticalNormalizedPosition > 0.001) {
                    loopScrollRect.verticalNormalizedPosition = 1 - (1 - loopScrollRect.verticalNormalizedPosition) * 0.95f;
                } else {
                    loopScrollRect.verticalNormalizedPosition = 1;
                    needToScrollDown = false;
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
        loopScrollRect.DeleteItemAtEnd();
        loopScrollRect.NewItemAtEnd();
        loopScrollRect.NewItemAtEnd();
        if (logToConsole) {
            Debug.LogError(counter.ToString() + " - CLICK");
        }
        needToScrollDown = true;
        skipScrollUpdates = 1; // verticalNormalizedPosition is actually updated on next frame
        //loopScrollRect.up
        //needToScrollDown = true;
    }
}
