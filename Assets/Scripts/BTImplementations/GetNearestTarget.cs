using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNearestTarget : Task {

    [SerializeField]
    private GameController controller;
    private float distanciaActual = 100f;
    public GameObject target;

    public void Start()
    {
        controller = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }

    public override bool Execute()
    {
        for (int i = 0; i < controller.players.Length; i++)
        {
            float distancia = Vector3.Distance(transform.position, controller.players[i].transform.position);
            if (distancia < distanciaActual && distancia != 0 && controller.players[i].gameObject != controller.lastTaggedplayer)
            {
                distanciaActual = distancia;
                target = controller.players[i].gameObject;
            }
        }
        return true;
    }
}
