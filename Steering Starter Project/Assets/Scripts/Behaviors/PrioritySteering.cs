using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySteering
{
    float epsilon = 0.1f;
    //holds a list of Blended Steering Instances, which in turn
    //contains sets of behaviors with their blending weights
    public BlendedSteering[] groups;

    public SteeringOutput GetSteering()
    {
        SteeringOutput steering = new SteeringOutput();
        foreach (BlendedSteering group in groups)
        {
            //create the steering structure for accumulation
            steering = group.GetSteering();

            //check if we are above the threshold, if so, return
            if (steering.linear.magnitude > epsilon || Mathf.Abs(steering.angular) > epsilon)
            {
                return steering;
            }
        }
        return steering;
    }
}
