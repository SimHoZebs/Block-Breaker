using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepOnlyOne : MonoBehaviour
{
    void Awake()
    {
        //fuck
        var objCount = FindObjectsOfType<keepOnlyOne>().Length;

        if (objCount > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
