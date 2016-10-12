using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroQuestion : MonoBehaviour {

    public GameObject[] answers;

    public void FuelFill() {
        gameObject.GetComponent<Image>().fillAmount = 1;

        for (int i = 0; i < answers.Length; i++) {
            answers[i].GetComponent<Image>().color = Color.red;
            if (answers[i].name == "CorrectAnswer") {
                answers[i].GetComponent<Image>().color = Color.green;
            }
        }
    }
}
