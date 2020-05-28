using System.Collections.Generic;
using Dapper;
using Npgsql;
using TagApi.Domain;

namespace TagApi.Repository
{
    public class Repositories
    {
        public static User GetByEmail(string Email)
        {
            var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=tagrepository");
            connection.Open();
            var users = new List<User>();
            var query = "select * from users where email = \"" + Email + "\"";
            var qEmail = connection.Execute(query);
           

            //users.Add(new User { id = qID, firstName = qFirstName, lastName= qLastName , cnpj= qCnpj, email = qEmail, senha = qSenha});


            return new User();         
        }
    }
}
