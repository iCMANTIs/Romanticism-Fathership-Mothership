using UnityEngine;
using System.Collections;


public class DontDestroyMybgm : MonoBehaviour
{
    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
