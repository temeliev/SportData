using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SportData.Web.Helpers
{
    public static class Utility
    {
        public static Expression<Func<TSource, TDestination>> Add<TSource, TDestination>(this Expression<Func<TSource, TDestination>> first, params Expression<Func<TSource, TDestination>>[] selectors)
        {
            var zeroth = ((MemberInitExpression)first.Body);
            var param = first.Parameters[0];
            List<MemberBinding> bindings = new List<MemberBinding>(zeroth.Bindings.OfType<MemberAssignment>());
            for (int i = 0; i < selectors.Length; i++)
            {
                var memberInit = (MemberInitExpression)selectors[i].Body;
                var replace = new ParameterRebinder(selectors[i].Parameters[0], param);
                foreach (var binding in memberInit.Bindings.OfType<MemberAssignment>())
                {
                    bindings.Add(Expression.Bind(binding.Member, replace.VisitAndConvert(binding.Expression, "Combine")));
                }
            }

            return Expression.Lambda<Func<TSource, TDestination>>(Expression.MemberInit(zeroth.NewExpression, bindings), param);
        }

        public static Expression<Func<TSource, TDestination>> Ignore<TSource, TDestination>(this Expression<Func<TSource, TDestination>> first, params Expression<Func<TSource, TDestination>>[] selectors)
        {
            var zeroth = ((MemberInitExpression)first.Body);
            var param = first.Parameters[0];
            List<MemberBinding> bindings = new List<MemberBinding>(zeroth.Bindings.OfType<MemberAssignment>());
            for (int i = 0; i < selectors.Length; i++)
            {
                var memberInit = (MemberInitExpression)selectors[i].Body;
                var replace = new ParameterRebinder(selectors[i].Parameters[0], param);
                foreach (var binding in memberInit.Bindings.OfType<MemberAssignment>())
                {
                    var item = bindings.Where(x => x.BindingType == binding.BindingType && x.Member == binding.Member).FirstOrDefault();
                    bindings.Remove(item);
                }
            }

            return Expression.Lambda<Func<TSource, TDestination>>(Expression.MemberInit(zeroth.NewExpression, bindings), param);
        }

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var rewrittenBody = new ParameterRebinder(first.Parameters[0], second.Parameters[0]).Visit(first.Body);
            var newFilter = Expression.Lambda<T>(merge(rewrittenBody, second.Body), second.Parameters);
            return newFilter;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }

    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly ParameterExpression _from;
        private readonly ParameterExpression _to;

        public ParameterRebinder(ParameterExpression from, ParameterExpression to)
        {
            this._from = from;
            this._to = to;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _from ? _to : base.VisitParameter(node);
        }
    }
}