using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scroll : MonoBehaviour {

    public float scrollSpeed = 1;
    public int sceneTimer = 13;

    void Start() {
        StartCoroutine(scroll());
    }

	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.up * scrollSpeed);
	}

    IEnumerator scroll() {
        yield return new WaitForSeconds(sceneTimer);
        SceneManager.LoadScene(0);
    }
}
