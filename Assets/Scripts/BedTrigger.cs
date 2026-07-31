using UnityEngine;
using UnityEngine.SceneManagement;

public class BedTrigger : MonoBehaviour
{
    public GameObject sleepPromptUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sleepPromptUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sleepPromptUI.SetActive(false);
        }
    }

    public void OnYesPressed()
    {
        SceneManager.LoadScene("DreamScene");
    }

    public void OnNoPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}