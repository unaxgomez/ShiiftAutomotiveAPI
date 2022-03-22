using System;
using System.Collections.Generic;

namespace ShiiftAutomotiveAPI.Models
{
    public class Illustration
    {
        public int Id { get; set; }

        public string CarName { get; set; }

        public string CarModel { get; set; }

        public string Image { get; set; }

        public int TypeIllustrationId { get; set; }

        //public TypeIllustration TypeIllustration { get; set; }

        public List<Purchase> Purchases { get; set; }

    }
}
