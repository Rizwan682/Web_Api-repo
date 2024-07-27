using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThirdTryOfASPNETCOREWEBAPI.Models;

public partial class Student
{

    [Key]
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentGender { get; set; }

    public int? Age { get; set; }

    public int? Standerd { get; set; }

    public string? FatherName { get; set; }
}
