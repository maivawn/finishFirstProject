using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSpwan : MonoBehaviour
{
    public GameObject objectPrefab;
    public int pooledAmount = 20;
    List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckSpawn"))
        {
            GameObject obj = GetPooledObject();
            if (obj != null)
            {
                // Tìm và xóa đối tượng cũ
                GameObject oldObject = FindActiveObject();
                if (oldObject != null)
                {
                    oldObject.SetActive(false);
                }

                // Kích hoạt đối tượng mới
                obj.transform.position = transform.position;
                obj.SetActive(true);
            }
        }
    }

    // Hàm này tìm và trả về đối tượng đang hoạt động
    GameObject FindActiveObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
}

