#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;

using Services;

namespace MVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductsController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly CategoryManager _categoryManager;
        private readonly PictureManager _pictureManager;
        private readonly IWebHostEnvironment _webHost;

        public ProductsController(ProductManager productManager, CategoryManager categoryManager, IWebHostEnvironment webHost, PictureManager pictureManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _webHost = webHost;
            _pictureManager = pictureManager;
        }

        // GET: AdminPanel/Products
        public IActionResult Index()
        {
            var selproduct =_productManager.GetAllProduct();
            return View(selproduct);
        }

        // GET: AdminPanel/Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productManager.GetProductId(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: AdminPanel/Products/Create
        public IActionResult Create()
        {
            ViewBag.CategoryList=_categoryManager.GetAll();
            return View();
        }

        // POST: AdminPanel/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Price,Discount,Instock,PhotoUrl,IsSlider,IsWeek,IsMonth,IsDeleted,PublishDate,ModifiedOn,CategoryID,Id")] Product product, IFormFile[] PictureUrlss, int? thumbnailPictureId)
        {
            ViewBag.CategoryList = _categoryManager.GetAll();
            product.ProductPictures = new();
            if (ModelState.IsValid)
            {
                foreach (var PhotoUrl in PictureUrlss)
                {
                    string filename = Guid.NewGuid() + PhotoUrl.FileName;
                    string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                    string mainFile = Path.Combine(rootFile, filename);
                    using FileStream stream = new FileStream(mainFile, FileMode.Create);
                    PhotoUrl.CopyTo(stream);              
                    Picture picture = new() { Url = "/uploads/" + filename };
                    _pictureManager.AddPicture(picture);
                    product.ProductPictures.Add(new ProductPicture() { PictureId = picture.Id });
                       
                }
                int picFirstId=product.ProductPictures.First().PictureId;
                product.CoverPhotoId = product.ProductPictures != null ?
                    product.ProductPictures[
                        thumbnailPictureId.HasValue ?
                        thumbnailPictureId.Value :
                        picFirstId].PictureId : null;
               
                product.PublishDate = DateTime.Now;  
                _productManager.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: AdminPanel/Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =_productManager.GetProductId(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryList = _categoryManager.GetAll();
            return View(product);
        }

        // POST: AdminPanel/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Description,Price,Discount,Instock,PhotoUrl,IsSlider,IsWeek,IsMonth,IsDeleted,PublishDate,ModifiedOn,CategoryID,Id")] Product product, string removepictureIds,string OldPicture, IFormFile[] pictureUrlss, int? thumbnailPictureId)
        {

            if (ModelState.IsValid)
            {

              
                List<int> removePicids = removepictureIds.Split("-").Select(c=>int.Parse(c)).ToList(); 

                List<int> OldPictureIds = OldPicture.Split("-").Select(c => int.Parse(c)).Where(c=>!removePicids.Contains(c)).ToList();
                
                var oldPicture = product.ProductPictures.Where(c => removePicids.Contains(c.PictureId)).ToList();
                product.ProductPictures = product.ProductPictures.Where(c => !removePicids.Contains(c.PictureId)).ToList();
                var picwithoutRemove = _pictureManager.GetProductIds(OldPictureIds);
                product.ProductPictures = picwithoutRemove.Count > 0 ? picwithoutRemove : new List<ProductPicture>();
                foreach (var PhotoUrl in pictureUrlss)
                {
                    string filename = Guid.NewGuid() + PhotoUrl.FileName;
                    string rootFile = Path.Combine(_webHost.WebRootPath, "uploads");
                    string mainFile = Path.Combine(rootFile, filename);
                    using FileStream stream = new FileStream(mainFile, FileMode.Create);
                    PhotoUrl.CopyTo(stream);
                    Picture picture = new() { Url = "/uploads/" + filename };
                    _pictureManager.AddPicture(picture);
                    product.ProductPictures.Add(new ProductPicture() { PictureId = picture.Id });

                }
                int picFirstId = product.ProductPictures.First().PictureId;
                product.CoverPhotoId = product.ProductPictures != null ?
                    product.ProductPictures[
                        thumbnailPictureId.HasValue ?
                        thumbnailPictureId.Value :
                        picFirstId].PictureId : null;

                product.PublishDate = DateTime.Now;
                _productManager.Update(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryList = _categoryManager.GetAll();
            return View(product);
        }

        // GET: AdminPanel/Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product delproduct = _productManager.GetProductId(id);
            if (delproduct == null)
            {
                return NotFound();
            }

            return View(delproduct);
        }

        // POST: AdminPanel/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productManager.GetProductId(id);
           _productManager.Delete(product);
        
            return RedirectToAction(nameof(Index));
        }

      
    }
}
