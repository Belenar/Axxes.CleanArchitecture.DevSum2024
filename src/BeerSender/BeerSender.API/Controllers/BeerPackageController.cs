using BeerSender.Application.Packages;
using BeerSender.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerPackageController : ControllerBase
    {
        private readonly ILogger<BeerPackageController> _logger;
        private readonly BoxCreator _creator;
        private readonly IPackageRepository _repo;

        public BeerPackageController(ILogger<BeerPackageController> logger,
            BoxCreator creator, IPackageRepository repo)
        {
            _logger = logger;
            _creator = creator;
            _repo = repo;
        }

        [HttpPost(Name = "Create")]
        public ActionResult<BeerPackage> Create(int bottles)
        {
            // map between API/View models in here
            // Domain should never know about those
            var box = _creator.Handle(new CreateBox(bottles));
            return Ok(box);
        }

        [HttpGet(Name = "GetAll")]
        public ActionResult<IEnumerable<BeerPackage>> GetAll()
        {
            var allPackages = _repo.GetAll();
            return Ok(allPackages);
        }
    }
}
