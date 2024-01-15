using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();//all the points car will go towrds
    public int targetIndex = 0;//index of target point
    public Transform car,target;// car' position, current target position 
    public float speed; //make speed cell

    void Start()
    {
        target = points[targetIndex]; //make the first transform the first target
    }

    
    void Update()
    {
    
        Vector3 dir = target.position - car.position; //make direction vector
        dir.y = 0;
        car.forward = dir; // looking towards direction you are going
        car.position += dir.normalized*speed*Time.deltaTime; //add direction vector to car's position
        if(Vector3.Distance(car.position, target.position) < 10f){
            if(targetIndex == points.Count-1)
            {
                targetIndex = 0; //make target first point if at last index
            }
            else{
                targetIndex++; // add to index if not at last point
            }
            target = points[targetIndex]; //make next point the target
        }
    }
}
