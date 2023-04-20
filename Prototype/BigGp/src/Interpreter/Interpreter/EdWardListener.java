package Interpreter.Interpreter;// Generated from java-escape by ANTLR 4.11.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link EdWardParser}.
 */
public interface EdWardListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link EdWardParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(EdWardParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(EdWardParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#line}.
	 * @param ctx the parse tree
	 */
	void enterLine(EdWardParser.LineContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#line}.
	 * @param ctx the parse tree
	 */
	void exitLine(EdWardParser.LineContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(EdWardParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(EdWardParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void enterIfStatement(EdWardParser.IfStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void exitIfStatement(EdWardParser.IfStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void enterWhileStatement(EdWardParser.WhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void exitWhileStatement(EdWardParser.WhileStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void enterForStatement(EdWardParser.ForStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void exitForStatement(EdWardParser.ForStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#parameters}.
	 * @param ctx the parse tree
	 */
	void enterParameters(EdWardParser.ParametersContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#parameters}.
	 * @param ctx the parse tree
	 */
	void exitParameters(EdWardParser.ParametersContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(EdWardParser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(EdWardParser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void enterFunctionCall(EdWardParser.FunctionCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void exitFunctionCall(EdWardParser.FunctionCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#objectFunctionCall}.
	 * @param ctx the parse tree
	 */
	void enterObjectFunctionCall(EdWardParser.ObjectFunctionCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#objectFunctionCall}.
	 * @param ctx the parse tree
	 */
	void exitObjectFunctionCall(EdWardParser.ObjectFunctionCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#objectFunctionCallFromFunction}.
	 * @param ctx the parse tree
	 */
	void enterObjectFunctionCallFromFunction(EdWardParser.ObjectFunctionCallFromFunctionContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#objectFunctionCallFromFunction}.
	 * @param ctx the parse tree
	 */
	void exitObjectFunctionCallFromFunction(EdWardParser.ObjectFunctionCallFromFunctionContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#objectCreationCall}.
	 * @param ctx the parse tree
	 */
	void enterObjectCreationCall(EdWardParser.ObjectCreationCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#objectCreationCall}.
	 * @param ctx the parse tree
	 */
	void exitObjectCreationCall(EdWardParser.ObjectCreationCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#inplaceQuestion}.
	 * @param ctx the parse tree
	 */
	void enterInplaceQuestion(EdWardParser.InplaceQuestionContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#inplaceQuestion}.
	 * @param ctx the parse tree
	 */
	void exitInplaceQuestion(EdWardParser.InplaceQuestionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code parenthesizedExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterParenthesizedExpression(EdWardParser.ParenthesizedExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code parenthesizedExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitParenthesizedExpression(EdWardParser.ParenthesizedExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code constantExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterConstantExpression(EdWardParser.ConstantExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code constantExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitConstantExpression(EdWardParser.ConstantExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code objectFunctionCallExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterObjectFunctionCallExpression(EdWardParser.ObjectFunctionCallExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code objectFunctionCallExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitObjectFunctionCallExpression(EdWardParser.ObjectFunctionCallExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code additiveExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterAdditiveExpression(EdWardParser.AdditiveExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code additiveExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitAdditiveExpression(EdWardParser.AdditiveExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code identifierExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterIdentifierExpression(EdWardParser.IdentifierExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code identifierExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitIdentifierExpression(EdWardParser.IdentifierExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code notExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterNotExpression(EdWardParser.NotExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code notExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitNotExpression(EdWardParser.NotExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code comparisonExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterComparisonExpression(EdWardParser.ComparisonExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code comparisonExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitComparisonExpression(EdWardParser.ComparisonExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code multiplicativeExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicativeExpression(EdWardParser.MultiplicativeExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code multiplicativeExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicativeExpression(EdWardParser.MultiplicativeExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code objectCreationCallExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterObjectCreationCallExpression(EdWardParser.ObjectCreationCallExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code objectCreationCallExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitObjectCreationCallExpression(EdWardParser.ObjectCreationCallExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code booleanExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterBooleanExpression(EdWardParser.BooleanExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code booleanExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitBooleanExpression(EdWardParser.BooleanExpressionContext ctx);
	/**
	 * Enter a parse tree produced by the {@code functionExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterFunctionExpression(EdWardParser.FunctionExpressionContext ctx);
	/**
	 * Exit a parse tree produced by the {@code functionExpression}
	 * labeled alternative in {@link EdWardParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitFunctionExpression(EdWardParser.FunctionExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#multOp}.
	 * @param ctx the parse tree
	 */
	void enterMultOp(EdWardParser.MultOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#multOp}.
	 * @param ctx the parse tree
	 */
	void exitMultOp(EdWardParser.MultOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#addOp}.
	 * @param ctx the parse tree
	 */
	void enterAddOp(EdWardParser.AddOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#addOp}.
	 * @param ctx the parse tree
	 */
	void exitAddOp(EdWardParser.AddOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#compareOp}.
	 * @param ctx the parse tree
	 */
	void enterCompareOp(EdWardParser.CompareOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#compareOp}.
	 * @param ctx the parse tree
	 */
	void exitCompareOp(EdWardParser.CompareOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#boolOp}.
	 * @param ctx the parse tree
	 */
	void enterBoolOp(EdWardParser.BoolOpContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#boolOp}.
	 * @param ctx the parse tree
	 */
	void exitBoolOp(EdWardParser.BoolOpContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#constant}.
	 * @param ctx the parse tree
	 */
	void enterConstant(EdWardParser.ConstantContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#constant}.
	 * @param ctx the parse tree
	 */
	void exitConstant(EdWardParser.ConstantContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(EdWardParser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(EdWardParser.BlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link EdWardParser#scope}.
	 * @param ctx the parse tree
	 */
	void enterScope(EdWardParser.ScopeContext ctx);
	/**
	 * Exit a parse tree produced by {@link EdWardParser#scope}.
	 * @param ctx the parse tree
	 */
	void exitScope(EdWardParser.ScopeContext ctx);
}