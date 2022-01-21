using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif

public class MenuUIhandler : MonoBehaviour
{
    public static MenuUIhandler Instance;
    public TMP_InputField inputField;
    public string playerName;
    public TextMeshProUGUI bestPlayer; 

    void Start()
    {
        bestPlayer.text = DataManager.Instance.BestPlayerInfo();
    }

    public void StartNew()
    {
        if(DataManager.Instance!=null)
        { 
        DataManager.Instance.newPlayer = inputField.text;
        }
       
        SceneManager.LoadScene(1);
    }
   

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
      
#endif
    }
    public void Awake()
    {
        
        

        if (Instance != null)

        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
         
        

    }
    



}
