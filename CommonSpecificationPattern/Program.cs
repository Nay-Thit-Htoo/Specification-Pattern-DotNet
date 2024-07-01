using CommonSpecificationPattern;
using Microsoft.EntityFrameworkCore;
using Specification;
using Specification.DbContext;
using Specification.Model;
using Specification.Services;
using Specification.UserSpecification;


var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("YourDataBase")
            .Options;
using (var context = new ApplicationDbContext(options))
{
    //var ageSpec = new AgeSpecification(age: 20);
    //var nameSpec = new NameSpecification(name: "Aung");
    //var andSpec = new AndSpecification<User>(ageSpec, nameSpec);

    var starteDateFiler = new DateRangeSpecification<User>(new DateTime(2024, 06, 02), new DateTime(2024, 06, 05), e => e.StartDate);
    var repository=new GenericRepository<User>(context);
    repository.Find(starteDateFiler);
}

