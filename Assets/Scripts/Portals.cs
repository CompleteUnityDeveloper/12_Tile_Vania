using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Portals : MonoBehaviour
{

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
        FindObjectOfType<Overlay>().FadeOut(2f);

        AudioSource.PlayClipAtPoint(loadLevelSFX, transform.position);

        yield return new WaitForSeconds(2f);
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
