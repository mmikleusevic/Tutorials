using UnityEngine;

public class SunSetTrigger : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("SunSet");
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("SunSet");
    }
}
