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
} //json ���� ������� ����ü

public class Req_Ord_lv1 : MonoBehaviour
{

    public Text order_text;
    public Text request_text;
    public Text o_d_T;
    public Text fiv_d_T;
    public Text t_d_T;
    public Text fift_d_T;
    public GameObject SuccesPanel; //����â
    public GameObject Explainer; //���� â ���� ���ޱ�


    public int leng;
    public string item_result; //�������� ������
    public int money_result; //�������� ����


    public int one_d = 0; //õ�� ���� ����
    public int five_d = 0; //5õ�� ���� ����
    public int ten_d = 0; //���� ���� ����
    public int fifty_d = 0; //5���� ���� ����


    private int result = 0; //���� ����
    private bool one_go, five_go, ten_go, fifty_go;


    // Start is called before the first frame update
    void Awake()
    {

        SuccesPanel.SetActive(false);

        DontDestroyOnLoad(Explainer);

        one_go = Explainer.GetComponent<Explainer>().one;
        five_go = Explainer.GetComponent<Explainer>().five;
        ten_go = Explainer.GetComponent<Explainer>().ten;
        fifty_go = Explainer.GetComponent<Explainer>().fifty;



        //order_text = GameObject.Find("order_Text").GetComponent<Text>();
        //request_text = GameObject.Find("request_Text").GetComponent<Text>(); �ӵ� ��������, ����Ƽ �󿡼� �ٲٴ°ɷ� ����!

        TextAsset loadJson = Resources.Load<TextAsset>("Items_money");
        valu eulav = JsonUtility.FromJson<valu>(loadJson.text);
        int leng = eulav.money.Length;

        item_result = eulav.items[Random.Range(0, eulav.items.Length)]; //0���� item �迭�� ����-1���� �������� ���ڸ� index�� �Ͽ���, items�迭���� ������ ����

        money_result = eulav.money[Random.Range(0, eulav.money.Length)]; //�� ���� money����


        order_text.text = $"Sir,  Can I get a '{item_result}'.  Please?";
        request_text.text = $"It's  '{money_result}'Won.";
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

    public void cancle(int ccl) //��� ��ư(�����Ƽ� ���� ��, ����Ƽ �󿡼� �����ϰ�)
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


    public void say()
    {
        result = 1000 * one_d + 5000 * five_d + 10000 * ten_d + 50000 * fifty_d;
        if (result == money_result)
        {
            SuccesPanel.SetActive(true);
        }
        else
        {
            
            StartCoroutine(Wait());
            
        }
    }
    public void end_click()
    {
        if (one_d > 0) Explainer.GetComponent<Explainer>().one = true;
        if (five_d > 0) Explainer.GetComponent<Explainer>().five = true;
        if (ten_d > 0) Explainer.GetComponent<Explainer>().ten = true;
        if (fifty_d > 0)    Explainer.GetComponent<Explainer>().fifty = true;

        SceneManager.LoadScene("Explain");
      }

    public void back()
    {
        SceneManager.LoadScene("Menu");
    }



    IEnumerator Wait()
    {
        request_text.text = $"Its {money_result} won. check out!";
        yield return new WaitForSeconds(2.5f);
        request_text.text = $"It's  '{money_result}'Won.";
    }


    


}
