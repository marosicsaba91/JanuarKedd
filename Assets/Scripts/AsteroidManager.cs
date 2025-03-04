using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid[] startAsteroids;
    [SerializeField] float minDistanceFromShapeship;

    void Start()
    {
        CameraManager cameraManager = FindAnyObjectByType<CameraManager>();
        SpaceshipController spaceship = FindAnyObjectByType<SpaceshipController>();
        Vector3 spaceShipPoint = spaceship.transform.position;

        foreach (Asteroid item in startAsteroids)
        {
            Vector3 position = Vector3.zero;
            int testCount = 10;
            for (int i = 0; i < testCount; i++)
            {
                position = cameraManager.GetRandomPositionInCamera();

                if (Vector3.Distance(position, spaceShipPoint) >= minDistanceFromShapeship)
                    break;

                if (i == testCount - 1)
                    Debug.LogError("No valid asteroid position found!");
            }

            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            Asteroid newAsteroid = Instantiate(item, position, rotation);
        }
    }
}
