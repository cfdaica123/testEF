using CPS_EF.Models;
using CPS_EF.Repository;

// su dung Repository
internal class Program
{
    private static async Task Main(string[] args)
    {
        var db = new AppDBContext();

        Repository<Category> repositoryCategory = new Repository<Category>(db);

        // show cac category
        // IEnumerable<Category> categories = await repositoryCategory.Get();
        // foreach (var category in categories)
        // {
        //     Console.WriteLine($"Category ID: {category.Id}, Name: {category.Name}");
        // }

        //them moi 1 category
        // await repositoryCategory.Create(new Category
        // {
        //     Name = "abcnew",
        // });

        // Console.WriteLine("Created: 1 Category");

        //tim kiem category co id la 3 sau do sua name 
        Category categoryToUpdate = await repositoryCategory.GetById(3);
        if (categoryToUpdate == null)
        {
            Console.WriteLine("Category with Id = 3 not found.");
            return;
        }

        categoryToUpdate.Name = "New Category Nameaa";
        await repositoryCategory.Update(categoryToUpdate);
        await db.SaveChangesAsync();

        Console.WriteLine("Updated category with Id = 3");


        //xoa category co id la 4
        // await repositoryCategory.Delete(5);
        // Console.WriteLine("Deleted Category with id = 5");
    }
}