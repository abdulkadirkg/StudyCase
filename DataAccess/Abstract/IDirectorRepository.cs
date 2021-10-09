using Core.DataAccess.CrudRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDirectorRepository : ICrudRepository<Director>
    {
        IEnumerable<Director> GetByAge(int age);
        IEnumerable<Director> GetByAgeGreaterThan(int greaterThan);
        IEnumerable<Director> GetByAgeLessThan(int lessThan);
    }
}
