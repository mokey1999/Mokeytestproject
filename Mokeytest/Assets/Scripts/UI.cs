using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;

    public UI_InGame inGameUI { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            inGameUI = GetComponentInChildren<UI_InGame>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
