using System;

namespace Module3_Exercise1.DifferentCollections;

internal static class GenericsExample
{
    public static void SwapObj(ref object left, ref object right)
    {
        (right, left) = (left, right);
    }

    public static void Swap<T1>(ref T1 left, ref T1 right)
    {
        (right, left) = (left, right);
    }

    public static void SwapOld<T>(ref T left, ref T right)
    {
        T temp = left;
        left = right;
        right = temp;
    }
}
