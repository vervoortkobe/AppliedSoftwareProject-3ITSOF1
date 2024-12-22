using AP.MyGameStore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.MyGameStore.Infrastructure.Seeding
{
    public static class StoreSeeding
    {
        public static void Seed(this EntityTypeBuilder<Store> modelBuilder)
        {
            modelBuilder.HasData(
                new Store() { Id = 1, Name = "MyGameStore Kortrijk", Street = "Korte Steenstraat", Number = "260", Zipcode = "8500", City = "Kortrijk", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 2, Name = "MyGameStore Ninove", Street = "Centrumlaan", Number = "95", Zipcode = "9400", City = "Ninove", IsFranchiseStore = true, Addition = "" },
new Store() { Id = 3, Name = "MyGameStore Roeselare", Street = "Ooststraat", Number = "97", Zipcode = "8800", City = "Roeselare", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 4, Name = "MyGameStore Zaventem", Street = "Weiveldlaan", Number = "173", Zipcode = "1930", City = "Zaventem", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 5, Name = "MyGameStore Hasselt", Street = "Demerstraat", Number = "254", Zipcode = "3500", City = "Hasselt", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 6, Name = "MyGameStore Gent", Street = "Veldstraat", Number = "128", Zipcode = "9000", City = "Gent", IsFranchiseStore = true, Addition = "" },
new Store() { Id = 7, Name = "MyGameStore Knokke-Heist", Street = "Lippenslaan", Number = "215", Zipcode = "8300", City = "Knokke-Heist", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 8, Name = "MyGameStore Maaseik", Street = "Bosstraat", Number = "239", Zipcode = "3680", City = "Maaseik", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 9, Name = "MyGameStore Beringen", Street = "Koolmijnlaan", Number = "85", Zipcode = "3580", City = "Beringen", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 10, Name = "MyGameStore Geraardsbergen", Street = "Winkelstraat", Number = "149", Zipcode = "9500", City = "Geraardsbergen", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 11, Name = "MyGameStore Asse", Street = "Stationsstraat", Number = "260", Zipcode = "1730", City = "Asse", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 12, Name = "MyGameStore Geel", Street = "Nieuwstraat", Number = "59", Zipcode = "2440", City = "Geel", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 13, Name = "MyGameStore Antwerpen", Street = "Meir", Number = "76", Zipcode = "2000", City = "Antwerpen", IsFranchiseStore = true, Addition = "" },
new Store() { Id = 14, Name = "MyGameStore Mol", Street = "Statiestraat", Number = "179", Zipcode = "2400", City = "Mol", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 15, Name = "MyGameStore Sint-Gillis", Street = "Fonsnylaan", Number = "286", Zipcode = "1060", City = "Sint-Gillis", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 16, Name = "MyGameStore Ieper", Street = "Boterstraat", Number = "189", Zipcode = "8900", City = "Ieper", IsFranchiseStore = false, Addition = "4" },
new Store() { Id = 17, Name = "MyGameStore Aalst", Street = "Nieuwstraat", Number = "64", Zipcode = "3800", City = "Aalst", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 18, Name = "MyGameStore Mechelen", Street = "Bruul", Number = "106", Zipcode = "2800", City = "Mechelen", IsFranchiseStore = false, Addition = "B" },
new Store() { Id = 19, Name = "MyGameStore Jette", Street = "Léon Theodorstraat", Number = "78", Zipcode = "1090", City = "Jette", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 20, Name = "MyGameStore Schaarbeek", Street = "Helmetsesteenweg", Number = "18", Zipcode = "1030", City = "Schaarbeek", IsFranchiseStore = true, Addition = "" },
new Store() { Id = 21, Name = "MyGameStore Dendermonde", Street = "Oude Vest", Number = "206", Zipcode = "9200", City = "Dendermonde", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 22, Name = "MyGameStore Sint-Niklaas", Street = "Stationsstraat", Number = "299", Zipcode = "9100", City = "Sint-Niklaas", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 23, Name = "MyGameStore Turnhout", Street = "Gasthuisstraat", Number = "40", Zipcode = "2300", City = "Turnhout", IsFranchiseStore = false, Addition = "A" },
new Store() { Id = 24, Name = "MyGameStore Brecht", Street = "Heiken", Number = "18", Zipcode = "2960", City = "Brecht", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 25, Name = "MyGameStore Sint-Jans-Molenbeek", Street = "Schoolstraat", Number = "191", Zipcode = "1080", City = "Sint-Jans-Molenbeek", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 26, Name = "MyGameStore Brasschaat", Street = "Bredabaan", Number = "26", Zipcode = "2930", City = "Brasschaat", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 27, Name = "MyGameStore Halle", Street = "Basiliekstraat", Number = "187", Zipcode = "1500", City = "Halle", IsFranchiseStore = true, Addition = "2" },
new Store() { Id = 28, Name = "MyGameStore Dilsen-Stokkem", Street = "Rijksweg", Number = "236", Zipcode = "3650", City = "Stokkem", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 29, Name = "MyGameStore Schoten", Street = "Paalstraat", Number = "77", Zipcode = "2900", City = "Schoten", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 30, Name = "MyGameStore Genk", Street = "Molenstraat", Number = "141", Zipcode = "3600", City = "Genk", IsFranchiseStore = false, Addition = "H" },
new Store() { Id = 31, Name = "MyGameStore Harelbeke", Street = "Tramstraat", Number = "184", Zipcode = "8530", City = "Harelbeke", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 32, Name = "MyGameStore Wevelgem", Street = "Menenstraat", Number = "192", Zipcode = "8560", City = "Wevelgem", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 33, Name = "MyGameStore Elsene", Street = "Elsensesteenweg", Number = "135", Zipcode = "1050", City = "Elsene", IsFranchiseStore = true, Addition = "" },
new Store() { Id = 34, Name = "MyGameStore Vilvoorde", Street = "Leuvensestraat", Number = "68", Zipcode = "1800", City = "Vilvoorde", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 35, Name = "MyGameStore Leuven", Street = "Diestsestraat", Number = "83", Zipcode = "3000", City = "Leuven", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 36, Name = "MyGameStore Anderlecht", Street = "Olympische Dreef", Number = "29", Zipcode = "1070", City = "Anderlecht", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 37, Name = "MyGameStore Grimbergen", Street = "Hogesteenweg", Number = "264", Zipcode = "1850", City = "Grimbergen", IsFranchiseStore = true, Addition = "" },
new Store() { Id = 38, Name = "MyGameStore Ukkel", Street = "Verrewinkelstraat", Number = "170", Zipcode = "1180", City = "Ukkel", IsFranchiseStore = false, Addition = "5" },
new Store() { Id = 39, Name = "MyGameStore Deinze", Street = "Winkelstraat", Number = "180", Zipcode = "9800", City = "Deinze", IsFranchiseStore = false, Addition = "A" },
new Store() { Id = 40, Name = "MyGameStore Brussel", Street = "Louizalaan", Number = "104", Zipcode = "1000", City = "Brussel", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 41, Name = "MyGameStore Waregem", Street = "Stationsstraat", Number = "172", Zipcode = "8790", City = "Waregem", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 42, Name = "MyGameStore Brugge", Street = "Steenstraat", Number = "176", Zipcode = "8000", City = "Brugge", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 43, Name = "MyGameStore Sint-Lambrechts-Woluwe", Street = "Konkelstraat", Number = "35", Zipcode = "1200", City = "Sint-Lambrechts-Woluwe", IsFranchiseStore = true, Addition = "" },
new Store() { Id = 44, Name = "MyGameStore Lommel", Street = "Kerkstraat", Number = "157", Zipcode = "3920", City = "Lommel", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 45, Name = "MyGameStore Evergem", Street = "Noorwegenstraat", Number = "41", Zipcode = "9940", City = "Evergem", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 46, Name = "MyGameStore Lier", Street = "Antwerpsestraat", Number = "169", Zipcode = "2500", City = "Lier", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 47, Name = "MyGameStore Sint-Truiden", Street = "Luikerstraat", Number = "76", Zipcode = "3800", City = "Sint-Truiden", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 48, Name = "MyGameStore Aarschot", Street = "Martelarenstraat", Number = "16", Zipcode = "3200", City = "Aarschot", IsFranchiseStore = false, Addition = "C" },
new Store() { Id = 49, Name = "MyGameStore Oostende", Street = "Kapellestraat", Number = "149", Zipcode = "8400", City = "Oostende", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 50, Name = "MyGameStore Lokeren", Street = "Kerkstraat", Number = "2", Zipcode = "9160", City = "Lokeren", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 51, Name = "MyGameStore Tienen", Street = "Leuvensestraat", Number = "183", Zipcode = "3300", City = "Tienen", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 52, Name = "MyGameStore Vorst", Street = "Neerstalse Steenweg", Number = "132", Zipcode = "1190", City = "Vorst", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 53, Name = "MyGameStore Dilbeek", Street = "Verheydenstraat", Number = "39", Zipcode = "1700", City = "Dilbeek", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 54, Name = "MyGameStore Bilzen", Street = "Hees", Number = "97", Zipcode = "3740", City = "Bilzen", IsFranchiseStore = false, Addition = "E" },
new Store() { Id = 55, Name = "MyGameStore Tongeren", Street = "Maastrichterstraat", Number = "44", Zipcode = "3700", City = "Tongeren", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 56, Name = "MyGameStore Sint-Pieters-Leeuw", Street = "Rink", Number = "97", Zipcode = "1600", City = "Sint-Pieters-Leeuw", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 57, Name = "MyGameStore Beveren", Street = "Vrasenestraat", Number = "62", Zipcode = "8791", City = "Beveren", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 58, Name = "MyGameStore Bree", Street = "Gerdingerstraat", Number = "68", Zipcode = "3960", City = "Bree", IsFranchiseStore = false, Addition = "1" },
new Store() { Id = 59, Name = "MyGameStore Menen", Street = "Rijselstraat", Number = "142", Zipcode = "8930", City = "Menen", IsFranchiseStore = false, Addition = "" },
new Store() { Id = 60, Name = "MyGameStore Heist-op-den-Berg", Street = "Bergstraat", Number = "39", Zipcode = "1910", City = "Berg", IsFranchiseStore = false, Addition = "" }



            );
        }
    }
}
