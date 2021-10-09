using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IResult Add(Movie movie);
        IDataResult<Movie> GetById(int id);
        IDataResult<IEnumerable<Movie>> GetByYear(int year);
        IDataResult<IEnumerable<Movie>> GetByYearAndMonth(int year, int month);
        IDataResult<IEnumerable<Movie>> GetAll();
        IDataResult<IEnumerable<MovieDetail>> GetByDirectorId(int directorId);
    }
}
