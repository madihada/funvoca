using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MonsterController : MonoBehaviour
{
    // ���Ϳ� UI
    public GameObject canvas;
    // ���� UI�� Input�� ����
    public TMP_InputField input_result;
    // ���� UI�� Input���� �ؽ�Ʈ Ÿ������ ��ȯ
    private string currentResult;

    private GameObject willDestroyObject;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnMonsterDie += DeleteMonster;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        // Player�� APPLE �±׿� �浹 �����Ǹ�,
        if (coll.collider.gameObject.tag == "Player")
        {
            // ��Ȱ��ȭ�� Canvas Ȱ��ȭ, ��ǲ�ʵ� �ٷ� Ÿ�Եǵ��� Ȱ��ȭ
            Debug.Log("ControllerColliderHit checked!");
            Debug.Log("this.canvas is ..." + this.canvas);
            Debug.Log("this.canvas.GetType() is ..." + this.canvas.GetType());
            Debug.Log("this.input_result is ..." + this.input_result);
            Debug.Log("this.input_result.GetType() is ..." + this.input_result.GetType());

            this.canvas.SetActive(true);
            this.input_result.ActivateInputField();
            // �׸��� ���콺 Ŀ���� ���̵����ϰ�, ���� �� ���콺 ȭ�� ���߾���ġ
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            // ���� InputController ��ũ��Ʈ�� �̵��ؼ� �Է°��� ���䰪�� �����ϸ� ������ ����� �����ϵ�������!

            // ���������� �������� �� �΋H�� monster �����ϰ�
            willDestroyObject = this.gameObject;
        }
    }

    public void DeleteMonster()
    {
        // ���������� �������� �� �΋H�� monster ����!
        Destroy(willDestroyObject);
    }
}
