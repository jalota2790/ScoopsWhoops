using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    public GameObject obj;
    public int count;

    public List<GameObject> objects;
    public List<GameObject> objectsInUse;

    void Start()
    {
        objects = new List<GameObject>();
        objectsInUse = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(this.obj);
            objects.Add(obj);
            obj.SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        GameObject obj = 
        objectsInUse.Add()
        return objects.Last();
    }         
}
