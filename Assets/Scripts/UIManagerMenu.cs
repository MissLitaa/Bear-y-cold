using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerMenu : MonoBehaviour
{
    public static UIManagerMenu callForName;
    public TMP_InputField inputField;

    private void Awake()
    {
        if (callForName == null)
            callForName = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        string existingName = PlayerPrefs.GetString("CHARACTER_NAME");
        if (existingName != "")
        {
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = existingName;
        }
    }

    public void saveCharName()
    {
        string charName = inputField.text;
        if (charName =="")
        {
            PersistentData.call.rememberName = inputField.placeholder.GetComponent<TextMeshProUGUI>().text;
        }
        else
        {
            PersistentData.call.rememberName = charName;
        }
        PlayerPrefs.SetString("CHARACTER_NAME", PersistentData.call.rememberName);
    }
}
