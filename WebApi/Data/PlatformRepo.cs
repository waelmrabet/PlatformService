using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _ctx;

        public PlatformRepo(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException();

            _ctx.Add(platform);
        }

        public List<Platform> GetAllPlatforms()
        {
            return _ctx.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _ctx.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
