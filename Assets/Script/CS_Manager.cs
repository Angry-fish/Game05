using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Manager : MonoBehaviour
{
    public static CS_Manager instance;

    public GameObject[] myCamera;
    public GameObject nowCamera;
    public int nowIndex;
    // Start is called before the first frame update
    void Start()
    {
        if (instance = null)
        {
            instance = this;
        }
        myCamera = GameObject.FindGameObjectsWithTag("Camera");
        for (int tempIndex = 0; tempIndex < myCamera.Length; tempIndex++)
        {
            if (myCamera[tempIndex].GetComponent<CS_Camera>().myIndex != tempIndex)
            {
                GameObject tempGameObject = null;
                int temp = 0;
                for (int tempIndexIn = 0; tempIndexIn < myCamera.Length; tempIndexIn++)
                {
                    if (myCamera[tempIndexIn].GetComponent<CS_Camera>().myIndex == tempIndex)
                    {
                        tempGameObject = myCamera[tempIndexIn];
                        temp = tempIndexIn;
                    }
                }
                
                if (tempGameObject)
                {
                    myCamera[temp] = myCamera[tempIndex];
                    myCamera[tempIndex] = tempGameObject;
                }

            }
        }

        //GameObject[] temp;
        /*
        for (int outIndex = 0; outIndex < myCamera.Length; outIndex++)
        {
            //if(myCamera[outIndex].GetComponent<CS_Camera>)
            for (int inIndex = 0; inIndex < allCamera.Length; inIndex++)
            {
                if(outIndex==allCamera[inIndex].GetComponent<CS_Camera>().myIndex){
                    targetCamera=allCamera[inIndex];
                    break;
                }
            }
            if(targetCamera)myCamera[outIndex]=targetCamera;
            targetCamera=null;
        }
        */

        for (int tempIndex = 0; tempIndex < myCamera.Length; tempIndex++)
        {
            myCamera[tempIndex].SetActive(false);
        }
        //nowIndex = myCamera.Length-1;
        nowIndex = 0;
        SetCameraActive(0);
    }
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        instance = this;
    }
    public void SetCameraActive(int index)
    {
        myCamera[nowIndex].SetActive(false);
        nowIndex = index;
        //nowIndex = myCamera.Length - index - 1;
        myCamera[nowIndex].SetActive(true);
        nowCamera = myCamera[nowIndex];
    }
}
