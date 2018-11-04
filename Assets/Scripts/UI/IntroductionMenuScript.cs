using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionMenuScript : MonoBehaviour {

    private CanvasGroup canvasGroup;
    [SerializeField]
    private Text itemName;

    [SerializeField]
    private Text introduction;
    [SerializeField]
    private Text detail;
    // Use this for initialization

        void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public bool IsOpen
    {
        get
        {
            return canvasGroup.alpha > 0;
        }
    }

    public Text MyItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }
    public Text MyIntroduction
    {
        get
        {
            return introduction;
        }

        set
        {
            introduction = value;
        }
    }
    public Text MyDetail
    {
        get
        {
            return detail;
        }

        set
        {
            detail = value;
        }
    }
    public void Show()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;

        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
    }
}
