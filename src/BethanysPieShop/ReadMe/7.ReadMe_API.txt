Adding an API
--------------------------
The MVC,Razor, or Blazzor projects are the web representation for Microsoft technologies. 
These three techniques can coexist in any web application.
Additionally, the web application can also host API end points.

To add an API there are few key ideas to cosnider.

* For the Program.cs (or startup.cs), it is requied to register as service and reference middleware
     
     // service
     builder.Services.AddControllers();

     // midleware - add after routing
     app.MapControllers();

     NOTE: For MVC applications, it is not necesary to add the above definitions
           as the MVC services and middle ware arealy include the necesary functionality.
           If by accident, these are added, teh instructor mentiion that no side effect
           will exist.

* Create a folder 'Api' under the 'Controllers' folder, for example 'Controlles/Api'


* For controllers, use the ControlerBase instead of regular Controller used in MVC. For example

public class PieController : ControllerBase
{
}

For API use Attribute base routing, instead of Convention-based routing used in MVC. 
For example, on a controller:

[Route("api/[controller]")]
public class PieController : ControllerBase
{
}

* To reach Action methods based on REST verbs, the following convention depcited
in the following example

[Route("api/[controller]")]
public class PieController : ControllerBase
{
    private readonly IPieRepository _pieRepository;
    
    // https://localhost:7275/api/search
    [HttpGet]
    public IActionResult GetAll()
    {
    }

    // https://localhost:7275/api/search/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
    }
    
    // POST https://localhost:7275/api/search
    // media type: raw/json
    // body: "apple"
    [HttpPost]
    public IActionResult SearchPies([FromBody] string searchQuery)
    {
    }
}

* It is recomended to use Postman for testing

Once is tested, the way to conect to the Web applicaiton is as follows

* Add to the page controller an action that returns an emoty View
  for example in the  PieController

       // Create SEARCH action and return an empty View
        public IActionResult Search()
        {
            return View();
        }

* Create an emoty View under the proper Views folder and teh associated controller.
  For example : Views/Pie/Search

* In the view, add pure HTML code, and add a JQuery Ajax call. 

* At the _Layout.cshtml file add a link to the Search page using ASP tags.
  For eacxmple, 

           <ul class="navbar-nav mb-2 mb-lg-0">
                <li class="nav-item">
                    <a class="nav-link" asp-controller="Pie" asp-action="Search">
                         <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                            <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
                        </svg>
                    </a>
               </li>
           </ul>

