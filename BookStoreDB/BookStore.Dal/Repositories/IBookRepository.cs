﻿using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Dal.ViewModel
{
    public interface IBookRepository 
    {
        Task<BookViewModel> GetTopTen(CancellationToken cancellationToken = default);
        //Task<List<BookDto>> GetTopTen(CancellationToken cancellationToken = default);
        Task<BookViewModel> GetById(int id, CancellationToken cancellationToken = default);
        Task<BookViewModel> Add(BookDto book, CancellationToken cancellationToken = default);
        Task Update(BookDto book, CancellationToken cancellationToken = default);
        Task<bool> Remove(int id, CancellationToken cancellationToken = default);
        Task<BookViewModel> SearchByName(string name, CancellationToken cancellationToken = default);

    }
}
