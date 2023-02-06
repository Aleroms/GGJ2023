using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamplayUIManager : MonoBehaviour
{
    public GameObject numHiddenWeedsUI;
    public GameObject numDigsUI;

    public GameObject losePanel;
    public GameObject winPanel;

    public GameObject messageDisplay;


    //private TestMeshPro

    // Start is called before the first frame update
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            updateNumHiddenWeeds(4);

        if (Input.GetKeyDown(KeyCode.B))
            updateNumDigs(2);

        if (Input.GetKeyDown(KeyCode.C))
            showLosePanel();

        if (Input.GetKeyDown(KeyCode.D))
            showWinPanel();
    }*/

    public void updateNumHiddenWeeds(int numHiddenWeeds)
    {
        numHiddenWeedsUI.GetComponent<TMPro.TextMeshProUGUI>().text = numHiddenWeeds.ToString();
        //Debug.Log(numHiddenWeedsUI.GetComponent<TMPro.TextMeshProUGUI>().text);
    }

    public void updateNumDigs(int numDigs)
    {
        numDigsUI.GetComponent<TMPro.TextMeshProUGUI>().text = numDigs.ToString();
    }
    public void UpdateMessageDisplay(string msg)
    {
        messageDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = msg;
        //StartCoroutine(MessageCoroutine(msg));
    }
    private IEnumerator MessageCoroutine(string msg)
    {
        messageDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = msg;
        yield return new WaitForSeconds(2f);
        messageDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "";

    }

    public void showLosePanel()
    {
        losePanel.SetActive(true);
        losePanel.GetComponent<Image>().raycastTarget = true;
    }

    public void showWinPanel()
    {
        winPanel.SetActive(true);
        winPanel.GetComponent<Image>().raycastTarget = true;
    }
}
