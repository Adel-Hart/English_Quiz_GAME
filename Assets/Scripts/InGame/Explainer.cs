using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explainer : MonoBehaviour
{

    public bool one;
    public bool five;
    public bool ten;
    public bool fifty;


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Scene scene = SceneManager.GetActiveScene();


    }
}
