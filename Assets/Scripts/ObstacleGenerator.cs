using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.IO;


public class ObstacleGenerator : MonoBehaviour
{
    //Struct
    public struct SavedData{
        public List<int> index;
        public List<Vector3> position;
        public List<Vector3> size;

        public void SaveData(int newIndex, Vector3 newPosition, Vector3 newSize)
        {
            index.Add(newIndex);
            position.Add(newPosition);
            size.Add(newSize);
        }

        public void SaveFile (string path)
		{
            string jsonString = JsonUtility.ToJson(this);
            File.WriteAllText(path, jsonString);
        }
    }

    //Attributes
    public List<GameObject> obstacles = new List<GameObject>();
    public int count = 5;

    private SavedData savedData;

    //Methods

    // Start is called before the first frame update
    void Start()
    {
        savedData.index = new List<int>();
        savedData.position = new List<Vector3>();
        savedData.size = new List<Vector3>();

        Generate();

        string path = Application.dataPath + "/Data/dataFinal.txt";
        if (File.Exists(path))
            LoadData(path);
    }


	private void OnDestroy()
	{
        savedData.SaveFile(Application.dataPath + "/Data/dataFinal.txt");
    }
	private void LoadData(string path)
	{
        string jsonString = File.ReadAllText(path);
        SavedData data = JsonUtility.FromJson<SavedData>(jsonString);
        for (int i = 0; i < data.index.Count; i++)
            CreateObject(data.index[i], data.position[i], data.size[i]);
    }

    private void Generate()
	{
		for (int i = 0; i < count; i++)
		{
            int index = Random.Range(0, obstacles.Count);
            Vector3 position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
            Vector3 size = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f));
            CreateObject(index, position, size);           
            savedData.SaveData(index, position, size);
        }
	}

	private void CreateObject(int index, Vector3 position, Vector3 size)
	{
        GameObject newObstable = Instantiate(obstacles[index], position, Quaternion.identity);
        newObstable.transform.position = position;
        newObstable.transform.localScale = size;
    }
}
