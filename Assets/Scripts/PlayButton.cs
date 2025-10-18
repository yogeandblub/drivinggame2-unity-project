using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject startImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideImage()
    {
        startImage.SetActive(false);
    }
}
