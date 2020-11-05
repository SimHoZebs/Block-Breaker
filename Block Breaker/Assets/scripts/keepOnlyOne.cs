using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepOnlyOne : MonoBehaviour
{
    void Start()
    {
        //fuck
        var objCount = FindObjectsOfType<keepOnlyOne>().Length;

        if (objCount > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
