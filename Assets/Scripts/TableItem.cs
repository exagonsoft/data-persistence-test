using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableItem : MonoBehaviour
{
    public Text _record;

    public void SetUpItem(string _text)
    {
        _record.text = _text;
    }
}
