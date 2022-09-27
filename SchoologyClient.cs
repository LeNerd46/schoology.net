using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoology.Entities;
using Newtonsoft.Json;

namespace Schoology
{
    public class SchoologyClient
    {
        private RestClient Client { get; }

        public string UserKey { get; }
        public string UserSecret { get; }

        public SchoologyClient(string key, string secret)
        {
            Client = new RestClient("https://api.schoology.com/v1/");

            UserKey = key;
            UserSecret = secret;

            /*Client.Authenticator = new OAuth1Authenticator()
            {
                Realm = "Schoology API",
                SignatureMethod = RestSharp.Authenticators.OAuth.OAuthSignatureMethod.PlainText
            };*/

            Client.Authenticator = OAuth1Authenticator.ForProtectedResource(UserKey, UserSecret, "", "", RestSharp.Authenticators.OAuth.OAuthSignatureMethod.PlainText);
        }

        public async Task<string> Inbox()
        {
            // var result = Client.Get(new RestRequest("messages/inbox"));

            var result = await Client.ExecuteAsync(new RestRequest("messages/inbox", Method.Get));

            return result.Content;
        }

        /// <summary>
        /// View a specified user
        /// </summary>
        /// <param name="uid">The ID of the user</param>
        /// <returns>The user object</returns>
        public async Task<User> GetUser(string uid)
        {
            var result = await Client.ExecuteAsync(new RestRequest($"users/{uid}", Method.Get));

            return JsonConvert.DeserializeObject<User>(result.Content, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }

        /// <summary>
        /// View a list of users in your school
        /// </summary>
        /// <returns>An IEnumerable of User objects</returns>
        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await Client.ExecuteAsync(new RestRequest("users?offset=5&limit=2", Method.Get));

            var users = JsonConvert.DeserializeObject<UserListRoot>(result.Content);

            return users.Users.AsEnumerable();
        }
    }

    internal class UserListLinks
    {
        public string self { get; set; }
        public string next { get; set; }
    }

    internal class UserListRoot
    {
        [JsonProperty("user")]
        public List<User> Users { get; set; }
        public string total { get; set; }
        public UserListLinks links { get; set; }
    }
}
