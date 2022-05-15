using Microsoft.AspNetCore.Mvc;

namespace SharesPrices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SharesPricesController : Controller
    {
      
        static List<Share> shares = new List<Share>
        {
            new Share { Id = 1, Name = "Tesla", Description = "Some Tesla share", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1)  },
            new Share { Id = 2, Name = "Affirm", Description = "Some Affirm share", StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(2)  },
            new Share { Id = 3, Name = "Gitlab", Description = "Some Gitlab share", StartDate = DateTime.Now.AddDays(-1), EndDate = DateTime.Now.AddDays(1)  },
        };

        [HttpGet]
        public ActionResult<Share> Get()
        {
            return Ok(shares);

        }

        [HttpGet("{id}")]
        public ActionResult<Share> Get(int id)
        {
            var share = shares.FirstOrDefault((share) => share.Id == id);
            if (share == null)
            {
                return NotFound();
            }
            return share;

        }

        [HttpPost]
        public void Post([FromBody] Share value)
        {
            Share newShare = new Share
            {
                Id = shares.Max(x => x.Id) + 1,
                Name = value.Name,
                Description = value.Description,
                StartDate = value.StartDate,
                EndDate = value.EndDate,
            };

            shares.Add(newShare);

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var share = shares.FirstOrDefault(share => share.Id == id);

            if (share != null)
                share.Name = value;

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var share = shares.FirstOrDefault(share => share.Id == id);

            if (share != null)
                shares.Remove(share);

        }
    }
}
