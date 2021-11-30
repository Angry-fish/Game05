using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_JGround : MonoBehaviour
{
    public float myJumpS;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            GetComponent<Animator>().Play("Tan",0,0f);
            other.GetComponent<CS_Player>().jumpS=myJumpS;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CS_Player>().jumpS=1;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CS_Player>().JumpInput();
        }
    }
    
}
