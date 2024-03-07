# Algorithm Description Document

Author: Seth Linares

Date: 10/7/23 

## 1. Name

Quick Sort

## 2. Abstract
Quick Sort is an efficient, in-place sorting algorithm that sorts a list by breaking it into smaller sublists, then sorting them recursively.



## 3. Methodology
Quick Sort is an efficient, in-place sorting algorithm that operates on the "divide and conquer" principle. The algorithm begins by selecting a pivot element from the list. The choice of the pivot is crucial and can significantly affect the algorithms efficiency. In our implementation, to improve performance and avoid the worst-case scenario, we randomly select the pivot, which typically leads to better average case performance. Once the pivot is selected, the algorithm reorders the list so that all elements with values less than the pivot come before it, and all elements with values greater are placed after it. This process, known as partitioning, effectively places the pivot element in its correct, sorted position in the array. The partitioning step works by initializing a marker for a smaller element called the Lowest Marked Greater than Pivot (LMGP). Starting from the beginning of the array segment, we compare each element with the pivot. If an element is less than the pivot, we swap it with the element at the LMGP position and then move the LMGP marker one position to the right. This ensures that, by the end of the partitioning process, all elements less than the pivot are on its left, and all greater elements are on its right. After partitioning, the pivot is in its final sorted position. The list is then recursively sorted on the sub-lists on either side of the pivot. These recursive calls continue until the base case is reached, where a sub-list is either of size 0 or 1, which by definition are sorted. The genius of Quick Sort is hidden inside its ability to sort in-place which means it requires only a small, constant amount of additional storage space. While its worst case time complexity is $O(n^2)$ with unfortunate pivot choices, the randomized pivot selection in our implementation typically leads to an average time complexity of $O(n*log(n))$, similar to Merge Sort but with less space requirement. This makes Quick Sort a preferred choice for many practical sorting applications.


## 4. Pseudocode

```
PARTITION(data, first, last)
    set pivot index = random integer from first to last
    swap data[pivot index] and data[last]
    set LMGP = first

    for i from first to last - 1:
        if data[i] < data[last]:
            swap data[i] and data[LMGP]
            increment LMGP
    swap data[LMGP] and data[last]
    return LMGP

SORT(data, first, last)
    if first >= last:
        return

    else:
        set pivot = PARTITION(data, first, last)
        SORT(data, first, pivot - 1)
        SORT(data, pivot + 1, last)

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

* Worst Case: $O(n^2)$

* Best Case: $\Omega(n*log(n))$

