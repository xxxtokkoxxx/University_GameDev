namespace Codebase.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveGameData();
        GameData LoadGameData();
    }
}