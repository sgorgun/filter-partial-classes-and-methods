using System;

namespace FilterByPalindromic
{
    public static partial class ArrayExtension
    {
        private static partial bool Verify(int item)
        {
            if (item < 0)
            {
                return false;
            }

            int reverse = 0;
            int temp = item;

            while (temp != 0)
            {
                reverse = (reverse * 10) + (temp % 10);
                temp /= 10;
            }

            return reverse == item;
        }
    }
}
