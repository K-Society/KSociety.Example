using KSociety.Base.Srv.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KSociety.Example.Pre.Web.App.Areas.Book.Controllers
{
    [Area("Book")]
    public class BookController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly KSociety.Example.Srv.Agent.Interface.Command.IBook _book;
        private readonly KSociety.Example.Srv.Agent.Interface.Query.Model.IBook _bookQueryModel;
        private readonly KSociety.Example.Srv.Agent.Interface.Query.List.GridView.IBook _bookQueryListGridView;

        [BindProperty]
        public Srv.Dto.Model.Book BookModel { get; set; }

        [BindProperty]
        public Srv.Dto.List.GridView.Book BookListGridView { get; set; }

        public BookController(
            IWebHostEnvironment webHostEnvironment,
            KSociety.Example.Srv.Agent.Interface.Command.IBook book,
            KSociety.Example.Srv.Agent.Interface.Query.Model.IBook bookQueryModel,
            KSociety.Example.Srv.Agent.Interface.Query.List.GridView.IBook bookQueryListGridView)
        {
            _webHostEnvironment = webHostEnvironment;
            _book = book;
            _bookQueryModel = bookQueryModel;
            _bookQueryListGridView = bookQueryListGridView;
        }

        public async ValueTask<IActionResult> Index()
        {
            BookListGridView = await _bookQueryListGridView.LoadAllRecordsAsync();
            return View(BookListGridView);
        }

        public async ValueTask<IActionResult> Upsert(Guid? id)
        {
            if (id == null)
            {
                BookModel = await _bookQueryModel.FindAsync(new IdObject(Guid.Empty));
                return View(BookModel);
            }
            BookModel = await _bookQueryModel.FindAsync(new IdObject(id.Value));
            if (BookModel.BookDto == null)
            {
                return NotFound();
            }

            return View(BookModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> Upsert()
        {
            if (ModelState.IsValid)
            {
                if (BookModel.BookDto.Id == Guid.Empty)
                {
                    await _book.AddAsync(BookModel.BookDto.GetAddReq());
                }
                else
                {
                    var connection = await _bookQueryModel.FindAsync(new IdObject(BookModel.BookDto.Id));
                    if (connection == null)
                    {
                        //await _tagGroup.AddAsync(TagGroup.GetAddReq());
                    }
                    else
                    {
                        await _book.UpdateAsync(BookModel.BookDto.GetUpdateReq());
                    }
                }

                return RedirectToAction("Index");
            }

            return View(BookModel);
        }

        public async ValueTask<IActionResult> Delete(Guid id)
        {
            var book = await _bookQueryModel.FindAsync(new IdObject(id));

            if (book == null)
            {
                return NotFound();
            }

            await _book.RemoveAsync(book.BookDto.GetRemoveReq());

            return RedirectToAction(nameof(Index));
        }
    }
}
