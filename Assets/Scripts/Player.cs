using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Player : Character {

    [SerializeField]
    private Stat hpBar;

    [SerializeField]
    private Stat mpBar;

    [SerializeField]
    private Stat expBar;

    [SerializeField]
    private int exp;
    [SerializeField]
    private int maxExp;

    [SerializeField]
    private Spell[] spellPrefab;

    private bool attackBlock;

    private Spell currentSpell;
    [SerializeField]
    private int strength;
    [SerializeField]
    private int intelligence;
    [SerializeField]
    private int constitution;
    [SerializeField]
    private int dexterity;
    [SerializeField]
    private int lucky;

    private int level;

    private int knowledgePoint;

    private int attack;
    private int defence;
    private float attackSpeed;

    private int tSTR;


    private int tDEX;

    private int tINT;

    private int tLUK;

    private int tCON;

    private int tKP;

    public Image[] skillbar;

    public Helmet helmet;
    public Weapon weapon;
    public Necklace necklace;
    public Ring ring;
    public Shield shield;
    public Armor armor;
    public Shoes shoes;

    private bool hitable;


    [SerializeField]
    private AudioClip bowaudio;
    [SerializeField]
    private AudioClip magicaudio1;
    [SerializeField]
    private AudioClip magicaudio2;
    [SerializeField]
    private AudioClip attackaudio1;
    [SerializeField]
    private AudioClip attackaudio2;
    [SerializeField]
    private AudioClip attackaudio3;
    [SerializeField]
    private AudioClip levelupaudio3;


    [SerializeField]
    private AudioClip hitaudio;
    [SerializeField]
    private AudioClip hitaudio1;
    [SerializeField]
    private AudioClip hitaudio2;
    [SerializeField]
    private AudioClip hitaudio3;
    [SerializeField]
    private AudioClip hitaudio4;

    private static Player instance;
    public static Player MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    public int MyHp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
    public int MyMp
    {
        get
        {
            return mp;
        }
        set
        {
            mp = value;
        }
    }
    public int MyMaxHp
    {
        get
        {
            return maxHp;
        }
        set
        {
            maxHp = value;
        }
    }
    public int MyMaxMp
    {
        get
        {
            return maxMp;
        }
        set
        {
            maxMp = value;
        }
    }

    public int MySTR
    {
        get
        {
            return strength;
        }
        set
        {
            if (value >= tSTR)
            {
                attack += value - strength;

                strength = value;
            }
        }
    }
    public int MyINT
    {
        get
        {
            return intelligence;
        }
        set
        {
            if (value >= tINT)
            {
                intelligence = value;
            }
        }
    }
    public int MyCON
    {
        get
        {
            return constitution;
        }
        set
        {
            if (value >= tCON)
            {
                constitution = value;
            }
        }
    }
    public int MyDEX
    {
        get
        {
            return dexterity;
        }
        set
        {
            if (value >= tDEX)
            {
                dexterity = value;
            }
        }
    }
    public int MyLUK
    {
        get
        {
            return lucky;
        }
        set
        {
            if (value >= tLUK)
            {
                lucky = value;
            }
        }
    }

    public int MyEXP
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
        }
    }



    public int TSTR
    {
        get
        {
            return tSTR;
        }

        set
        {
            tSTR = value;
        }
    }

    public int TDEX
    {
        get
        {
            return tDEX;
        }

        set
        {
            tDEX = value;
        }
    }

    public int TINT
    {
        get
        {
            return tINT;
        }

        set
        {
            tINT = value;
        }
    }

    public int TLUK
    {
        get
        {
            return tLUK;
        }

        set
        {
            tLUK = value;
        }
    }

    public int TCON
    {
        get
        {
            return tCON;
        }

        set
        {
            tCON = value;
        }
    }

    public int TKP
    {
        get
        {
            return tKP;
        }

        set
        {
            tKP = value;
        }
    }

    public int MyAttack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int MyDefence
    {
        get
        {
            return defence;
        }

        set
        {
            defence = value;
        }
    }
    public float MySpeed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public int MyKP
    {
        get
        {
            return knowledgePoint;
        }

        set
        {
            knowledgePoint = value;
        }
    }

    public float MyASPD
    {
        get
        {
            return attackSpeed;
        }

        set
        {
            attackSpeed = value;
        }
    }

    protected override void Start()
    {
        base.Start();
        hpBar.Initialize(hp, maxHp);
        mpBar.Initialize(mp, maxMp);
        expBar.Initialize(exp, maxExp);
        level = 1;
        ChangeSpell("crossbow1");
        attackBlock = false;
        hitable = true;
        tSTR = strength;
        tDEX = dexterity;
        tLUK = lucky;
        tCON = constitution;
        tINT = intelligence;
        tKP = 0;
        attack = strength;
        defence = 5;
        LoadGame();
    }

    protected override void FixedUpdate()
    {
        GetInput();
        if (hp > maxHp)
            hp = maxHp;
        if (mp > maxMp)
            mp = maxMp;
       // transform.position = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), Mathf.Clamp(transform.position.y, min.y, max.y), transform.position.z);
        hpBar.MyCurrentValue = hp;
        mpBar.MyCurrentValue = mp;
        expBar.MyCurrentValue = exp;
        hpBar.MyMaxValue = maxHp;
        mpBar.MyMaxValue = maxMp;
        base.FixedUpdate();
        if (exp >= maxExp)
        {
            LevelUp();
        }
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        animator.SetInteger("DirectionX", 0);
        animator.SetInteger("DirectionY", 0);
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            animator.SetInteger("DirectionY", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            animator.SetInteger("DirectionY", -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            animator.SetInteger("DirectionX", -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            animator.SetInteger("DirectionX", 1);
        }

        //use for debug
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.RandomizeSfx(levelupaudio3);

        }

        if (Input.GetMouseButtonDown(0) && !attackBlock)
        {
            attackRoutine = StartCoroutine(Attack());
        }
        if (Input.GetMouseButtonDown(1) && !attackBlock)
        {
            attackRoutine = StartCoroutine(NormalAttack());
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSpell(skillbar[0].name);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (skillbar[1].transform.GetChild(0).GetComponent<Image>().color.a != 0)
                ChangeSpell(skillbar[1].name);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (skillbar[2].transform.GetChild(0).GetComponent<Image>().color.a != 0)
                ChangeSpell(skillbar[2].name);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (skillbar[3].transform.GetChild(0).GetComponent<Image>().color.a != 0)
            {
                currentSpell = spellPrefab[7];
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (skillbar[4].transform.GetChild(0).GetComponent<Image>().color.a != 0)
            {
                currentSpell = spellPrefab[8];
            }

        }

    }

    public IEnumerator Attack()
    {
        animator.SetBool("attack", true);
        StartCoroutine(CastSpell());
        attackBlock = true;
        SoundManager.instance.RandomizeSfx(magicaudio1, magicaudio2);
        yield return new WaitForSeconds(attackSpeed + currentSpell.CastTime);  //
        attackBlock = false;

    }
    public IEnumerator NormalAttack()
    {
        animator.SetBool("attack", true);
        Vector2 direction = GameManager.MousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Debug.Log(randomRotation.z);

        // randomRotation.y
        Vector2 positionthis = transform.position;

        if (-45 <= angle && angle <= 45)
        {
            angle = 0;
            positionthis.y += 0.2f;
            positionthis.x += 0.2f;

        }
        else if (45 <= angle && angle <= 135)
        {
            angle = 90;
            positionthis.y += 0.2f;
            positionthis.x -= 0.2f;

        }
        else if (135 <= angle || angle <= -135)
        {
            angle = 180;
            positionthis.y -= 0.2f;
            positionthis.x -= 0.2f;
        }
        else if (-135 <= angle && angle <= -45)
        {
            angle = -90;
            positionthis.y -= 0.2f;
            positionthis.x += 0.2f;
        }
        Quaternion randomRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Instantiate(spellPrefab[9], positionthis, randomRotation);
        SoundManager.instance.RandomizeSfx(attackaudio1, attackaudio2, attackaudio3);
        attackBlock = true;
        yield return new WaitForSeconds(attackSpeed + 0.5f);  //
        attackBlock = false;
    }

    private void LevelUp()
    {
        exp = 0;
        maxExp = (int)(maxExp * 1.02);
        expBar.MyMaxValue = maxExp;
        maxHp = (int)(maxHp * 1.05);
        hpBar.MyMaxValue = maxHp;
        maxMp = (int)(maxMp * 1.05);
        mpBar.MyMaxValue = maxMp;
        hp = maxHp;
        mp = maxMp;
        knowledgePoint += 5;
        tKP = knowledgePoint;
        level++;
        SoundManager.instance.PlaySingle(levelupaudio3);

    }

    public IEnumerator CastSpell()
    {
        Vector2 direction = GameManager.MousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion randomRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (currentSpell.name == "fire2")
        {
            Instantiate(currentSpell, transform.position, randomRotation);
            yield return new WaitForSeconds(0.2f);
            Instantiate(currentSpell, transform.position, randomRotation);
        }
        else if (currentSpell.name == "ice2")
        {
            Instantiate(currentSpell, transform.position, randomRotation);
            yield return new WaitForSeconds(0.2f);
            Instantiate(currentSpell, transform.position, randomRotation);
        }
        else
        {
            Instantiate(currentSpell, transform.position, randomRotation);

        }

    }

    public void ChangeSpell(string newSpellName)
    {
        currentSpell = Array.Find(spellPrefab, x => x.MyName == newSpellName);

    }


    public void ChangeHelmet(Helmet newequipment)
    {
        if (helmet != null)
        {
            strength -= helmet.str;
            defence -= helmet.def;
            speed -= helmet.spd;
            maxHp -= helmet.hp;
            if (hp > maxHp)
                hp = maxHp;
            maxMp -= helmet.mp;
            if (mp > maxMp)
                mp = maxMp;
            strength -= helmet.str;
            constitution -= helmet.con;
            intelligence -= helmet.iNt;
            dexterity -= helmet.dex;
            lucky -= helmet.luk;
        }
        helmet = newequipment;
        attack += helmet.att;
        defence += helmet.def;
        speed += helmet.spd;
        maxHp += helmet.hp;
        maxMp += helmet.mp;

        strength += helmet.str;
        constitution += helmet.con;
        intelligence += helmet.iNt;
        dexterity += helmet.dex;
        lucky += helmet.luk;

        tSTR = strength;
        tDEX = dexterity;
        tLUK = lucky;
        tCON = constitution;
        tINT = intelligence;

        if (CharacterUi.MyInstance.helmet != null)
            BagScript.MyInstance.AddItem(CharacterUi.MyInstance.helmet);
        CharacterUi.MyInstance.helmet = helmet;
    }
    public void ChangeArmor(Armor newequipment)
    {
        if (armor != null)
        {
            strength -= armor.str;
            defence -= armor.def;
            speed -= armor.spd;
            maxHp -= armor.hp;
            if (hp > maxHp)
                hp = maxHp;
            maxMp -= armor.mp;
            if (mp > maxMp)
                mp = maxMp;
            strength -= armor.str;
            constitution -= armor.con;
            intelligence -= armor.iNt;
            dexterity -= armor.dex;
            lucky -= armor.luk;
        }
        armor = newequipment;
        attack += armor.att;
        defence += armor.def;
        speed += armor.spd;
        maxHp += armor.hp;
        maxMp += armor.mp;

        strength += armor.str;
        constitution += armor.con;
        intelligence += armor.iNt;
        dexterity += armor.dex;
        lucky += armor.luk;

        tSTR = strength;
        tDEX = dexterity;
        tLUK = lucky;
        tCON = constitution;
        tINT = intelligence;

        if (CharacterUi.MyInstance.armor != null)
            BagScript.MyInstance.AddItem(CharacterUi.MyInstance.armor);
        CharacterUi.MyInstance.armor = armor;

    }
    public void ChangeNecklace(Necklace newequipment)
    {
        if (necklace != null)
        {
            strength -= necklace.str;
            defence -= necklace.def;
            speed -= necklace.spd;
            maxHp -= necklace.hp;
            if (hp > maxHp)
                hp = maxHp;
            maxMp -= necklace.mp;
            if (mp > maxMp)
                mp = maxMp;
            strength -= necklace.str;
            constitution -= necklace.con;
            intelligence -= necklace.iNt;
            dexterity -= necklace.dex;
            lucky -= necklace.luk;
        }
        necklace = newequipment;
        attack += necklace.att;
        defence += necklace.def;
        speed += necklace.spd;
        maxHp += necklace.hp;
        maxMp += necklace.mp;

        strength += necklace.str;
        constitution += necklace.con;
        intelligence += necklace.iNt;
        dexterity += necklace.dex;
        lucky += necklace.luk;

        tSTR = strength;
        tDEX = dexterity;
        tLUK = lucky;
        tCON = constitution;
        tINT = intelligence;

        if (CharacterUi.MyInstance.necklace != null)
            BagScript.MyInstance.AddItem(CharacterUi.MyInstance.necklace);
        CharacterUi.MyInstance.necklace = necklace;
    }
    public void ChangeRing(Ring newequipment)
    {
        if (ring != null)
        {
            strength -= ring.str;
            defence -= ring.def;
            speed -= ring.spd;
            maxHp -= ring.hp;
            if (hp > maxHp)
                hp = maxHp;
            maxMp -= ring.mp;
            if (mp > maxMp)
                mp = maxMp;
            strength -= ring.str;
            constitution -= ring.con;
            intelligence -= ring.iNt;
            dexterity -= ring.dex;
            lucky -= ring.luk;
        }
        ring = newequipment;
        attack += ring.att;
        defence += ring.def;
        speed += ring.spd;
        maxHp += ring.hp;
        maxMp += ring.mp;

        strength += ring.str;
        constitution += ring.con;
        intelligence += ring.iNt;
        dexterity += ring.dex;
        lucky += ring.luk;

        tSTR = strength;
        tDEX = dexterity;
        tLUK = lucky;
        tCON = constitution;
        tINT = intelligence;

        if (CharacterUi.MyInstance.ring != null)
            BagScript.MyInstance.AddItem(CharacterUi.MyInstance.ring);
        CharacterUi.MyInstance.ring = ring;
    }
    public void ChangeWeapon(Weapon newequipment)
    {
        if (weapon != null)
        {
            strength -= weapon.str;
            defence -= weapon.def;
            speed -= weapon.spd;
            maxHp -= weapon.hp;
            if (hp > maxHp)
                hp = maxHp;
            maxMp -= weapon.mp;
            if (mp > maxMp)
                mp = maxMp;
            strength -= weapon.str;
            constitution -= weapon.con;
            intelligence -= weapon.iNt;
            dexterity -= weapon.dex;
            lucky -= weapon.luk;
            attackSpeed = attackSpeed * (1 + weapon.aspd);
        }
        weapon = newequipment;
        attack += weapon.att;
        defence += weapon.def;
        speed += weapon.spd;
        maxHp += weapon.hp;
        maxMp += weapon.mp;

        strength += weapon.str;
        constitution += weapon.con;
        intelligence += weapon.iNt;
        dexterity += weapon.dex;
        lucky += weapon.luk;
        attackSpeed = attackSpeed * (1 - weapon.aspd);

        tSTR = strength;
        tDEX = dexterity;
        tLUK = lucky;
        tCON = constitution;
        tINT = intelligence;

        if (CharacterUi.MyInstance.weapon != null)
            BagScript.MyInstance.AddItem(CharacterUi.MyInstance.weapon);
        CharacterUi.MyInstance.weapon = weapon;
    }
    public void ChangeShoes(Shoes newequipment)
    {
        if (shoes != null)
        {
            strength -= shoes.str;
            defence -= shoes.def;
            speed -= shoes.spd;
            maxHp -= shoes.hp;
            if (hp > maxHp)
                hp = maxHp;
            maxMp -= shoes.mp;
            if (mp > maxMp)
                mp = maxMp;
            strength -= shoes.str;
            constitution -= shoes.con;
            intelligence -= shoes.iNt;
            dexterity -= shoes.dex;
            lucky -= shoes.luk;
        }
        shoes = newequipment;
        attack += shoes.att;
        defence += shoes.def;
        speed += shoes.spd;
        maxHp += shoes.hp;
        maxMp += shoes.mp;

        strength += shoes.str;
        constitution += shoes.con;
        intelligence += shoes.iNt;
        dexterity += shoes.dex;
        lucky += shoes.luk;

        tSTR = strength;
        tDEX = dexterity;
        tLUK = lucky;
        tCON = constitution;
        tINT = intelligence;

        if (CharacterUi.MyInstance.shoes != null)
            BagScript.MyInstance.AddItem(CharacterUi.MyInstance.shoes);
        CharacterUi.MyInstance.shoes = shoes;
    }
    public void ChangeShield(Shield newequipment)
    {
        if (shield != null)
        {
            strength -= shield.str;
            defence -= shield.def;
            speed -= shield.spd;
            maxHp -= shield.hp;
            if (hp > maxHp)
                hp = maxHp;
            maxMp -= shield.mp;
            if (mp > maxMp)
                mp = maxMp;
            strength -= shield.str;
            constitution -= shield.con;
            intelligence -= shield.iNt;
            dexterity -= shield.dex;
            lucky -= shield.luk;
        }
        shield = newequipment;
        attack += shield.att;
        defence += shield.def;
        speed += shield.spd;
        maxHp += shield.hp;
        maxMp += shield.mp;

        strength += shield.str;
        constitution += shield.con;
        intelligence += shield.iNt;
        dexterity += shield.dex;
        lucky += shield.luk;

        tSTR = strength;
        tDEX = dexterity;
        tLUK = lucky;
        tCON = constitution;
        tINT = intelligence;

        if (CharacterUi.MyInstance.shield != null)
            BagScript.MyInstance.AddItem(CharacterUi.MyInstance.shield);
        CharacterUi.MyInstance.shield = shield;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

    }
    public override void TakeDamage(int damage)
    {
        damage = damage - defence;
        if (damage > 1)
        {
            hp -= damage;
        }
        else
        {
            hp -= 1;
        }
        if (hp <= 0)
        {
            Invoke("ChangeNextScene", 2);

            die = true;
        }
            StartCoroutine(ChangeHitable());
        
    }
  
    private void ChangeNextScene()
    {
        ChangeScene c = new ChangeScene();
        c.loadNextScene("End");
    }

    public IEnumerator ChangeHitable()
    {
        hitable = false;
        Player.MyInstance.gameObject.layer = 15;
        //  GetComponent<BoxCollider2D>().enabled = 
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        hitable = true;
        Player.MyInstance.gameObject.layer = 13;


    }


    public Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.kpRemain = 10;
        return save;
    }
    public void SaveGame()
    {
        Save save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }
    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            // 3
            Player.MyInstance.MyKP = save.kpRemain;

            Debug.Log("Game Loaded");

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
    public void hitAudio()
    {
        SoundManager.instance.RandomizeSfx2(hitaudio);
    }
    public void mhitAudio()
    {
        SoundManager.instance.RandomizeSfx2(hitaudio1,hitaudio2,hitaudio3,hitaudio4);
    }
}
