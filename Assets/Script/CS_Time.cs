using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_Time : MonoBehaviour
{
    public CS_Player myPlayer;
    public Text myTime;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time=0;
        myPlayer=GameObject.FindGameObjectWithTag("Player").GetComponent<CS_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myPlayer.RestartCamera!=4){
            time+=Time.deltaTime;
            myTime.text="Time:"+time.ToString("#0.00");
        }
    }
}
