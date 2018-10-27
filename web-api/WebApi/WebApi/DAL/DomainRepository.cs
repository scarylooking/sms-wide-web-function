using System;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    public class DomainRepository
    {
        //private readonly CloudTable _table;
        private readonly string TableName = "records";

        public DomainRepository()
        {/*
            var tableStorageConnStr = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            var storageAccount = CloudStorageAccount.Parse(tableStorageConnStr);
            var tableClient = storageAccount.CreateCloudTableClient();

            _table = tableClient.GetTableReference(TableName);*/
        }

        public async Task<bool> Register(string domain, string number)
        {
            if (string.IsNullOrWhiteSpace(domain))
            {
                throw new ArgumentException(nameof(domain));
            }

            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException(nameof(number));
            }
            /*
            var insertOperation = TableOperation
                .Insert(new DnsRecord(domain.Trim().ToLowerInvariant(), number));

            await _table.ExecuteAsync(insertOperation);
            */
            return true;
        }

        public async Task<string> Resolve(string domain)
        {/*
            if (string.IsNullOrEmpty(domain))
            {
                throw new ArgumentException(nameof(domain));
            }

            var retrieveOperation = TableOperation.Retrieve<DnsRecord>(DnsRecord.Partition, domain);
            
            var result = await _table.ExecuteAsync(retrieveOperation);
            
            if (!(result.Result is DnsRecord record))
            {
                return null;
            }

            return record.Address;*/
            throw new NotImplementedException();
        }
    }
}
