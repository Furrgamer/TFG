using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CanvasController : MonoBehaviour
{
    public TextMeshProUGUI textTitle;
    public void _buttonExit()
    {
        Application.Quit();
        Debug.Log("Hola mundo");
    }
}
