namespace Village;

public class PlayerInventory
{
    int coins;
    bool gotAFishingRod;
    bool gotABall;

    public int Coins { get { return coins; } }
    public bool GotAFishingRod { get { return gotAFishingRod; } }
    public bool GotABall { get { return gotABall; } }

    public void AddCoin() { coins++; }

    public void TakeFishingRod() { gotAFishingRod = true; }

    public void TakeBall() { gotABall = true; }

    public PlayerInventory()
    {
        coins = 0;
        gotAFishingRod = false;
        gotABall = false;
    }
}
