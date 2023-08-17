using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Close_Button : MonoBehaviour
{
    public GameObject _option;
    public void OnCloseButton()
    {
        _option.SetActive(false);
    }

    public void OnButtonLobby()
    {
        SceneManager.LoadScene((int)Define.Scene.Lobby);
    }
}
