﻿using Library.Models.Model;
using Library.UI.Model;
using System;
using System.Collections.Generic;

namespace Library.UI.ViewModel.Library
{
    public class BookViewModel : BaseViewModel
    {
        private Guid _bookId;
        public Guid BookId 
        {
            get => _bookId;
            set
            {
                _bookId = value;
                OnPropertyChanged();
            }
        }

        private int _bookCounter;
        public int BookCounter
        {
            get => _bookCounter;
            set 
            { 
                _bookCounter = value;
                OnPropertyChanged();
            }
        }


        private string _title;
        public string Title 
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private AuthorViewModel _author;
        public AuthorViewModel Author 
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        private string _category;
        public string Category 
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        private int _downloads;
        public int Downloads
        {
            get => _downloads;
            set 
            { 
                _downloads = value;
                OnPropertyChanged();
            }
        }


        private ICollection<BookLanguageModel> _bookLanguages;
        public ICollection<BookLanguageModel> BookLanguages 
        {
            get => _bookLanguages;
            set
            {
                _bookLanguages = value;
                OnPropertyChanged();
            }
        }
    }
}
