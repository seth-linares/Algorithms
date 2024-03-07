namespace AlgorithmLib;

public static class BinarySearch
{
    public static int Search(List<IComparable> data, IComparable target)
    {
        // If the list is empty, return -1
        if(data.Count >= 1) {

            int initial = 0;
            int final = data.Count - 1;

            
            

            while(initial <= final) { // While loop to ensure that we continually update our boundaries

                int mid = (initial + final) / 2; // Calculate the middle index of the list

                // if the middle of data == target, return the index of the middle
                if(data[mid].Equals(target)) { 
                    return mid;
                }


                // If the middle of data > target, update the final index to be one less than the previous middle index
                else if(data[mid].CompareTo(target) < 0) { 
                    initial = mid + 1;
                }


                // Covers the case of middle index < target. Will then update the initial bound to be one more than the previous middle
                else {
                    final = mid - 1;
                }

            }


            
        }

        return -1;
    }
}