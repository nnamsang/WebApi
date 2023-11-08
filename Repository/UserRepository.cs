using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Data.EF;
using WebApi.Data.Models;
using WebApi.Helper;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private QuanLyVatTuContext _context;
        private readonly IConfiguration _conf;

        public UserRepository(QuanLyVatTuContext context, IConfiguration conf) 
        { 
            _context=context;
            //_appSetting = optionsMonitor.SecretKey;
            _conf = conf;
        }
        public async Task<UserModel> Add(UserModel user)
        {
            string HinhDaiDien;
            if (user.Img.Length > 0)
            {
                var uniqueFileName = user.Img.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "avatar", uniqueFileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await user.Img.CopyToAsync(stream);
                }
                HinhDaiDien = "/avatar/" + uniqueFileName;
            }
            else HinhDaiDien =  null;

            var _user = new User
            {
                Username = user.Username,
                MatKhau = CreateMD5.GetMD5(user.MatKhau!),
                Email = user.Email,
                
                HoTen = user.HoTen,
                IdChucVu = user.IdChucVu,
                IdPhongBan = user.IdPhongBan,
                DiaChi = user.DiaChi,
                DienThoai = user.DienThoai,
                HinhDaiDien = HinhDaiDien
            };
            
                _context.Users.Add(_user);
                _context.SaveChanges();

                var addedUserVM = new UserModel
                {
                    
                    Username = _user.Username,
                    Email = _user.Email,
                    HoTen = _user.HoTen,
                    IdChucVu = _user.IdChucVu,
                    IdPhongBan = _user.IdPhongBan,
                    DiaChi = _user.DiaChi,
                    DienThoai = _user.DienThoai,
                    HinhDaiDien = _user.HinhDaiDien
                };

            return addedUserVM;
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.SingleOrDefault(o=>o.IdUser == userId);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }    
        }

        public List<UserVM> GetAllUsers()
        {
            var user = from u in _context.Users
                       join
                       cv in _context.ChucVus on
                       u.IdChucVu equals cv.IdChucVu
                       join pb in _context.PhongBans on
                       u.IdPhongBan equals pb.IdPhongBan
                       select new UserVM
                       {
                           IdUser = u.IdUser,
                           Username = u.Username,
                           Email = u.Email,
                           MatKhau = u.MatKhau,
                           HoTen = u.HoTen,
                           TenChucVu = cv.TenChucVu,
                           IdChucVu = u.IdChucVu,
                           TenPhongBan = pb.TenPhongBan,
                           IdPhongBan = u.IdPhongBan,
                           DiaChi = u.DiaChi,
                           DienThoai = u.DienThoai,
                           HinhDaiDien = u.HinhDaiDien,
                       };
            return user.ToList();
        }

        public UserVM GetUserById(int id)
        {
            var user = (from u in _context.Users
                        join
                        cv in _context.ChucVus on
                        u.IdChucVu equals cv.IdChucVu
                        join pb in _context.PhongBans on
                        u.IdPhongBan equals pb.IdPhongBan
                        where u.IdUser == id
                        select new UserVM
                        {
                            IdUser = u.IdUser,
                            Username = u.Username,
                            Email = u.Email,
                            MatKhau = u.MatKhau,
                            HoTen = u.HoTen,
                            TenChucVu = cv.TenChucVu,
                            IdChucVu = u.IdChucVu,
                            TenPhongBan = pb.TenPhongBan,
                            IdPhongBan = u.IdPhongBan,
                            DiaChi = u.DiaChi,
                            DienThoai = u.DienThoai,
                            HinhDaiDien = u.HinhDaiDien,
                        }).First();
          
           
                var jsonUser = JsonConvert.SerializeObject(user);
                return JsonConvert.DeserializeObject<UserVM>(jsonUser);
        }

        public async Task UpdateUser(int id, UserModel user)
        {
            string uniqueFileNam ="";
            if (user.Img.Length > 0)
            {
                uniqueFileNam = user.Img.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "avatar", uniqueFileNam);
                using (var stream = System.IO.File.Create(path))
                {
                    await user.Img.CopyToAsync(stream);
                }
            }
            var _users = _context.Users.SingleOrDefault(o => o.IdUser == id);    
     
                _users.Username = user.Username;
                _users.MatKhau = CreateMD5.GetMD5(user.MatKhau);
                _users.HoTen = user.HoTen;
                _users.Email = user.Email;
                _users.HinhDaiDien = user.HinhDaiDien;
                _users.IdChucVu = user.IdChucVu;
                _users.DiaChi = user.DiaChi;
                _users.DienThoai = user.DienThoai;
                _users.HinhDaiDien = "/avatar/" + uniqueFileNam;
            //_context.SaveChanges();
            
            _context.Entry(_users).State = EntityState.Modified;
            _context.SaveChanges();

        }


    }
}
