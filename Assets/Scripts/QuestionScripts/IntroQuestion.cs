using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroQuestion : MonoBehaviour {

    public GameObject[] answers;

    public void FuelFill(string _levelName) {
        gameObject.GetComponent<Image>().fillAmount = 1;

        for (int i = 0; i < answers.Length; i++) {
            answers[i].GetComponent<Image>().color = Color.red;
            if (answers[i].name == "CorrectAnswer") {
                answers[i].GetComponent<Image>().color = Color.green;
            }
        }
        StartCoroutine(BeginGame(_levelName));

    }

    IEnumerator BeginGame(string levelName) {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(levelName);
    }
}
