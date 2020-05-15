using DAL.Models;
using Repository.InterFace;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IRepositories
{
    public interface IUserRepository:IGenericRepository<ApplicationUser>
    {
        ApplicationUser GetUserByName(string userName);
    }
}
