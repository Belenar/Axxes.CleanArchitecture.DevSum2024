using BeerSender.Application.Packages;
using BeerSender.Domain;

namespace BeerSender.Persistence;

class PackageRepository(BeerContext context) : IPackageRepository
{
    public void SavePackage(BeerPackage package)
    {
        var newPackage = PersistedPackage.FromPackage(package);
        context.BeerPackages.Add(newPackage);
        context.SaveChanges();
    }

    public IEnumerable<BeerPackage> GetAll()
    {
        var packages = context.BeerPackages
            .Select(persisted => persisted.ToPackage())
            .ToList();

        return packages;
    }
}