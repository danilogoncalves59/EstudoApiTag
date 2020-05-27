using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using TagApi.Domain;

namespace TagApi.Repository
{
    public class Repositories
    {
        public static User Get(string email, string senha)
        {
            var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=tagrepository");
            connection.Open();
            var users = new List<User>();
            var qID = Convert.ToInt32( connection.Query("select id from _user"));
            var qFirstName = Convert.ToString(connection.Query("select firstname from _user"));
            var qLastName = Convert.ToString(connection.Query("select lastname from _user"));
            var qCnpj = Convert.ToString(connection.Query("select cnpj from _user"));
            var qEmail = Convert.ToString(connection.Query("select email from _user"));
            var qSenha = Convert.ToString(connection.Query("select senha from _user"));

            users.Add(new User { id = qID, firstName = qFirstName, lastName= qLastName , cnpj= qCnpj, email = qEmail, senha = qSenha});


            return users.
        

        ;
        }
    }
}
