using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAListOfIntegers
{
    //This is the basic class that is there for the sorting algorithm. This is an internal class and to use it, it must be instantiated first using a constructor. Then there is
    //a Public method -> sortArrayList which takes in a value of List<int>. This public method calls on two private methods to do the sorting and returns a sorted list.
    //The sorting is done using merge sort algorithm. The pseudocode can be found at the following website: https://en.wikipedia.org/wiki/Merge_sort#Top-down_implementation_using_lists
    public class SortingClass
    {
        public SortingClass()
        {
        }

        public static List<int> SortArrayList(List<int> inputList)
        {
            inputList = MergeSort(inputList);
            return inputList;
        }

        private static List<int> MergeSort(List<int> inputList)
        {
            if (inputList.Count <= 1)
            {
                return inputList;
            }

            List<int> leftSideOfArrayList = new List<int>();
            List<int> rightSideOfArrayList = new List<int>();
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

            leftSideOfArrayList = MergeSort(leftSideOfArrayList);
            rightSideOfArrayList = MergeSort(rightSideOfArrayList);
            return MergeArrays(leftSideOfArrayList, rightSideOfArrayList);
        }

        private static List<int> MergeArrays(List<int> leftArrayList, List<int> rightArrayList)
        {
            List<int> mergedArrayList = new List<int>();
            while (leftArrayList.Count > 0 && rightArrayList.Count > 0)
            {
                int leftValue = leftArrayList[0];
                int rightValue = rightArrayList[0];
                if (leftValue <= rightValue)
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
                int leftValue = leftArrayList[0];
                mergedArrayList.Add(leftValue);
                leftArrayList.RemoveAt(0);
            }

            while (rightArrayList.Count > 0)
            {
                int rightValue = rightArrayList[0];
                mergedArrayList.Add(rightValue);
                rightArrayList.RemoveAt(0);
            }

            return mergedArrayList;
        }
    }
}
