# Algorithm Description Document

Author: Seth Linares

Date: 9/23/2023

## 1. Name
Binary Search

## 2. Abstract
The Binary Search Algorithm will search a sorted list of numbers by repeatedly dividing the search interval in half until the search interval is empty or the target is found.

## 3. Methodology
When using the Binary Search Algorithm, the data must be sorted. The algorithm will start by comparing the target value to the middle item in the list.  If the target is less than the item at the middle index, then the algorithm will search the lower half of the list. If the target is greater than the middle item, then the algorithm will search the upper half of the list. This process will repeat until the target is found or until there are no more items to search.

## 4. Pseudocode

```
BINARY-SEARCH(data, target)
    low = 0
    high = size of data - 1
    while low <= high
        mid = (low + high) / 2
        if data[mid] == target
            return mid
        else if data[mid] < target
            low = mid + 1
        else
            high = mid - 1
    return -1

```

## 5. Inputs & Outputs

Inputs: 
* data - list of values that can be compared to one another
* target - item to search for that is the same type as items in data

Outputs:
* index of data that contains the target.  If not found, then -1 is returned.

## 6. Analysis Results

* Worst Case: $O(log(n))$

* Best Case: $\Omega(1)$

