using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public AudioClip buttonSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    public void StartButton()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();
        StartCoroutine(ButtonPressed());
        //SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {

    }

    IEnumerator ButtonPressed()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1);
    }

}
