using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Common
{
    public class GlobalConstants
    {
        public const string AdminRole = "Admin";
        public const string AdminAreaName = "Admin";

        public const int BooksPerPage = 10;
        public const string TitleSearchCategory = "Title";
        public const string AuthorSearchCategory = "Author";
        public const string GenreSearchCategory = "Genre";
        public const string SearchResultsPartial = "_SearchResults";

        public const int HomeViewNumberOfBooksWithHighestRating = 8;
        public const int HomeViewCacheDuration = 60 * 15;

        public const int BookRatingDefaultValue = 0;
        public const string JavascriptRefresh = "location.reload(true)";
        public const string JavascriptRedirect = "window.location.href=/mybooks/";

        public const string CacheVaryByCustom = "User";
    }
}
