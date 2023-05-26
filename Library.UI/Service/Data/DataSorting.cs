﻿using Library.Models.Model;
using Library.UI.Model;
using Library.UI.Services;
using Library.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Service.Data
{
    public class DataSorting : IDataSorting
    {
        private readonly IBaseRepository<BookModel> _bookBaseRepository;

        private readonly IBaseRepository<AuthorModel> _authBaseRepository;

        private readonly IBaseRepository<LanguageModel> _lngBaseRepository;

        private readonly IBaseRepository<BookLanguageModel> _bookLanguageBaseRepository;

        public DataSorting(IBaseRepository<BookModel> bookBaseRepository, IBaseRepository<AuthorModel> authBaseRepository,
            IBaseRepository<LanguageModel> lngBaseRepository, IBaseRepository<BookLanguageModel> bookLanguageBaseRepository)
        {
            _bookBaseRepository = bookBaseRepository;
            _authBaseRepository = authBaseRepository;
            _lngBaseRepository = lngBaseRepository;
            _bookLanguageBaseRepository = bookLanguageBaseRepository;
        }

        public List<BookModel> SortBooks(LibraryViewModel.SortingMethod selectedMethod,
            LibraryViewModel.BookQuantity selectedQuantity, LibraryViewModel.Genre selectedCategory)
        {
            List<BookModel> bookList = new List<BookModel>();
            List<AuthorModel> authorList = new List<AuthorModel>();
            List<LanguageModel> languageList = new List<LanguageModel>();
            List<BookLanguageModel> bookLanguageList = new List<BookLanguageModel>();

            bookList = _bookBaseRepository.GetAll().ToList();
            authorList = _authBaseRepository.GetAll().ToList();
            languageList = _lngBaseRepository.GetAll().ToList();
            bookLanguageList = _bookLanguageBaseRepository.GetAll().ToList();

            if (selectedCategory == LibraryViewModel.Genre.NOT_SET)
            {
                // If no category is selected, takes the default bookList which is defined above.
            }
            else
            {
                // If a category is selected, only take books with that category.
                bookList = _bookBaseRepository.GetAll().Where(c => c.Category == string.Join(" ", selectedCategory.ToString().Split('_'))).ToList();
            }

            if (selectedQuantity == LibraryViewModel.BookQuantity.NOT_SET)
            {
                selectedQuantity = (LibraryViewModel.BookQuantity)999;
            }

            // app startup setup
            if (selectedMethod == LibraryViewModel.SortingMethod.NOT_SET && selectedQuantity == LibraryViewModel.BookQuantity.NOT_SET)
            {
                bookList = bookList.Take(bookList.Count).ToList();
            }

            // combobox
            else if (selectedMethod == LibraryViewModel.SortingMethod.NOT_SET)
            {
                bookList = bookList.Take((int)selectedQuantity).ToList();
            }
            else if (selectedMethod == LibraryViewModel.SortingMethod.Az)
            {
                bookList = bookList.OrderBy(b => b.Title).Take((int)selectedQuantity).ToList();
            }
            else if (selectedMethod == LibraryViewModel.SortingMethod.Downloads)
            {
                bookList = bookList.OrderByDescending(d => d.Downloads).Take((int)selectedQuantity).ToList();
            }

            return bookList;
        }
    }
}
