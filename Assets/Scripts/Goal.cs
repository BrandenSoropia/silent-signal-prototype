using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject discoBall;

    void OnTriggerEnter(Collider other)
    {
        discoBall.GetComponent<Celebrate>().PlayAllCelebrations();

    }
}
