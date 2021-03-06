using System.Collections.Generic;
using System.Data.Linq.DbEngines.SqlServer;
using System.Data.Linq.Provider.NodeTypes;
using System.Data.Linq.Provider.Visitors;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Linq.Provider.Common
{
	internal class ColumnNominator : SqlVisitor {
		bool isBlocked;
		HashSet<SqlExpression> candidates;

		internal HashSet<SqlExpression> Nominate(SqlExpression expression) {
			this.candidates = new HashSet<SqlExpression>();
			this.isBlocked = false;
			this.Visit(expression);
			return this.candidates;
		}

		internal override SqlNode Visit(SqlNode node) {
			SqlExpression expression = node as SqlExpression;
			if (expression != null) {
				bool saveIsBlocked = this.isBlocked;
				this.isBlocked = false;
				if (CanRecurseColumnize(expression)) {
					base.Visit(expression);
				}
				if (!this.isBlocked) {
					if (CanBeColumn(expression)) {
						this.candidates.Add(expression);
					}
					else {
						this.isBlocked = true;
					}
				}
				this.isBlocked |= saveIsBlocked;
			}
			return node;
		}

		internal override SqlExpression VisitSimpleCase(SqlSimpleCase c) {
			c.Expression = this.VisitExpression(c.Expression);
			for (int i = 0, n = c.Whens.Count; i < n; i++) {
				// Don't walk down the match side. This can't be a column.
				c.Whens[i].Value = this.VisitExpression(c.Whens[i].Value);
			}
			return c;
		}

		internal override SqlExpression VisitTypeCase(SqlTypeCase tc) {
			tc.Discriminator = this.VisitExpression(tc.Discriminator);
			for (int i = 0, n = tc.Whens.Count; i < n; i++) {
				// Don't walk down the match side. This can't be a column.
				tc.Whens[i].TypeBinding = this.VisitExpression(tc.Whens[i].TypeBinding);
			}
			return tc;
		}

		internal override SqlExpression VisitClientCase(SqlClientCase c) {
			c.Expression = this.VisitExpression(c.Expression);
			for (int i = 0, n = c.Whens.Count; i < n; i++) {
				// Don't walk down the match side. This can't be a column.
				c.Whens[i].Value = this.VisitExpression(c.Whens[i].Value);
			}
			return c;
		}

		private static bool CanRecurseColumnize(SqlExpression expr) {
			switch (expr.NodeType) {
				case SqlNodeType.AliasRef:
				case SqlNodeType.ColumnRef:
				case SqlNodeType.Column:
				case SqlNodeType.Multiset:
				case SqlNodeType.Element:
				case SqlNodeType.ScalarSubSelect:
				case SqlNodeType.Exists:
				case SqlNodeType.ClientQuery:
				case SqlNodeType.SharedExpressionRef:
				case SqlNodeType.Link:
				case SqlNodeType.Nop:
				case SqlNodeType.Value:
				case SqlNodeType.Select:
					return false;
				default:
					return true;
			}
		}

		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "These issues are related to our use of if-then and case statements for node types, which adds to the complexity count however when reviewed they are easy to navigate and understand.")]
		private static bool IsClientOnly(SqlExpression expr) {
			switch (expr.NodeType) {
				case SqlNodeType.ClientCase:
				case SqlNodeType.TypeCase:
				case SqlNodeType.ClientArray:
				case SqlNodeType.Grouping:
				case SqlNodeType.DiscriminatedType:
				case SqlNodeType.SharedExpression:
				case SqlNodeType.SimpleExpression:
				case SqlNodeType.AliasRef:
				case SqlNodeType.Multiset:
				case SqlNodeType.Element:
				case SqlNodeType.ClientQuery:
				case SqlNodeType.SharedExpressionRef:
				case SqlNodeType.Link:
				case SqlNodeType.Nop:
					return true;
				case SqlNodeType.OuterJoinedValue:
					return IsClientOnly(((SqlUnary)expr).Operand);
				default:
					return false;
			}
		}

		internal static bool CanBeColumn(SqlExpression expression) {
			if (!IsClientOnly(expression)
				&& expression.NodeType != SqlNodeType.Column                            
				&& expression.SqlType.CanBeColumn) {

					switch (expression.NodeType) {
						case SqlNodeType.MethodCall:
						case SqlNodeType.Member:
						case SqlNodeType.New:
							return PostBindDotNetConverter.CanConvert(expression);
						default:
							return true;
					}
				}
			return false;
		}
	}
}