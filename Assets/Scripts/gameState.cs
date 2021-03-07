using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class gameState : MonoBehaviour
{

    Scene currentScene;
    public TextMeshProUGUI hudText;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        ChangeHudText("");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("reset"))
        {
            ResetCurrentSceen();
        }
    }

    public void ResetCurrentSceen()
    {
        SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Single);       
    }

    public void ChangeHudText(string hudtext)
    {
        hudText.text = hudtext;
    }
}

