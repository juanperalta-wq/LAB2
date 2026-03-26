using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform obstacle;

    public int moveThreshold = 5;
    public float speed = 3f;
    public float distance = 5f;

    public bool hasMoved;

    private bool isMoving = false;
    private bool goingForward = true;

    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        startPosition = obstacle.position;
        endPosition = startPosition + Vector3.forward * distance;
    }
    void Update()
    {
        if (!isMoving) return;

        Vector3 target = goingForward ? endPosition : startPosition;

        obstacle.position = Vector3.MoveTowards(obstacle.position,target,speed * Time.deltaTime);

        if (Vector3.Distance(obstacle.position, target) < 0.1f)
        {
            goingForward = !goingForward;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int randomValue = Random.Range(0, 11);

            if (randomValue >= moveThreshold && hasMoved == false)
            {
                isMoving = true;
                hasMoved = true;
            }
        }
    }
}