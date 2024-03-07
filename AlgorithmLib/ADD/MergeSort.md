# Algorithm Description Document

Author: Seth Linares

Date: 9/30/23

## 1. Name
Merge Sort

## 2. Abstract
Merge Sort is a sorting algorithm that uses the divide and conquer method to break a list into tiny sublists, then merges them back together in order.

## 3. Methodology
Merge Sort is able to sort a list of comparable items by breaking the original unsorted list into smaller and smaller lists, then merges them back together in order. The algorithm will break the list into two halves, then break those halves into halves, and so on until the list is broken into sublists of size 1. Then, the algorithm will merge the sublists back together in order. The algorithm will compare the first element of each sublist, and add the smaller element to the new list. The algorithm will continue to compare the first element of each sublist until all elements have been added to the new list.

## 4. Pseudocode

```
MERGE(data, first, mid, last)
    L = data[first, mid]
    R = data[mid + 1, last]

    L_index = 0
    R_index = 0
    
    for i from first to last:
        if L_index >= len(L):
            data[i] = R[R_index]
            increment R_index
        else if R_index >= len(R):
            data[i] = L[L_index]
            increment L_index
        else if L[L_index] <= R[R_index]:
            data[i] = L[L_index]
            increment L_index
        else:
            data[i] = R[R_index]
            increment R_index
    





SORT(data, first, last)
    if first >= last:
        return

    else:
        mid = (first + last) / 2
        SORT(data, first, mid)
        SORT(data, mid + 1, last)
        MERGE(data, first, mid, last)

```

## 5. Inputs & Outputs

List only inputs and outputs for the SORT function.

Inputs:
* data - list of values that are comparable with each other
* first - the index of the first element in the list
* last - the index of the last element in the list

Outputs:
* data - the same list of values, but sorted

## 6. Analysis Results

* Worst Case: $O(n*log(n))$

* Best Case: $\Omega(n*log(n))$

