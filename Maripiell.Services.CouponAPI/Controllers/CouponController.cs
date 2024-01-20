using AutoMapper;
using Maripiell.Common.Common.DataAccess.Repositories.Contracts;
using Maripiell.Services.CouponAPI.DataAccess;
using Maripiell.Services.CouponAPI.Domain.Dto;
using Maripiell.Services.CouponAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maripiell.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly IBaseRepository<Coupon, CouponDBContext> _baseRepository;
        private readonly IMapper mapper;

        public CouponController(IBaseRepository<Coupon, CouponDBContext> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(mapper.Map<IEnumerable<CouponDto>>(_baseRepository.GetAll()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _baseRepository.GetById(id);

            if (response == null) return NotFound();

            return Ok(mapper.Map<CouponDto>(response));
        }

        [HttpPost]
        public IActionResult Post(CouponDto entity)
        {
            var response = _baseRepository.Add(mapper.Map<Coupon>(entity));

            return Ok(mapper.Map<CouponDto>(response));
        }

        [HttpPut]
        public IActionResult Put(CouponDto entity)
        {
            var response = _baseRepository.Update(mapper.Map<Coupon>(entity));

            return Ok(mapper.Map<CouponDto>(response));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _baseRepository.GetById(id);

            if (entity == null) return NotFound();

            var response = _baseRepository.Delete(entity);

            return Ok(mapper.Map<CouponDto>(response));
        }
    }
}
