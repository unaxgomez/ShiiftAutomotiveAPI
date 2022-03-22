using System;
using System.Collections.Generic;

namespace ShiiftAutomotiveAPI.Models
{
    public class TypeIllustration
    {
       public int Id { get; set; }

       public string Style { get; set; }

       public List<Illustration> Illustrations { get; set; }

    }
}
