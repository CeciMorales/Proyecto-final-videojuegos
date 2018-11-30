using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform MinimumBoundary;
    public Transform MaxBoundary;
    public Transform WorldUpLimit;
    public float TimeForNextPosition = 3;

    public Transform Rayo;
    // Use this for initialization
    void Start () {
        ChangePosition();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangePosition()
    {
        float x = Random.Range(MinimumBoundary.position.x, MaxBoundary.position.x);
        float y = WorldUpLimit.position.y + 20;
        Vector2 currentPosition = transform.position;
        currentPosition.x = x;
        currentPosition.y = y;
        transform.position = currentPosition;

        //TimeForNextPosition *= .9f;
        //TimeForNextPosition = Mathf.Clamp(TimeForNextPosition, .5f, 3);
        
        Instantiate(Rayo, transform.position, Quaternion.identity);

        Invoke("ChangePosition", TimeForNextPosition);
    }
}
