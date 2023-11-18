using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesPWA.Shared.Models
{
public class Page<T>
{
    public T[] Content { get; set; }
    public Pageable Pageable { get; set; }
    public bool Last { get; set; }
    public int TotalPages { get; set; }
    public int TotalElements { get; set; }
    public int Size { get; set; }
    public int Number { get; set; }
    public Sort Sort { get; set; }
    public int NumberOfElements { get; set; }
    public bool First { get; set; }
    public bool Empty { get; set; }
}

public class Pageable
{
    public Sort Sort { get; set; }
    public int Offset { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public bool Unpaged { get; set; }
    public bool Paged { get; set; }
}

public class Sort
{
    public bool Empty { get; set; }
    public bool Sorted { get; set; }
    public bool Unsorted { get; set; }
}
}