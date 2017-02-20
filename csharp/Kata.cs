using System;
public class Kata
{
    public static int[] FoldArray(int[] array, int runs)
    {
        int[] fa = array;

        // fold the array according to the run number
        while (runs > 0)
        {
            fa = FoldArray(fa);
            runs--;
        }

        return fa;
    }

    /// <summary>
    /// Fold the array by the middle
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    static int[] FoldArray(int[] array)
    {
        // 1 integer only
        if (array.Length == 1) return array;
        // 2 integers only
        if (array.Length == 2) return new int[] { array[0] + array[1] };

        // split the array to 2 parts
        int middle = array.Length % 2 == 0 ? array.Length / 2 - 1: array.Length / 2;

        // create a new array with the first half
        int[] firstHalf = new int[middle + 1];
        int[] secondHalf = new int[array.Length - firstHalf.Length];
        Array.Copy(array, firstHalf, firstHalf.Length);
        Array.Copy(array, middle + 1, secondHalf, 0, secondHalf.Length);

        // add the second half reversely
        for(int i = 0; i < firstHalf.Length; i++)
        {
            int secondTail = secondHalf.Length - 1 - i;
            if (secondTail < 0) break;
            firstHalf[i] += secondHalf[secondTail];
        }

        return firstHalf;
    }
}

