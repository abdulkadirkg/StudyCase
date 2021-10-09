using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieManager(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IResult Add(Movie movie)
        {
            _movieRepository.Add(movie);
            return new SuccessResult("Film Ekleme Başarılı");
        }

        public IDataResult<IEnumerable<Movie>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Movie>>(_movieRepository.GetAll());
        }

        public IDataResult<IEnumerable<MovieDetail>> GetByDirectorId(int directorId)
        {
            return new SuccessDataResult<IEnumerable<MovieDetail>>(_movieRepository.GetByDirectorId(directorId));

        }

        public IDataResult<Movie> GetById(int id)
        {
            return new SuccessDataResult<Movie>(_movieRepository.GetById(id));
        }

        public IDataResult<IEnumerable<Movie>> GetByYear(int year)
        {
            return new SuccessDataResult<IEnumerable<Movie>>(_movieRepository.GetByYear(year));
        }

        public IDataResult<IEnumerable<Movie>> GetByYearAndMonth(int year, int month)
        {
            return new SuccessDataResult<IEnumerable<Movie>>(_movieRepository.GetByYearAndMonth(year, month));
        }
    }
}
