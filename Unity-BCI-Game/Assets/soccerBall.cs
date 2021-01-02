using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerBall : MonoBehaviour {

    public GameController Controller;
    public Rigidbody rb;
    private Vector3 respawnPosition;
    private GameObject[] targets;
    private GameObject randomTarget;
    private bool isRunning;

    void Start()
    {
        respawnPosition = GameObject.FindGameObjectWithTag("Spawn").transform.position;
        targets = GameObject.FindGameObjectsWithTag("Goal");
        randomTarget = targets[Random.Range(0, targets.Length)];
    }

    void FixedUpdate()
    {
      if (!isRunning)
      {
        transform.position = Vector3.MoveTowards(transform.position, randomTarget.transform.position, 5f*Time.deltaTime);
      }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Goal")
        {

            if (!isRunning)
            {
              rb.velocity = Vector3.zero;
              StartCoroutine(Respawn());
            }
            
        }
        if(other.gameObject.name == "Player")
        {
            rb.velocity = Vector3.zero;
            Controller.IncrementScore();
            StartCoroutine(Respawn());
        }

    }

    IEnumerator Respawn()
    {
        isRunning = true;
        yield return new WaitForSeconds(2);
        transform.position = respawnPosition;
        yield return new WaitForSeconds(2);
        randomTarget = targets[Random.Range(0, targets.Length)];
        isRunning = false;
    }

}
