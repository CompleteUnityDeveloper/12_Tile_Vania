using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{

    // Declare spriteRenderer
    SpriteRenderer spriteRenderer;


    void Start()
    {
        // Initialize the spriteRenderer
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    public void ChangeBubble(Sprite bubble)
    {
        spriteRenderer.sprite = bubble;

        StartCoroutine("BubbleNone");
    }

    IEnumerator BubbleNone()
    {
        yield return new WaitForSeconds(5f);
        spriteRenderer.sprite = null;
    }

    // Flip Speech Bubble so text is legible
    public void FlipSprite()
    {
        spriteRenderer.flipX = true;
    }
    // Flip Speech Bubble back so text is legible
    public void DefaultSprite()
    {
        spriteRenderer.flipX = false;
    }

}
