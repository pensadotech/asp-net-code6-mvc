Tag Helpers
-------------------------

Tag helpers enable server-side C# code to participate in 
creating and rendering HTML elements in Razor files.

* These can be seeing as custom html tags

* it is a good practice to put Tag helpers in a folder "TagHelpers"

* Tag helpers must be referenced in the _ViewImports.cshtml

  @addTagHelper BethanysPieShop.TagHelpers.*,BethanysPieShop

* There is a convention to follow, depicted in the following code.
  Look at the EmailTagHelper.cls for full details.

   public class EmailTagHelper : TagHelper
   {
       public override void Process(TagHelperContext context, TagHelperOutput output)
       {
       }
    }

* Tag helper are used as any regular HTML tag, passing the necesary attributes, 
  represented as properties in the class.  Look at the EmailTagHelper.cls for full details.

  <email
     address="myaddress@mydomain.com"
     content= "Contact us"
  </email>

  
*  For example in the View/Contact/Index.cshtml
    
   <div class="row gx-5">
      <img src="~/Images/contact/contact.jpg" class="img-fluid col-5" />
      <div class="col-7">
         <h1>We'd Love to Hear from You</h1>
         <h5>Please contact us by sending an email using the button below</h5>
         <!-- Use of custome tag helper -->
         <email address="info@@bethanyspieshop.com" content="Contact us" class="btn btn-secondary"></email>
      </div>
    </div>

* In this example, a link was creaeted in the _Layout.cshtml to reach the contact page

     <li class="nav-item">
        <a asp-controller="Contact" asp-action="Index" class="nav-link">Contact</a>
     </li>
