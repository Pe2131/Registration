using DAL;
using DAL.Models;
using Repository.InterFace;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private UserRepository _UserRepo;
        public UserRepository UserRepo
        {
            get
            {
                if (_UserRepo == null)
                {
                    _UserRepo = new UserRepository(_dbContext);
                }
                return _UserRepo;
            }
        }
        private GenericRepositori<Tb_Orders> _OrderRepo;
        public GenericRepositori<Tb_Orders> OrderRepo
        {
            get
            {
                if (_OrderRepo == null)
                {
                    _OrderRepo = new GenericRepositori<Tb_Orders>(_dbContext);
                }
                return _OrderRepo;
            }
        }
        private GenericRepositori<Tb_Slider> _SliderRepo;
        public GenericRepositori<Tb_Slider> SliderRepo
        {
            get
            {
                if (_SliderRepo == null)
                {
                    _SliderRepo = new GenericRepositori<Tb_Slider>(_dbContext);
                }
                return _SliderRepo;
            }
        }
        private GenericRepositori<Tb_Setting> _SettingRepo;
        public GenericRepositori<Tb_Setting> SettingRepo
        {
            get
            {
                if (_SettingRepo == null)
                {
                    _SettingRepo = new GenericRepositori<Tb_Setting>(_dbContext);
                }
                return _SettingRepo;
            }
        }
        private GenericRepositori<Tb_Contact> _ContactRepo;
        public GenericRepositori<Tb_Contact> ContactRepo
        {
            get
            {
                if (_ContactRepo == null)
                {
                    _ContactRepo = new GenericRepositori<Tb_Contact>(_dbContext);
                }
                return _ContactRepo;
            }
        }
        private GenericRepositori<Tb_Contact2> _Contact2Repo;
        public GenericRepositori<Tb_Contact2> Contact2Repo
        {
            get
            {
                if (_Contact2Repo == null)
                {
                    _Contact2Repo = new GenericRepositori<Tb_Contact2>(_dbContext);
                }
                return _Contact2Repo;
            }
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
