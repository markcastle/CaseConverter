using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using CaseConverter.Benchmarks;

Summary summary = BenchmarkRunner.Run<CaseConverterBenchmarks>();
