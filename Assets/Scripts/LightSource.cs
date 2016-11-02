namespace Assets.Scripts
{
    [System.Serializable]
    public class LightSource
    {
        public int iStrength, iLevel;
        public LightSource(int strength, int level)
        {
            this.iStrength = strength;
            this.iLevel = level;
        }
    }
}