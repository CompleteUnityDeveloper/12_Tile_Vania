using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Portals : MonoBehaviour
{

    private float loadTime = 2f;
    [SerializeField] AudioClip loadLevelSFX;
    private bool portal = false;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        PortalKey();
    }


    private void PortalKey()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump") && portal == true)
        {
            Debug.Log("Loaded level " + gameObject.name);
            StartCoroutine("LoadLevel");
        }
    }

    IEnumerator LoadLevel()
    {
        FindObjectOfType<Overlay>().FadeOut(loadTime);

        AudioSource.PlayClipAtPoint(loadLevelSFX, transform.position);

        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            portal = true;
            
            // Stops the player jump animation
            player.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            portal = false;

            // Enables the player jump animation
            player.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
