using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Movie : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime SceneDate { get; set; } = DateTime.Now;
        public long Rating { get; set; }
        public float Imdb { get; set; }
        public decimal Cost { get; set; }
    }
}
