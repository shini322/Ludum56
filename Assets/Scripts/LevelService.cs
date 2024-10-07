using UnityEngine;

[DefaultExecutionOrder(-34)]
public class LevelService : Singleton<LevelService>
{
    [HideInInspector] public BuyerSO CurrentBuyer;

    private int buyerIndex = 0;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        NextBuyer();
    }

    public void NextBuyer()
    {
        if (GameResources.Instance.Buyers.Count < buyerIndex + 1)
        {
            return;
        }
        CurrentBuyer = GameResources.Instance.Buyers[buyerIndex];
        buyerIndex += 1;
    }
}