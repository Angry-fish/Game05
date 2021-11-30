using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ChangeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public int rightC;
    public int lightC;
    public int upC;
    public int downC;
    public bool XY;
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (XY)
            {
                if (other.transform.position.x < transform.position.x) CS_Manager.instance.SetCameraActive(rightC);
                else CS_Manager.instance.SetCameraActive(lightC);
            }
            else
            {
                if (other.transform.position.y < transform.position.y) CS_Manager.instance.SetCameraActive(upC);
                else CS_Manager.instance.SetCameraActive(downC);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (XY)
            {
                if (other.transform.position.x < transform.position.x) CS_Manager.instance.SetCameraActive(lightC);
                else CS_Manager.instance.SetCameraActive(rightC);
            }
            else
            {
                if (other.transform.position.y < transform.position.y) CS_Manager.instance.SetCameraActive(downC);
                else CS_Manager.instance.SetCameraActive(upC);
            }
        }
    }
}
