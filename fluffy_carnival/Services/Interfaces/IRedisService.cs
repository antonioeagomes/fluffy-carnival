using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fluffy_carnival.Services.Interfaces
{
    public interface IRedisService
    {
        public Task Save(string key, string value);
        public Task<string?> Read(string key);
        
    }
}