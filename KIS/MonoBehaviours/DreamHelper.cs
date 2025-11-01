public class DreamHelper : MonoBehaviour
{
    public class DreamInfo
    {
        public HealthManager hm;
        public float cd;
    }
    public List<DreamInfo> dream_cds = new();
    public const float general_cd = 0.2f;
    public bool Exist(HealthManager hm)
    {
        if (hm == null) return true;
        foreach (var di in dream_cds)
        {
            if (di.hm == hm) return true;
        }
        return false;
    }
    public void Add(HealthManager hm)
    {
        if (hm == null) return;
        dream_cds.Add(new DreamInfo() { hm = hm, cd = general_cd });
    }
    public void Update()
    {
        for (int t = dream_cds.Count - 1; t >= 0; t--)
        {
            if (dream_cds[t].hm == null)
            {
                dream_cds.RemoveAt(t);
                continue;
            }
            dream_cds[t].cd -= Time.deltaTime;
            if (dream_cds[t].cd < 0)
            {
                dream_cds.RemoveAt(t);
            }

        }
    }
}