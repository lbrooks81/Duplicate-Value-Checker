```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4894/22H2/2022Update)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2 [AttachedDebugger]
  Job-HTJNCX : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2

MaxIterationCount=24  

```
| Method             | N     | Mean          | Error         | StdDev        | Gen0    | Gen1    | Gen2    | Allocated |
|------------------- |------ |--------------:|--------------:|--------------:|--------:|--------:|--------:|----------:|
| **HasDuplicateValue1** | **100**   |      **8.426 μs** |     **0.1019 μs** |     **0.0954 μs** |       **-** |       **-** |       **-** |         **-** |
| HasDuplicateValue2 | 100   |      1.465 μs |     0.0112 μs |     0.0094 μs |  1.4343 |       - |       - |    6000 B |
| **HasDuplicateValue1** | **1000**  |    **683.465 μs** |    **13.6451 μs** |    **15.7137 μs** |       **-** |       **-** |       **-** |       **6 B** |
| HasDuplicateValue2 | 1000  |     13.472 μs |     0.2650 μs |     0.2721 μs | 13.9771 |       - |       - |   58664 B |
| **HasDuplicateValue1** | **10000** | **67,101.580 μs** | **1,299.6535 μs** | **1,085.2695 μs** |       **-** |       **-** |       **-** |     **559 B** |
| HasDuplicateValue2 | 10000 |    232.485 μs |     2.4812 μs |     2.0719 μs | 95.2148 | 95.2148 | 95.2148 |  538657 B |
