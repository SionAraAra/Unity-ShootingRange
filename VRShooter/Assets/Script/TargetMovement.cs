using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 3f;

    private Vector3 pointAPosition;
    private Vector3 pointBPosition;

    private Vector3 currentTarget;

    void Start()
    {
        // Save the WORLD positions once
        pointAPosition = pointA.position;
        pointBPosition = pointB.position;

        // Start moving toward B
        currentTarget = pointBPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget,
            speed * Time.deltaTime
        );

        // Check if close enough
        if (Vector3.Distance(transform.position, currentTarget) < 0.05f)
        {
            // Switch direction
            if (currentTarget == pointAPosition)
            {
                currentTarget = pointBPosition;
            }
            else
            {
                currentTarget = pointAPosition;
            }
        }
    }
}