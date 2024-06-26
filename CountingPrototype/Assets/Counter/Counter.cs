using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private int delay = 15;

    public Text CounterText;
    public Text timeText;
    public Text winnerText;

    private int Count = 0;
    private float time;



    private void Start()
    {
        winnerText.gameObject.SetActive(false);
        Count = 0;
        time = delay;

        Invoke(nameof(ReloadScene), delay);
    }

    private void Update()
    {
        if (time >= 0)
        {
            timeText.text = "Time :" + string.Format("{0:00}", time);
            time -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;

        if (Count == 1)
        {
            winnerText.gameObject.SetActive(true);
            winnerText.text = "Winner is : " + other.name;
        }

        CounterText.text = "Count : " + Count;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
