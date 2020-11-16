using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    /// <summary>
    /// Прибытие в точку
    /// </summary>
    bool hasArrived;
    /// <summary>
    /// Продолжительность движения
    /// </summary>
    float movementDuration = 2.0f;
    /// <summary>
    /// Ожидание перед движением
    /// </summary>
    float waitBeforeMoving = 0.5f;

    private void Start()
    {
        gameObject.GetComponent<Move>();
    }
    void FixedUpdate()
    {
        if (!hasArrived)
        {
            hasArrived = true;
            StartCoroutine(MoveToPoints());
        }
    }

    private IEnumerator MoveToPoints()
    {
        Vector3[] v = new Vector3[100];

        for (int i = 0; i < v.Length; i++)
        {
            float timer = 0.0f;
            Vector3 startPos = transform.position;
            v[i] = new Vector3(Random.Range(-350.0f, 350.0f),
                    Random.Range(0.0f, 0.0f),
                    Random.Range(-170.0f, 170.0f));

            while (timer < movementDuration)
            {
                timer += Time.deltaTime;
                float t = timer / movementDuration;
                t = t * t * t * (t * (6f * t - 15f) + 10f);
                transform.position = Vector3.Lerp(startPos, v[i], t);
                yield return null;
            }
            yield return new WaitForSeconds(waitBeforeMoving);
        }
    }
}