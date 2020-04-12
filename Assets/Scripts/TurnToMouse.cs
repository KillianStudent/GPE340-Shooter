using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToMouse : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Pawn pawn;


    // Start is called before the first frame update
    void Start()
    {
        pawn = GetComponent<Pawn>();
    }

    // Update is called once per frame
    void Update()
    {
        // create a plane at target's feet
        Plane myPlane = new Plane(Vector3.up, transform.position);
        // Raycast from camera mousepoint towards plane
        // Create our ray
        Ray theRay = camera.ScreenPointToRay(Input.mousePosition);
        // Create a variable to hold distance
        float distance;
        // Find teh distance where the ray hits the plane
        myPlane.Raycast(theRay, out distance);
        // Find the point down that ray
        Vector3 hitPoint = theRay.GetPoint(distance);

        // Rotate to look at that point
        Vector3 vectorToPoint = hitPoint - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToPoint, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, pawn.rotationSpeed * Time.deltaTime);
    }
}
