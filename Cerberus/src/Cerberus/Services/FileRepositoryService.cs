using Cerberus.Interfaces.ServiceInterfaces;
using Cerberus.Interfaces.ManagerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Cerberus.Models;
using System.IO;
using Cerberus.Utils;
using Microsoft.AspNetCore.Hosting;

namespace Cerberus.Services
{
    public class FileRepositoryService : IFileRepositoryService
    {
        private readonly IUserManager user_manager;
        private readonly IFileManager file_manager;
        private readonly IHostingEnvironment hosting_environment;

        public FileRepositoryService(IUserManager UserManager, IFileManager FileManager, IHostingEnvironment HostingEnvironment)
        {
            this.user_manager = UserManager;
            this.file_manager = FileManager;
            this.hosting_environment = HostingEnvironment;
        }

        public void AddUserAvatar(IFormFile File, int UserId)
        {
            string[] content_types = new string[]
            {
                "image/jpeg",
                "image/jpg"
            };
            if (!content_types.Contains(File.ContentType)) throw new Exception("Unsupported file type.");
            
            string path = ConstUtil.USER_AVATAS_FOLDER_PATH + File.FileName;
            string full_server_path = this.hosting_environment.WebRootPath + path;
            if (System.IO.File.Exists(full_server_path)) throw new Exception("File with given name already exists. Try changing file name.");
            using (var file_stream = new FileStream(full_server_path, FileMode.Create))
            {
                File.CopyTo(file_stream);
            }


            TransactionContext transaction_context = new TransactionContext();
            try
            {   
                transaction_context.AddContextUser(this.user_manager);
                transaction_context.AddContextUser(this.file_manager);
                transaction_context.BeginTransaction();
                FILE new_file = new FILE();
                new_file.CONTENT_TYPE = File.ContentType;
                new_file.FULL_NAME = File.FileName;
                new_file.NAME = File.FileName;
                new_file.PATH = path;
                this.file_manager.Add(new_file);
                USER user = this.user_manager.Get(UserId);
                user.AVATAR = new_file;
                transaction_context.CommtTransaction();
            }
            catch(Exception ex)
            {
                transaction_context.RollbackTransaction();
                throw ex;
            }
        }
    }
}
