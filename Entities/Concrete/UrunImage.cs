using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UrunImage:IEntity
    {
        [Key]
        public int ImageId { get; set; }
        public int UrunId { get; set; }
        public string ImagePath { get; set; }

        public DateTime Date { get; set; }
        [NotMapped]

        public IFormFile File { get; set; }
    }
}
