namespace AlgorithmLib;

public static class BetterLinearSearch {
    public static int Search(List<IComparable> data, IComparable target) {

        // For loop that iterates through the list 'data'.
        for(int i = 0; i < data.Count; i++) {

            // If statement that checks if the current index of 'data' is equal to the target.
            if(data[i].Equals(target)) {
                // if the current index of 'data' is equal to the target, return the index.
                return i;
            }
        }

        // If the target is not found, return -1.
        return -1;
    }

    
}