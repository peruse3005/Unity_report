using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class exit : MonoBehaviour
{
    [SerializeField] Button btnExit;
    // Start is called before the first frame update
    void Start()
    {
        btnExit.onClick.AddListener(()=>{
            SceneManager.LoadScene("title");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
