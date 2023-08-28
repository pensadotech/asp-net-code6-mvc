View Components
------------------------------

* Used for partial content
* Consist of a class and a view. They have their own code.
* Support DI
* It is a stand alone component.
* Normally used for
     Login Panel
     Dynamic navigation
     Shopping cart

* View Components class must be stored in a <root>/Component folders and

* The view  must be locate under Shared/Component/<Component-name>
  with a Default.cshtml as the index.

  For example
    Class: Components/ShoppingCartSummary.cs
    View: Shared/Component/ShoppingCartSummary/Default.cshtml  
   
* The class must follow the convention depicted as follows:
  
      public class ShoppingCartSummary : ViewComponent
      {
          public IViewComponentResult Invoke()
          {
             return View(model);
          }
      }

* The view will receceive the model, and do something with it

    @model ShoppingCartViewModel

* It is required to reference teh view component inside the _ViewImports.cshtml

     @using BethanysPieShop.Components
     @addTagHelper *, BethanysPieShop

* To use the view component, use a Tags helper "vc", as follows.
  For example, it could be add to the _Layout.cshtml file

   <vc:shopping-cart-summary></vc:shopping-cart-summary>

* Alternativelley, the view componet could be invoked using a @await statement
  this is not used in this example

   @await Component.InvokeAsync("ShoppingCartSummary")






