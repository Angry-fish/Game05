using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Camera : MonoBehaviour
{
    public GameObject Player;
    public Vector3 myPosition;
    public bool move;
    public int myIndex;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!move) return;

        myPosition = Player.transform.position;
        myPosition.z = -10;
        gameObject.transform.position= myPosition;
    }
}
