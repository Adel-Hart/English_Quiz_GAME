using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explain_Scn : MonoBehaviour
{

    public GameObject one_b;
    public GameObject five_b;
    public GameObject ten_b;
    public GameObject fifty_b;




    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.Find("Explainer_Exchanger").GetComponent<Explainer>().one != true) one_b.SetActive(false);
        if (GameObject.Find("Explainer_Exchanger").GetComponent<Explainer>().five != true) five_b.SetActive(false);
        if (GameObject.Find("Explainer_Exchanger").GetComponent<Explainer>().ten != true) ten_b.SetActive(false);
        if (GameObject.Find("Explainer_Exchanger").GetComponent<Explainer>().fifty != true) fifty_b.SetActive(false);
    }

    // Update is called once per frame
    public void BackToMenu()
    {
        Destroy(GameObject.Find("Explainer_Exchanger"));
        SceneManager.LoadScene("Menu");
    }

    public void what_bill_go(string tango)
    {
        SceneManager.LoadScene(tango);
    }

}
