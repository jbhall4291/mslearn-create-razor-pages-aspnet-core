using ContosoPizza.Models;
using ContosoPizza.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPizza.Pages
{
  public class PizzaListModel : PageModel
{

    public IActionResult OnPostDelete(int id)
{
    _service.DeletePizza(id);

    return RedirectToAction("Get");
}

    [BindProperty]
public Pizza NewPizza { get; set; } = default!;

public IActionResult OnPost()
{
    if (!ModelState.IsValid || NewPizza == null)
    {
        return Page();
    }

    _service.AddPizza(NewPizza);

    return RedirectToAction("Get");
}

    private readonly PizzaService _service;
    public IList<Pizza> PizzaList { get;set; } = default!;

    public PizzaListModel(PizzaService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        PizzaList = _service.GetPizzas();
    }
}  
}
