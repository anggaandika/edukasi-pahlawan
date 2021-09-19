using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject subMenu;

    // Start is called before the first frame update
    void Start()
    {
        subMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        subMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void SelectedLevel(int level)
    {
        PlayerPrefs.SetInt("selectedLevel", level);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
