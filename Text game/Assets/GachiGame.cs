using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachiGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State currState;
    // Start is called before the first frame update
    void Start()
    {
        currState = startingState;
        textComponent.text = currState.GetStateStory();
    }

    // Update is called once per frame
    void Update(){
        ManageState();
    }
    
    private void ManageState(){
        var nextStates = currState.GetNextState();
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            currState = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)){
            currState = nextStates[1];
        }
        textComponent.text = currState.GetStateStory();
    }
}
