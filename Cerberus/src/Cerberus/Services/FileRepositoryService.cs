using Cerberus.Interfaces.ServiceInterfaces;
using Cerberus.Interfaces.ManagerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Cerberus.Models;

namespace Cerberus.Services
{
    public class FileRepositoryService : IFileRepositoryService
    {
        private readonly IUserManager user_manager;
        private readonly IFileManager file_manager;
        public FileRepositoryService(IUserManager UserManager, IFileManager FileManager)
        {
            this.user_manager = UserManager;
            this.file_manager = FileManager;
        }

        public void AddUserAvatar(IFormFile File, int UserId)
        {
            string[] content_types = new string[]
            {
                "image/jpeg",
                "image/jpg"
            };
            if (!content_types.Contains(File.ContentType)) throw new Exception("Unsupported file type.");

            USER user = this.user_manager.Get(UserId);
        }
    }
}
