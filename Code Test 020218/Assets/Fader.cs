using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField]
    private Image fadingPanel;

    [SerializeField]
    private Image fadingPanel2;

    private float panelAlpha = 0;

    [SerializeField]
    private GameObject view1Canvas;

    [SerializeField]
    private GameObject view2Canvas;
    
    public void StartFadingView1 ()
    {
        StartCoroutine(UIImageFaderView1());
    }
    
    private IEnumerator UIImageFaderView1 ()
    {
        while(fadingPanel.color.a < 1)
        {
            panelAlpha += Time.deltaTime;

            yield return 0;
        }
        view1Canvas.SetActive(false);
        view2Canvas.SetActive(true);
        StartCoroutine(UIImageFaderView2());
    }

    private IEnumerator UIImageFaderView2()
    {
        while(fadingPanel2.color.a > 0)
        {
            panelAlpha -= Time.deltaTime;

            yield return 0;
        }
    }

    private void Update()
    {
        fadingPanel.color = new Color(fadingPanel.color.r, fadingPanel.color.g, fadingPanel.color.b, panelAlpha);

        fadingPanel2.color = new Color(fadingPanel2.color.r, fadingPanel2.color.g, fadingPanel2.color.b, panelAlpha);
    }
}