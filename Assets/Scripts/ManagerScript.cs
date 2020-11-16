using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    /// <summary>
    /// Ссылка на человека
    /// </summary>
    public GameObject people;
    /// <summary>
    /// Ссылка на инфецированного
    /// </summary>
    public GameObject infected;

    /// <summary>
    /// Ссылка на панель информации
    /// </summary>
    public GameObject PanelDescription;
    /// <summary>
    /// Ссылка на кнопку панели
    /// </summary>
    public GameObject buttonPanelDescription;

    /// <summary>
    /// Ссылка на текст с населением
    /// </summary>
    public Text peopleText;
    /// <summary>
    /// Ссылка на текст с инфецированными
    /// </summary>
    public Text infectionsText;

    /// <summary>
    /// Общее колличество населения
    /// </summary>
    int totalPeople;
    /// <summary>
    /// Общее колличество инфецированных
    /// </summary>
    int totalInfections;

    /// <summary>
    /// Ссылка на текст погибли от старости
    /// </summary>
    public Text Died_of_old_age;
    /// <summary>
    /// Ссылка на текст погибли от зарожения
    /// </summary>
    public Text Died_of_infection;

    /// <summary>
    /// Хранит значения о погибших от старости
    /// </summary>
    public int total_Died_of_old_age;
    /// <summary>
    /// Хранит значения о погибших от инфекции
    /// </summary>
    public int total_Died_of_infection;

    private void Start()
    {
        gameObject.GetComponent<ManagerScript>();
        infected.GetComponent<Infection>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(people);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Instantiate(people);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(infected);
        }

        if (Input.GetKey(KeyCode.R))
        {
            Instantiate(infected);
        }

        if (PanelDescription && Input.GetKeyDown(KeyCode.Return))
        {
            PanelDescription.SetActive(false);
        }
    }

    private void FixedUpdate()
    {   
        totalPeople = GameObject.FindGameObjectsWithTag("Player").Length;
        peopleText.text = "Население " + totalPeople.ToString();

        totalInfections = GameObject.FindGameObjectsWithTag("Infections").Length;
        infectionsText.text = "Зараженные " + totalInfections.ToString();

        Died_of_old_age.text = "Погибли от старости " + total_Died_of_old_age.ToString();
        Died_of_infection.text = "Погибли от инфекции " + total_Died_of_infection.ToString();
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
}