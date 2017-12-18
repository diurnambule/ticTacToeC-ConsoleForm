namespace MorpionExtra
{
    internal class Human : Player
    {
        private string v;

        public Human(string v, bool isCross):base(isCross)
        {
            this.v = v;
        }
    }
}