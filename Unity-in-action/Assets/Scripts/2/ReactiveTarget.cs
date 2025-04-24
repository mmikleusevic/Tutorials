using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behaviour = GetComponent<WanderingAI>();
        if (behaviour)
        {
            behaviour.SetAlive(false);
        }
        
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        transform.Rotate(-75, 0 ,0);

        yield return new WaitForSeconds(1.5f);
        
        Destroy(gameObject);
    }
}
