
using ArtworksEntityFramework.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;

var dbContext = new ArtworksContext();

// 1 QUERY
Console.WriteLine("Scrivere una query \"select\" per recuperare la lista contenete: museo, nome opera, nome degli artisti italiani");
var quey1 = dbContext.Museums
.Include(m => m.Artworks)
.ThenInclude(aw => aw.IdArtistNavigation)
.Include(m => m.Artworks)
.ThenInclude(aw => aw.IdCharacterNavigation)
.Where(m => m.Artworks.Any(aw => aw.IdArtistNavigation.Country == "Italia"))
.Select(m => new {
    MuseumName = m.MuseumName,
    ArtworkName = m.Artworks.Select(aw => aw.Name).First(),
    CharacterName = m.Artworks.Select(aw => aw.IdCharacterNavigation.Name).First()
})
.ToList();

foreach (var item in quey1)
{
    var characterName = item.CharacterName is null ? "----" : item.CharacterName;
    Console.WriteLine($"{item.MuseumName}, {item.ArtworkName}, {characterName}");
}
Console.WriteLine();

//2 QUERY 
Console.WriteLine("Scrivere una query per recuperare i nomi degli artisti le cui opere sono conservate a Parigi");
var query2 = dbContext.Artists
    .Include(a => a.Artworks)
        .ThenInclude(aw => aw.IdMuseumNavigation)
    .Where(a => a.Artworks.Any(aw => aw.IdMuseumNavigation.City == "Parigi"))
    .Select(a => a.Name)
    .Distinct();

foreach (var item in query2) Console.WriteLine(item);
Console.WriteLine();

//3 QUERY
Console.WriteLine("Scrivere una query “select” per recuperare la città in quale è conservato quadro \"Flora\""); 
var query3 = dbContext.Artworks
    .Include(a => a.IdMuseumNavigation)
    .Where(a => a.Name == "Flora")
    .Select(a => a.IdMuseumNavigation.City);
foreach (var item in query3) Console.WriteLine(item);






