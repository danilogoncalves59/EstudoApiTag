using System.Collections.Generic;
using Dapper;
using Npgsql;
using TagApi.Domain;

namespace TagApi.Repository
{
    public class Repositories
    {
        public static User Get(string Email)
        {
            var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=postgres;Database=tagrepository");
            connection.Open();
            var users = new List<User>();
            var qID = connection.QueryFirstOrDefault("select id from _user");
            var qFirstName = connection.QueryFirstOrDefault("select firstname from _user");
            var qLastName = connection.QueryFirstOrDefault("select lastname from _user");
            var qCnpj = connection.QueryFirstOrDefault("select cnpj from _user");
            var qEmail = connection.QueryFirstOrDefault("select email from _user");
            var qSenha = connection.QueryFirstOrDefault("select senha from _user");


            users.Add(new User { id = qID, firstName = qFirstName, lastName= qLastName , cnpj= qCnpj, email = qEmail, senha = qSenha});


            return qEmail;         
        }
    }
}
