using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    public string answer;
    public string displayAnswer;

    public string[] hints;

    public string[] GetHints()
    {
        if (hints.Length == 0)
        {
            Debug.Log("Hints not initialized!");
        }

        return hints;
    }
}
