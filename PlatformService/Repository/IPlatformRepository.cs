using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Repository;
public interface IPlatformRepository
{
    IEnumerable<Platform> GetAllPlatforms();
    Platform GetPlatformById(int platformId);
    void CreatePlatform(Platform platform);
    void UpdatePlatform(Platform platform);
    void DeletePlatform(int platformId);
    bool SaveChanges();
}