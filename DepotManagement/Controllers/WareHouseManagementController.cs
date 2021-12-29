using Contracts;
using DepotManagement.Paging;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagementService.Models;

namespace DepotManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseManagementController : ControllerBase
    {
        readonly ILogger<WareHouseManagementController> _log;
        private readonly IProductBundlesRepo _productBundlesRepo;
        private readonly ProductRepo _productRepo;

        public WareHouseManagementController(IProductBundlesRepo productBundlesRepo, ProductRepo productRepo, ILogger<WareHouseManagementController> log)
        {
            _productBundlesRepo = productBundlesRepo;
            _productRepo = productRepo;
            _log = log;
        }


        [HttpGet]
        [Route("GetPalletsDetails")]
        public ActionResult<IEnumerable<ProductBundles>> GetPalletsDetails([FromQuery] PagingParameters pagingParameters)
        {
            _log.LogInformation("LogCreated for // GET:GetPalletsDetails WareHouseManagementController ");
            // return await _context.ProductBundles.ToListAsync();
            try
            {
                var productBundles = _productBundlesRepo.GetPalletsDetailsPaging(pagingParameters);
                var metadata = new
                {
                    productBundles.TotalCount,
                    productBundles.PageSize,
                    productBundles.CurrentPage,
                    productBundles.TotalPages,
                    productBundles.HasNext,
                    productBundles.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return Ok(productBundles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }
        }
        [HttpGet]
        [Route("GetProductDetails")]
        public ActionResult<IEnumerable<Products>> GetProductDetails()
        {
            _log.LogInformation("LogCreated for // GET:GetProductDetails WareHouseManagementController ");
            try
            {
                return Ok(_productBundlesRepo.GetProductDetails());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }

        }


        //3-a. Update Product Information
        [HttpPut("{pid}")]

        public async Task<IActionResult> UpdateProductDetails(int pid, Products products)
        {
            _log.LogInformation("LogCreated for // PUT:Update Product Information WareHouseManagementController ");
            try
            {
                if (pid != products.ProductId)
                {
                    return BadRequest();
                }
                _productBundlesRepo.UpdateProductDetails(pid, products);


                if (!ProductModelExists(pid))
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }
        }

        //5.	Update/Manage LPN 

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLPN(int id, LPN lPN)
        {
            _log.LogInformation("LogCreated for // PUT:Update/Manage LPN  WareHouseManagementController ");
            if (id != lPN.LPNID)
            {
                return BadRequest();
            }

            try
            {
                _productBundlesRepo.UpdateLPN(id, lPN);
                return Ok(lPN);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LPNModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "An error occured ");
                }
            }
        }
        //6.	Search APIs for the Products.
        [HttpGet]
        public ActionResult<IEnumerable<Products>> SearchProductDetails([FromQuery] ProductSearchParameter productSearchParameter)
        {
            _log.LogInformation("LogCreated for // GET:Search Product  WareHouseManagementController ");

            try
            {
                var filteredProducts = _productRepo.SearchProductDetails(productSearchParameter);
                var metadata = new
                {
                    filteredProducts.TotalCount,
                    filteredProducts.PageSize,
                    filteredProducts.CurrentPage,
                    filteredProducts.TotalPages,
                    filteredProducts.HasNext,
                    filteredProducts.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return Ok(filteredProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured " + ex.Message);
            }
        }
        private bool ProductModelExists(int id)
        {
            return _productBundlesRepo.ProductModelExists(id);

        }
        private bool LPNModelExists(int id)
        {
            return _productBundlesRepo.LPNModelExists(id);
        }
    }
}

