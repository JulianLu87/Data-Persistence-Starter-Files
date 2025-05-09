using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField inputField;
    public Text HighScoreText;

    private void Start()
    {
        HighScoreText.text =  $"Best Score: {DataManager.Instance.HighScore} - {DataManager.Instance.HighScoreName}";
    }

    public void Startnew()
    {   
        DataManager.Instance.CurrentPlayerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
