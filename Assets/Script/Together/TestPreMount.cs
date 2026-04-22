using UnityEngine;
using UnityEngine.SceneManagement;
public class TestPreMount : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("An vao press");
        LoadScence();
    }
    protected void LoadScence()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
