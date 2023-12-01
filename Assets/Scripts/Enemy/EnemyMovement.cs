using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting;
using System.Xml.Schema;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent badGuy;
    public float squareOfMovement = 50f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;
    private float xPos;
    private float zPos;

    private float yPos;

    private float closeEnough = 3;

    // Start is called before the first frame update
    void Start()
    {
        xMin = -squareOfMovement;
        zMin = -squareOfMovement;
        xMax = squareOfMovement;
        zMax = squareOfMovement;

        NewLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPos, yPos, zPos)) <= closeEnough)
        {
            NewLocation();
        }

    }

    public void NewLocation()
    {
        yPos = transform.position.y;
        xPos = Random.Range(xMin, xMax);
        zPos = Random.Range(zMin, zMax);

        badGuy.SetDestination(new Vector3(xPos, yPos, zPos));
        Animator anim = GetComponent<Animator>();
        anim.Play("Walk");
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            Destroy(gameObject);
        }
    }
}
