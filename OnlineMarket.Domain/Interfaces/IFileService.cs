using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineMarket.Domain.Interfaces;

public interface IFileService
{
    Task<string> SaveFiles(IFormFile files);
}