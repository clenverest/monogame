

namespace Village;

public class Achievements
{
    bool wellIsVisited;
    int cleanedDirt;
    bool isWin;

    public bool WellIsVisited { get { return wellIsVisited; } }
    public int CleanedDirt { get { return cleanedDirt; } }

    public bool IsWin { get { return isWin; } }

    public Achievements()
    {
        wellIsVisited = false;
        cleanedDirt = 0;
        isWin = false;
    }

    public void VisitWell() { wellIsVisited = true; }
    public void CleanDirt() { cleanedDirt++; }

    public void Win() { isWin = true; }
}
