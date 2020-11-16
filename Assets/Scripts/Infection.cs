using UnityEngine;

public class Infection : MonoBehaviour
{
    /// <summary>
    /// Ссылка на префаб инфецированного
    /// </summary>
    public GameObject InfectionPrefab;
    /// <summary>
    /// Время жизни инфецированного
    /// </summary>
    float timetoDeath = 10f;

    /// <summary>
    /// Ссылка на sceneManager
    /// </summary>
    GameObject sceneManager;
    /// <summary>
    /// Счетчик заражения
    /// </summary>
    int count = 1;

    private void Start()
    {
        gameObject.GetComponent<Infection>();
        sceneManager = GameObject.FindGameObjectWithTag("ManagerScene");
        sceneManager.GetComponent<ManagerScript>();
        timetoDeath = 10f;
    }

    private void FixedUpdate()
    {
        timetoDeath -= Time.fixedDeltaTime;

        if (timetoDeath <= 0)
        {
            sceneManager.GetComponent<ManagerScript>().total_Died_of_infection += count;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(InfectionPrefab);
            Destroy(other.gameObject);
        }
    }
}
