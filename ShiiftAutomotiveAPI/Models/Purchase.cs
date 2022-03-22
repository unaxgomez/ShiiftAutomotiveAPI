using System;
namespace ShiiftAutomotiveAPI.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int IllustrationId { get; set; }

        public Illustration Illustration { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
