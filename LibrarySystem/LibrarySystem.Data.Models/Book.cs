﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Data.Models.Abstractions;

namespace LibrarySystem.Data.Models
{
    public class Book : DataModel
    {

        private ICollection<Author> authors;

        private ICollection<Genre> genres;

        private ICollection<Rating> ratings;

        private ICollection<User> wantedBy;

        public Book()
        {
            this.authors = new HashSet<Author>();
            this.genres = new HashSet<Genre>();
            this.ratings = new HashSet<Rating>();
            this.wantedBy = new HashSet<User>();
        }

        [Required]
        [StringLength(128, ErrorMessage = "Book Title Invalid Length", MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Book ISBN Invalid Length")]
        public string ISBN { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2048, ErrorMessage = "Book Description Invalid Length", MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        [Range(1, 32768, ErrorMessage = "Book PageCount cannot be {0}. It must be between {1} and {2}.")]
        public int PageCount { get; set; }

        [Required]
        [Range(1, 4096, ErrorMessage = "Book YearOfPublishing cannot be {0}. It must be between {1} and {2}.")]
        public int YearOfPublishing { get; set; }

        public virtual ICollection<Author> Authors
        {
            get
            {
                return this.authors;
            }

            set
            {
                this.authors = value;
            }
        }

        public virtual ICollection<Genre> Genres
        {
            get
            {
                return this.genres;
            }

            set
            {
                this.genres = value;
            }
        }

        public virtual ICollection<Rating> Ratings
        {
            get
            {
                return this.ratings;
            }

            set
            {
                this.ratings = value;
            }
        }

        public virtual ICollection<User> WantedBy
        {
            get
            {
                return this.wantedBy;
            }

            set
            {
                this.wantedBy = value;
            }
        }
    }
}
