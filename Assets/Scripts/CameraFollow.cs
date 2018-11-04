using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour {

    private Transform target;
    private float xMax, xMin, yMin, yMax;

    public Tilemap tilemap;
    private Player player;

    [SerializeField]
    public TileData tiled;

    [SerializeField]
    private Enemy[] enemy;
	// Use this for initialization
	void Start () {
       // tilemap = GetTransform(GameObject.FindGameObjectWithTag("Map").transform, "Ground").GetComponent<Tilemap>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = target.GetComponent<Player>();
       // Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
       // Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);
       // SetLimits(minTile, maxTile);
        //player.Setlimits(minTile, maxTile);
        }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(target.position.x,target.position.y,-10);
	}

    private void SetLimits(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;

        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;

    }


    Transform GetTransform(Transform check, string name)
    {
        foreach (Transform t in check.transform)
        {
            if (t.gameObject.name == name) { return t; }
            GetTransform(t, name);
        }
        return null;
    }
    public void ChangeMap()
    {
        tilemap = GetTransform(GameObject.FindGameObjectWithTag("Map").transform, "Ground").GetComponent<Tilemap>();
        Instantiate(enemy[0], transform.position,transform.rotation);
    }
}

