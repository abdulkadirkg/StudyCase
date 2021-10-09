using Core.Exceptions;
using DataAccess.Abstract;
using DataAccess.Config;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class DirectorRepository : IDirectorRepository
    {
        private const string _selectAllCommandStr = "SELECT * FROM Director";
        private const string _insertSqlCommandStr =
            "INSERT INTO Director (Name, BirthDate) VALUES (@Name, @BirthDate)";
        private const string _getByAgeGreaterThanCommandStr = 
            "SELECT * FROM Director WHERE DATEDIFF(YY,BirthDate,GETDATE()) > @Age";
        private const string _getByAgeLessThanCommandStr = 
            "SELECT * FROM Director WHERE DATEDIFF(YY,BirthDate,GETDATE()) < @Age";

        private readonly ConnectionConfig _connectionConfig;
        private readonly SqlConnection _connection;
        public DirectorRepository(ConnectionConfig connectionConfig)
        {
            _connectionConfig = connectionConfig;
            _connection = new(_connectionConfig.ConnectionString);
        }
        private Director getDirectorInfo(SqlDataReader reader)
        {
            return new()
            {
                Id = (int)reader[0],
                Name = (string)reader[1],
                BirthDate = (DateTime)reader[2]
            };
        }

        public void Add(Director director)
        {
            try
            {
                var command = new SqlCommand(_insertSqlCommandStr, _connection);
                command.Parameters.AddWithValue("@Name", director.Name);
                command.Parameters.AddWithValue("@BirthDate", director.BirthDate);
                _connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("DirectorRepository.Add", ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public void Delete(Director director)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetAll()
        {
            try
            {
                var command = new SqlCommand(_selectAllCommandStr, _connection);
                var list = new List<Director>();
                _connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                    list.Add(getDirectorInfo(reader));

                return list;
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public IEnumerable<Director> GetByAge(int age)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetByAgeGreaterThan(int greaterThan)
        {
            try
            {
                var command = new SqlCommand(_getByAgeGreaterThanCommandStr, _connection);
                command.Parameters.AddWithValue("@Age", greaterThan);
                var list = new List<Director>();
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(getDirectorInfo(reader));

                return list;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("DirectorRepository.GetByAgeGreaterThan", ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public IEnumerable<Director> GetByAgeLessThan(int lessThan)
        {
            try
            {
                var command = new SqlCommand(_getByAgeLessThanCommandStr, _connection);
                command.Parameters.AddWithValue("@Age", lessThan);
                var list = new List<Director>();
                _connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(getDirectorInfo(reader));
                return list;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("DirectorRepository.GetByAgeLessThan", ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
        }

        public Director GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Director director)
        {
            throw new NotImplementedException();
        }
    }
}
