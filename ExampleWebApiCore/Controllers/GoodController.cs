using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using ExampleWebApiCore.Infrastructure;
using ExampleWebApiCore.Models;
using ExampleWebApiCore.Services.Interfaces;
using ExampleWebApiCore.Views;
using ExampleWebApiCore.Views.Good;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class GoodController : Controller
    {
        private readonly IRepositoryService<Good> _repositoryService;
        private readonly IMapper _mapper;

        public GoodController(IRepositoryService<Good> repositoryService, IMapper mapper)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<GoodView> GetAll(ODataQueryOptions<Good> options)
        {
            return _repositoryService.GetAll().QueryableForOData<Good, GoodView>(options,_mapper);
        }

        [HttpPost]
        public string Insert(string name)
        {
            _repositoryService.Insert(new Good{Name = name});
            return "ok";
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {
            _repositoryService.HardDelete(_repositoryService.Find(id));
        }
    }
}