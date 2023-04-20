package Interpreter.Interpreter;// Generated from java-escape by ANTLR 4.11.1
import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link EdWardParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface EdWardVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link EdWardParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(EdWardParser.ProgramContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#line}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLine(EdWardParser.LineContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStatement(EdWardParser.StatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#ifStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIfStatement(EdWardParser.IfStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#whileStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitWhileStatement(EdWardParser.WhileStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#forStatement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitForStatement(EdWardParser.ForStatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#parameters}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameters(EdWardParser.ParametersContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#assignment}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAssignment(EdWardParser.AssignmentContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#functionCall}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionCall(EdWardParser.FunctionCallContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#objectFunctionCall}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitObjectFunctionCall(EdWardParser.ObjectFunctionCallContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#objectFunctionCallFromFunction}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitObjectFunctionCallFromFunction(EdWardParser.ObjectFunctionCallFromFunctionContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#objectCreationCall}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitObjectCreationCall(EdWardParser.ObjectCreationCallContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#inplaceQuestion}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitInplaceQuestion(EdWardParser.InplaceQuestionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code parenthesizedExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParenthesizedExpression(EdWardParser.ParenthesizedExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code constantExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstantExpression(EdWardParser.ConstantExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code objectFunctionCallExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitObjectFunctionCallExpression(EdWardParser.ObjectFunctionCallExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code additiveExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAdditiveExpression(EdWardParser.AdditiveExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code identifierExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitIdentifierExpression(EdWardParser.IdentifierExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code notExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNotExpression(EdWardParser.NotExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code comparisonExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitComparisonExpression(EdWardParser.ComparisonExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code multiplicativeExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultiplicativeExpression(EdWardParser.MultiplicativeExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code objectCreationCallExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitObjectCreationCallExpression(EdWardParser.ObjectCreationCallExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code booleanExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBooleanExpression(EdWardParser.BooleanExpressionContext ctx);
	/**
	 * Visit a parse tree produced by the {@code functionExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionExpression(EdWardParser.FunctionExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#multOp}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitMultOp(EdWardParser.MultOpContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#addOp}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitAddOp(EdWardParser.AddOpContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#compareOp}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitCompareOp(EdWardParser.CompareOpContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#boolOp}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBoolOp(EdWardParser.BoolOpContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#constant}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitConstant(EdWardParser.ConstantContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#block}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBlock(EdWardParser.BlockContext ctx);
	/**
	 * Visit a parse tree produced by {@link EdWardParser#scope}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitScope(EdWardParser.ScopeContext ctx);
}