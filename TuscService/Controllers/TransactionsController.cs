using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TuscData;
namespace TuscService.Controllers
{
    public class TransactionsController : ApiController
    {
        // GET api/<Transaction>
        [HttpGet]
        [Route("transactions")]
        public IEnumerable<Transaction> Get()
        {
            return DataManager.GetTransactions();
        }
    }
}
