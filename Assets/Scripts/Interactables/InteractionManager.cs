using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionManager : MonoBehaviour
{
    public float interactionRange = 3f;
    public bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public UnityEvent interactionEvent;
    public LayerMask playerLayer;
    public SpriteRenderer GFX;

    void Start()
    {
        
    }

    void Update()
    {
        if(inRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactionEvent.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello");
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            GFX.color = Color.yellow;
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            GFX.color = Color.white;
            Debug.Log("Player is out of range");
        }
    }
}
