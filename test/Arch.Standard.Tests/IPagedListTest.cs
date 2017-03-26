using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Newtonsoft.Json;

namespace Arch.Standard.Tests
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class IPagedListTest
    {
        private readonly IList<User> _users;
        public IPagedListTest()
        {
            _users = new User[]
            {
                new User
                {
                    Id = 1,
                    Username = "rigofunc",
                    Password = "p@ssword"
                },
                new User
                {
                    Id = 2,
                    Username = "yingtingxu",
                    Password = "p@ssword"
                }
            };
        }

        [Fact]
        public void IPagedList_Can_Json_Serialized_And_Deserialized_Test()
        {
            var querable = _users.AsQueryable();

            var pagedUsers = querable.OrderBy(u => u.Id).ToPagedList(0, 10, 0);

            var json = JsonConvert.SerializeObject(pagedUsers);

            Assert.False(string.IsNullOrEmpty(json));

            var users = JsonConvert.DeserializeObject<PagedList<User>>(json);

            Assert.IsAssignableFrom<IPagedList<User>>(users);

            Assert.Equal(2, users.Items.Count);
        }
    }
}
