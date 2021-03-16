using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulha : State{

    SteerableBehaviour steerable;
    GameManager gm;

    float angle = 0;


    public override void Awake()
    {
        base.Awake();
        gm = GameManager.GetInstance(); 
        Transition ToAtacando = new Transition();
        ToAtacando.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform,2.0f);

        ToAtacando.target = GetComponent<StateAtaque>();
        transitions.Add(ToAtacando);

        steerable = GetComponent<SteerableBehaviour>();
    }

    public  void Update()
    {
        if(gm.gameState != GameManager.GameState.GAME) return;
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        steerable.Thrust(x, y);
       
    }
}
