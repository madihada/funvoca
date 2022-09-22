using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MonsterController : MonoBehaviour
{
    // 몬스터용 UI
    public GameObject canvas;
    // 몬스터 UI의 Input값 저장
    public TMP_InputField input_result;
    // 몬스터 UI의 Input값을 텍스트 타입으로 변환
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
        // Player가 APPLE 태그에 충돌 감지되면,
        if (coll.collider.gameObject.tag == "Player")
        {
            // 비활성화된 Canvas 활성화, 인풋필드 바로 타입되도록 활성화
            Debug.Log("ControllerColliderHit checked!");
            Debug.Log("this.canvas is ..." + this.canvas);
            Debug.Log("this.canvas.GetType() is ..." + this.canvas.GetType());
            Debug.Log("this.input_result is ..." + this.input_result);
            Debug.Log("this.input_result.GetType() is ..." + this.input_result.GetType());

            this.canvas.SetActive(true);
            this.input_result.ActivateInputField();
            // 그리고 마우스 커서도 보이도록하고, 보일 대 마우스 화면 정중앙위치
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            // 이제 InputController 스크립트로 이동해서 입력값이 정답값과 동일하면 나머지 기능을 수행하도록하자!

            // 최종적으로 없어져야 할 부딫힌 monster 저장하고
            willDestroyObject = this.gameObject;
        }
    }

    public void DeleteMonster()
    {
        // 최종적으로 없어져야 할 부딫힌 monster 삭제!
        Destroy(willDestroyObject);
    }
}
