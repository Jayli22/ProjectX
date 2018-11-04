using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeSceneAnimation : MonoBehaviour
{

    private CanvasGroup canvas;
    public float FadeSpeed;
    //等待时间
    public float WaitTime;
    //渐入结束的时间
    private float mFadeInFinishedTime;
    private static ChangeSceneAnimation instance;


    #region 渐入渐出的状态
    public enum FadeStatus
    {
        FadeIn,
        FadeWait,
        FadeOut
    }
    private FadeStatus mStatus = FadeStatus.FadeWait;
    public static ChangeSceneAnimation MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ChangeSceneAnimation>();
            }
            return instance;
        }
    }
    public FadeStatus MyStatus
    {
        get
        {
            return mStatus;
        }

        set
        {
            mStatus = value;
        }
    }

    public CanvasGroup MyCanvas
    {
        get
        {
            return canvas;
        }

        set
        {
            canvas = value;
        }
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
       // SceneAnimated();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SceneAnimated();
    }
    public void SceneAnimated()
    {
        canvas.blocksRaycasts = true;
        switch (mStatus)
        {
            case FadeStatus.FadeIn:
                {
                    canvas.alpha += FadeSpeed * Time.deltaTime;
                    //Time.timeScale = 0.1f;
                }
                break;
            case FadeStatus.FadeOut:
                canvas.alpha -= FadeSpeed * Time.deltaTime;
                break;
            case FadeStatus.FadeWait:
                //当设定为FadeWait时可根据时间判定或者玩家触发进入下一个状态
                if (Time.time > mFadeInFinishedTime + WaitTime)
                {
                    mStatus = FadeStatus.FadeOut;
                }
                break;
        }
        if (canvas.alpha >= 1.0F&&mStatus==FadeStatus.FadeIn)
        {
            mStatus = FadeStatus.FadeWait;
            mFadeInFinishedTime = Time.time;
            canvas.alpha = 1.0F;
           // Time.timeScale = 1f;

        }

        if (canvas.alpha <= 0.0F)
        {
            canvas.alpha = 0f;
            canvas.blocksRaycasts = false;

        }


        //if (mStatus == FadeStatus.FadeWait)
        //{
        //    mStatus = FadeStatus.FadeOut;

        //    //Debug.Log("请按任意键继续");   

        //}
    }
}