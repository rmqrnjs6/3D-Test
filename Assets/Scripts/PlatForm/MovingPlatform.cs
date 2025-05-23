using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public Vector3 moveDirection = Vector3.right; // 예: 오른쪽/왼쪽 이동
    public float moveDistance = 5f;               // 이동 거리
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool goingToTarget = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + moveDirection.normalized * moveDistance;
    }

    void Update()
    {
        Vector3 destination = goingToTarget ? targetPos : startPos;

        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // 목적지에 도달하면 방향 반전
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            goingToTarget = !goingToTarget;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}