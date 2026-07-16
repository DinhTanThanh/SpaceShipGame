using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 2f;
    [SerializeField] protected Image valueLoadScene;
    [SerializeField] protected BorderLoadController borderLoadController;
    protected AsyncOperation asyncLoad;
    protected override void Start()
    {
        base.Start();
        this.asyncLoad = SceneManager.LoadSceneAsync("Scene");
        this.asyncLoad.allowSceneActivation = false;
    }
    private void Update()
    {
        this.LoadSceneByTime();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadValueLoadScene();
        this.LoadBorderLoadController();
    }
    protected virtual void LoadBorderLoadController()
    {
        if (this.borderLoadController != null) return;
        this.borderLoadController = GetComponentInParent<BorderLoadController>();
        Debug.LogWarning("Load BorderLoadController: " + transform.name);
    }
    protected virtual void LoadValueLoadScene()
    {
        if (this.valueLoadScene != null) return;
        this.valueLoadScene=GetComponent<Image>();
        Debug.LogWarning("Load ValueLoadScene: " + transform.name);
    }
    protected virtual void LoadSceneByTime()
    {
        if (this.timer > this.timeDelay)
        {
            if (this.asyncLoad.progress >= 0.9f)
            {
                this.asyncLoad.allowSceneActivation = true;
            }
            return;
        }
        this.timer += Time.deltaTime;
        float percent = Mathf.Clamp01(this.timer / this.timeDelay);
        this.valueLoadScene.fillAmount = percent;
        this.borderLoadController.PercentLoadScene.text = Mathf.CeilToInt(percent * 100).ToString() + "%";
    }
}
