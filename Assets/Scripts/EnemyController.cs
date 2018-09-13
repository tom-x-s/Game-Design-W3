using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 1f;
    public float speed;
    float moveHorizontal;
    float moveVertical;
    private Rigidbody rb;
    System.Random rnd1 = new System.Random();

    // Use this for initialization
    void Start () {
        latestDirectionChangeTime = 0f;
        rb = GetComponent<Rigidbody>();
        calculateNewMovementVector();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void calculateNewMovementVector()
    { 
        moveHorizontal = rnd1.Next(-21, 21);
        moveVertical = rnd1.Next(-21, 21);
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.transform.Translate(movement * Time.deltaTime * speed);
    }

    void FixedUpdate()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }
    }
}
