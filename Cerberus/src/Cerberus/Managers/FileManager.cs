using Cerberus.AbstractClasses;
using Cerberus.Interfaces.ManagerInterfaces;
using Cerberus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.Managers
{
    public class FileManager : AbstractManager<FILE>, IFileManager
    {
        public FileManager(MainContext Context) : base(Context)
        {
        }
    }
}
