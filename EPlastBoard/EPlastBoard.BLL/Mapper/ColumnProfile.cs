using AutoMapper;
using EPlastBoard.BLL.DTO;
using EPlastBoard.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.BLL.Mapper
{
    class ColumnProfile : Profile
    {
        public ColumnProfile()
        {
            CreateMap<Column, ColumnDTO>();
            CreateMap<ColumnDTO, Column>();
        }
    }
}
