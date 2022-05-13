﻿using CookBook.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Application.Queries.PostQueries
{
    public class GetAllPostsByCategory : IRequest<List<Post>>
    {
        public int Category { get; set; }
    }
}
