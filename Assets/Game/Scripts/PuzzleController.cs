using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures1;
    [SerializeField]
    private Transform[] pictures2;
    public GameObject wall;
    public GameObject wall2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pictures1[0].rotation.z == 0 &&
           pictures1[1].rotation.z == 0 &&
           pictures1[2].rotation.z == 0 &&
           pictures1[3].rotation.z == 0 &&
           pictures1[4].rotation.z == 0 &&
           pictures1[5].rotation.z == 0 &&
           pictures1[6].rotation.z == 0 &&
           pictures1[7].rotation.z == 0 &&
           pictures1[8].rotation.z == 0)
        {
            //벽 제거
            Destroy(wall);
        }

        if (pictures2[0].rotation.z == 0 &&
           pictures2[1].rotation.z == 0 &&
           pictures2[2].rotation.z == 0 &&
           pictures2[3].rotation.z == 0 &&
           pictures2[4].rotation.z == 0 &&
           pictures2[5].rotation.z == 0 &&
           pictures2[6].rotation.z == 0 &&
           pictures2[7].rotation.z == 0 &&
           pictures2[8].rotation.z == 0)
        {
            //벽 제거
            Destroy(wall2);
        }

    }
}
