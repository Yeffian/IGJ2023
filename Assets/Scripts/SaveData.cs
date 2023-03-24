[System.Serializable]
public class SaveData
{
    public SaveData()
    {
        Kills = 0;
        Switches = 0;
    }
    
    public int Kills { get; set; }
    
    public int Switches { get; set; }
}
