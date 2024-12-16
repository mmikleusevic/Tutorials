using System;
using UnityEngine;
using UnityEngine.Rendering;

public class DissolveController : MonoBehaviour
{
    private static readonly int Cutoff = Shader.PropertyToID("_Cutoff");
    //[SerializeField] private float cutOff = 0.5f;
    [SerializeField] private GameObject effect;
    [SerializeField] private new Renderer renderer;
    
    [SerializeField] private float dissolveSpeed = 1f;
    private float dissolveAmount = 1f;
    private bool dissolving = false;

    private void Update()
    {
        //renderer.material.SetFloat(Cutoff, cutOff);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dissolving = !dissolving;

            if (effect)
            {
                effect.SetActive(true);
            }
        }

        dissolveAmount = Mathf.MoveTowards(dissolveAmount, dissolving ? 0f : 1f, dissolveSpeed * Time.deltaTime);
        
        renderer.material.SetFloat(Cutoff, dissolveAmount);
        renderer.shadowCastingMode = dissolveAmount > 0.5f ? ShadowCastingMode.On : ShadowCastingMode.Off;
    }
}
