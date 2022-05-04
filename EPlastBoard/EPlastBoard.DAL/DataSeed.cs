﻿using EPlastBoard.DAL.Entities;
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
                new Column { Title = "To do", BoardId = context.Boards.FirstOrDefault().Id, Index = 0 },
                new Column { Title = "In progress", BoardId = context.Boards.FirstOrDefault().Id, Index = 2 },
                new Column { Title = "Done", BoardId = context.Boards.FirstOrDefault().Id, Index = 1 },

            };
            foreach (Column column in columns)
                context.Columns.Add(column);
            context.SaveChanges();

            Card[] cards = new Card[]
            {
              new Card { Title = "Card example title index 1", Description = "Need to do something", ColumnId = context.Columns.FirstOrDefault().Id, Index = 1 },
              new Card { Title = "Card example title index 0", Description = "Need to do something", ColumnId = context.Columns.FirstOrDefault().Id, Index = 0 },
              new Card { Title = "Card example title index 2", Description = "Need to do something", ColumnId = context.Columns.FirstOrDefault().Id, Index = 2 },
              new Card { Title = "Card example title index 3", Description = "Need to do something", ColumnId = context.Columns.FirstOrDefault().Id, Index = 3 },
              new Card { Title = "Card example title index 4", Description = "Need to do something", ColumnId = context.Columns.FirstOrDefault().Id, Index = 4 },
              new Card { Title = "Card example title index 0 col 1", Description = "Need to do something", ColumnId = context.Columns.FirstOrDefault().Id+1, Index = 0 },

        };
            foreach (Card card in cards)
                context.Cards.Add(card);
            context.SaveChanges();
        }
    }
}
