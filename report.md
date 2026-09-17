# Searching and Sorting: Report

| |                      |
|---|----------------------|
| Name | Mostafa Maassou      |
| Date | 17-09-2026           |
| Data | phonebook.csv, 200 contacts |

---

## 1. Searching unsorted data

| Field | Target | Case | Matches | Comparisons |
|---|---|---|---:|---:|
| LastName | [first record surname] | first record (best case) | [result] | 200 |
| LastName | [last record surname] | last record (worst case) | [result] | 200 |
| LastName | ZZZ_NOT_FOUND | absent value | 0 | 200 |
| Mobile | 00000000 | absent value | 0 | 200 |

**Reflection.** An absent value requires 200 comparisons because linear search has to check every contact before it can know that the value is not present. In my implementation, the first-record and last-record cases also require 200 comparisons. This is because the search must return every matching contact, so it cannot stop after finding the first match. Because of this requirement, the practical best case for this implementation is still O(n), even though a linear search that stops at the first match can have an O(1) best case. Finding several matches also does not require more comparisons than finding none, because all 200 contacts are checked in both cases.

## 2. Sorting

| Algorithm | Input shape | Comparisons | Swaps or moves |
|---|---|---:|---:|
| Insertion Sort | as supplied | 9691 | 9494 |
| Insertion Sort | already sorted | 199 | 0 |
| Insertion Sort | reverse sorted | 19571 | 19411 |
| Merge Sort | as supplied | 1282 | 1544 |
| Merge Sort | already sorted | 812 | 1544 |
| Merge Sort | reverse sorted | 890 | 1544 |

**Reflection.** The biggest difference was with Insertion Sort. It needed only 199 comparisons and 0 moves when the data was already sorted, but 19571 comparisons and 19411 moves when it was reverse sorted. On the supplied data it needed 9691 comparisons and 9494 moves. This agrees with its O(n) best case and O(n²) average and worst cases. Merge Sort was more consistent, using 1282, 812 and 890 comparisons for the three input shapes. Its time complexity is O(n log n) in the best, average and worst cases. It also uses O(n) extra space because of the temporary array. For Merge Sort, I counted a move when an element was placed into the temporary merged result, not again when it was copied back.

## 3. Searching sorted data

| Field | Target | Result | Comparisons |
|---|---|---:|---:|
| LastName | Amundsen | index 2 | 8 |
| LastName | ZZZ_NOT_FOUND | -1 | 8 |
| Mobile | 49502717 | index 100 | 7 |
| FirstName | Andreas | index 4 | 8 |

Linear search on the same targets, for comparison:

| Target | Comparisons (linear) | Comparisons (binary) |
|---|---:|---:|
| Amundsen | 200 | 8 |
| ZZZ_NOT_FOUND | 200 | 8 |
| 49502717 | 200 | 7 |
| Andreas | 200 | 8 |

**Reflection.** Binary search needed only 7 or 8 comparisons for these searches against 200 contacts. This is close to log2(200), which is about 7.64, and shows the expected O(log n) behaviour. To return the first occurrence of a duplicate, my binary search does not stop when it finds a match. It stores the index and continues searching the left half. For example, `Amundsen` was returned at index 2 and the previous surname was `Aas`. `Andreas` was returned at index 4 and the previous first name was `Amalie`, confirming that both results were the first occurrence.

Sorting has an upfront cost. Using the supplied-data Merge Sort result as an example, sorting cost 1282 comparisons. A linear search costs 200 comparisons, while binary search used about 7–8. This saves roughly 192 comparisons per search. Based only on these comparison counts, 1282 / 192 is about 6.7, so the sorting cost is recovered after roughly 7 searches. This is only an estimate because it compares operation counts rather than actual execution time.

## 4. Insight

The most useful thing I learned from my results is that the starting order of the data can make a large difference depending on the algorithm. Insertion Sort changed from 199 comparisons on already sorted data to 19571 on reverse-sorted data, while Merge Sort stayed much more consistent. I also saw that sorting can be worth the initial cost when the same data will be searched many times, because binary search reduced about 200 comparisons per search to only 7 or 8 in my tests.

## AI Prompts

**Prompt 1:**
> How can binary search return the first occurrence when duplicate values exist while keeping O(log n) complexity?

**Prompt 2:**
> How should comparisons and moves be counted fairly when comparing Insertion Sort and Merge Sort?