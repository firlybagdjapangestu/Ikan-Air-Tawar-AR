using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public FishData[] fishData;
    private int fishSelect;

    [SerializeField] private float speed;
    [SerializeField] private Transform maxX;
    [SerializeField] private Transform minX;
    [SerializeField] private Transform maxY;
    [SerializeField] private Transform minY;
    [SerializeField] private Transform maxZ;
    [SerializeField] private Transform minZ;
    private Vector3 destinationDirection;
    // Start is called before the first frame update
    void Start()
    {
        fishSelect = PlayerPrefs.GetInt("SelectFish");
        print("Ikan Ke berapa : " + fishSelect);
        GameObject obj = Instantiate(fishData[fishSelect].fishPrefabs, gameObject.transform.position, gameObject.transform.rotation);
        obj.transform.SetParent(gameObject.transform);
        SetRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationDirection, speed * Time.deltaTime);

        // Calculate fish's facing direction (forward)
        Vector3 fishFacingDirection = destinationDirection - transform.position;
        fishFacingDirection.y = 0; // Keep the fish parallel to the ground
        if (fishFacingDirection != Vector3.zero)
        {
            Quaternion rotationTowardsForward = Quaternion.LookRotation(fishFacingDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationTowardsForward, 0.1f);
        }

        // If reached the destination point, choose a new random destination
        if (transform.position == destinationDirection)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        // Choose a random position within the range (-10, 10) for x, y, and z
        float randomX = Random.Range(minX.position.x, maxX.position.x);
        float randomY = Random.Range(minY.position.y, maxY.position.y);
        float randomZ = Random.Range(minZ.position.z, maxZ.position.z);
        destinationDirection = new Vector3(randomX, randomY, randomZ);
    }
}
