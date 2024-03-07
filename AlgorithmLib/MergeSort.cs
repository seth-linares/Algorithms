namespace AlgorithmLib;

public static class MergeSort
{


    public static void Sort(List<IComparable> data) // helper method
    {
        ActualSort(data, 0, data.Count - 1); // call the actual sort function to begin recursion
    }



    private static void ActualSort(List<IComparable> data, int first, int last) {

        if(first >= last || data.Count <= 1) { 
            return; // nothing needed to be returned (because Lists are reference types) but we need to exit from our base case. Also caught when the list is size 1 or empty.
        }

        int mid = (first + last) / 2; // calculate the mid point. Will update on each iteration. This will give us our "shrinking window" to reach the base case

        ActualSort(data, first, mid); // divide the array into a "left" half
        ActualSort(data, mid + 1, last); // divide the array into a "right" half
        Merge(data, first, mid, last); // begin merging the arrays by going "up" recursively

    }


    private static void Merge(List<IComparable> data, int first, int mid, int last)
    {
        int list1Index = 0; // use the indices to keep track of where in the subarrays we are adding from next. Will help us know when a list has fully been checked over. 
        int list2Index = 0;
        List<IComparable> L = data.GetRange(first, (mid - first + 1)); // .GetRange() creates copy by taking beginning index and count of items to include
        List<IComparable> R = data.GetRange(mid + 1, last - mid); // Use these copies to create right and left arrays to compare to one another for reordering the data array

        for(int i = first; i < last + 1; i++) {
            if(list1Index >= L.Count) { // will set data[i] equal to the next value in the right array if we have finished checking the left array.
                data[i] = R[list2Index];
                list2Index++;

            }

            else if(list2Index >= R.Count) { // will do the same as above but instead will add from the left array since the right is finished.
                data[i] = L[list1Index];
                list1Index++;

            }

            else if(L[list1Index].CompareTo(R[list2Index]) < 0) { // see if the value in the left array is less than the one in the right array
                data[i] = L[list1Index]; 
                list1Index++;

            }

            else {
                data[i] = R[list2Index];
                list2Index++;           
            }
        }


    }

    

    


    
}

 