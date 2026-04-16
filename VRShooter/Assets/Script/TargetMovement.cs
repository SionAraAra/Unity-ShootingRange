using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float maxDistance = 3;
    public float maxPosition;
    public float minPosition;
    public float direction = 1;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxPosition = transform.position.x + maxDistance;
        minPosition = transform.position.x - maxDistance;
        speed = Random.value+1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxPosition)
        {
            direction *= -1;
        }else if (transform.position.x < minPosition)
        {
            direction *= -1;
        }
        gameObject.transform.Translate(Vector3.right * Time.deltaTime * direction * speed);
    }
}
