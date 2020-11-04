using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadProperties : MonoBehaviour
{
    // Start is called before the first frame update
    private string objectTag;
    void Start()
    {
        KeepOnlyOne();
    }

    private void KeepOnlyOne(){
        /*  All objects with tag "keepOnlyOne" will have DontDestroyOnLoad().
            If there is more than two objects with the same name, Destroy().

            Duplication check is done with a alphabetically sorted list.
            Each obj is iterated through, attempting match with the prev iterated obj. If they match, there's a duplicate.
        */

        List<GameObject> objList = GameObject.FindGameObjectsWithTag("keepOnlyOne").OrderBy(obj => obj.name).ToList();

        GameObject prevObj = objList[0];

        foreach (GameObject obj in objList){
            if (obj != objList[0] && obj.name == prevObj.name){
                GameObject.Destroy(obj);
            }
            else{
                DontDestroyOnLoad(obj);
                prevObj = obj;
            }
        }
    }
}
