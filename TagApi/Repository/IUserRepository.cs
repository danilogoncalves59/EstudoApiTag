using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagApi.Domain;

namespace TagApi.Repository
{
    public interface IUserRepository
    {
        User Create(User user);
        User findById(long id);
        List<User> findAll ();
        User Update (User user);
        void Delete (long id);

    }
}
