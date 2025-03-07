using System.Collections;
using UnityEngine;

public class PlatformMove3D : MonoBehaviour
{
    [SerializeField] private Transform pos1, pos2;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float pauseTime = 1f;

    private Vector3 nextPos;
    private Rigidbody rb;

    private void Start()
    {
        nextPos = pos1.position;

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true;

        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        while (true)
        {
            while (Vector3.Distance(transform.position, nextPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(pauseTime);

            nextPos = (nextPos == pos1.position) ? pos2.position : pos1.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        if (pos1 != null && pos2 != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pos1.position, pos2.position);
        }
    }
}
