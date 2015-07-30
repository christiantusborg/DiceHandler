using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiceHandler
{
    public class Dice
    {
        private static readonly RNGCryptoServiceProvider RngCsp = new RNGCryptoServiceProvider();

        private static byte Random(byte numberSides)
        {
            if (numberSides <= 0)
                throw new ArgumentOutOfRangeException("numberSides");


            var randomNumber = new byte[1];

            do
            {
                RngCsp.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0], numberSides));

            return (byte)((randomNumber[0] % numberSides) + 1);
        }

        private static bool IsFairRoll(byte roll, byte numSides)
        {

            int fullSetsOfValues = Byte.MaxValue / numSides;
            return roll < numSides * fullSetsOfValues;
        }

        public int Roll(DiceType diceType)
        {
           return Random((byte) diceType);
        }

        public List<int> Roll(DiceType diceType, int numberOfDice)
        {
            List<int> listOfRolls = new List<int>();

            for (int i = 1; i < numberOfDice; i++)
            {
                listOfRolls.Add(Roll(diceType));
            }

            return listOfRolls;
        }

    }
}
