using Dos.User.Api.Domain.Seedwork;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dos.User.Api.Domain.AggregateModels
{
    [Table("Users")]
    public partial class UserEntity : Entity, IAggregateRoot
    {
        
        [Column("first_name")]
        public string First_Name { get; set; }
        [Column("last_name")]
        public string Last_Name { get; set; }
        [Column("date_of_birth")]
        public string Date_Of_Birth { get; set; }
        [Column("email_address")]
        public string Email_Address { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("country")]
        public string Country { get; set; }
        [Column("zip_code")]
        public string Zip_Code { get; set; }
    }
}