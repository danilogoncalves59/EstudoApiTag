using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagApi.Domain;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace TagApi.Repository.Services.Implementation
{
    public class UserRepositoryImp : IUserRepository
    {
        public User Create(User user)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<User> findAll()
        {
            throw new NotImplementedException();
        }

        public User findById(long id)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
