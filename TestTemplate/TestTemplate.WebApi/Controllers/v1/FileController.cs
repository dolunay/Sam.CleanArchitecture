﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using TestTemplate.Application.Interfaces;

namespace TestTemplate.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class FileController : BaseApiController
    {
        private readonly IFileManagerService fileManagerService;

        public FileController(IFileManagerService fileManagerService)
        {
            this.fileManagerService = fileManagerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFile(string name)
        {
            var bytes = await fileManagerService.Download(name);

            return File(bytes, MediaTypeNames.Application.Octet, name);
        }

    }
}