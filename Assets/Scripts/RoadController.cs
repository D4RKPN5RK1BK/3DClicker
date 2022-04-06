using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RoadController : MonoBehaviour
{
    public List<GameObject> Bricks;
    public List<GameObject> BossBricks;
    public List<GameObject> MiniBossBricks;
    public uint Size;

    void Start()
    {
        List<GameObject> brickList = new List<GameObject>();
        float distance = 0;

        for(int i = 0; i < Size; i++) {
            GameObject temp;

            if (i % 3 == 1) {
                temp = Instantiate(MiniBossBricks[Random.Range(0, MiniBossBricks.Count)], new Vector3(0, 0, distance), new Quaternion());
            }
            else {
                temp = Instantiate(Bricks[Random.Range(0, Bricks.Count)], new Vector3(0, 0, distance), new Quaternion());
            }

            BoxCollider box = FindBrickTriggerArea(temp).GetComponent<BoxCollider>();
            temp.transform.parent = transform;
            distance += box.size.z;
            Debug.Log("Current distance = " + distance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject FindBrickTriggerArea(GameObject obj) {
        foreach(Transform t in obj.transform) {
            if (t.tag == "BrickTrigger") return t.gameObject;
        }
        return null;
    }
}
