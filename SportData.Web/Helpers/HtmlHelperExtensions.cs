using System;
using System.Linq.Expressions;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportData.Web.Helpers
{
    public static class HtmlHelperExtensions
    {

        public static MvcHtmlString Image(this HtmlHelper helper,
                                    string url,
                                    string altText,
                                    object htmlAttributes)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", url);
            builder.Attributes.Add("alt", altText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        //public static string Action<TController>(this UrlHelper helper, Expression<Action<TController>> action) where TController : Controller
        //{
        //    RouteValueDictionary routeValuesFromExpression = ExpressionHelperInternal.GetRouteValuesFromExpression<TController>(action);

        //    return helper.Action(routeValuesFromExpression["action"].ToString(), routeValuesFromExpression);
        //}

        /// <summary>
        /// Converts the .net supported date format current culture 
        /// format into JQuery Datepicker format.
        /// </summary>
        /// <param name="html">HtmlHelper object.</param>
        /// <returns>Format string that supported in JQuery Datepicker.</returns>
        public static string ConvertDateFormat(this HtmlHelper html)
        {
            return ConvertDateFormat(html,
        Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern);
        }

        /// <summary>
        /// Converts the .net supported date format current culture 
        /// format into JQuery Datepicker format.
        /// </summary>
        /// <param name="html">HtmlHelper object.</param>
        /// <param name="format">Date format supported by .NET.</param>
        /// <returns>Format string that supported in JQuery Datepicker.</returns>
        public static string ConvertDateFormat(this HtmlHelper html, string format)
        {
            /*
             *  Date used in this comment : 5th - Nov - 2009 (Thursday)
             *
             *  .NET    JQueryUI        Output      Comment
             *  --------------------------------------------------------------
             *  d       d               5           day of month(No leading zero)
             *  dd      dd              05          day of month(two digit)
             *  ddd     D               Thu         day short name
             *  dddd    DD              Thursday    day long name
             *  M       m               11          month of year(No leading zero)
             *  MM      mm              11          month of year(two digit)
             *  MMM     M               Nov         month name short
             *  MMMM    MM              November    month name long.
             *  yy      y               09          Year(two digit)
             *  yyyy    yy              2009        Year(four digit)             *
             */

            string currentFormat = format;

            // Convert the date
            currentFormat = currentFormat.Replace("dddd", "DD");
            currentFormat = currentFormat.Replace("ddd", "D");

            // Convert month
            if (currentFormat.Contains("MMMM"))
            {
                currentFormat = currentFormat.Replace("MMMM", "MM");
            }
            else if (currentFormat.Contains("MMM"))
            {
                currentFormat = currentFormat.Replace("MMM", "M");
            }
            else if (currentFormat.Contains("MM"))
            {
                currentFormat = currentFormat.Replace("MM", "mm");
            }
            else
            {
                currentFormat = currentFormat.Replace("M", "m");
            }

            // Convert year
            currentFormat = currentFormat.Contains("yyyy") ?
        currentFormat.Replace("yyyy", "yy") : currentFormat.Replace("yy", "y");

            return currentFormat;
        }
    }
}