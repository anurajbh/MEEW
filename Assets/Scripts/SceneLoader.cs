using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    Scene scene;
    int sceneIndex;
    [SerializeField] GameObject musicPlayer;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneIndex + 1);
            DontDestroyOnLoad(musicPlayer);
        }
    }
}
