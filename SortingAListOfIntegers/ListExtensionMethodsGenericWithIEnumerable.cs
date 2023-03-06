using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAListOfIntegers
{
    /// This last static class is the most generic execution of the extension methods. In this case, the application does not even need lists and data structures such as arrays and arraylists can be passed in as well
    /// The datatype is also open ended (generic) so that a string[] and a List<int> both can utilize this extension method. This means that the program doesn't have to worry about cleaning up the data and putting it into the correct data structure
    /// and allows for the merge sort algorithm to sort on different data structures without writing specific extension methods for each of them.
    public static class ListExtensionMethodsGenericWithIEnumerable
    {
        public static IEnumerable<T> MergeSortGenericWithIEnumerable<T>(this IEnumerable<T> inputList)
            where T : IComparable
        {
            if (inputList.Count() <= 1)
            {
                return inputList;
            }

            var leftSideOfArrayList = Enumerable.Empty<T>();
            var rightSideOfArrayList = Enumerable.Empty<T>();
            for (int i = 0; i < inputList.Count(); i++)
            {
                if (i < inputList.Count() / 2)
                {
                    leftSideOfArrayList = leftSideOfArrayList.Concat((new[] { inputList.ElementAt(i) }));
                }
                else
                {
                    rightSideOfArrayList = rightSideOfArrayList.Concat((new[] { inputList.ElementAt(i) }));
                }
            }

            leftSideOfArrayList = MergeSortGenericWithIEnumerable(leftSideOfArrayList);
            rightSideOfArrayList = MergeSortGenericWithIEnumerable(rightSideOfArrayList);
            return MergeArraysGenericWithIEnumerable(leftSideOfArrayList, rightSideOfArrayList);
        }

        private static IEnumerable<T> MergeArraysGenericWithIEnumerable<T>(IEnumerable<T> leftArrayList, IEnumerable<T> rightArrayList)
            where T : IComparable
        {
            IEnumerable<T> mergedArrayList = Enumerable.Empty<T>();
            while (leftArrayList.Any() && rightArrayList.Any())
            {
                T leftValue = leftArrayList.ElementAt(0);
                T rightValue = rightArrayList.ElementAt(0);
                if ((leftValue.CompareTo(rightValue) < 0 && rightValue.CompareTo(leftValue) > 0) || (leftValue.CompareTo(rightValue) == 0 && rightValue.CompareTo(leftValue) == 0))
                {
                    mergedArrayList = mergedArrayList.Concat((new[] { leftValue }));
                    leftArrayList = leftArrayList.Skip(1);
                }
                else
                {
                    mergedArrayList = mergedArrayList.Concat((new[] { rightValue }));
                    rightArrayList = rightArrayList.Skip(1);
                }
            }

            while (leftArrayList.Any())
            {
                T leftValue = leftArrayList.ElementAt(0);
                mergedArrayList = mergedArrayList.Concat((new[] { leftValue }));
                leftArrayList = leftArrayList.Skip(1);
            }

            while (rightArrayList.Any())
            {
                T rightValue = rightArrayList.ElementAt(0);
                mergedArrayList = mergedArrayList.Concat((new[] { rightValue }));
                rightArrayList = rightArrayList.Skip(1);
            }

            return mergedArrayList;
        }
    }
}
