using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public GameObject _infoMenu;
    public void Cancel()
    {
        _infoMenu.SetActive(false);
    }
}
