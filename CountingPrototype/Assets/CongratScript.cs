using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay;

    [SerializeField] private float RotatingSpeed = 5f;
    private float TimeToNextText;

    private int CurrentText;

    private void Awake()
    {
        TextToDisplay = new List<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;

        TextToDisplay.Add("Congratulations");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];

        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;

        Text.transform.Rotate(Vector3.back * Time.deltaTime * RotatingSpeed, Space.World);

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }

            Text.text = TextToDisplay[CurrentText];
        }
    }
}