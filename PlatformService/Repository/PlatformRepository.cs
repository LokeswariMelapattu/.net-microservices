

using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;
using PlatformService.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions; 

    
namespace PlatformService.Repository;
public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }   

    public Platform GetPlatformById(int platformId)
    {
        return _context.Platforms.FirstOrDefault(p => p.Id == platformId);
    }
    public void CreatePlatform(Platform platform)
    {
        if (platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }
        _context.Platforms.Add(platform);
    }
    public void UpdatePlatform(Platform platform)
    {
        // No code in this method, as EF Core tracks changes automatically
    }
    public void DeletePlatform(int platformId)
    {
        var platform = GetPlatformById(platformId);
        if (platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }
        _context.Platforms.Remove(platform);
    }
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
} 