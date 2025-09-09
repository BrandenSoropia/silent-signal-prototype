using UnityEngine;

public class DropGate : MonoBehaviour
{

    [SerializeField] bool isEnabled;
    [SerializeField] GameObject frontGate;
    [SerializeField] GameObject backGate;
    Rigidbody frontGateRb;
    Rigidbody backGateRb;

    void Awake()
    {
        // make sure associated gate is not falling.
        frontGateRb = frontGate.GetComponent<Rigidbody>();
        frontGateRb.useGravity = false;

        backGateRb = backGate.GetComponent<Rigidbody>();
        backGateRb.useGravity = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (isEnabled && other.tag == "Player")
        {
            frontGateRb.useGravity = true;
            backGateRb.useGravity = true;
        }
    }
}
