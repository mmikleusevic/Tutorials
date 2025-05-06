using _9;
using UnityEngine;

public class WebLoadingBillboard : MonoBehaviour
{
    public void Operate()
    {
        ManagersWeather.Images.GetWebImage(OnWebImage);
    }

    private void OnWebImage(Texture2D texture)
    {
        GetComponent<Renderer>().material.mainTexture = texture;
    }
}
