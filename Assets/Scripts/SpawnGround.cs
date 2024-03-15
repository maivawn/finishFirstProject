using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
  
    public List<GameObject> floorPrefabs;
    public Transform playerTransform;
    public float spawnX = 45f; // Thay đổi spawnZ thành spawnX để spawn theo trục x
    public float floorLength = 10f;
    public int numberOfFloorsOnScreen = 7;

    private List<GameObject> activeFloors;
    private int lastPrefabIndex = -1;

    private void Awake()
    {
        activeFloors = new List<GameObject>();

        // Sinh ra floor ban đầu
        for (int i = 0; i < numberOfFloorsOnScreen; i++)
        {
            SpawnFloors();
        }
    }

    private void Update()
    {
        // Thay đổi playerTransform.position.z thành playerTransform.position.x để theo dõi vị trí theo trục x
        if (playerTransform.position.x - 30 > (spawnX - numberOfFloorsOnScreen * floorLength))
        {
            SpawnFloors();
            DeleteFloor();
        }
    }

    private void SpawnFloors()
    {
        int randomIndex = Random.Range(0, floorPrefabs.Count);

        // Kiểm tra xem prefab mới có trùng với prefab trước đó không
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, floorPrefabs.Count);
        }

        lastPrefabIndex = randomIndex; // Lưu lại chỉ số của prefab được sinh ra gần nhất

        GameObject go = Instantiate(floorPrefabs[randomIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(spawnX, 0, 0); // Thay đổi vị trí sinh ra thành Vector3 theo trục x
        spawnX += floorLength;
        activeFloors.Add(go);
    }

    private void DeleteFloor()
    {
        Destroy(activeFloors[0]);
        activeFloors.RemoveAt(0);
    }


}
