# The Books Stop Application
.NET 6 Web API, MVC Web App, EF Core, and Stripe Integration


```
    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));

        ViewBag.JavaScriptFunction = string.Format("DisplayProgressMessage();");
    }
```