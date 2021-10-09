using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDirectorService
    {
        IResult Add(Director movie);
        IDataResult<Director> GetById(int id);
        IDataResult<IEnumerable<Director>> GetAll();
        IDataResult<IEnumerable<Director>> GetByAge(int age);
        IDataResult<IEnumerable<Director>> GetByAgeGreaterThan(int greaterThan);
        IDataResult<IEnumerable<Director>> GetByAgeLessThan(int lessThan);
    }
}
