using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUi : MonoBehaviour
{
    [SerializeField]
    private Text strNumber;
    [SerializeField]
    private Text intNumber;
    [SerializeField]
    private Text conNumber;
    [SerializeField]
    private Text dexNumber;
    [SerializeField]
    private Text lukNumber;
    [SerializeField]
    private Text attNumber;
    [SerializeField]
    private Text defNumber;
    [SerializeField]
    private Text spdNumber;
    [SerializeField]
    private Text hpNumber;
    [SerializeField]
    private Text mpNumber;
    [SerializeField]
    private Text apNumber;
    [SerializeField]
    private Text aspdNumber;

    public Helmet helmet;
    public Weapon weapon;
    public Necklace necklace;
    public Ring ring;
    public Shield shield;
    public Armor armor;
    public Shoes shoes;

    public Image headSlot;
    public Image necklaceSlot;
    public Image armorSlot;
    public Image shieldSlot;
    public Image ringSlot;
    public Image weaponSlot;
    public Image shoesSlot;

    private static CharacterUi instance;
    private CanvasGroup canvasGroup;

    private Player player;

    public static CharacterUi MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterUi>();
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
        player = Player.MyInstance;
	}
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    // Update is called once per frame
    void Update() {
        strNumber.text = "" + player.MySTR;
        intNumber.text = "" + player.MyINT;
        conNumber.text = "" + player.MyCON;
        dexNumber.text = "" + player.MyDEX;
        lukNumber.text = "" + player.MyLUK;
        apNumber.text = "" + player.MyKP;
        attNumber.text = "" + player.MyAttack;
        defNumber.text = "" + player.MyDefence;
        spdNumber.text = "" + player.MySpeed;
        hpNumber.text = "" + player.MyMaxHp;
        mpNumber.text = "" + player.MyMaxMp;
        aspdNumber.text = "" + player.MyASPD;

        if (helmet != null)
        {
            headSlot.sprite = helmet.MyIcon;
            headSlot.GetComponent<EquipmentSlot>().equipment = helmet;
        }
        if (weapon != null)
        {
            weaponSlot.sprite = weapon.MyIcon;
            weaponSlot.GetComponent<EquipmentSlot>().equipment = weapon;
        }
        if (necklace != null)
        {
            necklaceSlot.sprite = necklace.MyIcon;
            necklaceSlot.GetComponent<EquipmentSlot>().equipment = necklace;
        }
        if (armor != null)
        {
            armorSlot.sprite = armor.MyIcon;
            armorSlot.GetComponent<EquipmentSlot>().equipment = armor;

        }
        if (ring != null)
        {
            ringSlot.sprite = ring.MyIcon;
            ringSlot.GetComponent<EquipmentSlot>().equipment = ring;

        }
        if (shoes != null)
        {
            shoesSlot.sprite = shoes.MyIcon;
            shoesSlot.GetComponent<EquipmentSlot>().equipment = shoes;

        }
        if (shield != null)
        {
            shieldSlot.sprite = shield.MyIcon;
            shieldSlot.GetComponent<EquipmentSlot>().equipment = shield;

        }
    }

    public void OpenClose()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;

        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;

    }
}
