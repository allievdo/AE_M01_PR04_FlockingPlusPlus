using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    public float avoidDistance = 30f;

    //the distance to look ahead for a collision
    public float lookAhead = 10f;
    protected override Vector3 getTargetPosition()
    {
        //calculate the collision ray vector
        RaycastHit hit;

        if (Physics.Raycast(character.transform.position, character.linearVelocity, out hit, lookAhead))
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized, Color.yellow, 0.5f);
            Debug.Log("Hit " + hit.collider);
            return hit.point - (hit.normal * avoidDistance);
        }

        else
        {
            Debug.DrawRay(character.transform.position, character.linearVelocity.normalized, Color.red, 0.5f);
            Debug.Log("safe");
            return Vector3.positiveInfinity;
        }
    }
}