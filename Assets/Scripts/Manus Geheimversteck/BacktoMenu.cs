using UnityEngine;
using System.Collections;

public class BacktoMenu : MonoBehaviour {

    public GameObject gameMode;
    public GameObject iventoryMode;

    // Goes Back to the Menucavas
    public void Back()
    {
        gameMode.active = true;
        iventoryMode.active = false;
    }
}
