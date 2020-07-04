using QotD.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QotD.Client.Contracts
{
    public interface IApiClient
    {
        Task<Result> Get();
    }
}
