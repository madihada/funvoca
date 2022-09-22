using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;


    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;



    private readonly int hashTrace = Animator.StringToHash("IsTrace");
    private readonly int hashWin = Animator.StringToHash("Win");

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");


        Vector3 direction = new Vector3 (horizontal, 0f, vertical).normalized;
        Vector3 jumpSpeed = new Vector3(0, jump, 0);

        if (direction.magnitude >= 0.1f)
        {
            anim.SetBool(hashTrace, true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool(hashTrace, false);
        }

        if (Input.GetButton("Jump"))
        {
            Debug.Log(jumpSpeed);
            controller.Move(jumpSpeed * 20f * Time.deltaTime);
        }
    }


/*    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Player�� APPLE �±׿� �浹 �����Ǹ�,
        if (hit.collider.gameObject.tag == "APPLE")
        {
            // ��Ȱ��ȭ�� Canvas Ȱ��ȭ, ��ǲ�ʵ� �ٷ� Ÿ�Եǵ��� Ȱ��ȭ
            Debug.Log("ControllerColliderHit checked!");
            GameManager.instance.canvas.SetActive(true);
            GameManager.instance.input_result.ActivateInputField();
            // �׸��� ���콺 Ŀ���� ���̵����ϰ�, ���� �� ���콺 ȭ�� ���߾���ġ
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            // ���� InputController ��ũ��Ʈ�� �̵��ؼ� �Է°��� ���䰪�� �����ϸ� ������ ����� �����ϵ�������!
        }
    }*/
}
