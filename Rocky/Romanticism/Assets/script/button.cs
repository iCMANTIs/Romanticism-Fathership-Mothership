using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class button : MonoBehaviour
{
    public GameObject gameObject;
    //设置分辨率
    #region Attributes

    #region Player Pref Key Constants

    private const string resolution_perf_key = "resolution";

    #region Resolution

    [SerializeField]
    private Text resolutionText;

    private Resolution[] resolutions;

    private int currentindex = 0;

    #endregion

    #endregion
    #region misc helpers
    #region index wrap Helpers
    private int Getnextwrappedindex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        return (currentIndex + 1) % collection.Count;
    }
    private int Getperviouswrappedindex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        if ((currentIndex - 1) < 0) return collection.Count - 1;
        return (currentIndex - 1) % collection.Count;

    }
    #endregion
    #endregion
    #endregion

    // Start is called before the first frame update
    public void click()
    {
        Application.Quit();//关软件
    }
    public void clickk()
    {
        SceneManager.LoadScene("0");//回到主菜单
    }
    public void click1()
    {
        gameObject.SetActive(true);
    }
    public void click2()
    {
        gameObject.SetActive(false);//关闭setting

    }
    public void click3()
    {
        SceneManager.LoadScene("01");//开始游戏

    }
    public void click6()
    {
        Screen.fullScreen = true; //设置成全屏,
    }
    public void click7()
    {
        Screen.fullScreen = false; //设置不是全屏,
    }
    void Start()
    {   //设置分辨率
        currentindex = PlayerPrefs.GetInt(resolution_perf_key, 0);
        setresolutiontext(resolutions[currentindex]);
    }
    void Update()
    {
        resolutions = Screen.resolutions;   //设置分辨率
    }
    #region resolution cycling

    //设置分辨率
    private void setresolutiontext(Resolution resolution)
    {
        resolutionText.text = resolution.width + "x" + resolution.height;
    }
    public void setnextresolution()
    {
        currentindex = Getnextwrappedindex(resolutions, currentindex);
        setresolutiontext(resolutions[currentindex]);
    }
    public void setperviousresolution()
    {
        currentindex = Getperviouswrappedindex(resolutions, currentindex);
        setresolutiontext(resolutions[currentindex]);

    }
    #endregion

    #region apply resolution

    //应用分辨率
    private void setandapplyresolution(int newresolutionindex)
    {
        currentindex = newresolutionindex;
        applycurrentresolution();
    }
    private void applycurrentresolution()
    {
        applyresolution(resolutions[currentindex]);
    }
    private void applyresolution(Resolution resolution)
    {
        setresolutiontext(resolution);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(resolution_perf_key, currentindex);
    }
    #endregion
    public void applychanges()
    {
        setandapplyresolution(currentindex);
    }
}