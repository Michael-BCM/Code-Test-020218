using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    private float panelAlpha = 0;

    [SerializeField]
    private Image fadingPanel0, fadingPanel1;

    [SerializeField]
    private GameObject view1Canvas, view2Canvas;
    
    public void StartFadingView1 ()
    {
        StartCoroutine(UIImageFaderView1());
    }
    
    private IEnumerator UIImageFaderView1 ()
    {
        while(fadingPanel0.color.a < 1)
        {
            panelAlpha += Time.deltaTime;

            fadingPanel0.color = new Color(fadingPanel0.color.r, fadingPanel0.color.g, fadingPanel0.color.b, panelAlpha);
            
            yield return 0;
        }
        view1Canvas.SetActive(false);
        view2Canvas.SetActive(true);
        StartCoroutine(UIImageFaderView2());
    }

    private IEnumerator UIImageFaderView2()
    {
        while(fadingPanel1.color.a > 0)
        {
            panelAlpha -= Time.deltaTime;

            fadingPanel1.color = new Color(fadingPanel1.color.r, fadingPanel1.color.g, fadingPanel1.color.b, panelAlpha);
            
            yield return 0;
        }
    }
}