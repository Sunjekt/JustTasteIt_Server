using Server.Models;

namespace Server.Data
{
    public static class ModelsManagerSeed
    {
        public static async Task SeedAsync(ModelsManager context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (context.Category.Any())
                {
                    return;
                }
                var categories = new Category[]
                {
                    new Category{Name = "Завтрак"},
                    new Category{Name = "Обед"},
                    new Category{Name = "Ужин"},
                    new Category{Name = "Салаты"},
                    new Category{Name = "Закуски"},
                    new Category{Name = "Десерты"},
                };
                foreach (Category b in categories)
                {
                    context.Category.Add(b);
                }
                await context.SaveChangesAsync();

                var measurements = new Measurement[]
                {
                    new Measurement{Name = "стак."},
                    new Measurement{Name = "ст. л."},
                    new Measurement{Name = "ч. л."},
                    new Measurement{Name = "шт."},
                    new Measurement{Name = "зубч."},
                    new Measurement{Name = "г."},
                    new Measurement{Name = "мл."},
                    new Measurement{Name = "л."},
                    new Measurement{Name = "кг."},
                    new Measurement{Name = "лист."},
                    new Measurement{Name = "пуч."},
                    new Measurement{Name = "пер."},
                    new Measurement{Name = "головк."},
                    new Measurement{Name = "щепот."},
                    new Measurement{Name = "веточк."},
                    new Measurement{Name = "кочан."},
                    new Measurement{Name = "ломтик."},
                    new Measurement{Name = "палочк."},
                    new Measurement{Name = "дол."},
                    new Measurement{Name = "по вкусу"},
                    new Measurement{Name = "по желанию"},
                    new Measurement{Name = "банк. / 100 г"},
                    new Measurement{Name = "банк. / 150 г"},
                    new Measurement{Name = "банк. / 200 г"},
                    new Measurement{Name = "банк. / 250 г"},
                    new Measurement{Name = "банк. / 300 г"},
                    new Measurement{Name = "банк. / 350 г"},
                    new Measurement{Name = "банк. / 370 г"},
                    new Measurement{Name = "банк. / 380 г"},
                    new Measurement{Name = "банк. / 400 г"},
                    new Measurement{Name = "метр."},
                    new Measurement{Name = "кап."},
                };
                foreach (Measurement b in measurements)
                {
                    context.Measurement.Add(b);
                }
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
