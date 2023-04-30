using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Manager : MonoBehaviour {

    public string loadLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadLevel);
        }
    }

}
