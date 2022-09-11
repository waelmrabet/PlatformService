using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IPlatformRepo
    {
        List<Platform> GetAllPlatforms();

        Platform GetPlatformById(int id);

        void CreatePlatform(Platform platform);

        bool SaveChanges();
    }
}
