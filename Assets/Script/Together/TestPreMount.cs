using UnityEngine;
using UnityEngine.SceneManagement;
public class TestPreMount : LoadMonoBehaviour
{
    [SerializeField] protected EnemyMotherShipCtrl enemyMotherShipCtrl;
    public EnemyMotherShipCtrl EnemyMotherShipCtrl => enemyMotherShipCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyMotherShipCtrl();
    }
    protected virtual void LoadEnemyMotherShipCtrl()
    {
        if (this.enemyMotherShipCtrl != null) return;
        this.enemyMotherShipCtrl=FindFirstObjectByType<EnemyMotherShipCtrl>();
        Debug.LogWarning("Load EnemyMotherShipCtrl: " + transform.name);
    }
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Scence");
        if (!this.enemyMotherShipCtrl.DameReceiver.IsDead)
        {
            Debug.Log("Khong duoc qua man");
            return;
        }
        LoadScence();
    }
    protected void LoadScence()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
