using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints; // Массив точек патрулирования
    public Transform player; // Игрок
    public float speed = 2f; // Скорость передвижения
    public float chaseSpeed = 3.5f; // Скорость преследования
    public float stoppingDistance = 0.1f; // Минимальное расстояние до точки
    public float chaseRadius = 5f; // Радиус обнаружения игрока
    public float returnWaitTime = 5f; // Ожидание перед продолжением патруля

    private int currentPointIndex = 0;
    private bool isWaiting = false;
    private bool isChasing = false;
    private Vector3 startPosition; // Исходная точка противника

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isWaiting) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRadius)
        {
            StartChase();
        }
        else if (isChasing)
        {
            StopChase();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < stoppingDistance)
        {
            StartCoroutine(WaitBeforeNextPoint());
        }
    }

    IEnumerator WaitBeforeNextPoint()
    {
        isWaiting = true;
        float waitTime = Random.Range(3f, 7f);
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
        NextPoint();
    }

    void NextPoint()
    {
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }

    void StartChase()
    {
        isChasing = true;
        StopAllCoroutines(); 
        GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime));

    }

    void StopChase()
    {
        isChasing = false;
        StartCoroutine(ReturnToStart());
    }

    IEnumerator ReturnToStart()
    {
        isWaiting = true;

       
        while (Vector3.Distance(transform.position, startPosition) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            yield return null;
        }

      
        yield return new WaitForSeconds(returnWaitTime);
        
        isWaiting = false;
    }

    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
