using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Keypad : MonoBehaviour
{
    public KeypadData startingKey;
    public TextMeshPro textBox;
    KeypadData data;

    int[] keys;
    int[] inputKeys;
    int keyIndex = 0;
    int keyLength = 0;
    bool fin = false;

    private void Start()
    {
        SetKey(startingKey);
    }

    public void SetKey(KeypadData data)
    {
        this.data = data;
        fin = false;
        keyIndex = 0;

        char[] charArr = data.key.ToString().ToCharArray();
        keys = new int[charArr.Length];
        inputKeys = new int[charArr.Length];

        int k = 0;
        foreach (char c in charArr)
        {
            keys[k] = int.Parse(c.ToString());
            inputKeys[k] = -1;
            k++;
        }

        keyLength = keys.Length;
        SetString();
    }


    public void ClickKey(int key)
    {
        if (fin) { return; }
        if (key >= 0)
        {
            inputKeys[keyIndex] = key;
            keyIndex++;
        }
        else if (keyIndex > 0)
        {
            keyIndex--;
            inputKeys[keyIndex] = -1;
        }

        if (SetString())
        {
            if (CheckResult())
            {
                fin = true;

                data.onSuccess?.Invoke();
            }
            else
            {
                keyIndex = 0;
                for (int x = 0; x < keyLength; x++)
                {
                    inputKeys[x] = -1;
                }
                SetString();

            }
        }
    }


    bool CheckResult()
    {
        for (int x = 0; x < keyLength; x++)
        {
            if (inputKeys[x] != keys[x]) { return false; }
        }
        return true;
    }


    bool SetString()
    {
        bool fill = true;

        string s = "";
        for (int x = 0; x < keyLength; x++)
        {
            s += inputKeys[x] >= 0 ? inputKeys[x].ToString() : "-";
            if (inputKeys[x] < 0) { fill = false; }
        }
        textBox.text = s;

        return fill;
    }
}
