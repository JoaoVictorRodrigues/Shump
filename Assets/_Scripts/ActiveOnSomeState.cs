using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActiveOnSomeState : MonoBehaviour
{

    public GameManager.GameState[] activeStates;
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += UpdateVisibility;
        UpdateVisibility();
    }

    // Update is called once per frame
    void UpdateVisibility()
    {
        if(activeStates.Contains(gm.gameState)){
            gameObject.SetActive(true);
        }else{
            gameObject.SetActive(false);
        }
    }
}
