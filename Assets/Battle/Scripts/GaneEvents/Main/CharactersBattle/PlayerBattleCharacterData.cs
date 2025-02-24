using Events.Main.CharactersBattle;

public class PlayerBattleCharacterData
{
    private CharacterBattleData _characterBattleData;

    public CharacterBattleData CharacterBattleData => _characterBattleData;

    public void InitNewPlayer(Bar hPBar)
    {
        _characterBattleData = new CharacterBattleData(hPBar, new ColorBar());
    }
}
