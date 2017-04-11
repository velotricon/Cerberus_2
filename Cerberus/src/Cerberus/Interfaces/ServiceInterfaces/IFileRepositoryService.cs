using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Interfaces.ServiceInterfaces
{
    public interface IFileRepositoryService
    {
        void AddUserAvatar(IFormFile File, int UserId);
        void RemoveUserAvatar(int UserId);
    }
}
