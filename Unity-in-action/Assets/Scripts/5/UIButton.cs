using System;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;

    public Color highlightColor = Color.cyan;

    private void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    private void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        if (targetObject)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
