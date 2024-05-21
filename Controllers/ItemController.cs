using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Repo.Base;

namespace ShoppingCart.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepo _itemRepo;
        private readonly ICategoryRepo _categoryRepo;
        public ItemController(IItemRepo itemRepo, ICategoryRepo categoryRepo)
        {
            _itemRepo = itemRepo;
            _categoryRepo = categoryRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _itemRepo.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateItemViewModel()
            {
                CategoriesSelectList = _categoryRepo.GetCategoriesSelectList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CategoriesSelectList = _categoryRepo.GetCategoriesSelectList();
                return View(viewModel);
            }
            var isCreated = _itemRepo.Create(viewModel);
            if (isCreated == 0)
            {
                return BadRequest();
            }
            TempData["Success"] = "the item has been added successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _itemRepo.GetById(id);
            if (item == null)
            {
                return BadRequest();
            }
            var viewModel = new UpdateItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CategoryId = item.CategoryId,
                CategoriesSelectList = _categoryRepo.GetCategoriesSelectList(),
                Cover = item.Cover
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(UpdateItemViewModel viewModel)
        {
            var item = _itemRepo.GetById(viewModel.Id);
            if (item == null)
            {
                return BadRequest();
            }
            if (viewModel.FormFile == null)
            {
                ModelState.Remove("FormFile");
            }
            if (!ModelState.IsValid)
            {
                viewModel.CategoriesSelectList = _categoryRepo.GetCategoriesSelectList();
                return View(viewModel);
            }
            var isUpdated = _itemRepo.Update(viewModel);
            if (isUpdated == 0)
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }
    }
}
