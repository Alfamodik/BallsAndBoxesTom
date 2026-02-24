
namespace YG
{
    [System.Serializable]
    public partial class SavesYG
    {
        public int idSave;
        
        public int money;
        public int level;
        public int[] upgradeLevels = new int[11];
        public float[] ballPrices = new float[5];
        public int[] ballCounts = new int[5];
    }
}
