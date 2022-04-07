using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RoadController : MonoBehaviour
{
    public List<GameObject> Bricks;
    public List<GameObject> BossBricks;
    public List<GameObject> MiniBossBricks;
    public uint Size;
    private GameObject lastBrick;

    void Start()
    {
        lastBrick = Instantiate(Bricks[Random.Range(0, Bricks.Count)]);
        lastBrick.transform.parent = transform;

        for(int i = 0; i < Size; i++) {
            if (Random.Range(0, 100) < 15) {
                lastBrick = AddNewBrick(MiniBossBricks[Random.Range(0, MiniBossBricks.Count)], lastBrick);
            }
            else {
                lastBrick = AddNewBrick(Bricks[Random.Range(0, Bricks.Count)], lastBrick);
            }

            lastBrick.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to find specificlu bricks trigger areas
    BoxCollider FindBrickTriggerArea(GameObject obj) {
        foreach(Transform t in obj.transform) {
            if (t.tag == "BrickTrigger") return t.GetComponent<BoxCollider>();
        }
        return null;
    }

    // Add new Brick to the road
    GameObject AddNewBrick(GameObject type, GameObject previous) {
        float spawnPoint = previous?.transform.position.z ?? 0;
        spawnPoint += FindBrickTriggerArea(previous).size.z / 2;
        spawnPoint += FindBrickTriggerArea(type).size.z / 2;
        return Instantiate(type, new Vector3(0, 0, spawnPoint), new Quaternion());
    }
}
