using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

public class SkillLearnScript : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Image skillImage;
  //  [SerializeField]
  //  private GameObject itemIntroduction;
    [SerializeField]
    private string skillname;
    [SerializeField]
    private string skillintroduction;
    public bool canLearn;
    [SerializeField]
    private Image nextSkill;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && Player.MyInstance.MyKP >0&&canLearn)
        {
            
        switch (transform.GetChild(0).name)
        {
            case "crossbow2":
                    {
                        if (Player.MyInstance.MyKP > 6)
                        {
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.skillbar[0].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.sprite;
                            Player.MyInstance.skillbar[0].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            Player.MyInstance.skillbar[0].name = "crossbow2";
                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyKP -= 7;
                        }
                    }
                break;
                case "crossbow3":
                    {
                        if (Player.MyInstance.MyKP > 17)
                        {
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.skillbar[0].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.sprite;
                            Player.MyInstance.skillbar[0].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            Player.MyInstance.skillbar[0].name = "crossbow3";
                            Player.MyInstance.MyKP -= 18;

                        }
                    }
                    break;
                case "fire1":
                    {
                        if (Player.MyInstance.MyKP > 4)
                        {
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.skillbar[1].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.sprite;
                            Player.MyInstance.skillbar[1].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            Player.MyInstance.skillbar[1].name = "fire1";

                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyKP -= 5;

                        }

                    }
                    break;
                case "fire2":
                    {
                        if (Player.MyInstance.MyKP > 11)
                        {
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.skillbar[1].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.sprite;
                            Player.MyInstance.skillbar[1].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            Player.MyInstance.skillbar[1].name = "fire2";
                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyKP -= 12;

                        }
                    }
                    break;
                case "ice1":
                    {
                        if (Player.MyInstance.MyKP > 4)
                        {
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.skillbar[2].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.sprite;
                            Player.MyInstance.skillbar[2].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            Player.MyInstance.skillbar[2].name = "ice1";

                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyKP -= 5;

                        }
                    }
                    break;
                case "ice2":
                    {
                        if (Player.MyInstance.MyKP > 11)
                        {
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.skillbar[2].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.sprite;
                            Player.MyInstance.skillbar[2].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            Player.MyInstance.skillbar[2].name = "ice2";

                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyKP -= 12;

                        }
                    }
                    break;
                case "thunder":
                    {
                        if (Player.MyInstance.MyKP > 25)
                        {
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.skillbar[3].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.sprite;
                            Player.MyInstance.skillbar[3].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            Player.MyInstance.skillbar[3].name = "thunder";
                            Player.MyInstance.MyKP -= 26;

                        }
                    }
                    break;
                case "storm":
                    {
                        if (Player.MyInstance.MyKP > 25)
                        {
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.skillbar[4].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.sprite;
                            Player.MyInstance.skillbar[4].transform.GetChild(0).GetComponent<Image>().color = Color.white;
                            Player.MyInstance.skillbar[4].name = "storm";
                            Player.MyInstance.MyKP -= 26;

                        }
                    }
                    break;
                case "speed1":
                    {
                        if (Player.MyInstance.MyKP > 3)
                        {
                            Player.MyInstance.MyKP -= 4;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MySpeed += 0.1f;
                        }
                    }
                    break;
                case "speed2":
                    {
                        if (Player.MyInstance.MyKP > 9)
                        {
                            Player.MyInstance.MyKP -= 10;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MySpeed += 0.2f;

                        }
                    }
                    break;
                case "speed3":
                    {
                        if (Player.MyInstance.MyKP > 15)
                        {
                            Player.MyInstance.MyKP -= 16;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.MySpeed += 0.3f;
                        }
                    }
                    break;
                case "health1":
                    {
                        if (Player.MyInstance.MyKP > 3)
                        {
                            Player.MyInstance.MyKP -= 4;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyMaxHp = (int)(Player.MyInstance.MyMaxHp * 1.1f);

                        }
                    }
                    break;
                case "health2":
                    {
                        if (Player.MyInstance.MyKP > 9)
                        {
                            Player.MyInstance.MyKP -= 10;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyMaxHp = (int)(Player.MyInstance.MyMaxHp * 1.1f);

                        }
                    }
                    break;
                case "health3":
                    {
                        if (Player.MyInstance.MyKP > 15)
                        {
                            Player.MyInstance.MyKP -= 16;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.MyMaxHp = (int)(Player.MyInstance.MyMaxHp * 1.1f);

                        }
                    }
                    break;
                case "defence1":
                    {
                        if (Player.MyInstance.MyKP > 3)
                        {
                            Player.MyInstance.MyKP -= 4;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyDefence += 10;

                        }
                    }
                    break;
                case "defence2":
                    {
                        if (Player.MyInstance.MyKP > 9)
                        {
                            Player.MyInstance.MyKP -= 10;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            nextSkill.GetComponent<SkillLearnScript>().canLearn = true;
                            Player.MyInstance.MyDefence += 10;

                        }
                    }
                    break;
                case "defence3":
                    {
                        if (Player.MyInstance.MyKP > 15)
                        {
                            Player.MyInstance.MyKP -= 16;
                            skillImage = transform.GetChild(0).GetComponent<Image>();
                            skillImage.material = null;
                            Player.MyInstance.MyDefence += 10;

                        }
                    }
                    break;
            }

   

}
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //transform.GetComponent<Image>().color = Color.red;
        }
        //    Debug.Log(skillImage.name);

    }

    // Use this for initialization
    void Start () {
        //itemIntroduction = Instantiate(itemIntroduction);
        

    }

    // Update is called once per frame
    void Update () {
		
	}
    GameObject obj;
    public void OnPointerEnter(PointerEventData eventData)
    {

            Vector2 position;


            Canvas canvas = FindObjectOfType<Canvas>();
        obj = Instantiate(Resources.Load("ItemIntroduce")) as GameObject;
        obj.GetComponent<IntroductionMenuScript>().MyItemName.text = skillname;
        obj.GetComponent<IntroductionMenuScript>().MyIntroduction.text = skillintroduction;
        obj.GetComponent<IntroductionMenuScript>().MyDetail.text = "";
        obj.transform.SetParent(canvas.transform);

        // itemIntroduction.transform.SetParent(canvas.transform);

        // Debug.Log(cornerall[3]/2);
        //  Debug.Log(cornersthis[3]);

        position.x = Input.mousePosition.x - 110;
            position.y = Input.mousePosition.y - 140;
         //   itemIntroduction.transform.position = position;
        //    itemIntroduction.GetComponent<IntroductionMenuScript>().Show();
        obj.transform.position = position;
        obj.GetComponent<IntroductionMenuScript>().Show();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(obj);
    }
}
