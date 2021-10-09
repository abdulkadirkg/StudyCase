using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MovieToDirector : IEntity
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public long MovieId { get; set; }
    }
}
