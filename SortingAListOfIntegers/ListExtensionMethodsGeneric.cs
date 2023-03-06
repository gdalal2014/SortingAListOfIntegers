using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAListOfIntegers
{
    ///This is the first generic method -> in this case only the type is generic, the data structure needs to be a list. So a List of Strings and a List of Ints can both get sorted without any issues. 
    public static class ListExtensionMethodsGeneric
    {
        public static List<T> MergeSortGeneric<T>(this List<T> inputList)
            where T : IComparable
        {
            if (inputList.Count <= 1)
            {
                return inputList;
            }

            var leftSideOfArrayList = new List<T>();
            var rightSideOfArrayList = new List<T>();
            for (int i = 0; i < inputList.Count; i++)
            {
                if (i < inputList.Count / 2)
                {
                    leftSideOfArrayList.Add(inputList[i]);
                }
                else
                {
                    rightSideOfArrayList.Add(inputList[i]);
                }
            }

            leftSideOfArrayList = MergeSortGeneric(leftSideOfArrayList);
            rightSideOfArrayList = MergeSortGeneric(rightSideOfArrayList);
            return MergeArraysGeneric(leftSideOfArrayList, rightSideOfArrayList);
        }

        private static List<T> MergeArraysGeneric<T>(List<T> leftArrayList, List<T> rightArrayList)
            where T : IComparable
        {
            List<T> mergedArrayList = new List<T>();
            while (leftArrayList.Count > 0 && rightArrayList.Count > 0)
            {
                T leftValue = leftArrayList[0];
                T rightValue = rightArrayList[0];
                if ((leftValue.CompareTo(rightValue) < 0 && rightValue.CompareTo(leftValue) > 0) || (leftValue.CompareTo(rightValue) == 0 && rightValue.CompareTo(leftValue) == 0))
                {
                    mergedArrayList.Add(leftValue);
                    leftArrayList.RemoveAt(0);
                }
                else
                {
                    mergedArrayList.Add(rightValue);
                    rightArrayList.RemoveAt(0);
                }
            }

            while (leftArrayList.Count > 0)
            {
                T leftValue = leftArrayList[0];
                mergedArrayList.Add(leftValue);
                leftArrayList.RemoveAt(0);
            }

            while (rightArrayList.Count > 0)
            {
                T rightValue = rightArrayList[0];
                mergedArrayList.Add(rightValue);
                rightArrayList.RemoveAt(0);
            }

            return mergedArrayList;
        }
    }
}
