using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float value;
    
    private GameObject enemy;

    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void Update()
    {
        if (!enemy)
        {
            enemy = Instantiate(enemyPrefab);
            
            enemy.transform.position = new Vector3(-2, 1, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);

            WanderingAI wanderingAI = enemy.GetComponent<WanderingAI>();
            if (!wanderingAI) return;
            
            wanderingAI.OnSpeedChanged(value);
        }
    }

    private void OnSpeedChanged(float value)
    {
        this.value = value;
    }
}
