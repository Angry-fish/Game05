using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_Player : MonoBehaviour
{

    [Header("默认")]
    public Rigidbody2D myRigidbody;
    public GameObject myBody;
    public Animator myAnimator;
    public GameObject[] CheckObject;
    public float checkradius;
    public Vector2 RestartPoint;
    public int RestartCamera;
    public Vector2 AddSpeed;

    [Header("移动")]
    public float myHorizontal;
    public float speed;

    [Header("跳跃")]
    public float jumpSpeed;
    public bool canJump;
    public float InputTime;
    public bool tryJump;
    public Coroutine tryJumpIE;
    public bool JumpIEing;
    public float jumpS;

    [Header("冲刺")]
    public Vector2 tempDashDis;
    public Vector2 dashDis;
    public float dashSpeed;
    public bool isDash;
    public bool canDash;
    public float dashTime;
    public float dashCD;
    float dashCDLeft;


    public float time;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        canDash = true;
        jumpS=1;
    }
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R)&&RestartCamera==4){
                 SceneManager.LoadScene("SampleScene");
        } 
        Time.timeScale = time;
        //Debug.Log( CS_Manager.instance);
        dashDis = CS_Manager.instance.nowCamera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //dashDis=Vector2.down;
        dashDis.Normalize();
        /*
        canJump = Physics2D.OverlapCircle(CheckObject[0].transform.position, checkradius, LayerMask.GetMask("Ground"))||
                  Physics2D.OverlapBox(CheckObject[0].transform.position,new Vector2(1,1),0f,LayerMask.GetMask("Could")) ||
                  Physics2D.OverlapCircle(CheckObject[0].transform.position, checkradius, LayerMask.GetMask("Water")) ||
                  Physics2D.OverlapCircle(CheckObject[1].transform.position, checkradius, LayerMask.GetMask("Ground"))||
                  Physics2D.OverlapBox(CheckObject[1].transform.position,new Vector2(1,1),0f,LayerMask.GetMask("Could"))||
                  Physics2D.OverlapCircle(CheckObject[1].transform.position, checkradius, LayerMask.GetMask("Water"));
        */
        canJump = Physics2D.OverlapArea(CheckObject[0].transform.position, CheckObject[1].transform.position, LayerMask.GetMask("Ground")) ||
                  Physics2D.OverlapArea(CheckObject[0].transform.position, CheckObject[1].transform.position, LayerMask.GetMask("Water"))||
                  Physics2D.OverlapArea(CheckObject[2].transform.position,CheckObject[3].transform.position ,LayerMask.GetMask("Could"));
        if (Input.GetMouseButtonDown(1) && canDash)
        {
            canDash = false;
            dashCDLeft = dashCD;
            tempDashDis = dashDis;
            StartCoroutine(IE_Dash());
        }
        if (!canDash)
        {
            dashCDLeft -= Time.deltaTime;
            if (dashCDLeft <= 0) canDash = true;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput();
        }
        if (tryJump && canJump && !isDash)// myRigidbody.velocity.y <= 0 &&
        {
            StopTryJumpIE();
            Jump();
        }

        if (isDash) return;
        if (canDash) myBody.GetComponent<SpriteRenderer>().color = new Color(0, 125, 0);
        else myBody.GetComponent<SpriteRenderer>().color = new Color(125, 125, 0);
    }

    private void FixedUpdate()
    {
        myHorizontal = Input.GetAxis("Horizontal");
        if (isDash) myRigidbody.velocity = tempDashDis * dashSpeed;
        else myRigidbody.velocity = new Vector2(speed * myHorizontal, myRigidbody.velocity.y);
        Flip();
        myRigidbody.velocity += AddSpeed;
    }

    void Flip()
    {
        if (myRigidbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void JumpInput()
    {
        if (JumpIEing)
        {
            StopTryJumpIE();
            tryJumpIE = StartCoroutine(IE_tryJump());
        }
        else
        {
            tryJumpIE = StartCoroutine(IE_tryJump());
        }
    }
    public void Jump()
    {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpSpeed*jumpS);
        myAnimator.Play("Jump", 0, 0f);
    }
    IEnumerator IE_tryJump()
    {
        JumpIEing = true;
        tryJump = true;
        yield return new WaitForSeconds(InputTime);
        tryJump = false;
        JumpIEing = false;
    }
    void StopTryJumpIE()
    {
        if (JumpIEing) StopCoroutine(tryJumpIE);
        tryJump = false;
        JumpIEing = false;
    }

    IEnumerator IE_Dash()
    {
        myAnimator.Play("Dash", 0, 0f);
        isDash = true;
        yield return new WaitForSeconds(dashTime);
        isDash = false;
        myRigidbody.velocity = Vector2.zero;
        myAnimator.Play("Idle", 0, 0f);
    }

    private void OnDrawGizmos()
    {
        // Gizmos.DrawWireSphere(CheckObject[0].transform.position, checkradius);
        //Gizmos.DrawWireSphere(CheckObject[1].transform.position, checkradius);
    }
}
