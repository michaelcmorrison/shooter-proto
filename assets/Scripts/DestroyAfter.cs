using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField] private int seconds;
    void Start()
    {
        Destroy(gameObject, seconds);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
