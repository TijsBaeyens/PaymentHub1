﻿using DomainLayer.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI1.Controllers.Models.Payment1;
using WebAPI1.Controllers.Models.Webshop1;

namespace WebAPI1.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WebshopController : ControllerBase {
        private IWebshopRepo _webshopRepo;
        private IPaymentRepo _paymentRepo;

        public WebshopController(IWebshopRepo wr, IPaymentRepo paymentRepo) {
            _webshopRepo = wr;
            _paymentRepo = paymentRepo;
        }

        // GET: api/Webshop
        [HttpGet]
        public IEnumerable<Webshop> Get() {
            return _webshopRepo.GetAll();
        }

        // GET: api/Webshop/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_webshopRepo.GetWebshop(id));
            } catch (WebshopException ex) {
                return NotFound();
            }
        }

        // POST: api/Webshop
        [HttpPost]
        public IActionResult Post([FromBody] Webshop value) {
            try {
                _webshopRepo.AddWebshop(value);
                return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
            } catch (WebshopException ex) {
                return BadRequest();
            }
        }

        // PUT: api/Webshop/
        [HttpPut]
        public IActionResult Put([FromBody] Webshop value) {
            try {
                _webshopRepo.AddWebshop(value);
                return Ok();
            } catch (WebshopException ex) {
                return BadRequest();
            }
        }

        // DELETE: api/Webshop/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                _webshopRepo.RemoveWebshop(_webshopRepo.GetWebshop(id));
                return Ok();
            } catch (WebshopException ex) {
                return BadRequest();
            }
        }

        // POST: api/paymentRequest
        [HttpPost("paymentRequest")]
        public IActionResult PaymentRequest([FromBody] Payment value) {
            try {
                _paymentRepo.AddPayment(value);
                return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
            } catch (WebshopException ex) {
                return BadRequest();
            }
        }

        // GET: api/payment/5
        [HttpGet("payment/{id}")]
        public IActionResult GetPayment(int id) {
            try {
                return Ok(_paymentRepo.GetPayment(id));
            } catch (WebshopException ex) {
                return NotFound();
            }
        }

        // PUT: api/payment/
        [HttpPut("payment")]
        public IActionResult PutPayment([FromBody] Payment value) {
            try {
                _paymentRepo.UpdatePayment(value);
                return Ok();
            } catch (WebshopException ex) {
                return BadRequest();
            }
        }


        // SESSION

        // Start session
        [HttpPost("startSession")]
        public IActionResult StartSession([FromBody] Webshop value) {
            try {
                Session s = new Session();
                s.WebshopId = value.Id;
                return Ok(s);
            } catch (WebshopException ex) {
                return BadRequest();
            }
        }

        // End session
        [HttpDelete("endSession")]
        public IActionResult EndSession() {
            try {
                Session s = null;
                return Ok();
            } catch (WebshopException ex) {
                return BadRequest();
            }
        }
    }
}
