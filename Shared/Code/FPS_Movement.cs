using UnityEngine;

public class FPS_Movement : MonoBehaviour
{
	#region UNITY SYSTEM

    // Start is called before the first frame update
    private void Start()
    {
        TestInit();
    }

    // Update is called once per frame
    private void Update()
    {
        TestUpdate();
    }

    #endregion

    #region CUSTOMER
    /// <summary>
    /// move update
    /// </summary>
    public CharacterController FPSChController;
    public float Speed = 12f;

    public Transform GroundCheckPoint;
    public float GroundDistance = 0.4f;
    public float JumHight = 3f;
    public LayerMask GroundMask;

    private float Gravity = -9.81f;
    private Vector3 Velocity;
    private bool IsGround;

    private void FPSMoveUpdate()
    {
        IsGround = Physics.CheckSphere(GroundCheckPoint.position, GroundDistance, GroundMask);
        if(IsGround && Velocity.y<0)
        {
            Velocity.y = -2f;
        }

        //if(Input.GetButtonDown("Jump")&&IsGround)
        //{
        //    Velocity.y = Mathf.Sqrt(JumHight * -2f * Gravity);
        //}

        // Jump
        if(Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            //Debug.Log("JUMP");
            Velocity.y = Mathf.Sqrt(JumHight * -2f * Gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        FPSChController.Move(move * Speed * Time.deltaTime);
        Velocity.y += Gravity * Time.deltaTime;
        FPSChController.Move(Velocity*Time.deltaTime);
    }
    /// <summary>
    /// this is test function
    /// </summary>
    private void TestInit()
    {

    }
    private void TestUpdate()
    {
        FPSMoveUpdate();
    }
	#endregion
}
