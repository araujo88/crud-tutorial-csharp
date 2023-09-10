# crud-tutorial-csharp
A simple REST API CRUD tutorial in C#

## Environment setup (Ubuntu)

Running an ASP.NET Core Web API application on Ubuntu is fairly straightforward. Here are the steps to get your app up and running:

### Step 1: Install .NET SDK

First, you'll need to install the .NET SDK on your Ubuntu machine. Open a terminal and run the following commands to install it:

For .NET 5:

```bash
wget https://download.visualstudio.microsoft.com/download/pr/904da7d0-ff02-49db-bd6b-5ea615cbdfc5/966690e36643662dcc65e3ca2423041e/dotnet-sdk-5.0.408-linux-x64.tar.gz

mkdir -p $HOME/dotnet && tar zxf dotnet-sdk-5.0.408-linux-x64.tar.gz -C $HOME/dotnet
```

Add these to your `.bashrc` file:

```bash
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
```

If you need to install a different version of the .NET SDK, you can find the installation instructions on the [official .NET website](https://dotnet.microsoft.com/download/dotnet/5.0).

#### Extra - openssl

```bash
wget https://www.openssl.org/source/openssl-1.1.1c.tar.gz
tar -xzvf openssl-1.1.1c.tar.gz
cd openssl-1.1.1c
./config
make
sudo make install
```

### Step 2: Clone or Copy Your Project

Next, you'll need to get your project files onto your Ubuntu machine. You can either clone your project from a Git repository, or you can copy the files over directly.

```bash
git clone <your-repository-url>
```

### Step 3: Navigate to Your Project Folder

Open a terminal and navigate to your project folder. If you've cloned a repository, it might look something like this:

```bash
cd /path/to/your/project/SimpleCRUDAPI
```

### Step 4: Restore Packages and Build the Project

Run the following command to restore any NuGet packages and build your project:

```bash
dotnet restore
dotnet build
```

### Step 5: Run Your Application

Finally, run the following command to start your application:

```bash
dotnet run
```

Your application will start, and you should be able to access it from a web browser or tools like Postman or `curl` by navigating to the displayed URL, usually `http://localhost:5000` or `https://localhost:5001`.

And that's it! Your ASP.NET Core Web API application should now be running on Ubuntu.

Building a simple CRUD (Create, Read, Update, Delete) RESTful API using C# is relatively straightforward with the help of the ASP.NET Core framework. Below is a simple example to guide you through the process.

### Prerequisites

- .NET SDK installed (5.0 or later)
- IDE like Visual Studio or Visual Studio Code

### Steps

1. **Create a new ASP.NET Core Web API project**

    ```bash
    dotnet new webapi -n SimpleCRUDAPI
    ```

    This will create a new Web API project with the name "SimpleCRUDAPI".

2. **Navigate to the project directory**

    ```bash
    cd SimpleCRUDAPI
    ```

3. **Create a Model**

    Create a new file in the `Models` folder called `Item.cs`.

    ```csharp
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    ```

4. **Create a Data Store**

    In a real-world application, you'd use a database, but for simplicity, let's use an in-memory list to act as our data store.

    Create a new folder called `Data` and add a new file called `ItemRepository.cs`.

    ```csharp
    using SimpleCRUDAPI.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = 1, Name = "Item 1" },
            new Item { Id = 2, Name = "Item 2" }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(int id)
        {
            var item = items.First(existingItem => existingItem.Id == id);
            items.Remove(item);
        }
    }
    ```

5. **Create a Controller**

    Create a new controller named `ItemsController`.

    ```csharp
    using Microsoft.AspNetCore.Mvc;
    using SimpleCRUDAPI.Data;
    using SimpleCRUDAPI.Models;
    using System.Collections.Generic;

    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository itemRepository;

        public ItemsController()
        {
            itemRepository = new ItemRepository();
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return itemRepository.GetItems();
        }

        [HttpGet("{id}")]
        public Item GetItem(int id)
        {
            return itemRepository.GetItem(id);
        }

        [HttpPost]
        public void CreateItem(Item item)
        {
            itemRepository.CreateItem(item);
        }

        [HttpPut]
        public void UpdateItem(Item item)
        {
            itemRepository.UpdateItem(item);
        }

        [HttpDelete("{id}")]
        public void DeleteItem(int id)
        {
            itemRepository.DeleteItem(id);
        }
    }
    ```

6. **Test the API**

    Run the application.

    ```bash
    dotnet run
    ```

    You should see output indicating the application has started and is listening on a port (usually 5000 or 5001 for HTTPS).

    Use Postman or `curl` to test the API endpoints.

    - GET: `https://localhost:5001/api/items`
    - GET by ID: `https://localhost:5001/api/items/1`
    - POST: `https://localhost:5001/api/items` with JSON payload like `{ "Id": 3, "Name": "Item 3" }`
    - PUT: `https://localhost:5001/api/items` with JSON payload like `{ "Id": 1, "Name": "Updated Item" }`
    - DELETE: `https://localhost:5001/api/items/1`

And that's it! You've built a simple CRUD RESTful API using C# and ASP.NET Core.