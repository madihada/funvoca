using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
public class InputController : MonoBehaviour
{
    [SerializeField]
    private Text output_result; 
    [SerializeField]
    private TMP_InputField input_result;

    public Animator anim;

    // 캔버스
    public GameObject canvas;
    // 몬스터
    public GameObject monster;
    // 컨버스+몬스터
    public GameObject monsterWithUI;



    private string currentResult;
    private int count;


    private void Start()
    {
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        MonsterController[] monsters = FindObjectsOfType<MonsterController>();
        count = 0;
        FindObjectOfType<MonsterController>();
    }


    public void OnEndEditEvent()
    {
        // 입력한 값이 정답이면
        if (input_result.text == "apple" || input_result.text == "Apple" || input_result.text == "APPLE")
        {
            // 기쁜 애니메이션 넣어주고, 소리 넣어주고, 1회 정답임을 적어준다.
            Debug.Log("Congratulations!");
            anim.SetTrigger("Win");
            SoundManager.instance.SEPlay("AwardSound", SoundManager.instance.awardClip);
            count += 1;

            // 5번 입력하도록 설정
            if (count % 2 != 0)
            {
                input_result.text = "";
                input_result.ActivateInputField();
            }
            // 5회 입력하면, 몬스터오버 true되고 게임메니저로 이동!
            else if(count == 2)
            {
                count = 0;
                // 몬스터 사망 이벤트 호출(발생)
                Destroy(canvas);
                /*this.gameObject.SetActive(false);*/
                GameManager.instance.IsMonsterOver = true;

            }
            // 몬스터오버 true되면,
            // 1.게임메니저: 델리게이트 함수로 MonsterController 스크립트로 이동하여
            // 2.Destroy(this.gameObject)실행
        }
    }

}
