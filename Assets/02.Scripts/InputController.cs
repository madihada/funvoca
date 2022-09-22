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

    // ĵ����
    public GameObject canvas;
    // ����
    public GameObject monster;
    // ������+����
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
        // �Է��� ���� �����̸�
        if (input_result.text == "apple" || input_result.text == "Apple" || input_result.text == "APPLE")
        {
            // ��� �ִϸ��̼� �־��ְ�, �Ҹ� �־��ְ�, 1ȸ �������� �����ش�.
            Debug.Log("Congratulations!");
            anim.SetTrigger("Win");
            SoundManager.instance.SEPlay("AwardSound", SoundManager.instance.awardClip);
            count += 1;

            // 5�� �Է��ϵ��� ����
            if (count % 2 != 0)
            {
                input_result.text = "";
                input_result.ActivateInputField();
            }
            // 5ȸ �Է��ϸ�, ���Ϳ��� true�ǰ� ���Ӹ޴����� �̵�!
            else if(count == 2)
            {
                count = 0;
                // ���� ��� �̺�Ʈ ȣ��(�߻�)
                Destroy(canvas);
                /*this.gameObject.SetActive(false);*/
                GameManager.instance.IsMonsterOver = true;

            }
            // ���Ϳ��� true�Ǹ�,
            // 1.���Ӹ޴���: ��������Ʈ �Լ��� MonsterController ��ũ��Ʈ�� �̵��Ͽ�
            // 2.Destroy(this.gameObject)����
        }
    }

}
