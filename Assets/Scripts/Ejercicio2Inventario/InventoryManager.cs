using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static FigureSpawner;

public class InventoryManager : MonoBehaviour
{
    [Serializable]
    public struct InventoryItem
    {
        public string itemType;
        public bool collected;
        public Color color;
    }

    public struct InventoryData
    {
        public List<InventoryItem> items;
        public void Init()
        {
            if (items == null)
                items = new List<InventoryItem>();
        }

        public void SaveFile(string path)
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(path, json);
        }
    }

    // Attributes
    public GameObject[] arrayPrefabs;
    public int spawnCountperType = 5;

    // Private attributes
    private InventoryData inventoryData;
    private List<GameObject> activeCollectables = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Data/inventoryData.txt";
        if (File.Exists(path))
        {
            LoadInventory(path);
        }
        else
        {
            inventoryData = new InventoryData();
            inventoryData.Init();
        }

        SpawnCollectables();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                Collectable collectable = clickedObject.GetComponent<Collectable>();

                if (collectable != null && activeCollectables.Contains(clickedObject))
                {                
                    for (int i = 0; i < inventoryData.items.Count; i++)
                    {
                        if (!inventoryData.items[i].collected && inventoryData.items[i].itemType == collectable.itemType)
                        {
                            InventoryItem temp = inventoryData.items[i];
                            temp.collected = true;
                            inventoryData.items[i] = temp;
                            break;
                        }
                    }
                    activeCollectables.Remove(clickedObject);
                    Destroy(clickedObject);
                }
            }
        }
    }
    private void SpawnCollectables()
    {
        for(int i = 0; i < arrayPrefabs.Length; i++)
        {            
            GameObject prefab = arrayPrefabs[i];
            Collectable tempCollectable = prefab.GetComponent<Collectable>();
            if (tempCollectable == null)
            {
                Debug.LogError("Prefab " + prefab.name + " does not have a Collectable component.");
                break;
            }

            string itemType = tempCollectable.itemType;

            for (int j = 0; j < spawnCountperType; j++)
            {

                Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-3f, 3f), 3f);
                GameObject collectable = Instantiate(arrayPrefabs[i], randomPosition, Quaternion.identity);
                MeshRenderer renderer = collectable.GetComponent<MeshRenderer>();
                Color randomColor = Color.white;
                if (renderer != null)
                {
                    randomColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                    renderer.material.color = randomColor;
                }

                activeCollectables.Add(collectable);
                InventoryItem newItem = new InventoryItem
                {
                    itemType = itemType,
                    collected = false,
                    color = randomColor,
                };
                inventoryData.items.Add(newItem);
            }
            
        }
    }

    private void LoadInventory(string path)
    {
        string jsonString = File.ReadAllText(path);
        inventoryData = JsonUtility.FromJson<InventoryData>(jsonString);
        inventoryData.Init();

        // Respawn uncollected items
        foreach (InventoryItem item in inventoryData.items)
        {
            if (!item.collected)
            {
                GameObject prefab = Array.Find(arrayPrefabs, p => p.GetComponent<Collectable>()?.itemType == item.itemType);
                if (prefab != null)
                {
                    Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(1f, 5f), UnityEngine.Random.Range(-8f, 8f));
                    GameObject collectable = Instantiate(arrayPrefabs[Array.FindIndex(arrayPrefabs, prefab => prefab.name == item.itemType)], randomPosition, Quaternion.identity);
                    MeshRenderer renderer = collectable.GetComponent<MeshRenderer>();
                    if (renderer != null)
                    {
                        renderer.material.color = item.color;
                    }

                    activeCollectables.Add(collectable);
                }
                
            }
        }
    }

    private void OnApplicationQuit()
    {
        inventoryData.SaveFile(Application.dataPath + "/Data/inventoryData.txt");
    }
}
