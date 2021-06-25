# Balanced multi-path merger

### Go to

```
./PA_LR1.2/bin/Debug/netcoreapp3.1/index.txt
```

Enter numbers

```
10
8
2
1
29
3
```
Result file 

```
./PA_LR1.2/bin/Debug/netcoreapp3.1/b/b1.txt
```

### Example

Now I will give an example of this algorithm on a small array

```
| 3 | 5 | 1 | 10 | 12 | 6 | 4 | 15 | 11 | 9 | 7 | 13 | 14 | 2 | 8 |
```

First you need to split this whole file into three

```
| 3 | 10 | 4 | 9 | 14 |
| 5 | 12 | 15 | 7 | 2 |
| 1 | 6 | 11 | 13 | 8 |
```

Then from each file it is necessary to take on the first, second,… fifth element to sort them and to add in the following files and at the end to delete these files.

```
| 1 | 3 | 5 || 7 | 9 | 13 |
| 6 | 10 | 12 || 2 | 8 | 14 |
| 4 | 11 | 15 ||  |  |  |    
```

We also take the first series, the second, and repeat these operations until there is one file with one series

```
| 1 | 3 | 4 | 5 | 6 | 10 | 11 | 12 | 15
| 2 | 7 | 8 | 9 | 13 | 14
```

```
| 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 |
```

### Run the program

