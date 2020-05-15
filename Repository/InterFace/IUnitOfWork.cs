using DAL.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InterFace
{
   public interface IUnitOfWork
    {
        public UserRepository UserRepo  { get; }
        public GenericRepositori<Tb_Orders> OrderRepo { get; }
        public GenericRepositori<Tb_Slider> SliderRepo { get; }
        public GenericRepositori<Tb_Setting> SettingRepo { get; }
        public GenericRepositori<Tb_Contact> ContactRepo { get; }
        public GenericRepositori<Tb_Contact2> Contact2Repo { get; }
        Task Save();
    }
}
