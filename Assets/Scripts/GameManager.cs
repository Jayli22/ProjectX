using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GameManager : MonoBehaviour {

    [SerializeField]
    private Player player;

    private bool isChange;
    private int level;

    public static Vector3 MousePosition;
    private static GameManager instance;

    private Bag bag;

    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }


    public Bag Bag
    {
        get
        {
            return bag;
        }

        set
        {
            bag = value;
        }
    }

    // Use this for initialization
    void Start () {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      
    }
    private void Awake()
    {
        isChange = false;
        level = 1;
        LoadLevel(level);
        //Object tilemapobj = Resources.Load("Map/b1");
        //GameObject nMap =  Instantiate(tilemapobj) as GameObject ;
        //player.transform.position = nMap.GetComponent<MonsterPosition>().playerposition.transform.position;

        //Object monster = Resources.Load("Enemy/LizardMan");
        //Enemy oEnemy = Instantiate(monster, 
        //    nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.position, 
        //    nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.rotation) as Enemy;
        //oEnemy.transform.position = nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.position;
        // Grid grid = Instantiate(tilemapobj) as Grid;
        // instance.GetComponent<CameraFollow>().tilemap = GetTransform(grid.transform, "Ground").gameObject.GetComponent<Tilemap>(); 
        //foreach(Transform child in grid.transform)
        //{
        //    Debug.Log(child.gameObject.name);
        //    Debug.Log(GetTransform(grid.transform, "Ground").gameObject.name;
        //}
        //grid.transform.GetChild(0).GetComponent<Tilemap>() ;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryScript.MyInstance.OpenClose();
            if(CharacterUi.MyInstance.IsOpen)
                CharacterUi.MyInstance.OpenClose();
            if (SetUi.MyInstance.IsOpen)
                SetUi.MyInstance.OpenClose();
            if (SkillUi.MyInstance.IsOpen)
                SkillUi.MyInstance.OpenClose();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CharacterUi.MyInstance.OpenClose();
            if (InventoryScript.MyInstance.IsOpen)
                InventoryScript.MyInstance.OpenClose();
            if (SetUi.MyInstance.IsOpen)
                SetUi.MyInstance.OpenClose();
            if (SkillUi.MyInstance.IsOpen)
                SkillUi.MyInstance.OpenClose();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SkillUi.MyInstance.OpenClose();
            if (CharacterUi.MyInstance.IsOpen)
                CharacterUi.MyInstance.OpenClose();
            if (SetUi.MyInstance.IsOpen)
                SetUi.MyInstance.OpenClose();
            if (InventoryScript.MyInstance.IsOpen)
                InventoryScript.MyInstance.OpenClose();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetUi.MyInstance.OpenClose();
            if (CharacterUi.MyInstance.IsOpen)
                CharacterUi.MyInstance.OpenClose();
            if (InventoryScript.MyInstance.IsOpen)
                InventoryScript.MyInstance.OpenClose();
            if (SkillUi.MyInstance.IsOpen)
                SkillUi.MyInstance.OpenClose();
        }
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Map"));
            if (isChange == false)
            {
                ChangeSceneAnimation.MyInstance.MyStatus = ChangeSceneAnimation.FadeStatus.FadeIn;
                isChange = true;
                level++;

            }
            if (ChangeSceneAnimation.MyInstance.MyCanvas.alpha < 0.1 && ChangeSceneAnimation.MyInstance.MyStatus == ChangeSceneAnimation.FadeStatus.FadeOut)
            {
                LoadLevel(level);
                isChange = false;
            }
                //   GetComponent<CameraFollow>().ChangeMap();
            
        }

    }

    public void UpdateStackSize(IClickable clickable)
    {
        if(clickable.MyCount == 0)
        {
            clickable.MyIcon.color = new Color(0, 0, 0, 0);
        }
    }

    Transform GetTransform(Transform check, string name)
    {
        foreach (Transform t in check.transform)
        {
            if (t.gameObject.name == name) { return t; }
            GetTransform(t, name);
            instance.GetComponent<CameraFollow>().ChangeMap();
        }
        return null;
    }

    public void LoadBoss(int level)
    {
        switch (level)
        {
            case 10:
                {
                    Object tilemapobj = Resources.Load("Map/b1");
                    GameObject nMap = Instantiate(tilemapobj) as GameObject;
                    player.transform.position = nMap.GetComponent<MonsterPosition>().playerposition.transform.position;

                    Object monster = Resources.Load("Enemy/LizardMan");
                    Enemy oEnemy = Instantiate(monster,
                        nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.position,
                        nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.rotation) as Enemy;
                    break;
                }
            case 20:
                {
                    Object tilemapobj = Resources.Load("Map/b2");
                    GameObject nMap = Instantiate(tilemapobj) as GameObject;
                    player.transform.position = nMap.GetComponent<MonsterPosition>().playerposition.transform.position;

                    Object monster = Resources.Load("Enemy/Pumpkin");
                    Enemy oEnemy = Instantiate(monster,
                        nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.position,
                        nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.rotation) as Enemy;
                    break;
                }
            case 30:
                {
                    Object tilemapobj = Resources.Load("Map/b3");
                    GameObject nMap = Instantiate(tilemapobj) as GameObject;
                    player.transform.position = nMap.GetComponent<MonsterPosition>().playerposition.transform.position;

                    Object monster = Resources.Load("Enemy/Undead");
                    Enemy oEnemy = Instantiate(monster,
                        nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.position,
                        nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.rotation) as Enemy;
                    break;
                }
            case 40:
                {
                    Object tilemapobj = Resources.Load("Map/b4");
                    GameObject nMap = Instantiate(tilemapobj) as GameObject;
                    player.transform.position = nMap.GetComponent<MonsterPosition>().playerposition.transform.position;

                    Object monster = Resources.Load("Enemy/RedEye");
                    Enemy oEnemy = Instantiate(monster,
                        nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.position,
                        nMap.GetComponent<MonsterPosition>().monsterposition[0].transform.rotation) as Enemy;

                     monster = Resources.Load("Enemy/GreenEye");
                     oEnemy = Instantiate(monster,
                        nMap.GetComponent<MonsterPosition>().monsterposition[1].transform.position,
                        nMap.GetComponent<MonsterPosition>().monsterposition[1].transform.rotation) as Enemy;
                    break;
                }
        }
       
    }
    public void LoadLevel(int level)
    {
        if (level == 10 || level == 20 || level == 30 || level == 40)
        {
            LoadBoss(level);
        }
        else
        {
            Object tilemapobj = Resources.Load("Map/1");
            Object monster = Resources.Load("Enemy/Bat");
            int i = Random.Range(1, 13);

            switch (i)
            {
                case 1:
                    {
                        tilemapobj = Resources.Load("Map/1");
                        break;
                    }
                case 2:
                    {
                        tilemapobj = Resources.Load("Map/2");
                        break;
                    }
                case 3:
                    {
                        tilemapobj = Resources.Load("Map/3");
                        break;
                    }
                case 4:
                    {
                        tilemapobj = Resources.Load("Map/4");
                        break;
                    }
                case 5:
                    {
                        tilemapobj = Resources.Load("Map/c1");
                        break;
                    }
                case 6:
                    {
                        tilemapobj = Resources.Load("Map/c2");
                        break;
                    }
                case 7:
                    {
                        tilemapobj = Resources.Load("Map/c3");
                        break;
                    }
                case 8:
                    {
                        tilemapobj = Resources.Load("Map/c4");
                        break;
                    }
                case 9:
                    {
                        tilemapobj = Resources.Load("Map/c5");
                        break;
                    }
                case 10:
                    {
                        tilemapobj = Resources.Load("Map/c6");
                        break;
                    }
                case 11:
                    {
                        tilemapobj = Resources.Load("Map/c7");
                        break;
                    }
                case 12:
                    {
                        tilemapobj = Resources.Load("Map/c8");
                        break;
                    }

            }

            GameObject nMap = Instantiate(tilemapobj) as GameObject;
            player.transform.position = nMap.GetComponent<MonsterPosition>().playerposition.transform.position;

            if (level < 10)
            {

                int monsternumber = Random.Range(1, 5);
                for (int x = 1; x <= monsternumber; x++)
                {
                    int tPosition = Random.Range(0, 5);

                    float monsterTypepar = Random.Range(0f, 1f);
                    if (monsterTypepar < 0.25)
                    {
                        monster = Resources.Load("Enemy/Bat");

                    }
                    else if (monsterTypepar >= 0.25 && monsterTypepar < 0.5)
                    {
                        monster = Resources.Load("Enemy/Spider");

                    }
                    else if (monsterTypepar >= 0.5 && monsterTypepar < 0.75)
                    {
                        monster = Resources.Load("Enemy/Caterpillar");

                    }
                    else if (monsterTypepar >= 0.75)
                    {
                        monster = Resources.Load("Enemy/Octopus");

                    }

                    Enemy oEnemy = Instantiate(monster,
                nMap.GetComponent<MonsterPosition>().monsterposition[tPosition].transform.position,
                nMap.GetComponent<MonsterPosition>().monsterposition[tPosition].transform.rotation) as Enemy;
                }
            }
            else if (level < 20)
            {

                int monsternumber = Random.Range(2, 6);
                for (int x = 1; x <= monsternumber; x++)
                {
                    int tPosition = Random.Range(0, 5);

                    float monsterTypepar = Random.Range(0f, 1f);
                    if (monsterTypepar < 0.25)
                    {
                        monster = Resources.Load("Enemy/Slime");

                    }
                    else if (monsterTypepar >= 0.25 && monsterTypepar < 0.5)
                    {
                        monster = Resources.Load("Enemy/Ghost");

                    }
                    else if (monsterTypepar >= 0.5 && monsterTypepar < 0.75)
                    {
                        monster = Resources.Load("Enemy/GreenSlime");

                    }
                    else if (monsterTypepar >= 0.75 && monsterTypepar < 0.9)
                    {
                        monster = Resources.Load("Enemy/Caterpillar");

                    }
                    else if (monsterTypepar >= 0.9)
                    {
                        monster = Resources.Load("Enemy/Feufollet");

                    }
                    Enemy oEnemy = Instantiate(monster,
                nMap.GetComponent<MonsterPosition>().monsterposition[tPosition].transform.position,
                nMap.GetComponent<MonsterPosition>().monsterposition[tPosition].transform.rotation) as Enemy;
                }
            }
            else if (level < 30)
            {

                int monsternumber = Random.Range(3, 6);
                for (int x = 1; x <= monsternumber; x++)
                {
                    int tPosition = Random.Range(0, 5);

                    float monsterTypepar = Random.Range(0f, 1f);
                    if (monsterTypepar < 0.2)
                    {
                        monster = Resources.Load("Enemy/Grok");

                    }
                    else if (monsterTypepar >= 0.2 && monsterTypepar < 0.4)
                    {
                        monster = Resources.Load("Enemy/Skull");

                    }
                    else if (monsterTypepar >= 0.4 && monsterTypepar < 0.5)
                    {
                        monster = Resources.Load("Enemy/GreenSlime");

                    }
                    else if (monsterTypepar >= 0.6 && monsterTypepar < 0.8)
                    {
                        monster = Resources.Load("Enemy/Feufollet");

                    }
                    else if (monsterTypepar >= 0.8)
                    {
                        monster = Resources.Load("Enemy/RedFeufollet");

                    }
                    Enemy oEnemy = Instantiate(monster,
                nMap.GetComponent<MonsterPosition>().monsterposition[tPosition].transform.position,
                nMap.GetComponent<MonsterPosition>().monsterposition[tPosition].transform.rotation) as Enemy;
                }
            }
            else
            {
                {

                    int monsternumber = 5;
                    for (int x = 1; x <= monsternumber; x++)
                    {
                        int tPosition = Random.Range(0, 5);

                        float monsterTypepar = Random.Range(0f, 1f);
                        if (monsterTypepar < 0.125)
                        {
                            monster = Resources.Load("Enemy/Grok");

                        }
                        else if (monsterTypepar >= 0.125 && monsterTypepar < 0.25)
                        {
                            monster = Resources.Load("Enemy/BlueCrocodile");

                        }
                        else if (monsterTypepar >= 0.25 && monsterTypepar < 0.375)
                        {
                            monster = Resources.Load("Enemy/Redcaterpillar");

                        }
                        else if (monsterTypepar >= 0.375 && monsterTypepar < 0.5)
                        {
                            monster = Resources.Load("Enemy/victreebel");

                        }
                        else if (monsterTypepar >= 0.5 && monsterTypepar < 0.625)
                        {
                            monster = Resources.Load("Enemy/Mole");

                        }
                        else if (monsterTypepar >= 0.625 && monsterTypepar < 0.75)
                        {
                            monster = Resources.Load("Enemy/DungBeetle");

                        }
                        else if (monsterTypepar >= 0.75 && monsterTypepar < 0.875)
                        {
                            monster = Resources.Load("Enemy/Squirrel");

                        }
                        else if (monsterTypepar >= 0.875)
                        {
                            monster = Resources.Load("Enemy/LizardMan");

                        }
                        Enemy oEnemy = Instantiate(monster,
                    nMap.GetComponent<MonsterPosition>().monsterposition[tPosition].transform.position,
                    nMap.GetComponent<MonsterPosition>().monsterposition[tPosition].transform.rotation) as Enemy;
                    }
                }
            }


        }
    }
}
