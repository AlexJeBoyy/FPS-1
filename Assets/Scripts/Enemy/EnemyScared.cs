using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScared : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    public Transform player;
    public float attackRange = 10f;

    public Material defaultColor;
    public Material attackMaterial;
    private Renderer rend;
    private NavMeshAgent agent;

    private bool foundPlayer = false;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<EnemyMovement>();
        rend = GetComponent<Renderer>();
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            rend.sharedMaterial = attackMaterial;
            enemyMovement.badGuy.SetDestination(player.position * -1);
            foundPlayer = true;

        }


        else if (foundPlayer)
        {
            rend.sharedMaterial = defaultColor;
            enemyMovement.NewLocation();
            //enemyMovement.agent;
            foundPlayer = false;
        }
    }

}
