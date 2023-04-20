package Interpreter.Interpreter;// Generated from java-escape by ANTLR 4.11.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class EdWardParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.11.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, BOOL_OPERATOR=26, INTEGER=27, STRING=28, BOOL=29, NULL=30, COMMENT=31, 
		WS=32, IDENTIFIER=33;
	public static final int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_ifStatement = 3, 
		RULE_whileStatement = 4, RULE_forStatement = 5, RULE_parameters = 6, RULE_assignment = 7, 
		RULE_functionCall = 8, RULE_objectFunctionCall = 9, RULE_objectFunctionCallFromFunction = 10, 
		RULE_objectCreationCall = 11, RULE_inplaceQuestion = 12, RULE_expression = 13, 
		RULE_multOp = 14, RULE_addOp = 15, RULE_compareOp = 16, RULE_boolOp = 17, 
		RULE_constant = 18, RULE_block = 19, RULE_scope = 20;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "line", "statement", "ifStatement", "whileStatement", "forStatement", 
			"parameters", "assignment", "functionCall", "objectFunctionCall", "objectFunctionCallFromFunction", 
			"objectCreationCall", "inplaceQuestion", "expression", "multOp", "addOp", 
			"compareOp", "boolOp", "constant", "block", "scope"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "';'", "'if'", "'('", "')'", "'while'", "'for'", "','", "'*'", 
			"'+'", "'-'", "'='", "'.'", "'new'", "'!'", "'/'", "'=='", "'!='", "'>'", 
			"'<'", "'>='", "'<='", "'{'", "'}'", "'['", "']'", null, null, null, 
			null, "'null'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, "BOOL_OPERATOR", "INTEGER", "STRING", "BOOL", "NULL", "COMMENT", 
			"WS", "IDENTIFIER"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "java-escape"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public EdWardParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ProgramContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(EdWardParser.EOF, 0); }
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public List<TerminalNode> COMMENT() { return getTokens(EdWardParser.COMMENT); }
		public TerminalNode COMMENT(int i) {
			return getToken(EdWardParser.COMMENT, i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener) ((EdWardListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitProgram(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor) return ((EdWardVisitor<? extends T>)visitor).visitProgram(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(46);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (((_la) & ~0x3f) == 0 && ((1L << _la) & 10754195556L) != 0) {
				{
				setState(44);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
				case 1:
					{
					setState(42);
					line();
					}
					break;
				case 2:
					{
					setState(43);
					match(COMMENT);
					}
					break;
				}
				}
				setState(48);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(49);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class LineContext extends ParserRuleContext {
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public IfStatementContext ifStatement() {
			return getRuleContext(IfStatementContext.class,0);
		}
		public WhileStatementContext whileStatement() {
			return getRuleContext(WhileStatementContext.class,0);
		}
		public ForStatementContext forStatement() {
			return getRuleContext(ForStatementContext.class,0);
		}
		public ScopeContext scope() {
			return getRuleContext(ScopeContext.class,0);
		}
		public TerminalNode COMMENT() { return getToken(EdWardParser.COMMENT, 0); }
		public LineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_line; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterLine(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitLine(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitLine(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LineContext line() throws RecognitionException {
		LineContext _localctx = new LineContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_line);
		try {
			setState(57);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IDENTIFIER:
				enterOuterAlt(_localctx, 1);
				{
				setState(51);
				statement();
				}
				break;
			case T__1:
				enterOuterAlt(_localctx, 2);
				{
				setState(52);
				ifStatement();
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 3);
				{
				setState(53);
				whileStatement();
				}
				break;
			case T__5:
				enterOuterAlt(_localctx, 4);
				{
				setState(54);
				forStatement();
				}
				break;
			case T__23:
				enterOuterAlt(_localctx, 5);
				{
				setState(55);
				scope();
				}
				break;
			case COMMENT:
				enterOuterAlt(_localctx, 6);
				{
				setState(56);
				match(COMMENT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StatementContext extends ParserRuleContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitStatement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(61);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				{
				setState(59);
				assignment();
				}
				break;
			case 2:
				{
				setState(60);
				functionCall();
				}
				break;
			}
			setState(63);
			match(T__0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class IfStatementContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public IfStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterIfStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitIfStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitIfStatement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final IfStatementContext ifStatement() throws RecognitionException {
		IfStatementContext _localctx = new IfStatementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_ifStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(65);
			match(T__1);
			setState(66);
			match(T__2);
			setState(67);
			expression(0);
			setState(68);
			match(T__3);
			setState(69);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class WhileStatementContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public WhileStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterWhileStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitWhileStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitWhileStatement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final WhileStatementContext whileStatement() throws RecognitionException {
		WhileStatementContext _localctx = new WhileStatementContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_whileStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(71);
			match(T__4);
			setState(72);
			match(T__2);
			setState(73);
			expression(0);
			setState(74);
			match(T__3);
			setState(75);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ForStatementContext extends ParserRuleContext {
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public BlockContext block() {
			return getRuleContext(BlockContext.class,0);
		}
		public TerminalNode IDENTIFIER() { return getToken(EdWardParser.IDENTIFIER, 0); }
		public TerminalNode INTEGER() { return getToken(EdWardParser.INTEGER, 0); }
		public ForStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_forStatement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterForStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitForStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitForStatement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ForStatementContext forStatement() throws RecognitionException {
		ForStatementContext _localctx = new ForStatementContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_forStatement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(77);
			match(T__5);
			setState(78);
			match(T__2);
			setState(79);
			assignment();
			setState(80);
			match(T__6);
			setState(81);
			expression(0);
			setState(82);
			match(T__6);
			setState(83);
			_la = _input.LA(1);
			if ( !(((_la) & ~0x3f) == 0 && ((1L << _la) & 1792L) != 0) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(84);
			_la = _input.LA(1);
			if ( !(_la==INTEGER || _la==IDENTIFIER) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			setState(85);
			match(T__3);
			setState(86);
			block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ParametersContext extends ParserRuleContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public ParametersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameters; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterParameters(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitParameters(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitParameters(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ParametersContext parameters() throws RecognitionException {
		ParametersContext _localctx = new ParametersContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_parameters);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(96);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (((_la) & ~0x3f) == 0 && ((1L << _la) & 10603225096L) != 0) {
				{
				setState(88);
				expression(0);
				setState(93);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==T__6) {
					{
					{
					setState(89);
					match(T__6);
					setState(90);
					expression(0);
					}
					}
					setState(95);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AssignmentContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(EdWardParser.IDENTIFIER, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterAssignment(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitAssignment(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitAssignment(this);
			else return visitor.visitChildren(this);
		}
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_assignment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(98);
			match(IDENTIFIER);
			setState(99);
			match(T__10);
			setState(100);
			expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class FunctionCallContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(EdWardParser.IDENTIFIER, 0); }
		public ParametersContext parameters() {
			return getRuleContext(ParametersContext.class,0);
		}
		public FunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCall; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterFunctionCall(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitFunctionCall(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitFunctionCall(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FunctionCallContext functionCall() throws RecognitionException {
		FunctionCallContext _localctx = new FunctionCallContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_functionCall);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
			match(IDENTIFIER);
			setState(103);
			match(T__2);
			setState(104);
			parameters();
			setState(105);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ObjectFunctionCallContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(EdWardParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(EdWardParser.IDENTIFIER, i);
		}
		public ParametersContext parameters() {
			return getRuleContext(ParametersContext.class,0);
		}
		public ObjectFunctionCallFromFunctionContext objectFunctionCallFromFunction() {
			return getRuleContext(ObjectFunctionCallFromFunctionContext.class,0);
		}
		public ObjectFunctionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_objectFunctionCall; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterObjectFunctionCall(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitObjectFunctionCall(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitObjectFunctionCall(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ObjectFunctionCallContext objectFunctionCall() throws RecognitionException {
		ObjectFunctionCallContext _localctx = new ObjectFunctionCallContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_objectFunctionCall);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(107);
			match(IDENTIFIER);
			setState(108);
			match(T__11);
			setState(109);
			match(IDENTIFIER);
			setState(110);
			match(T__2);
			setState(111);
			parameters();
			setState(112);
			match(T__3);
			setState(113);
			objectFunctionCallFromFunction();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ObjectFunctionCallFromFunctionContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(EdWardParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(EdWardParser.IDENTIFIER, i);
		}
		public List<ParametersContext> parameters() {
			return getRuleContexts(ParametersContext.class);
		}
		public ParametersContext parameters(int i) {
			return getRuleContext(ParametersContext.class,i);
		}
		public ObjectFunctionCallFromFunctionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_objectFunctionCallFromFunction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterObjectFunctionCallFromFunction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitObjectFunctionCallFromFunction(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitObjectFunctionCallFromFunction(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ObjectFunctionCallFromFunctionContext objectFunctionCallFromFunction() throws RecognitionException {
		ObjectFunctionCallFromFunctionContext _localctx = new ObjectFunctionCallFromFunctionContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_objectFunctionCallFromFunction);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(123);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,6,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(115);
					match(T__11);
					setState(116);
					match(IDENTIFIER);
					setState(117);
					match(T__2);
					setState(118);
					parameters();
					setState(119);
					match(T__3);
					}
					} 
				}
				setState(125);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,6,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ObjectCreationCallContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(EdWardParser.IDENTIFIER, 0); }
		public ParametersContext parameters() {
			return getRuleContext(ParametersContext.class,0);
		}
		public ObjectCreationCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_objectCreationCall; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterObjectCreationCall(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitObjectCreationCall(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitObjectCreationCall(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ObjectCreationCallContext objectCreationCall() throws RecognitionException {
		ObjectCreationCallContext _localctx = new ObjectCreationCallContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_objectCreationCall);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(126);
			match(T__12);
			setState(127);
			match(IDENTIFIER);
			setState(128);
			match(T__2);
			setState(129);
			parameters();
			setState(130);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class InplaceQuestionContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(EdWardParser.IDENTIFIER, 0); }
		public InplaceQuestionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_inplaceQuestion; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterInplaceQuestion(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitInplaceQuestion(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitInplaceQuestion(this);
			else return visitor.visitChildren(this);
		}
	}

	public final InplaceQuestionContext inplaceQuestion() throws RecognitionException {
		InplaceQuestionContext _localctx = new InplaceQuestionContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_inplaceQuestion);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(132);
			match(T__11);
			setState(133);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExpressionContext extends ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	 
		public ExpressionContext() { }
		public void copyFrom(ExpressionContext ctx) {
			super.copyFrom(ctx);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ParenthesizedExpressionContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public ParenthesizedExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterParenthesizedExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitParenthesizedExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitParenthesizedExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ConstantExpressionContext extends ExpressionContext {
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public ConstantExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterConstantExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitConstantExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitConstantExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ObjectFunctionCallExpressionContext extends ExpressionContext {
		public ObjectFunctionCallContext objectFunctionCall() {
			return getRuleContext(ObjectFunctionCallContext.class,0);
		}
		public InplaceQuestionContext inplaceQuestion() {
			return getRuleContext(InplaceQuestionContext.class,0);
		}
		public ObjectFunctionCallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterObjectFunctionCallExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitObjectFunctionCallExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitObjectFunctionCallExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class AdditiveExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public AddOpContext addOp() {
			return getRuleContext(AddOpContext.class,0);
		}
		public AdditiveExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterAdditiveExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitAdditiveExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitAdditiveExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class IdentifierExpressionContext extends ExpressionContext {
		public TerminalNode IDENTIFIER() { return getToken(EdWardParser.IDENTIFIER, 0); }
		public IdentifierExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterIdentifierExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitIdentifierExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitIdentifierExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class NotExpressionContext extends ExpressionContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public NotExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterNotExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitNotExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitNotExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ComparisonExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public CompareOpContext compareOp() {
			return getRuleContext(CompareOpContext.class,0);
		}
		public ComparisonExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterComparisonExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitComparisonExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitComparisonExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class MultiplicativeExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public MultOpContext multOp() {
			return getRuleContext(MultOpContext.class,0);
		}
		public MultiplicativeExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterMultiplicativeExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitMultiplicativeExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitMultiplicativeExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class ObjectCreationCallExpressionContext extends ExpressionContext {
		public ObjectCreationCallContext objectCreationCall() {
			return getRuleContext(ObjectCreationCallContext.class,0);
		}
		public ObjectCreationCallExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterObjectCreationCallExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitObjectCreationCallExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitObjectCreationCallExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class BooleanExpressionContext extends ExpressionContext {
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public BoolOpContext boolOp() {
			return getRuleContext(BoolOpContext.class,0);
		}
		public BooleanExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterBooleanExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitBooleanExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitBooleanExpression(this);
			else return visitor.visitChildren(this);
		}
	}
	@SuppressWarnings("CheckReturnValue")
	public static class FunctionExpressionContext extends ExpressionContext {
		public FunctionCallContext functionCall() {
			return getRuleContext(FunctionCallContext.class,0);
		}
		public InplaceQuestionContext inplaceQuestion() {
			return getRuleContext(InplaceQuestionContext.class,0);
		}
		public FunctionExpressionContext(ExpressionContext ctx) { copyFrom(ctx); }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterFunctionExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitFunctionExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitFunctionExpression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 26;
		enterRecursionRule(_localctx, 26, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(153);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				_localctx = new ConstantExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(136);
				constant();
				}
				break;
			case 2:
				{
				_localctx = new IdentifierExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(137);
				match(IDENTIFIER);
				}
				break;
			case 3:
				{
				_localctx = new FunctionExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(138);
				functionCall();
				setState(140);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
				case 1:
					{
					setState(139);
					inplaceQuestion();
					}
					break;
				}
				}
				break;
			case 4:
				{
				_localctx = new ParenthesizedExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(142);
				match(T__2);
				setState(143);
				expression(0);
				setState(144);
				match(T__3);
				}
				break;
			case 5:
				{
				_localctx = new NotExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(146);
				match(T__13);
				setState(147);
				expression(7);
				}
				break;
			case 6:
				{
				_localctx = new ObjectFunctionCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(148);
				objectFunctionCall();
				setState(150);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
				case 1:
					{
					setState(149);
					inplaceQuestion();
					}
					break;
				}
				}
				break;
			case 7:
				{
				_localctx = new ObjectCreationCallExpressionContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(152);
				objectCreationCall();
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(173);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(171);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
					case 1:
						{
						_localctx = new MultiplicativeExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(155);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(156);
						multOp();
						setState(157);
						expression(5);
						}
						break;
					case 2:
						{
						_localctx = new AdditiveExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(159);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(160);
						addOp();
						setState(161);
						expression(4);
						}
						break;
					case 3:
						{
						_localctx = new ComparisonExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(163);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(164);
						compareOp();
						setState(165);
						expression(3);
						}
						break;
					case 4:
						{
						_localctx = new BooleanExpressionContext(new ExpressionContext(_parentctx, _parentState));
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(167);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(168);
						boolOp();
						setState(169);
						expression(2);
						}
						break;
					}
					} 
				}
				setState(175);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class MultOpContext extends ParserRuleContext {
		public MultOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_multOp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterMultOp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitMultOp(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitMultOp(this);
			else return visitor.visitChildren(this);
		}
	}

	public final MultOpContext multOp() throws RecognitionException {
		MultOpContext _localctx = new MultOpContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_multOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(176);
			_la = _input.LA(1);
			if ( !(_la==T__7 || _la==T__14) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AddOpContext extends ParserRuleContext {
		public AddOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_addOp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterAddOp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitAddOp(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitAddOp(this);
			else return visitor.visitChildren(this);
		}
	}

	public final AddOpContext addOp() throws RecognitionException {
		AddOpContext _localctx = new AddOpContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_addOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(178);
			_la = _input.LA(1);
			if ( !(_la==T__8 || _la==T__9) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CompareOpContext extends ParserRuleContext {
		public CompareOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compareOp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterCompareOp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitCompareOp(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitCompareOp(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CompareOpContext compareOp() throws RecognitionException {
		CompareOpContext _localctx = new CompareOpContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_compareOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(180);
			_la = _input.LA(1);
			if ( !(((_la) & ~0x3f) == 0 && ((1L << _la) & 4128768L) != 0) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BoolOpContext extends ParserRuleContext {
		public TerminalNode BOOL_OPERATOR() { return getToken(EdWardParser.BOOL_OPERATOR, 0); }
		public BoolOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolOp; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterBoolOp(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitBoolOp(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitBoolOp(this);
			else return visitor.visitChildren(this);
		}
	}

	public final BoolOpContext boolOp() throws RecognitionException {
		BoolOpContext _localctx = new BoolOpContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_boolOp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(182);
			match(BOOL_OPERATOR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode INTEGER() { return getToken(EdWardParser.INTEGER, 0); }
		public TerminalNode STRING() { return getToken(EdWardParser.STRING, 0); }
		public TerminalNode BOOL() { return getToken(EdWardParser.BOOL, 0); }
		public TerminalNode NULL() { return getToken(EdWardParser.NULL, 0); }
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterConstant(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitConstant(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitConstant(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_constant);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(184);
			_la = _input.LA(1);
			if ( !(((_la) & ~0x3f) == 0 && ((1L << _la) & 2013265920L) != 0) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BlockContext extends ParserRuleContext {
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitBlock(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitBlock(this);
			else return visitor.visitChildren(this);
		}
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_block);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(186);
			match(T__21);
			setState(190);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (((_la) & ~0x3f) == 0 && ((1L << _la) & 10754195556L) != 0) {
				{
				{
				setState(187);
				line();
				}
				}
				setState(192);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(193);
			match(T__22);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ScopeContext extends ParserRuleContext {
		public List<LineContext> line() {
			return getRuleContexts(LineContext.class);
		}
		public LineContext line(int i) {
			return getRuleContext(LineContext.class,i);
		}
		public ScopeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_scope; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).enterScope(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof EdWardListener ) ((EdWardListener)listener).exitScope(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof EdWardVisitor ) return ((EdWardVisitor<? extends T>)visitor).visitScope(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ScopeContext scope() throws RecognitionException {
		ScopeContext _localctx = new ScopeContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_scope);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			match(T__23);
			setState(199);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (((_la) & ~0x3f) == 0 && ((1L << _la) & 10754195556L) != 0) {
				{
				{
				setState(196);
				line();
				}
				}
				setState(201);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(202);
			match(T__24);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 13:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 4);
		case 1:
			return precpred(_ctx, 3);
		case 2:
			return precpred(_ctx, 2);
		case 3:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001!\u00cd\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0001\u0000\u0001\u0000"+
		"\u0005\u0000-\b\u0000\n\u0000\f\u00000\t\u0000\u0001\u0000\u0001\u0000"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0001"+
		"\u0003\u0001:\b\u0001\u0001\u0002\u0001\u0002\u0003\u0002>\b\u0002\u0001"+
		"\u0002\u0001\u0002\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001"+
		"\u0003\u0001\u0003\u0001\u0004\u0001\u0004\u0001\u0004\u0001\u0004\u0001"+
		"\u0004\u0001\u0004\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001"+
		"\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005\u0001"+
		"\u0005\u0001\u0006\u0001\u0006\u0001\u0006\u0005\u0006\\\b\u0006\n\u0006"+
		"\f\u0006_\t\u0006\u0003\u0006a\b\u0006\u0001\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\u0007\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\t\u0001\t\u0001"+
		"\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\n\u0001\n\u0001\n\u0001"+
		"\n\u0001\n\u0001\n\u0005\nz\b\n\n\n\f\n}\t\n\u0001\u000b\u0001\u000b\u0001"+
		"\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\f\u0001\f\u0001\f\u0001"+
		"\r\u0001\r\u0001\r\u0001\r\u0001\r\u0003\r\u008d\b\r\u0001\r\u0001\r\u0001"+
		"\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0003\r\u0097\b\r\u0001\r\u0003"+
		"\r\u009a\b\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001"+
		"\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0005"+
		"\r\u00ac\b\r\n\r\f\r\u00af\t\r\u0001\u000e\u0001\u000e\u0001\u000f\u0001"+
		"\u000f\u0001\u0010\u0001\u0010\u0001\u0011\u0001\u0011\u0001\u0012\u0001"+
		"\u0012\u0001\u0013\u0001\u0013\u0005\u0013\u00bd\b\u0013\n\u0013\f\u0013"+
		"\u00c0\t\u0013\u0001\u0013\u0001\u0013\u0001\u0014\u0001\u0014\u0005\u0014"+
		"\u00c6\b\u0014\n\u0014\f\u0014\u00c9\t\u0014\u0001\u0014\u0001\u0014\u0001"+
		"\u0014\u0000\u0001\u001a\u0015\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010"+
		"\u0012\u0014\u0016\u0018\u001a\u001c\u001e \"$&(\u0000\u0006\u0001\u0000"+
		"\b\n\u0002\u0000\u001b\u001b!!\u0002\u0000\b\b\u000f\u000f\u0001\u0000"+
		"\t\n\u0001\u0000\u0010\u0015\u0001\u0000\u001b\u001e\u00d0\u0000.\u0001"+
		"\u0000\u0000\u0000\u00029\u0001\u0000\u0000\u0000\u0004=\u0001\u0000\u0000"+
		"\u0000\u0006A\u0001\u0000\u0000\u0000\bG\u0001\u0000\u0000\u0000\nM\u0001"+
		"\u0000\u0000\u0000\f`\u0001\u0000\u0000\u0000\u000eb\u0001\u0000\u0000"+
		"\u0000\u0010f\u0001\u0000\u0000\u0000\u0012k\u0001\u0000\u0000\u0000\u0014"+
		"{\u0001\u0000\u0000\u0000\u0016~\u0001\u0000\u0000\u0000\u0018\u0084\u0001"+
		"\u0000\u0000\u0000\u001a\u0099\u0001\u0000\u0000\u0000\u001c\u00b0\u0001"+
		"\u0000\u0000\u0000\u001e\u00b2\u0001\u0000\u0000\u0000 \u00b4\u0001\u0000"+
		"\u0000\u0000\"\u00b6\u0001\u0000\u0000\u0000$\u00b8\u0001\u0000\u0000"+
		"\u0000&\u00ba\u0001\u0000\u0000\u0000(\u00c3\u0001\u0000\u0000\u0000*"+
		"-\u0003\u0002\u0001\u0000+-\u0005\u001f\u0000\u0000,*\u0001\u0000\u0000"+
		"\u0000,+\u0001\u0000\u0000\u0000-0\u0001\u0000\u0000\u0000.,\u0001\u0000"+
		"\u0000\u0000./\u0001\u0000\u0000\u0000/1\u0001\u0000\u0000\u00000.\u0001"+
		"\u0000\u0000\u000012\u0005\u0000\u0000\u00012\u0001\u0001\u0000\u0000"+
		"\u00003:\u0003\u0004\u0002\u00004:\u0003\u0006\u0003\u00005:\u0003\b\u0004"+
		"\u00006:\u0003\n\u0005\u00007:\u0003(\u0014\u00008:\u0005\u001f\u0000"+
		"\u000093\u0001\u0000\u0000\u000094\u0001\u0000\u0000\u000095\u0001\u0000"+
		"\u0000\u000096\u0001\u0000\u0000\u000097\u0001\u0000\u0000\u000098\u0001"+
		"\u0000\u0000\u0000:\u0003\u0001\u0000\u0000\u0000;>\u0003\u000e\u0007"+
		"\u0000<>\u0003\u0010\b\u0000=;\u0001\u0000\u0000\u0000=<\u0001\u0000\u0000"+
		"\u0000>?\u0001\u0000\u0000\u0000?@\u0005\u0001\u0000\u0000@\u0005\u0001"+
		"\u0000\u0000\u0000AB\u0005\u0002\u0000\u0000BC\u0005\u0003\u0000\u0000"+
		"CD\u0003\u001a\r\u0000DE\u0005\u0004\u0000\u0000EF\u0003&\u0013\u0000"+
		"F\u0007\u0001\u0000\u0000\u0000GH\u0005\u0005\u0000\u0000HI\u0005\u0003"+
		"\u0000\u0000IJ\u0003\u001a\r\u0000JK\u0005\u0004\u0000\u0000KL\u0003&"+
		"\u0013\u0000L\t\u0001\u0000\u0000\u0000MN\u0005\u0006\u0000\u0000NO\u0005"+
		"\u0003\u0000\u0000OP\u0003\u000e\u0007\u0000PQ\u0005\u0007\u0000\u0000"+
		"QR\u0003\u001a\r\u0000RS\u0005\u0007\u0000\u0000ST\u0007\u0000\u0000\u0000"+
		"TU\u0007\u0001\u0000\u0000UV\u0005\u0004\u0000\u0000VW\u0003&\u0013\u0000"+
		"W\u000b\u0001\u0000\u0000\u0000X]\u0003\u001a\r\u0000YZ\u0005\u0007\u0000"+
		"\u0000Z\\\u0003\u001a\r\u0000[Y\u0001\u0000\u0000\u0000\\_\u0001\u0000"+
		"\u0000\u0000][\u0001\u0000\u0000\u0000]^\u0001\u0000\u0000\u0000^a\u0001"+
		"\u0000\u0000\u0000_]\u0001\u0000\u0000\u0000`X\u0001\u0000\u0000\u0000"+
		"`a\u0001\u0000\u0000\u0000a\r\u0001\u0000\u0000\u0000bc\u0005!\u0000\u0000"+
		"cd\u0005\u000b\u0000\u0000de\u0003\u001a\r\u0000e\u000f\u0001\u0000\u0000"+
		"\u0000fg\u0005!\u0000\u0000gh\u0005\u0003\u0000\u0000hi\u0003\f\u0006"+
		"\u0000ij\u0005\u0004\u0000\u0000j\u0011\u0001\u0000\u0000\u0000kl\u0005"+
		"!\u0000\u0000lm\u0005\f\u0000\u0000mn\u0005!\u0000\u0000no\u0005\u0003"+
		"\u0000\u0000op\u0003\f\u0006\u0000pq\u0005\u0004\u0000\u0000qr\u0003\u0014"+
		"\n\u0000r\u0013\u0001\u0000\u0000\u0000st\u0005\f\u0000\u0000tu\u0005"+
		"!\u0000\u0000uv\u0005\u0003\u0000\u0000vw\u0003\f\u0006\u0000wx\u0005"+
		"\u0004\u0000\u0000xz\u0001\u0000\u0000\u0000ys\u0001\u0000\u0000\u0000"+
		"z}\u0001\u0000\u0000\u0000{y\u0001\u0000\u0000\u0000{|\u0001\u0000\u0000"+
		"\u0000|\u0015\u0001\u0000\u0000\u0000}{\u0001\u0000\u0000\u0000~\u007f"+
		"\u0005\r\u0000\u0000\u007f\u0080\u0005!\u0000\u0000\u0080\u0081\u0005"+
		"\u0003\u0000\u0000\u0081\u0082\u0003\f\u0006\u0000\u0082\u0083\u0005\u0004"+
		"\u0000\u0000\u0083\u0017\u0001\u0000\u0000\u0000\u0084\u0085\u0005\f\u0000"+
		"\u0000\u0085\u0086\u0005!\u0000\u0000\u0086\u0019\u0001\u0000\u0000\u0000"+
		"\u0087\u0088\u0006\r\uffff\uffff\u0000\u0088\u009a\u0003$\u0012\u0000"+
		"\u0089\u009a\u0005!\u0000\u0000\u008a\u008c\u0003\u0010\b\u0000\u008b"+
		"\u008d\u0003\u0018\f\u0000\u008c\u008b\u0001\u0000\u0000\u0000\u008c\u008d"+
		"\u0001\u0000\u0000\u0000\u008d\u009a\u0001\u0000\u0000\u0000\u008e\u008f"+
		"\u0005\u0003\u0000\u0000\u008f\u0090\u0003\u001a\r\u0000\u0090\u0091\u0005"+
		"\u0004\u0000\u0000\u0091\u009a\u0001\u0000\u0000\u0000\u0092\u0093\u0005"+
		"\u000e\u0000\u0000\u0093\u009a\u0003\u001a\r\u0007\u0094\u0096\u0003\u0012"+
		"\t\u0000\u0095\u0097\u0003\u0018\f\u0000\u0096\u0095\u0001\u0000\u0000"+
		"\u0000\u0096\u0097\u0001\u0000\u0000\u0000\u0097\u009a\u0001\u0000\u0000"+
		"\u0000\u0098\u009a\u0003\u0016\u000b\u0000\u0099\u0087\u0001\u0000\u0000"+
		"\u0000\u0099\u0089\u0001\u0000\u0000\u0000\u0099\u008a\u0001\u0000\u0000"+
		"\u0000\u0099\u008e\u0001\u0000\u0000\u0000\u0099\u0092\u0001\u0000\u0000"+
		"\u0000\u0099\u0094\u0001\u0000\u0000\u0000\u0099\u0098\u0001\u0000\u0000"+
		"\u0000\u009a\u00ad\u0001\u0000\u0000\u0000\u009b\u009c\n\u0004\u0000\u0000"+
		"\u009c\u009d\u0003\u001c\u000e\u0000\u009d\u009e\u0003\u001a\r\u0005\u009e"+
		"\u00ac\u0001\u0000\u0000\u0000\u009f\u00a0\n\u0003\u0000\u0000\u00a0\u00a1"+
		"\u0003\u001e\u000f\u0000\u00a1\u00a2\u0003\u001a\r\u0004\u00a2\u00ac\u0001"+
		"\u0000\u0000\u0000\u00a3\u00a4\n\u0002\u0000\u0000\u00a4\u00a5\u0003 "+
		"\u0010\u0000\u00a5\u00a6\u0003\u001a\r\u0003\u00a6\u00ac\u0001\u0000\u0000"+
		"\u0000\u00a7\u00a8\n\u0001\u0000\u0000\u00a8\u00a9\u0003\"\u0011\u0000"+
		"\u00a9\u00aa\u0003\u001a\r\u0002\u00aa\u00ac\u0001\u0000\u0000\u0000\u00ab"+
		"\u009b\u0001\u0000\u0000\u0000\u00ab\u009f\u0001\u0000\u0000\u0000\u00ab"+
		"\u00a3\u0001\u0000\u0000\u0000\u00ab\u00a7\u0001\u0000\u0000\u0000\u00ac"+
		"\u00af\u0001\u0000\u0000\u0000\u00ad\u00ab\u0001\u0000\u0000\u0000\u00ad"+
		"\u00ae\u0001\u0000\u0000\u0000\u00ae\u001b\u0001\u0000\u0000\u0000\u00af"+
		"\u00ad\u0001\u0000\u0000\u0000\u00b0\u00b1\u0007\u0002\u0000\u0000\u00b1"+
		"\u001d\u0001\u0000\u0000\u0000\u00b2\u00b3\u0007\u0003\u0000\u0000\u00b3"+
		"\u001f\u0001\u0000\u0000\u0000\u00b4\u00b5\u0007\u0004\u0000\u0000\u00b5"+
		"!\u0001\u0000\u0000\u0000\u00b6\u00b7\u0005\u001a\u0000\u0000\u00b7#\u0001"+
		"\u0000\u0000\u0000\u00b8\u00b9\u0007\u0005\u0000\u0000\u00b9%\u0001\u0000"+
		"\u0000\u0000\u00ba\u00be\u0005\u0016\u0000\u0000\u00bb\u00bd\u0003\u0002"+
		"\u0001\u0000\u00bc\u00bb\u0001\u0000\u0000\u0000\u00bd\u00c0\u0001\u0000"+
		"\u0000\u0000\u00be\u00bc\u0001\u0000\u0000\u0000\u00be\u00bf\u0001\u0000"+
		"\u0000\u0000\u00bf\u00c1\u0001\u0000\u0000\u0000\u00c0\u00be\u0001\u0000"+
		"\u0000\u0000\u00c1\u00c2\u0005\u0017\u0000\u0000\u00c2\'\u0001\u0000\u0000"+
		"\u0000\u00c3\u00c7\u0005\u0018\u0000\u0000\u00c4\u00c6\u0003\u0002\u0001"+
		"\u0000\u00c5\u00c4\u0001\u0000\u0000\u0000\u00c6\u00c9\u0001\u0000\u0000"+
		"\u0000\u00c7\u00c5\u0001\u0000\u0000\u0000\u00c7\u00c8\u0001\u0000\u0000"+
		"\u0000\u00c8\u00ca\u0001\u0000\u0000\u0000\u00c9\u00c7\u0001\u0000\u0000"+
		"\u0000\u00ca\u00cb\u0005\u0019\u0000\u0000\u00cb)\u0001\u0000\u0000\u0000"+
		"\u000e,.9=]`{\u008c\u0096\u0099\u00ab\u00ad\u00be\u00c7";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}