using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    // Structures
    [System.Serializable]
    public struct DataBucket
    {
        public int explotionCount;
        public int spawnCount;
        public int collisionCount;

        public void Save(string path)
        {
            string json = JsonUtility.ToJson(this);
            File.WriteAllText(path, json);
        }
    }

    // Attributes
    public DataBucket bucket;

    // Methods
    // Start is called before the first frame update
    void Start()
    {
        bucket.explotionCount = 0;
        bucket.spawnCount = 0;
        bucket.collisionCount = 0;
    }

    public void CollectData (KPIType type)
    {
        switch(type)
        {
            case KPIType.ExplodedBallsKPI:
                bucket.explotionCount++;
                break;
            case KPIType.SpawnedBallsKPI:
                bucket.spawnCount++;
                break;
            case KPIType.CollisionKPI:
                bucket.collisionCount++;
                break;
        }
    }

    public void OnDestroy()
    {
        bucket.Save(Application.dataPath + "/Data/dataBucket.txt");
    }
}
