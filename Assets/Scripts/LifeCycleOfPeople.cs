using System.Collections;
using UnityEngine;

public class LifeCycleOfPeople : MonoBehaviour
{
    /// <summary>
    /// Ссылка на население
    /// </summary>
    public GameObject peoplePrefs;
    /// <summary>
    /// Время до рождения
    /// </summary>
    float timeBirth = 20f;
    /// <summary>
    /// Время до смерти
    /// </summary>
    float dead = 40f;
    /// <summary>
    /// Таймер
    /// </summary>
    float timer = 0f;

    /// <summary>
    /// Счетчик заражения
    /// </summary>
    int count = 1;
    /// <summary>
    /// Ссылка на sceneManager
    /// </summary>
    GameObject sceneManager;
    /// <summary>
    /// Случайное число определяет колл-во рождений
    /// </summary>
    int randomBirth;

    private void Start()
    {
        gameObject.GetComponent<LifeCycleOfPeople>();
        StartCoroutine(Berth());
        timer = 0f;
        randomBirth = Random.Range(0, 4);
        sceneManager = GameObject.FindGameObjectWithTag("ManagerScene");
        sceneManager.GetComponent<ManagerScript>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= dead)
        {
            sceneManager.GetComponent<ManagerScript>().total_Died_of_old_age += count;
            Destroy(gameObject);
        }
    }
    IEnumerator Berth()
    {
        yield return new WaitForSeconds(timeBirth);

        for (int i = 0; i < randomBirth; i++)
        {
            Instantiate(peoplePrefs);
        }
    }
}