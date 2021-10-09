using Core.DataAccess.CrudRepository;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMovieRepository : ICrudRepository<Movie>
    {
        IEnumerable<Movie> GetByYear(int year);
        IEnumerable<MovieDetail> GetByDirectorId(int directorId);
        IEnumerable<Movie> GetByYearAndMonth(int year, int month);
    }
}
