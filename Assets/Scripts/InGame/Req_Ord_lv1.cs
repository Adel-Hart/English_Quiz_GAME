using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[System.Serializable]
class valu
{
    public string[] items;
    public int[] money;
} //json 값을 담기위한 구조체

public class Req_Ord_lv1 : MonoBehaviour
{

    public Text order_text;
    public Text request_text;
    public Text o_d_T;
    public Text fiv_d_T;
    public Text t_d_T;
    public Text fift_d_T;


    public int leng;
    public string item_result; //최종적인 아이템
    public int money_result; //최종적인 가격


    public int one_d = 0; //천원 선택 개수
    public int five_d = 0; //5천원 선택 개수
    public int ten_d = 0; //만원 선택 개수
    public int fifty_d = 0; //5만원 선택 개수

    // Start is called before the first frame update
    void Awake()
    {
        //order_text = GameObject.Find("order_Text").GetComponent<Text>();
//request_text = GameObject.Find("request_Text").GetComponent<Text>(); 속도 느려져서, 유니티 상에서 바꾸는걸로 수정!

        TextAsset loadJson = Resources.Load<TextAsset>("Items_money");
        valu eulav = JsonUtility.FromJson<valu>(loadJson.text);
        int leng = eulav.money.Length;

        item_result = eulav.items[Random.Range(0, eulav.items.Length)]; //0부터 item 배열의 길이-1까지 무작위의 숫자를 index로 하여서, items배열에서 무작위 선택

        money_result = eulav.money[Random.Range(0, eulav.money.Length)]; //위 과정 money버전


        order_text.text = $"그 '{item_result}' 하나 주세요.";
        request_text.text = $"갸는 '{money_result}'원이여";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void one()
    {
        one_d++;
        o_d_T.text = one_d.ToString();
    }

    public void five()
    {
        five_d++;
        fiv_d_T.text = five_d.ToString();
    }

    public void ten()
    {
        ten_d++;
        t_d_T.text = ten_d.ToString();
    }

    public void fifty()
    {
        fifty_d++;
        fift_d_T.text = fifty_d.ToString();
    }

    public void cancle(int ccl) //취소 버튼(귀찮아서 일케 함, 유니티 상에서 설정하게)
    {
        switch (ccl)
        {
            case 0:
                if (one_d > 0)
                {
                    one_d--;
                    o_d_T.text = one_d.ToString();
                }
                break;

            case 1:
                if (five_d > 0)
                {
                    five_d--;
                    fiv_d_T.text = five_d.ToString();
                }
                break;

            case 2:
                if (ten_d > 0)
                {
                    ten_d--;
                    t_d_T.text = ten_d.ToString();
                }
                break;

            case 3:
                if (fifty_d > 0)
                {
                    fifty_d--;
                    fift_d_T.text = fifty_d.ToString();
                }
                break;


        }

    }


}
