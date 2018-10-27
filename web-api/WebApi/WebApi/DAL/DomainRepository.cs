using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DAL
{
    public class DomainRepository
    {
        public DomainRepository()
        {
            var tableStorageConnStr = Environment.GetEnvironmentVariable("TableStorage");
        }

        public bool Register(string domain, string number)
        {
            throw new NotImplementedException();
        }

        public string Resolve(string domain)
        {
            throw new NotImplementedException();
        }
    }
}
