using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DmgTxtControl : MonoBehaviour
{

    private static DmgTxtControl _instance = null;

    public static DmgTxtControl instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DmgTxtControl>();
                if(_instance == null)
                {
                    Debug.LogError("ªÏ∑¡¡‡");
                }
            }

            return _instance;
        }
    }

    public Canvas canvas;
    public GameObject dmgTxt;


    // Start is called before the first frame update
    public void CreatDamageTxt(Vector3 hitPos, int hitDamage)
    {
        bool value = AudioManager.instance.isDamText;
        Debug.Log(value);
        if(value)
        {
            GameObject dmg = Instantiate(dmgTxt, hitPos, Quaternion.identity, canvas.transform);
            dmg.GetComponent<Text>().text = hitDamage.ToString();
            Debug.Log("√‚∑¬");
        }
        
    }
}
