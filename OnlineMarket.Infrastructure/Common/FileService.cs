using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using OnlineMarket.Domain.Exceptions.GeneralExceptions;
using OnlineMarket.Domain.Interfaces;

namespace OnlineMarket.Infrastructure.Common;

public class FileService : IFileService
{
    private IHostEnvironment  _environment;

    public FileService(IHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveFiles(IFormFile files)
    {
        var fileExtension = Path.GetExtension(files.FileName);
        if (!fileExtension.Equals(".jpg") && !fileExtension.Equals(".jpeg"))
        {
            throw new BadRequestException("file format is wrong");
        }
        string filePath = Path.Combine(_environment.ContentRootPath,"image");
            
        
                string fileName = Path.Combine(filePath, files.FileName);
                
              
                using (Stream fileStream = new FileStream(fileName, FileMode.Create))
                {
                    await files.CopyToAsync(fileStream);
                }
                
                return fileName;

    }

}