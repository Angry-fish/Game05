using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_JumpCould : MonoBehaviour
{
     public bool canMove;
    public float moveSpeed;
    public GameObject[] movePoints;
    public Vector3[] myMovePoint;
     public int nowIndex;
    // Start is called before the first frame update
     void Start()
    {
        moveSpeed=Mathf.Abs(moveSpeed);
        if (canMove)
        {
            for (int index = 0; index < movePoints.Length; index++)
            {
                myMovePoint[index] = movePoints[index].transform.position;
            }
            // nowIndex=Random.Range(0,movePoints.Length);
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
    }
}
