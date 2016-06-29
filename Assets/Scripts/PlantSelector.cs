using UnityEngine;
using System.Collections;

public class PlantSelector : MonoBehaviour {

    public static PlantSelector Instance;

    public Vector2 SelectorOffset;
    public float FadeDelay;
    public float NormalFadeOutTime;
    public float QuickFadeOutTime;

    private Feld activeFeld;
    private CanvasGroup canvasGroup;
    private Vector2 UnseenPoint = new Vector2(2000, 2000);
    

	// Use this for initialization
	void Start () {
        if (Instance == null)
            Instance = this;

        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        GetComponent<RectTransform>().anchoredPosition = UnseenPoint;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CenterOn(Feld feld)
    {
        activeFeld = feld;

        GetComponent<RectTransform>().anchoredPosition = activeFeld.GetComponent<RectTransform>().anchoredPosition + SelectorOffset;

        ResetFade();
        StartCoroutine("NormalFadeOut");
    }

    public void OnClick(string ingredient)
    {
        if (!activeFeld)
            return;

        ResetFade();

        switch(ingredient.ToLower())
        {
            case "brokkoli":
                activeFeld.Plant(Zutat.ID.Brokkoli);
                StartCoroutine("QuickFadeOut");
                break;

            case "suesskartoffel":
                activeFeld.Plant(Zutat.ID.Suesskartoffel);
                StartCoroutine("QuickFadeOut");
                break;

            case "tomate":
                activeFeld.Plant(Zutat.ID.Tomate);
                StartCoroutine("QuickFadeOut");
                break;

            case "pilz":
                activeFeld.Plant(Zutat.ID.Pilz);
                StartCoroutine("QuickFadeOut");
                break;

            default:
                Debug.Log("No Ingredient set for this button");
                break;
        }
    }

    private void ResetFade()
    {
        if (NormalFadeOutRunning)
        {
            StopCoroutine("NormalFadeOut");
            NormalFadeOutRunning = false;
        }

        if(QuickFadeOutRunning)
        {
            StopCoroutine("QuickFadeOut");
            QuickFadeOutRunning = false;
        }

        canvasGroup.alpha = 1;
    }

    private bool NormalFadeOutRunning = false;
    IEnumerator NormalFadeOut()
    {
        NormalFadeOutRunning = true;
        float fadeSpeed = 1f / NormalFadeOutTime;

        yield return new WaitForSeconds(FadeDelay);

        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        GetComponent<RectTransform>().anchoredPosition = UnseenPoint;
        NormalFadeOutRunning = false;
    }

    private bool QuickFadeOutRunning = false;
    IEnumerator QuickFadeOut()
    {
        QuickFadeOutRunning = true;
        float fadeSpeed = 1f / QuickFadeOutTime;

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
        GetComponent<RectTransform>().anchoredPosition = UnseenPoint;

        QuickFadeOutRunning = false;
    }
}
