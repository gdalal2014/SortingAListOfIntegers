using System.Text;

namespace SortingAListOfIntegers
{


    public class Program
    {
        ///Assumptions I made when i started this coding exercise
        ///1. The first assumption was that this would be a console application and the input into the console application would be fed in as part of the parameters. Something like: dotnet run inputvalues
        ///2. That an input would not be required from the console where Console.readline() argument would be needed
        ///3. I also made the assumption that only one list of integers would need to be sorted
        ///4. Merge Sort was the sorting algorithm used and the pseudocode that was implemented was the following: https://en.wikipedia.org/wiki/Merge_sort#Top-down_implementation_using_lists
        public static void Main(string[] args)
        {
            RunSortingProgram();
        }

        public static void RunSortingProgram()
        {
            //var inputValues = args;
            //string[] inputValues = {"43,56,87,93,09,12,87,45,38,20,03,09, 8,78,478,485,34875,0458,049,49, 8948, 84,  9048, -449"};
            string[] inputValuesRandStrings = { "Hello,Bye,Why,Come,Go,Yes,No,Wow,Hello,Hi,Well,This, Needs,to,be,checked,UPPERCASE,lowercase,AlLcAsE" };
            var rnd = new Random();
            long lengthOfArray = 25;
            var inputListString = new StringBuilder();
            for (int i = 0; i <= lengthOfArray; i++)
            {
                double num = rnd.Next(1, 10000);
                if (i != lengthOfArray)
                {
                    inputListString.Append(num).Append(",");
                }
                else
                {
                    inputListString.Append(num);
                }
            }

            string[] inputValues = { inputListString.ToString() };
            try
            {
                if (inputValues == null)
                {
                    throw new Exception("Input Can Not Be Null");
                }
                else if (inputValues.Length == 0)
                {
                    throw new Exception("Input has to be given");
                }

                if (inputValues.Length != 1)
                {
                    throw new Exception("Only One Input Can Be Given");
                }
                else
                {
                    var listOfInputs = new List<int>();
                    var splitUpValues = inputValues[0].Split(',');
                    for (int i = 0; i < splitUpValues.Length; i++)
                    {
                        if (!int.TryParse(splitUpValues[i].ToString(), out int inputInteger))
                        {
                            throw new Exception("All values must be Integers");
                        }
                        
                        listOfInputs.Add(inputInteger);
                        
                    }

                    var splitUpRandStrings = inputValuesRandStrings[0].Split(',');
                    var randStringsList = new List<string>();
                    for (int i = 0; i < splitUpRandStrings.Length; i++)
                    {
                        randStringsList.Add(splitUpRandStrings[i].ToString());
                    }

                    //This is the most basic way to do this, you create an internal class, then you create methods to do the sorting. The class has to be instantiated, the method called, and the values passed in.
                    var newClassForSorting = new SortingClass();
                    var orderedArrayList = SortingClass.SortArrayList(listOfInputs);
                    Console.WriteLine("Sorting Class Implementation: ");
                    Console.WriteLine();
                    for (int i = 0; i < orderedArrayList.Count; i++)
                    {
                        Console.WriteLine(orderedArrayList[i].ToString());
                    }

                    // In this case the extension method "hooks onto" the List and i am able to call the mergesort procedure without needing to instantiate a class to do so				
                    var orderedArrayList2 = listOfInputs.MergeSort();
                    Console.WriteLine();
                    Console.WriteLine("Sorting Extension Method Implementation: ");
                    Console.WriteLine();
                    for (int i = 0; i < orderedArrayList2.Count; i++)
                    {
                        Console.WriteLine(orderedArrayList2[i].ToString());
                    }

                    //With Generics i can pass in a List of Strings and List of Ints and the IComparable operator should take care of the comparisons
                    var orderedArrayList3 = listOfInputs.MergeSortGeneric();
                    var orderedRandStringsList = randStringsList.MergeSortGeneric();
                    Console.WriteLine();
                    Console.WriteLine("Sorting Extension Method Implementation with Generics: ");
                    Console.WriteLine();
                    for (int i = 0; i < orderedArrayList3.Count; i++)
                    {
                        Console.WriteLine(orderedArrayList3[i].ToString());
                    }

                    Console.WriteLine();
                    Console.WriteLine("Sorting Extension Method Implementation with Generics Sorting Strings instead of Ints: ");
                    Console.WriteLine();
                    for (int i = 0; i < orderedRandStringsList.Count; i++)
                    {
                        Console.WriteLine(orderedRandStringsList[i].ToString());
                    }

                    //With IEnumerable i can pass in a List like i did with the list of Integers and I can also pass in an array like I did with the Random Array of Strings
                    var orderedArrayListIEnumerable = listOfInputs.MergeSortGenericWithIEnumerable();
                    var orderedRandStringsListIEnumerable = splitUpRandStrings.MergeSortGenericWithIEnumerable();
                    Console.WriteLine();
                    Console.WriteLine("Sorting Extension Method Implementation with Generics using IEnumerable: ");
                    Console.WriteLine();
                    for (int i = 0; i < orderedArrayListIEnumerable.Count(); i++)
                    {
                        Console.WriteLine(orderedArrayListIEnumerable.ElementAt(i).ToString());
                    }

                    Console.WriteLine();
                    Console.WriteLine("Sorting Extension Method Implementation with Generics using IEnumerable Sorting Strings instead of Ints: ");
                    Console.WriteLine();
                    for (int i = 0; i < orderedRandStringsListIEnumerable.Count(); i++)
                    {
                        Console.WriteLine(orderedRandStringsListIEnumerable.ElementAt(i).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Environment.Exit(1);
            }
        }
    }

   
    






}