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
    public class DirectorManager : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorManager(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public IResult Add(Director director)
        {
            _directorRepository.Add(director);
            return new SuccessResult("Director Ekleme Başarılı");
        }

        public IDataResult<IEnumerable<Director>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<Director>>(_directorRepository.GetAll());
        }

        public IDataResult<IEnumerable<Director>> GetByAge(int age)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Director>> GetByAgeGreaterThan(int greaterThan)
        {
            return new SuccessDataResult<IEnumerable<Director>>(_directorRepository.GetByAgeGreaterThan(greaterThan));
        }

        public IDataResult<IEnumerable<Director>> GetByAgeLessThan(int lessThan)
        {
            return new SuccessDataResult<IEnumerable<Director>>(_directorRepository.GetByAgeLessThan(lessThan));
        }

        public IDataResult<Director> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
