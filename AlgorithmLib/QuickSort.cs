namespace AlgorithmLib;

public static class QuickSort
{
    private static Random num = new Random(); // making the random variable static so I don't have to create a new object every time we recurse

    public static void Sort(List<IComparable> data)
    {
        ActualSort(data, 0, data.Count - 1); // basic little call to the recursive method :)
    }
    private static int Partition(List<IComparable> data, int first, int last)
    {

        
        int randnum = num.Next(first, last + 1); // attempting to avoid worst case by randomizing the pick of a pivot index
        (data[last], data[randnum]) = (data[randnum], data[last]);
        int next = first;

        for(int i = first; i < last; i++) {
            if(data[i].CompareTo(data[last]) < 0) { // 
                (data[i], data[next]) = (data[next], data[i]); // if data[i] < pivot, then swap the LMGP with the current index and increment LMGP by 1
                next++;
            }
        }

        (data[next], data[last]) = (data[last], data[next]); // at the end, swap positions of LMGP and pivot
        return next; // return pivot index
    }

    

    private static void ActualSort(List<IComparable> data, int first, int last) {
        if(first >= last) { // base case
            return;
        }

        int p_index = Partition(data, first, last); // get the pivot index to pass to our recursive calls

        ActualSort(data, first, p_index - 1); // split the list into sublists
        ActualSort(data, p_index + 1, last);

    }

}