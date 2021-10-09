using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccess.Config;
using Core.Utilities.Results.Concrete;
using Core.Exceptions;

namespace DataAccess.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private const string _selectAllCommandStr = "SELECT * FROM Movie";
        private const string _insertSqlCommandStr = 
            "INSERT INTO Movie (Name, SceneDate, Rating, Imdb, Cost) VALUES (@Name, @SceneDate, @Rating, @Imdb, @Cost)";
        private const string _getByYearAndMonthCommandStr = 
            "SELECT * FROM Movie WHERE MONTH(SceneDate) = @Month AND YEAR(SceneDate) = @Year";
        private const string _getByYearCommandStr =
            "SELECT * FROM Movie WHERE YEAR(SceneDate) = @Year";
        private const string _getByDirectorIdCommandStr =
            "SELECT * FROM Movie JOIN MovieToDirector ON Movie.Id = MovieToDirector.MovieId JOIN Director ON Director.Id = MovieToDirector.DirectorId WHERE MovieToDirector.DirectorId = @DirectorId";

        private readonly ConnectionConfig _connectionConfig;
        private readonly SqlConnection _connection;
        public MovieRepository(ConnectionConfig connectionConfig)
        {
            _connectionConfig = connectionConfig;
            _connection = new(_connectionConfig.ConnectionString);
        }

        private Movie getMovieInfo(SqlDataReader reader)
        {
            return new()
            {
                Id = (long)reader[0],
                Name = (string)reader[1],
                SceneDate = (DateTime)reader[2],
                Rating = (long)reader[3],
                Imdb = (float)reader[4],
                Cost = (decimal)reader[5]
            };
        }

        private MovieDetail getMovieDetail(SqlDataReader reader)
        {
            return new()
            {
                Movie = getMovieInfo(reader),
                Director = new()
                {
                    Id = (int)reader[9],
                    Name = (string)reader[10],
                    BirthDate = (DateTime)reader[11]
                }
            };
        }

        public void Add(Movie movie)
        {
            try
            {
                var command = new SqlCommand(_insertSqlCommandStr, _connection);
                command.Parameters.AddWithValue("@Name", movie.Name);
                command.Parameters.AddWithValue("@SceneDate", movie.SceneDate);
                command.Parameters.AddWithValue("@Rating", movie.Rating);
                command.Parameters.AddWithValue("@Imdb", movie.Imdb);
                command.Parameters.AddWithValue("@Cost", movie.Cost);
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                throw new RepositoryException("MovieRepository.Add", ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public void Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            try
            {
                var command = new SqlCommand(_selectAllCommandStr, _connection);
                var list = new List<Movie>();
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(getMovieInfo(reader));

                return list;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Movie> GetByYear(int year)
        {
            try
            {
                var command = new SqlCommand(_getByYearCommandStr, _connection);
                command.Parameters.AddWithValue("@Year", year);
                var list = new List<Movie>();
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(getMovieInfo(reader));
                return list;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("MovieRepository.GetByYear", ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetByYearAndMonth(int year, int month)
        {
            try
            {
                var command = new SqlCommand(_getByYearAndMonthCommandStr, _connection);
                command.Parameters.AddWithValue("@Year", year);
                command.Parameters.AddWithValue("@Month", month);
                var list = new List<Movie>();
                _connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                    list.Add(getMovieInfo(reader));
                return list;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("MovieRepository.GetByYearAndMonth", ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public IEnumerable<MovieDetail> GetByDirectorId(int directorId)
        {
            try
            {
                var command = new SqlCommand(_getByDirectorIdCommandStr, _connection);
                command.Parameters.AddWithValue("@DirectorId", directorId);
                var list = new List<MovieDetail>();
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(getMovieDetail(reader));
                return list;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("MovieRepository.GetByDirectorId", ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }
    }
}
