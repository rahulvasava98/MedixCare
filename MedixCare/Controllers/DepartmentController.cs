using AutoMapper;
using MedixCare.Data;
using MedixCare.Models;
using MedixCare.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MedixCare.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }


        //Get DepartMent
        [HttpGet]
        public async Task<IActionResult> Index()
       {
            var Department = await _unitOfWork.Departments.GetAllAsync();

            return View(Department); 
        }

        //Get: Department/Create
        [HttpGet]
        public IActionResult Create() { 

            return View();
        }


        // POST: Department/Create
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                var department = _mapper.Map<Department>(ViewModel);

                if (ViewModel.ImageFile != null)
                {
                    //validate file type
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(ViewModel.ImageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("ImageFile", "Invalid file type. Only JPG, PNG, and GIF files are allowed.");
                    }

                    //Validate file size (limit to 5mb)
                    if (ViewModel.ImageFile.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("ImageFile", "File size exceeds the 5MB limit.");
                    }

                    // If any validation errors exist, return the view with error messages
                    if (!ModelState.IsValid)
                    {
                        return View(ViewModel);
                    }


                    //if file is valid, upload the file
                    string uniqueFileName = UploadedFile(ViewModel.ImageFile);
                    department.Image = uniqueFileName;  // Store the file name in the department's image property
                }

                await _unitOfWork.Departments.AddAsync(department);
                await _unitOfWork.SaveAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(ViewModel);

            //without FIle Upload Validation

            //if (ModelState.IsValid) {
            //    var department = _mapper.Map<Department>(ViewModel);
            //    if(ViewModel.ImageFile != null)
            //    {
            //        string uniqueFileName = UploadedFile(ViewModel.ImageFile);
            //        department.Image = uniqueFileName; 
            //    }

            //    await _unitOfWork.Departments.AddAsync(department);
            //    await _unitOfWork.SaveAsync();
            //    return RedirectToAction(nameof(Index)); 

            //}
            //return View(ViewModel);


        }


        // GET: Department/Edit/id
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)  return NotFound();

            var department = await _unitOfWork.Departments.GetByIdAsync(id.Value);
            if(department == null) return NotFound();   

            var viewModel = _mapper.Map<DepartmentViewModel>(department);

            return View(viewModel);

        }


        // POST: Department/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,DepartmentViewModel viewModel)
        {
            if (id != viewModel.id) return NotFound();

            if (ModelState.IsValid)
            {
                var department = await _unitOfWork.Departments.GetByIdAsync(id);
                if (department == null) return NotFound();

                department.Name = viewModel.Name;
                department.Description = viewModel.Description;

                if(viewModel.ImageFile != null)
                {
                    //validate file type
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var extension = Path.GetExtension(viewModel.ImageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("ImageFile", "Invalid file type. Only JPG, PNG, and GIF files are allowed.");
                    }

                    //Validate file size (limit to 5mb)
                    if (viewModel.ImageFile.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("ImageFile", "File size exceeds the 5MB limit.");
                    }

                    // If any validation errors exist, return the view with error messages
                    if (!ModelState.IsValid)
                    {
                        return View(viewModel);
                    }

                    //Delete old Image
                    if (!string.IsNullOrEmpty(department.Image))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/Department", department.Image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                   
                    string uniqueFileName = UploadedFile(viewModel.ImageFile);
                    department.Image = uniqueFileName;

                }

                _unitOfWork.Departments.Update(department);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        // GET: Department/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var department = await _unitOfWork.Departments.GetByIdAsync(id.Value);
            if (department == null) return NotFound();
            return View(department);

        }

        [HttpPost,ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null) return NotFound();

            if (!string.IsNullOrEmpty(department.Image))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/Department", department.Image);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _unitOfWork.Departments.Remove(department);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));

        } 


        //C:\Users\user\source\repos\MedixCare\MedixCare\wwwroot\images\Department\

        private string UploadedFile(IFormFile imageFile) {

            string UploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/Department");
            Directory.CreateDirectory(UploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
            string filePath = Path.Combine(UploadsFolder, uniqueFileName);

            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }
            return uniqueFileName;
        }


    }
}
