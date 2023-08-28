Client side libraries
----------------------------

For the web layout pages, specially _Layout.cshtml, it is required to bring styling (e.g. Boostrap) and jquery libraries. 
For this project in particular, and to provide AJAX funcitonality, the recomended libraries are as follow, 
(it is indicated the final location in the project):

  wwwroot/lib/jquery/jquery.js
  wwwroot/lib/jquery-validate/jquery.validate.js
  wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js
  wwwroot/lib/bootstrap/js/bootstrap.js


The author of the training also provided a CSS file specific for the project. This was copied from 
the sample code provided. But traditionally this will be created by teh developer. 

  wwwroot/css/site.css

To bring them in, selct the project and with mouse right-button select "Add -> Client-Side Library".
The screen that shows, type the name of the libraries needed, one at at time.
For example, for this project all of the following were added:

  jquery
  jquery-validate
  jquery-validation-unobtrusive
  bootstrap

NOTE: Make sure that the location is properly specified in the field at the bottom of teh dialog-box
The final directory must match what was indicated above (i.e. wwwroot/lib/).

Any additiona client side library, like the custom CSS provide by the instructor, most be located under 
the proper wwwroot subfolder. Even the static images go here.

Once the libraries are added, then refrence them in the _Layout.cshtml following HTLM standar notations.
For example:

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Bethany's Pie Shop</title>
    <link href='https://fonts.googleapis.com/css?family=Work+Sans' rel='stylesheet' type='text/css'>
    <script src="~/lib/jquery/jquery.js"></script>
    <script src="~/lib/jquery-validate/jquery.validate.js"></script>
    <script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"></script>
    <script src="~/lib/bootstrap/js/bootstrap.js"></script>
    <link href="~/css/site.css" rel="stylesheet" />
    <base href="/" />
</head>
<body>
</body>
</html>

With this settings in palce teh developer can use styling and jqueires across the pages.



