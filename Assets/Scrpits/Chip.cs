using UnityEngine;

public class Chip : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(rb.linearVelocity.magnitude < 0.01)
        {
            rb.isKinematic = true;
        }
    }
}
