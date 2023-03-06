using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAListOfIntegers
{
    ///This is a static class which is the first set of static extension methods created. In this case, it is the least generic and won't sort anything that isn't a List<int>
    ///To call these methods, once a list is defined in the main execution of the program, it will be available as a method. An example of this is the following:
    /// List<int> orderedArrayList2 = listOfInputs.mergeSort(); -> in this case listOfInputs object can call on mergeSort from below, and what is returned is a sorted
    /// List of integers
    public static class ListExtensionMethods
    {
        public static List<int> MergeSort(this List<int> inputList)
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
