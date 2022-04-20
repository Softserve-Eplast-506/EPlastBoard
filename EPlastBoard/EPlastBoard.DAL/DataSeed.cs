using EPlastBoard.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.DAL
{
    public class DataSeed
    {
        public static void Initialize(EPlastBoardDBContext context)
        {
            if (context.Boards.Any() || context.Columns.Any() || context.Cards.Any())
                return;
            Board[] boards = new Board[]
            {
                new Board { Title = "TestBoard" },
                new Board { Title = "TestBoard 2" }
            };

            foreach (Board board in boards)
                context.Boards.Add(board);
            context.SaveChanges();

            Column[] columns = new Column[]
            {
                new Column { Title = "Done", BoardId = 1 },
                new Column { Title = "To Do", BoardId = 1 },
                new Column { Title = "To Do", BoardId = 2 }
            };
            foreach (Column column in columns)
                context.Columns.Add(column);
            context.SaveChanges();

            Card[] cards = new Card[]
            {
              new Card { Title = "make some money", Description = "shut up and do smth", ColumnId = 1 },
                new Card { Title = "make some money", Description = "shut up and do smth", ColumnId = 1 },
                new Card { Title = "make some money", Description = "shut up and do smth", ColumnId = 2 },
                new Card { Title = "make some money", Description = "shut up and do smth", ColumnId = 3 }
        };
            foreach (Card card in cards)
                context.Cards.Add(card);
            context.SaveChanges();
        }
    }
}
