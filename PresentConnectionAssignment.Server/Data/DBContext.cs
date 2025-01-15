using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PresentConnectionAssignment.Server.Data.Models;

namespace PresentConnectionAssignment.Server.Data
{
    public class DBContext : DbContext
    {

         public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<TestQuestion> Test { get; set; }
        public DbSet<Testee> Testees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestQuestion>().HasData(

                 new TestQuestion
                 {
                     QuestionId = Guid.NewGuid(),
                     Question = "Which of these are primary colors?",
                     QuestionType = "CheckBox",
                     PossibleQuestionAnswers = new List<string> { "Red", "Green", "Blue", "Orange" },
                     QuestionAnswer = new List<string> { "Red", "Green" }

                 },

                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "Who was the first person to walk on the Moon?",
                        QuestionType = "RadioBtn",
                        PossibleQuestionAnswers = new List<string> { "Buzz Aldrin", "Neil Armstrong", "Michael Collins", "Yuri Gagarin" },
                        QuestionAnswer = new List<string> { "Neil Armstrong" }

                    },

                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "What is the capital of Japan?",
                        QuestionType = "TextBox",
                        PossibleQuestionAnswers = new List<string> { "Tokyo" },
                        QuestionAnswer = new List<string> { "Tokyo" }

                    },

                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "What is the chemical symbol for water?",
                        QuestionType = "RadioBtn",
                        PossibleQuestionAnswers = new List<string> { "H2O", "O2", "CO2", "02H" },
                        QuestionAnswer = new List<string> { "H2O" }

                    },


                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "Which of these animals are mammals?",
                        QuestionType = "CheckBox",
                        PossibleQuestionAnswers = new List<string> { "Dolphin", "Crocodile", "Shark", "Bat" },
                        QuestionAnswer = new List<string> { "Dolphin", "Bat" }

                    },


                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "Which of these elements are gases at room temperature?",
                        QuestionType = "CheckBox",
                        PossibleQuestionAnswers = new List<string> { "Iron", "Oxygen", "Gold", "Nitrogen" },
                        QuestionAnswer = new List<string> { "Oxygne", "Nitrogen" }

                    },

                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "In which year did World War II end?",
                        QuestionType = "TextBox",
                        PossibleQuestionAnswers = new List<string> { "1945" },
                        QuestionAnswer = new List<string> { "1945" }

                    },

                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "Which of these countries are part of the European Union?",
                        QuestionType = "CheckBox",
                        PossibleQuestionAnswers = new List<string> { "Norway", "France", "Germany", "Switzerland" },
                        QuestionAnswer = new List<string> { "France", "Switzerland" }

                    },

                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "Which of these are planets in our solar system?",
                        QuestionType = "CheckBox",
                        PossibleQuestionAnswers = new List<string> { "Mars", "Pluto", "Earth", "Sun" },
                        QuestionAnswer = new List<string> { "Mars", "Earth" }

                    },

                    new TestQuestion
                    {
                        QuestionId = Guid.NewGuid(),
                        Question = "Who wrote The Hobbit?",
                        QuestionType = "RadioBtn",
                        PossibleQuestionAnswers = new List<string> { "J.K. Rowling", "J.R.R. Tolkien", "C.S. Lewis", "George R.R. Martin" },
                        QuestionAnswer = new List<string> { "J.R.R. Tolkien" }

                    }




                );

            modelBuilder.Entity<Testee>().HasData(


                  new Testee
                  {
                      Email = "DummyTestee1@gmail.com",
                      Score = 990,

                      Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)


                  },
                    new Testee
                    {
                        Email = "DummyTestee2@gmail.com",
                        Score = 890,
                        Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    },
                     new Testee
                     {
                         Email = "DummyTestee3@gmail.com",
                         Score = 790,
                         Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                     },
                    new Testee
                    {
                        Email = "DummyTestee4@gmail.com",
                        Score = 690,
                        Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    },
                     new Testee
                     {
                         Email = "DummyTestee5@gmail.com",
                         Score = 590,
                         Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                     },
                    new Testee
                    {
                        Email = "DummyTestee6@gmail.com",
                        Score = 490,
                        Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    },
                     new Testee
                     {
                         Email = "DummyTestee7@gmail.com",
                         Score = 390,
                         Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                     },
                    new Testee
                    {
                        Email = "DummyTestee8@gmail.com",
                        Score = 290,
                        Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    },
                     new Testee
                     {
                         Email = "DummyTestee9@gmail.com",
                         Score = 190,
                         Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                     },
                    new Testee
                    {
                        Email = "DummyTestee10@gmail.com",
                        Score = 90,
                        Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)

                    }, new Testee
                    {
                        Email = "DummyTestee15@gmail.com",
                        Score = 80,
                        Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)

                    }


                );
        }

       
        
    }
}
