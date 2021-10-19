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

        int selectedLevel = PlayerPrefs.GetInt("selectedLevel");

        if (selectedLevel.Equals(1))
        {
            subMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
        else
        {
            subMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
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
        if (GameObject.Find("MasterGame"))
        {
            GameObject
                .Find("MasterGame")
                .GetComponent<PuzzelLevelSelection>()
                .enabled = true;
            GameObject.Find("MasterGame").GetComponent<TimerSetting>().enabled =
                true;
        }
    }
}
