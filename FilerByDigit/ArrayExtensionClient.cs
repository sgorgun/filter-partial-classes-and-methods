using System;
using System.Reflection.Metadata.Ecma335;

namespace FilterByDigit
{
    public static partial class ArrayExtension
    {
        private static long digit;

        public static long Digit
        {
            get => digit;
            set => digit = value <= 9 && value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)} can't be less 0 and more then 9.");
        }

        private static partial bool Verify(int item)
        {
            if (item == digit)
            {
                return true;
            }

            while (item != 0)
            {
                int remainder = item % 10;
                if (remainder == digit || remainder == (digit * -1))
                {
                    return true;
                }

                item /= 10;
            }

            return false;
        }
    }
}
