using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUi : MonoBehaviour {

    private static SetUi instance;
    private CanvasGroup canvasGroup;

    public static SetUi MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SetUi>();
            }
            return instance;
        }
    }
    public bool IsOpen
    {
        get
        {
            return canvasGroup.alpha > 0;
        }


    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        canvasGroup = GetComponent<CanvasGroup>();

    }

    public void OpenClose()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;

        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;

    }
}
