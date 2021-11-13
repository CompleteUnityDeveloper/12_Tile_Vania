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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            portal = false;
        }
    }

}
