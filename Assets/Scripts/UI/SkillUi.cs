using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUi : MonoBehaviour {


    private static SkillUi instance;
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Text sp;
    public static SkillUi MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SkillUi>();
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
        sp.text = ""+Player.MyInstance.MyKP;

    }
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

    }

    public void OpenClose()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;

        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;

    }
}
