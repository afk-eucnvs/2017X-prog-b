using System.Collections.Generic;
using System.Linq;

namespace CheapPark
{
    public class ParkingMachine
    {
        readonly List<(string licensePlate, int amount)> transactions = new List<(string, int)>();

        public void Checkout(string licensePlate)
        {
            transactions.Add((licensePlate, 200));
        }

        public IReadOnlyDictionary<string, int> GetBalance()
        {
            return transactions
                .GroupBy(x => x.licensePlate, x => x.amount)
                .ToDictionary(x => x.Key, x => x.Sum());
        }
    }
}
