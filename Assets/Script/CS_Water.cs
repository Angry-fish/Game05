using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           // other.GetComponent<CS_Player>().canJump = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          //  other.GetComponent<CS_Player>().canJump = false;
        }
    }

}
