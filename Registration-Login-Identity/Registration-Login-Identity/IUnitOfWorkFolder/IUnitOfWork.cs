using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.IUnitOfWorkFolder
{
public   interface IUnitOfWork
    {
        void uploadImage(IFormFile file);
    }
}
