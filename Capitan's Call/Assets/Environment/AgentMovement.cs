using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    public Transform startPoint; // Начальная точка маршрута
    public Transform endPoint; // Конечная точка маршрута

    private NavMeshAgent navMeshAgent;
    private Vector3 currentDestination;

    private float timer = 0f; // Таймер для обновления цели
    public float changeDestinationInterval = 15.0f; // Интервал для смены цели

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Назначаем случайную начальную цель
        MoveToRandomDestination();
    }

    private void Update()
    {
        // Обновляем таймер
        timer += Time.deltaTime;

        // Если прошло достаточно времени, меняем цель
        if (timer >= changeDestinationInterval)
        {
            MoveToRandomDestination();
            timer = 0f; // Сбрасываем таймер
        }
    }

    private void MoveToRandomDestination()
    {
        if (navMeshAgent != null)
        {
            // Генерируем случайную цель в диапазоне между startPoint и endPoint
            Vector3 randomDestination = new Vector3(
                Random.Range(startPoint.position.x, endPoint.position.x),
                startPoint.position.y, // Чтобы оставаться на том же уровне Y
                Random.Range(startPoint.position.z, endPoint.position.z)
            );

            // Назначаем агенту новую цель
            navMeshAgent.SetDestination(randomDestination);
        }
    }
}
