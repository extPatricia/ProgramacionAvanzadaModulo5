using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    // Structs
    [Serializable]
    public struct FigureInstanceData
    {
        public string type;
        public Vector3 position;
        public Color color;
    }

    [Serializable]
    public struct FigureData
    {
        public List<FigureInstanceData> figures;

        public void Init()
        {
            if (figures == null)
                figures = new List<FigureInstanceData>();
        }
        public void SaveFile(string path)
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(path, json);
        }
    }
    // Attributes
    public GameObject[] arrayPrefabs;

    // Private attributes
    private List<GameObject> prefabList = new List<GameObject>();
    private FigureData figureData;

    // Methods
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press 1 to spawn Cube, 2 to spawn Sphere, 3 to spawn Capsule");

        string path = Application.dataPath + "/Data/figureData.txt";
        if (File.Exists(path))
        {
            LoadData(path);
        }
        else
        {
            figureData = new FigureData();
            figureData.Init();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SpawnFigure(0, "Cube");
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SpawnFigure(1, "Sphere");
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SpawnFigure(2, "Capsule");
    }

    private void SpawnFigure(int index, string figureType)
    {
        Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-8f, 8f), 1f, UnityEngine.Random.Range(-8f, 8f));

        GameObject figure = Instantiate(arrayPrefabs[index], randomPosition, Quaternion.identity);
        prefabList.Add(figure);

        MeshRenderer meshRenderer = figure.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        }

        // Save instance data
        FigureInstanceData instanceData = new FigureInstanceData
        {
            type = figureType,
            position = randomPosition,
            color = meshRenderer != null ? meshRenderer.material.color : Color.white
        };
        figureData.figures.Add(instanceData);
    }

    private void LoadData(string path)
    {
        string jsonString = File.ReadAllText(path);
        figureData = JsonUtility.FromJson<FigureData>(jsonString);
        figureData.Init();

        foreach (FigureInstanceData data in figureData.figures)
        {
            GameObject prefab = null;
            switch (data.type)
            {
                case "Cube":
                    prefab = arrayPrefabs[0];
                    break;
                case "Sphere":
                    prefab = arrayPrefabs[1];
                    break;
                case "Capsule":
                    prefab = arrayPrefabs[2];
                    break;
            }
            if (prefab != null)
            {
                GameObject figure = Instantiate(prefab, data.position, Quaternion.identity);
                MeshRenderer meshRenderer = figure.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.material.color = data.color;
                }

                prefabList.Add(figure);
            }
        }

    }

    private void OnApplicationQuit()
    {
        figureData.SaveFile(Application.dataPath + "/Data/figureData.txt");
    }
}
