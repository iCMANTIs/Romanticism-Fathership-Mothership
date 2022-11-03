using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class test : MonoBehaviour
{
    public GameObject bgmPrefab;
    GameObject bgmInstance = null;
    public Slider slider;
    // Use this for initialization
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        bgmInstance = GameObject.FindGameObjectWithTag("sound");
        if (bgmInstance == null)
        {
            bgmInstance = (GameObject)Instantiate(bgmPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = bgmPrefab.GetComponent<AudioSource>().volume;
    }
}
