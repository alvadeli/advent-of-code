using System.Linq.Dynamic.Core;

namespace day11
{
    public class Player
    {
 
        private Func<long, long> _operation;
        
        private string _throwRecipientTrue = "";
        private string _throwRecipientFalse = "";

        public Player(Func<long, long> operation, 
                        int divisor, 
                        string throwRecipientTrue, 
                        string throwRecipientFalse, 
                        string name, 
                        List<long> startingItems)
        {
            _operation = operation;
            Divisor = divisor;
            _throwRecipientTrue = throwRecipientTrue;
            _throwRecipientFalse = throwRecipientFalse;
            Name = name;
            StartingItems = startingItems;
        }

        public void ThrowItems(List<Player> players, bool decreaseWorryLevel, long commonDivisior =3) 
        {
            foreach (var item in StartingItems) 
            {
                var newItemValue = _operation(item);
                newItemValue %= commonDivisior;
                if (decreaseWorryLevel) newItemValue /= 3;

                bool check = newItemValue % Divisor == 0;


                var recipientName = check ? _throwRecipientTrue : _throwRecipientFalse;
                var recipient = players.First(p => p.Name.Equals(recipientName,StringComparison.InvariantCultureIgnoreCase));
                recipient.StartingItems.Add(newItemValue);
                ItemInspections++;
            }

            StartingItems.Clear();
        }

        public string Name {get; private set; } = "";

        public List<long> StartingItems { get; private set; } = new List<long>();
        public long ItemInspections = 0;
        public int Divisor { get; private set; }
    }
}
