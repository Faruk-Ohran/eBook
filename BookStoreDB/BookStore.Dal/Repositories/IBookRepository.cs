﻿using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Dal.ViewModel
{
    interface IBookRepository : IBaseRepository<Book>
    {
    }
}
