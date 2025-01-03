namespace Events.Main.CharactersBattle
{
    public interface ICharacter
    {
        public void TakeAttack(int damage);

        public void Attack(ICharacter character);
        public void StartRound();
    }
}
