using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Ground : MonoBehaviour
{
    public bool canMove;
    public float moveSpeed;
    public GameObject[] movePoints;
    public int nowIndex;
    public Vector3[] myMovePoint;
    float lastSpeed;
    float nowSpeed;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed=Mathf.Abs(moveSpeed);
        lastSpeed = 0;
        if (canMove)
        {
            for (int index = 0; index < movePoints.Length; index++)
            {
                myMovePoint[index] = movePoints[index].transform.position;
            }
            // nowIndex=Random.Range(0,movePoints.Length);
        }else{

            if(GetComponents<Collider2D>()[0].isTrigger)GetComponents<Collider2D>()[0].enabled=false;
            else GetComponents<Collider2D>()[1].enabled=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        if (Vector3.Distance(transform.position, myMovePoint[nowIndex]) < 0.1f)
        {
            nowIndex++;
            if (nowIndex >= myMovePoint.Length) nowIndex = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, myMovePoint[nowIndex], moveSpeed * Time.deltaTime);
        if ((myMovePoint[nowIndex].x - transform.position.x) > 0) nowSpeed = moveSpeed;
        else nowSpeed = -moveSpeed;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CS_Player>().AddSpeed.x -= lastSpeed;
            other.GetComponent<CS_Player>().AddSpeed.x += nowSpeed;
            lastSpeed = nowSpeed;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<CS_Player>().AddSpeed.x -= lastSpeed;
        lastSpeed = 0;
    }
}
