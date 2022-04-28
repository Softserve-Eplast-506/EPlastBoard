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
                new Board { Title = "Example Board" },
            };

            foreach (Board board in boards)
                context.Boards.Add(board);
            context.SaveChanges();

            Column[] columns = new Column[]
            {
                new Column { Title = "To do", BoardId = context.Boards.FirstOrDefault().Id },
                new Column { Title = "In progress", BoardId = context.Boards.FirstOrDefault().Id },
                new Column { Title = "Done", BoardId = context.Boards.FirstOrDefault().Id },

            };
            foreach (Column column in columns)
                context.Columns.Add(column);
            context.SaveChanges();

            Card[] cards = new Card[]
            {
              new Card { Title = "Card example title", Description = "Need to do something", ColumnId = context.Columns.FirstOrDefault().Id },
                new Card { Title = "Card example title", Description = "Need to do something", ColumnId = context.Columns.FirstOrDefault().Id },
              
        };
            foreach (Card card in cards)
                context.Cards.Add(card);
            context.SaveChanges();
        }
    }
}
