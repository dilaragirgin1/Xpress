using Beymen.IT.Package.EntityFrameworkCore;
using Beymen.IT.Package.EntityFrameworkCore.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BG.Express.API.Data.Entities
{
    public class Driver : IEntity<string>
    {
        public string DriverName { get; set; }
        public string DriverImage { get; set; }
        public string DriverPhone { get; set; }
        public bool IsActive { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
